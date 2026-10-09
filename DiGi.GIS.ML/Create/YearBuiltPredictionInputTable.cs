using DiGi.Core;
using DiGi.Core.Classes;
using DiGi.Core.IO.Table.Classes;
using System;
using System.Collections.Generic;

namespace DiGi.GIS.ML
{
    public static partial class Create
    {
        /// <summary>
        /// Builds the Year Built prediction input table from stored building feature tables: the projection the regressor scores, for every building, labelled or not.
        /// <para>The result is the reference, then every column of <c>DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns</c> in its own order. <see cref="YearBuiltPredictionTrainingTable(IEnumerable{Table?}?, IDictionary{string, short}?, Range{int}?, IEnumerable{double}?)"/> is this table filtered to the labelled buildings with the label appended, so a county scored from this table is shown exactly the features a training row of the same building would have carried.</para>
        /// <para><b>The schema is fixed, and that is the point of this method.</b> <c>Modify.Update_Building2D_YearBuiltPredictions</c> creates the five detection columns only for years it actually saw, so a county whose orthophoto series skips a year has no columns for it and the read comes back narrower. Concatenating those tables as they arrive would line different features up under the same position. Every allow-list column is therefore materialised for every row, and a column the source did not carry is filled with the same default the inference path would have used.</para>
        /// <para>That default matters more than it looks. <c>Query.PredictedYearBuilts</c> reads an absent feature as <c>0F</c>, so training on an absent feature written as anything else would show the model one distribution and the deployed pipeline another.</para>
        /// <para>A reference read twice - overlapping pages, or a county asked for more than once - becomes one row, the first one read.</para>
        /// </summary>
        /// <param name="tables">The stored feature tables to draw rows from, typically one page or one county each.</param>
        /// <param name="years">The range of years for the detection and population features. Defaults to 2008..2025 when null.</param>
        /// <param name="radiuses">The radiuses for the radial ratio features. Defaults to 200, 400, 600, 1000 when null.</param>
        /// <returns>The input table, or null when there is nothing to build one from.</returns>
        public static Table? YearBuiltPredictionInputTable(this IEnumerable<Table?>? tables, Range<int>? years = null, IEnumerable<double>? radiuses = null)
        {
            if (tables is null)
            {
                return null;
            }

            List<Column> columns_Input = GIS.IO.Query.YearBuiltPredictionInputColumns(years, radiuses);
            if (columns_Input is null || columns_Input.Count == 0)
            {
                return null;
            }

            Table result = new();
            result.AddColumn(GIS.IO.Constants.Column.Reference);
            foreach (Column column in columns_Input)
            {
                result.AddColumn(column);
            }

            // A value the source did not carry has to look to the trainer exactly as it will look to the scorer.
            object? DefaultValue(Type? type)
            {
                if (type is null || type == typeof(string))
                {
                    return string.Empty;
                }

                if (type == typeof(bool))
                {
                    return false;
                }

                // Fully qualified: DiGi.Core also declares a Convert, and both namespaces are imported here.
                return System.Convert.ChangeType(0, Nullable.GetUnderlyingType(type) ?? type);
            }

            List<object?> values_Default = [];
            foreach (Column column in columns_Input)
            {
                values_Default.Add(DefaultValue(column?.Type));
            }

            HashSet<string> references_Added = [];

            foreach (Table? table in tables)
            {
                if (table is null || table.ColumnCount == 0 || table.RowCount == 0)
                {
                    continue;
                }

                List<Column> columns_Source = [.. table.Columns];

                int IndexOf(Column? column)
                {
                    if (column is null)
                    {
                        return -1;
                    }

                    string? uniqueId = column.UniqueId();
                    if (!string.IsNullOrWhiteSpace(uniqueId))
                    {
                        for (int i = 0; i < columns_Source.Count; i++)
                        {
                            if (columns_Source[i] is Column column_Source && string.Equals(column_Source.UniqueId(), uniqueId, StringComparison.Ordinal))
                            {
                                return i;
                            }
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(column.Name))
                    {
                        for (int i = 0; i < columns_Source.Count; i++)
                        {
                            if (columns_Source[i] is Column column_Source && string.Equals(column_Source.Name, column.Name, StringComparison.OrdinalIgnoreCase))
                            {
                                return i;
                            }
                        }
                    }

                    return -1;
                }

                int index_Reference = IndexOf(GIS.IO.Constants.Column.Reference);
                if (index_Reference < 0)
                {
                    continue;
                }

                List<int> indexes_Input = [];
                foreach (Column column in columns_Input)
                {
                    indexes_Input.Add(IndexOf(column));
                }

                for (int i = 0; i < table.RowCount; i++)
                {
                    Row? row = table.GetRow(i);
                    if (row is null)
                    {
                        continue;
                    }

                    string? reference = row.GetValue(index_Reference, string.Empty);
                    if (string.IsNullOrWhiteSpace(reference) || !references_Added.Add(reference!))
                    {
                        continue;
                    }

                    List<object?> values = [reference];
                    for (int j = 0; j < indexes_Input.Count; j++)
                    {
                        int index = indexes_Input[j];
                        object? value = index < 0 ? null : table.GetValue(i, index);
                        values.Add(value ?? values_Default[j]);
                    }

                    result.AddRow(values);
                }
            }

            return result;
        }
    }
}
