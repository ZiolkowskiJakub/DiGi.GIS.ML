using DiGi.GIS.Classes;
using DiGi.GIS.Enums;
using DiGi.GIS.Interfaces;
using System.Collections.Generic;

namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Extracts the training labels from stored year built data, by building reference.
        /// <para>A stored <see cref="YearBuiltData"/> holds the history of every year anyone has attributed to the building, and on the counties this model trains on that includes <b>this model&apos;s own predecessor</b>: every record sampled on 2026-09-02 carried a <see cref="UserYearBuilt"/> together with a <see cref="PredictedYearBuilt"/> stamped 2025-05-29, the two disagreeing on 26 to 28 percent of records. Taking whichever year a record happens to list first would therefore train the regressor on the previous regressor&apos;s output for a quarter of its rows, and that reads as an accuracy gain rather than as a defect.</para>
        /// <para>So only an entry whose <see cref="IYearBuilt.YearBuiltSource"/> is not <see cref="YearBuiltSource.Prediction"/> can be a label. A record carrying nothing else is an unlabelled building and is left out rather than defaulted - a building with no known year is not a building whose year is zero.</para>
        /// <para>The filter is on the source rather than on the concrete type, so a future non-prediction entry counts as ground truth without this having to be revisited.</para>
        /// </summary>
        /// <param name="yearBuiltDatas">The stored year built data to take labels from.</param>
        /// <returns>The construction year of each labelled building, by reference. Empty when nothing was labelled.</returns>
        public static Dictionary<string, short> YearBuiltLabels(this IEnumerable<YearBuiltData?>? yearBuiltDatas)
        {
            Dictionary<string, short> result = [];

            if (yearBuiltDatas is null)
            {
                return result;
            }

            foreach (YearBuiltData? yearBuiltData in yearBuiltDatas)
            {
                string? reference = yearBuiltData?.Reference;
                if (yearBuiltData is null || string.IsNullOrWhiteSpace(reference))
                {
                    continue;
                }

                // The user supplied year is the ground truth wherever there is one; anything else that is not a
                // prediction is taken only when there is not.
                short? year = yearBuiltData.GetUserYearBuilt()?.Year;

                if (year is null && yearBuiltData.YearBuilts is IEnumerable<IYearBuilt> yearBuilts)
                {
                    foreach (IYearBuilt yearBuilt in yearBuilts)
                    {
                        if (yearBuilt is not null && yearBuilt.YearBuiltSource != YearBuiltSource.Prediction)
                        {
                            year = yearBuilt.Year;
                            break;
                        }
                    }
                }

                if (year is short year_Temp)
                {
                    result[reference!] = year_Temp;
                }
            }

            return result;
        }
    }
}
