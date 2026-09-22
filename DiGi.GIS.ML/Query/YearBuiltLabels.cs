using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Extracts the training labels from the stored <c>User year built</c> column, by building reference.
        /// <para>The value is the most frequent exact user year over every stored record of the building. The rule and its tie-breaks are defined once, on <c>DiGi.GIS.Query.MostFrequentUserYearBuilt</c>, and applied when <c>DiGi.GIS.IO.Modify.Update_Building2D_YearBuilt</c> writes the column. This method reads, it does not re-derive.</para>
        /// <para>Only this column is read, because the two year built columns beside it are the regressor's own territory. <c>Predicted year built</c> is this model's own output, and <c>Calculated year built</c> equals the prediction wherever no user year exists: on the counties this model trains on the stored user and predicted years disagree on roughly a quarter of the buildings, so reading either would train the regressor on its predecessor, which reads as an accuracy gain rather than as a defect.</para>
        /// <para>An empty cell is an unlabelled building, not year zero. A table without the column - a county the Year Built update has not reached - gives no labels.</para>
        /// </summary>
        /// <param name="tables">The stored building data tables to take labels from, typically one page or one county each.</param>
        /// <returns>The construction year of each labelled building, by reference. Empty when nothing was labelled.</returns>
        public static Dictionary<string, short> YearBuiltLabels(this IEnumerable<Table?>? tables)
        {
            Dictionary<string, short> result = [];

            if (tables is null)
            {
                return result;
            }

            foreach (Table? table in tables)
            {
                if (table is null || table.RowCount == 0)
                {
                    continue;
                }

                int index_Reference = table.GetColumnIndex(GIS.IO.Constants.Column.Reference.Name);
                int index_UserYearBuilt = table.GetColumnIndex(GIS.IO.Constants.Column.UserYearBuilt.Name);
                if (index_Reference < 0 || index_UserYearBuilt < 0)
                {
                    continue;
                }

                for (int i = 0; i < table.RowCount; i++)
                {
                    string? reference = table.GetValue<string>(i, index_Reference);
                    if (string.IsNullOrWhiteSpace(reference))
                    {
                        continue;
                    }

                    // An empty cell is an unlabelled building, not a year of zero, and a value above short.MaxValue would wrap on the cast.
                    if (!table.TryGetValue<int>(i, index_UserYearBuilt, out int year) || year < 1 || year > short.MaxValue)
                    {
                        continue;
                    }

                    result[reference!] = (short)year;
                }
            }

            return result;
        }

        /// <summary>
        /// Extracts the training labels of one stored building data table, by building reference.
        /// <para>Delegates to the IEnumerable&lt;Table?&gt; overload with a single element so the two cannot disagree.</para>
        /// </summary>
        /// <param name="table">The stored building data table to take labels from, or null.</param>
        /// <returns>The construction year of each labelled building, by reference. Empty when the table is null or holds no labels.</returns>
        public static Dictionary<string, short> YearBuiltLabels(this Table? table)
        {
            return YearBuiltLabels(table is null ? null : [table]);
        }
    }
}
