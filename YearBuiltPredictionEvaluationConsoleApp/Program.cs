using DiGi.Core.IO.DelimitedData;
using DiGi.Core.IO.DelimitedData.Enums;
using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.ML;
using DiGi.GIS.ML.Classes;
using DiGi.GIS.ML.EvaluationConsoleApp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

// Scores every predictor on the same holdouts and reports them side by side.
//
// Usage: YearBuiltPredictionEvaluationConsoleApp --table <training.tsv> --model <new.mlnet>
//                                               [--incumbent <old.mlnet>] [--output <report.txt>]
//
// Exit codes: 0 reported, 1 arguments, 2 the table or a model could not be read.

string? path_Table = null;
string? path_Model = null;
string? path_Output = null;
string? text_Years = null;
string? text_Radiuses = null;

for (int i = 0; i < args.Length; i++)
{
    string argument = args[i].ToLowerInvariant();
    if (i + 1 >= args.Length) { break; }

    if (argument is "--table" or "-t") { path_Table = args[++i]; }
    else if (argument is "--model" or "-m") { path_Model = args[++i]; }
    else if (argument is "--output" or "-o") { path_Output = args[++i]; }
    else if (argument is "--years") { text_Years = args[++i]; }
    else if (argument is "--radiuses") { text_Radiuses = args[++i]; }
}

DiGi.Core.Classes.Range<int>? range_Years = null;
if (!string.IsNullOrWhiteSpace(text_Years) && text_Years!.Split("..") is string[] parts_Years && parts_Years.Length == 2 && int.TryParse(parts_Years[0].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int years_Min) && int.TryParse(parts_Years[1].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int years_Max))
{
    range_Years = new DiGi.Core.Classes.Range<int>(years_Min, years_Max);
}

List<double>? radiuses = null;
if (!string.IsNullOrWhiteSpace(text_Radiuses))
{
    List<double> radiuses_Parsed = [];
    foreach (string token_Raw in text_Radiuses!.Split(','))
    {
        string token = token_Raw.Trim();
        if (token.Length != 0 && double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out double radius))
        {
            radiuses_Parsed.Add(radius);
        }
    }

    if (radiuses_Parsed.Count != 0) { radiuses = radiuses_Parsed; }
}

if (string.IsNullOrWhiteSpace(path_Table) || !File.Exists(path_Table))
{
    Console.WriteLine("Usage: YearBuiltPredictionEvaluationConsoleApp --table <training.tsv> --model <new.mlnet> [--output <report.txt>]");
    return 1;
}

Table? table = DiGi.Core.IO.DelimitedData.Create.Table(path_Table, DelimitedDataSeparator.Tab);
if (table is null || table.RowCount == 0)
{
    Console.WriteLine($"[ERROR] the training table could not be read: {path_Table}");
    return 2;
}

int index_Reference = table.GetColumnIndex(DiGi.GIS.IO.Constants.Column.Reference.Name);
int index_Label = table.GetColumnIndex(DiGi.GIS.ML.Constants.Column.YearBuilt.Name);
int index_Subdivision = table.GetColumnIndex(DiGi.GIS.IO.Constants.Column.SubdivisionId.Name);
if (index_Reference < 0 || index_Label < 0)
{
    Console.WriteLine($"[ERROR] the table needs a '{DiGi.GIS.IO.Constants.Column.Reference.Name}' and a '{DiGi.GIS.ML.Constants.Column.YearBuilt.Name}' column.");
    return 2;
}

List<double?> years = [];
List<string?> references = [];
List<string?> subdivisions = [];
for (int i = 0; i < table.RowCount; i++)
{
    references.Add(table.GetValue<string>(i, index_Reference));
    subdivisions.Add(index_Subdivision < 0 ? null : table.GetValue<string>(i, index_Subdivision));
    years.Add(table.TryGetValue(i, index_Label, out double year) ? year : null);
}

// Holdout membership is a property of the row, not of a shuffle - see Query.Split.
Dictionary<string, List<bool>> splits = new()
{
    ["random 20% (by reference)"] = DiGi.GIS.ML.EvaluationConsoleApp.Query.Split(references),
    ["grouped 20% (by subdivision)"] = DiGi.GIS.ML.EvaluationConsoleApp.Query.Split(subdivisions),
};

// The predictors that need no model at all. The bar the retrain has to clear is the third.
List<double?> years_Constant2008 = [];
List<double?> years_FirstDetection = [];

int[] indexes_Confidence = new int[18];
for (int y = 2008; y <= 2025; y++)
{
    indexes_Confidence[y - 2008] = table.GetColumnIndex($"{DiGi.GIS.IO.Constants.ColumnNamePrefix.PredictionConfidence} {y}");
}

for (int i = 0; i < table.RowCount; i++)
{
    years_Constant2008.Add(2008);

    double? year_First = null;
    for (int k = 0; k < indexes_Confidence.Length; k++)
    {
        if (indexes_Confidence[k] >= 0 && table.TryGetValue(i, indexes_Confidence[k], out double confidence) && confidence > 0)
        {
            year_First = 2008 + k;
            break;
        }
    }

    years_FirstDetection.Add(year_First ?? 2008);
}

Console.WriteLine($"Loaded {table.RowCount} rows from {path_Table}");

Dictionary<string, List<double?>> predictors = new()
{
    ["constant 2008"] = years_Constant2008,
    ["first detection year"] = years_FirstDetection,
};

// Scored through Query.PredictedYearBuilts - whatever model is installed as OrtoBuildingDetectionModel.mlnet.
// This row therefore measures the deployed path end to end, binding included, not a particular model.
Table? table_Incumbent = table.PredictedYearBuilts();
if (table_Incumbent is not null)
{
    int index_Reference_Incumbent = table_Incumbent.GetColumnIndex(DiGi.GIS.IO.Constants.Column.Reference.Name);
    int index_Predicted = table_Incumbent.GetColumnIndex(DiGi.GIS.IO.Constants.Column.PredictedYearBuilt.Name);
    Dictionary<string, double> years_ByReference = [];
    for (int i = 0; i < table_Incumbent.RowCount; i++)
    {
        if (table_Incumbent.GetValue<string>(i, index_Reference_Incumbent) is string reference && table_Incumbent.TryGetValue(i, index_Predicted, out double year))
        {
            years_ByReference[reference] = year;
        }
    }

    List<double?> years_Deployed = [];
    foreach (string? reference in references)
    {
        years_Deployed.Add(reference is not null && years_ByReference.TryGetValue(reference, out double year) ? year : null);
    }

    predictors["deployed path"] = years_Deployed;
    Console.WriteLine($"Deployed path scored {years_ByReference.Count} rows");
}

// When a projection is named, narrow the table to the projected columns before scoring: a column the table does
// not carry is read as its type default by the deployed path, which is exactly the silent degradation the guard
// refuses in production. This measures what that degradation costs rather than assuming it is small.
Table? Narrow(Table source, DiGi.Core.Classes.Range<int>? years, List<double>? radiuses)
{
    HashSet<string> names_Keep = DiGi.GIS.IO.Query.YearBuiltPredictionInputColumnNames(years, radiuses);
    if (DiGi.GIS.IO.Constants.Column.Reference.Name is string name_Reference) { names_Keep.Add(name_Reference); }
    if (DiGi.GIS.ML.Constants.Column.YearBuilt.Name is string name_Label) { names_Keep.Add(name_Label); }

    Table result = new();
    List<int> indexes_Keep = [];
    foreach (DiGi.Core.IO.Table.Classes.Column column in source.Columns)
    {
        if (column.Name is string name && names_Keep.Contains(name))
        {
            result.AddColumn(name, column.Type);
            indexes_Keep.Add(source.GetColumnIndex(name));
        }
    }

    for (int i = 0; i < source.RowCount; i++)
    {
        List<object?> values = [];
        foreach (int index in indexes_Keep) { values.Add(source.GetValue(i, index)); }
        result.AddRow(values);
    }

    return result;
}

if (range_Years is not null || radiuses is not null)
{
    string label_Narrowed = "narrowed";
    if (range_Years is not null) { label_Narrowed += string.Format(CultureInfo.InvariantCulture, " {0}", range_Years.ToString()); }
    if (radiuses is not null)
    {
        List<string> radiuses_Tokens = [];
        foreach (double radius in radiuses) { radiuses_Tokens.Add(radius.ToString(CultureInfo.InvariantCulture)); }
        label_Narrowed += string.Format(CultureInfo.InvariantCulture, " radiuses [{0}]", string.Join(",", radiuses_Tokens));
    }

    Table? table_Predictions_Narrowed = Narrow(table, range_Years, radiuses)?.PredictedYearBuilts();
    if (table_Predictions_Narrowed is not null)
    {
        int index_Reference_Narrowed = table_Predictions_Narrowed.GetColumnIndex(DiGi.GIS.IO.Constants.Column.Reference.Name);
        int index_Predicted_Narrowed = table_Predictions_Narrowed.GetColumnIndex(DiGi.GIS.IO.Constants.Column.PredictedYearBuilt.Name);
        Dictionary<string, double> years_ByReference_Narrowed = [];
        for (int i = 0; i < table_Predictions_Narrowed.RowCount; i++)
        {
            if (table_Predictions_Narrowed.GetValue<string>(i, index_Reference_Narrowed) is string reference && table_Predictions_Narrowed.TryGetValue(i, index_Predicted_Narrowed, out double year))
            {
                years_ByReference_Narrowed[reference] = year;
            }
        }

        List<double?> years_Narrowed = [];
        foreach (string? reference in references)
        {
            years_Narrowed.Add(reference is not null && years_ByReference_Narrowed.TryGetValue(reference, out double year) ? year : null);
        }

        predictors[label_Narrowed] = years_Narrowed;
        Console.WriteLine($"Narrowed projection {label_Narrowed} scored {years_ByReference_Narrowed.Count} rows");
    }
}

if (!string.IsNullOrWhiteSpace(path_Model))
{
    // Taken from the allow-list rather than from the saved model schema, which misreports a
    // categorical column as Single and then fails inside the transform chain that maps it.
    List<string> names_String = [];
    List<string> names_Boolean = [];
    foreach (Column column in DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns())
    {
        if (column.Name is not string name) { continue; }
        if (column.Type == typeof(string)) { names_String.Add(name); }
        else if (column.Type == typeof(bool)) { names_Boolean.Add(name); }
    }

    List<double?>? years_Model = DiGi.GIS.ML.EvaluationConsoleApp.Query.Scores(path_Model, path_Table, names_String, names_Boolean);
    if (years_Model is null)
    {
        Console.WriteLine($"[ERROR] the model could not be scored: {path_Model}");
        return 2;
    }

    predictors["retrained"] = years_Model;
    Console.WriteLine($"Retrained model scored {years_Model.Count} rows");
}

StringBuilder stringBuilder = new();
void Emit(string text)
{
    Console.WriteLine(text);
    stringBuilder.AppendLine(text);
}

Emit(string.Empty);
Emit($"Year Built prediction accuracy - {DateTimeOffset.Now:yyyy-MM-dd HH:mm}");
Emit($"table: {path_Table}");
Emit($"rows: {table.RowCount}");
Emit(string.Empty);
Emit($"{"split",-30}{"predictor",-28}{"n",8}{"MAE",10}{"RMSE",10}{"R2",10}");
Emit(new string('-', 96));

foreach (KeyValuePair<string, List<bool>> split in splits)
{
    foreach (KeyValuePair<string, List<double?>> predictor in predictors)
    {
        List<double?> years_Holdout = [];
        List<double?> years_Predicted_Holdout = [];
        for (int i = 0; i < table.RowCount && i < split.Value.Count; i++)
        {
            if (!split.Value[i]) { continue; }
            years_Holdout.Add(years[i]);
            years_Predicted_Holdout.Add(i < predictor.Value.Count ? predictor.Value[i] : null);
        }

        YearBuiltPredictionAccuracyResult? result = DiGi.GIS.ML.Create.YearBuiltPredictionAccuracyResult(predictor.Key, split.Key, years_Holdout, years_Predicted_Holdout);
        if (result is null) { continue; }

        Emit($"{split.Key,-30}{predictor.Key,-28}{result.Count,8}{result.MeanAbsoluteError,10:F3}{result.RootMeanSquaredError,10:F3}{result.RSquared,10:F4}");
    }

    Emit(string.Empty);
}

if (!string.IsNullOrWhiteSpace(path_Output))
{
    string? directory = Path.GetDirectoryName(path_Output);
    if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory)) { Directory.CreateDirectory(directory); }
    File.WriteAllText(path_Output, stringBuilder.ToString(), new UTF8Encoding(false));
    Console.WriteLine($"Written to: {path_Output}");
}

return 0;
