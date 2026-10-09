using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Finds, for each row, the first year the detector saw the building with confidence at or above a threshold.
        /// <para>With the default threshold, <see cref="Constants.Plausibility.ConfidentDetectionThreshold"/>, this is the year built the heuristic of <see cref="PredictedYearBuilts"/> predicts, and the bound a prediction is judged against: a building confidently seen in a year cannot have been built after it. A threshold of 0 finds the first year the building was seen at all - any confidence above zero - which is the fallback of that heuristic.</para>
        /// <para>The years scanned are <see cref="Constants.Heuristic.Years"/>, and each confidence column is resolved by <see cref="ColumnIndex"/>, so a table read through the WebAPI binds the same way the scoring path does.</para>
        /// <para>Unlike <c>DiGi.GIS.IO.Query.FirstDetectionYears</c>, which falls back to a default year, a row with no detection at the threshold is <c>null</c> here: it has nothing to be dated or judged by, and a default would count it as evidence.</para>
        /// </summary>
        /// <param name="table">The table carrying the per-year <c>Prediction Confidence</c> columns, or null.</param>
        /// <param name="threshold">The confidence a detection must reach to count. 0 counts any confidence above zero.</param>
        /// <returns>One entry per row, in row order: the first year at the threshold, or null when the row has none. Empty when the table is null or holds no rows.</returns>
        public static List<int?> FirstConfidentDetectionYears(this Table? table, float threshold = Constants.Plausibility.ConfidentDetectionThreshold)
        {
            List<int?> result = [];
            if (table is null || table.RowCount == 0)
            {
                return result;
            }

            List<int> years = [];
            List<int> indexes = [];
            for (int year = Constants.Heuristic.Years.Min; year <= Constants.Heuristic.Years.Max; year++)
            {
                years.Add(year);
                indexes.Add(table.ColumnIndex(GIS.IO.Create.Column_PredictionYearBuit(GIS.IO.Constants.ColumnNamePrefix.PredictionConfidence, year)));
            }

            for (int i = 0; i < table.RowCount; i++)
            {
                int? year_First = null;
                for (int j = 0; j < indexes.Count; j++)
                {
                    if (indexes[j] >= 0 && table.TryGetValue(i, indexes[j], out double confidence) && confidence > 0 && confidence >= threshold)
                    {
                        year_First = years[j];
                        break;
                    }
                }

                result.Add(year_First);
            }

            return result;
        }
    }
}
