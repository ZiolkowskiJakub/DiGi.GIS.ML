using DiGi.Core;
using DiGi.Core.IO;
using DiGi.Core.IO.DelimitedData;
using DiGi.Core.IO.DelimitedData.Enums;
using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.Classes;
using DiGi.GIS.ML;
using DiGi.GIS.ML.Classes;
using DiGi.GIS.ML.ConsoleApp;
using DiGi.GIS.WebAPI.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

// Assembles the Year Built prediction training table from the deployed database and writes it as a TSV.
//
// Usage: YearBuiltPredictionTrainingTableConsoleApp --output <path.tsv> --counties 104106,75125,80328,5
//
// Exit codes: 0 assembled, 1 argument or configuration error, 2 nothing could be read, 3 no key.

string? path_Output = null;
List<int> countyIds = [];

for (int i = 0; i < args.Length; i++)
{
    if ((string.Equals(args[i], "--output", StringComparison.OrdinalIgnoreCase) || string.Equals(args[i], "-o", StringComparison.OrdinalIgnoreCase)) && i + 1 < args.Length)
    {
        path_Output = args[++i];
    }
    else if ((string.Equals(args[i], "--counties", StringComparison.OrdinalIgnoreCase) || string.Equals(args[i], "-c", StringComparison.OrdinalIgnoreCase)) && i + 1 < args.Length)
    {
        foreach (string text in args[++i].Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            if (int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int countyId) && countyId > 0 && !countyIds.Contains(countyId))
            {
                countyIds.Add(countyId);
            }
        }
    }
}

if (string.IsNullOrWhiteSpace(path_Output) || countyIds.Count == 0)
{
    Console.WriteLine("Usage: YearBuiltPredictionTrainingTableConsoleApp --output <path.tsv> --counties <id,id,...>");
    Console.WriteLine("A county is named by its identifier, never by its four character code.");
    return 1;
}

// This runner only reads, and the deployed read endpoints are unauthenticated today, so a missing key is
// reported rather than fatal. It is still passed when configured: should the reads ever move behind the
// same guard the write endpoints already sit behind, the run would otherwise start and fail per request.
string? key = DiGi.GIS.ML.ConsoleApp.Query.Key();
if (string.IsNullOrWhiteSpace(key))
{
    Console.WriteLine($"[INFO] no key in '{DiGi.GIS.ML.ConsoleApp.Constants.FileName.GISWebAPIClientConfigurationFile}' - continuing unauthenticated, which the read endpoints currently allow.");
}

GISWebAPIManager? gisWebAPIManager = DiGi.GIS.WebAPI.Create.GISWebAPIManager(key);
if (gisWebAPIManager is null)
{
    Console.WriteLine("[ERROR] Failed to initialize GISWebAPIManager with the configured key.");
    return 3;
}

// The projection the inference pipeline uses, so the trainer and the scorer cannot disagree about what a
// feature is. The reference is asked for on top of it: an identifier rather than a feature, and the only way
// to line a feature row up with its label.
List<string> columnUniqueIds = [];
if (DiGi.GIS.IO.Constants.Column.Reference.UniqueId() is string columnUniqueId_Reference)
{
    columnUniqueIds.Add(columnUniqueId_Reference);
}

foreach (string columnUniqueId in YearBuiltPredictor.InputColumnUniqueIds())
{
    if (!columnUniqueIds.Contains(columnUniqueId))
    {
        columnUniqueIds.Add(columnUniqueId);
    }
}

CancellationToken cancellationToken = CancellationToken.None;

Dictionary<string, short> years_ByReference = [];
List<Table?> tables = [];

foreach (int countyId in countyIds)
{
    Console.WriteLine($"County {countyId}");

    List<YearBuiltData>? yearBuiltDatas = await gisWebAPIManager.YearBuiltDatasAsync(countyId, cancellationToken: cancellationToken);
    if (yearBuiltDatas is null)
    {
        Console.WriteLine("  [WARN] the stored year built data could not be read - county skipped");
        continue;
    }

    // Only a non-prediction entry is a label. Every record on these counties also carries the incumbent
    // model's own answer, and taking that would train this model on its predecessor.
    Dictionary<string, short> years_County = yearBuiltDatas.YearBuiltLabels();
    Console.WriteLine($"  {yearBuiltDatas.Count} stored year built data, {years_County.Count} usable labels");

    if (years_County.Count == 0)
    {
        continue;
    }

    List<string> references = [.. years_County.Keys];
    foreach (KeyValuePair<string, short> keyValuePair in years_County)
    {
        years_ByReference[keyValuePair.Key] = keyValuePair.Value;
    }

    int rowCount_County = 0;
    int pageCount_County = 0;
    for (int i = 0; i < references.Count; i += DiGi.GIS.ML.ConsoleApp.Constants.Count.Reference_Maximum)
    {
        List<string> references_Batch = references.GetRange(i, Math.Min(DiGi.GIS.ML.ConsoleApp.Constants.Count.Reference_Maximum, references.Count - i));

        Table? table = await gisWebAPIManager.BuildingDataTableAsync(countyId, references_Batch, columnUniqueIds, cancellationToken: cancellationToken);
        if (table is null)
        {
            Console.WriteLine($"  [WARN] a page of {references_Batch.Count} feature rows could not be read");
            continue;
        }

        rowCount_County += table.RowCount;
        pageCount_County++;
        tables.Add(table);
    }

    Console.WriteLine($"  {rowCount_County} feature rows read over {pageCount_County} page(s)");
}

Table? table_Training = tables.YearBuiltPredictionTrainingTable(years_ByReference);
if (table_Training is null || table_Training.RowCount == 0)
{
    Console.WriteLine("[ERROR] nothing could be assembled - no labelled building had a feature row.");
    return 2;
}

Console.WriteLine();
Console.WriteLine($"Assembled {table_Training.RowCount} rows over {table_Training.ColumnCount} columns.");

// The signature of a table assembled before the detection and population runs: whole feature groups constant.
List<string> names_Constant = table_Training.DefaultOnlyColumnNames();
if (names_Constant.Count != 0)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"[WARN] {names_Constant.Count} of {table_Training.ColumnCount} columns never vary. A whole feature group here means the run that populates it has not happened:");
    Console.WriteLine($"       {string.Join(", ", names_Constant.Count > 12 ? [.. names_Constant.GetRange(0, 12)] : names_Constant)}{(names_Constant.Count > 12 ? ", ..." : string.Empty)}");
    Console.ResetColor();
}

string? directory_Output = System.IO.Path.GetDirectoryName(path_Output);
if (!string.IsNullOrWhiteSpace(directory_Output) && !Directory.Exists(directory_Output))
{
    Directory.CreateDirectory(directory_Output);
}

if (!table_Training.Write(path_Output, DelimitedDataSeparator.Tab))
{
    Console.WriteLine($"[ERROR] the training table could not be written to: {path_Output}");
    return 2;
}

Console.WriteLine($"Written to: {path_Output}");
return 0;
