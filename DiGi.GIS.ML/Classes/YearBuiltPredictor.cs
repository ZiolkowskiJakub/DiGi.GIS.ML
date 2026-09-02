using DiGi.Core;
using DiGi.Core.Classes;
using DiGi.Core.IO;
using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.IO.Interfaces;
using System.Collections.Generic;

namespace DiGi.GIS.ML.Classes
{
    /// <summary>
    /// Implements the year built prediction engine using the trained machine learning model.
    /// </summary>
    public class YearBuiltPredictor : IYearBuiltPredictor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YearBuiltPredictor"/> class.
        /// </summary>
        public YearBuiltPredictor()
        {
        }

        /// <summary>
        /// Predicts the construction year for building features in the provided table.
        /// </summary>
        /// <param name="table">The table containing building features, including a reference column.</param>
        /// <returns>A new table carrying the reference and predicted year built columns, or null if the input table is invalid.</returns>
        public Table? Predict(Table? table)
        {
            return table.PredictedYearBuilts();
        }

        /// <summary>
        /// Retrieves the list of columns permitted as input features for the year built prediction model across the specified range of years and radial radiuses.
        /// </summary>
        /// <param name="years">The range of years for temporal features. Defaults to 2008..2025 when null.</param>
        /// <param name="radiuses">The collection of radiuses for radial ratio features. Defaults to 200, 400, 600, 1000 when null.</param>
        /// <returns>A list of <see cref="Column"/> instances representing the allowed input features.</returns>
        public static List<Column> InputColumns(Range<int>? years = null, IEnumerable<double>? radiuses = null)
        {
            return IO.Query.YearBuiltPredictionInputColumns(years, radiuses);
        }

        /// <summary>
        /// Retrieves the unique identifiers of the columns permitted as input features for the year built prediction model across the specified range of years and radial radiuses.
        /// </summary>
        /// <param name="years">The range of years for temporal features. Defaults to 2008..2025 when null.</param>
        /// <param name="radiuses">The collection of radiuses for radial ratio features. Defaults to 200, 400, 600, 1000 when null.</param>
        /// <returns>A list of distinct unique identifiers for the input feature columns.</returns>
        public static List<string> InputColumnUniqueIds(Range<int>? years = null, IEnumerable<double>? radiuses = null)
        {
            List<string> uniqueIds = [];
            List<Column> columns = InputColumns(years, radiuses);
            if (columns is null)
            {
                return uniqueIds;
            }

            foreach (Column column in columns)
            {
                if (column?.UniqueId() is string uniqueId && !uniqueIds.Contains(uniqueId))
                {
                    uniqueIds.Add(uniqueId);
                }
            }

            return uniqueIds;
        }
    }
}
