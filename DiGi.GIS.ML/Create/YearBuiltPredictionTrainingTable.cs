using DiGi.Core.Classes;
using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.ML
{
    public static partial class Create
    {
        /// <summary>
        /// Builds the Year Built prediction training table from stored building feature tables and the labels of those buildings.
        /// <para>The result is the projection the regressor is trained on: the reference, then every column of <c>DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns</c> in its own order, then the label. The reference is an identifier rather than a feature and the incumbent model ignores it; it is carried so a row can be traced back to its building.</para>
        /// <para>It is <see cref="YearBuiltPredictionInputTable(IEnumerable{Table?}?, Range{int}?, IEnumerable{double}?)"/> filtered to the labelled buildings with the label appended. <b>The schema is fixed, and that is the point of both methods.</b> <c>Modify.Update_Building2D_YearBuiltPredictions</c> creates the five detection columns only for years it actually saw, so a county whose orthophoto series skips a year has no columns for it and the read comes back narrower. Concatenating those tables as they arrive would line different features up under the same position. Every allow-list column is therefore materialised for every row, and a column the source did not carry is filled with the same default the inference path would have used.</para>
        /// <para>That default matters more than it looks. <c>Query.PredictedYearBuilts</c> reads an absent feature as <c>0F</c>, so training on an absent feature written as anything else would show the model one distribution and the deployed pipeline another.</para>
        /// <para>Only a labelled building becomes a row. A building with no label is skipped rather than defaulted, because a building whose year nobody knows is not a building built in year zero.</para>
        /// </summary>
        /// <param name="tables">The stored feature tables to draw rows from, typically one page or one county each.</param>
        /// <param name="years_ByReference">The construction year of each labelled building, by reference, as returned by <c>DiGi.GIS.IO.Query.YearBuiltLabels</c>.</param>
        /// <param name="years">The range of years for the detection and population features. Defaults to 2008..2025 when null.</param>
        /// <param name="radiuses">The radiuses for the radial ratio features. Defaults to 200, 400, 600, 1000 when null.</param>
        /// <returns>The training table, or null when there is nothing to build one from.</returns>
        public static Table? YearBuiltPredictionTrainingTable(this IEnumerable<Table?>? tables, IDictionary<string, short>? years_ByReference, Range<int>? years = null, IEnumerable<double>? radiuses = null)
        {
            if (tables is null || years_ByReference is null || years_ByReference.Count == 0)
            {
                return null;
            }

            // The training row is the input row with its label appended, so the trainer and an unlabelled scoring
            // run cannot disagree about what a feature is or what an absent one defaults to.
            Table? table_Input = tables.YearBuiltPredictionInputTable(years, radiuses);
            if (table_Input is null)
            {
                return null;
            }

            Table result = new();
            foreach (Column column in table_Input.Columns)
            {
                result.AddColumn(column);
            }
            result.AddColumn(Constants.Column.YearBuilt);

            int index_Reference = table_Input.GetColumnIndex(GIS.IO.Constants.Column.Reference.Name);
            int columnCount = table_Input.ColumnCount;

            for (int i = 0; i < table_Input.RowCount; i++)
            {
                string? reference = table_Input.GetValue<string>(i, index_Reference);
                if (string.IsNullOrWhiteSpace(reference) || !years_ByReference.TryGetValue(reference!, out short year))
                {
                    continue;
                }

                List<object?> values = [];
                for (int j = 0; j < columnCount; j++)
                {
                    values.Add(table_Input.GetValue(i, j));
                }
                values.Add(year);

                result.AddRow(values);
            }

            return result;
        }

        /// <summary>
        /// Builds the Year Built prediction training table from one stored building feature table and the labels of those buildings.
        /// </summary>
        /// <param name="table">The stored feature table to draw rows from.</param>
        /// <param name="years_ByReference">The construction year of each labelled building, by reference, as returned by <c>DiGi.GIS.IO.Query.YearBuiltLabels</c>.</param>
        /// <param name="years">The range of years for the detection and population features. Defaults to 2008..2025 when null.</param>
        /// <param name="radiuses">The radiuses for the radial ratio features. Defaults to 200, 400, 600, 1000 when null.</param>
        /// <returns>The training table, or null when there is nothing to build one from.</returns>
        public static Table? YearBuiltPredictionTrainingTable(this Table? table, IDictionary<string, short>? years_ByReference, Range<int>? years = null, IEnumerable<double>? radiuses = null)
        {
            return YearBuiltPredictionTrainingTable([table], years_ByReference, years, radiuses);
        }
    }
}
