using DiGi.Core;
using DiGi.Core.Classes;
using DiGi.Core.IO;
using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.IO.Interfaces;
using DiGi_GIS_ML;
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
        /// Reports whether this predictor can score at all.
        /// <para>Answers from the generated model's readiness surface: the trained file must be present at its resolved path, or the first scoring batch throws and the Lazy caches the failure for the life of the process.</para>
        /// </summary>
        /// <para>It also carries the model's identity, the SHA-256 of the model file, which the runner stamps on every prediction. A file that is present but cannot be read to identify it is not runnable: predictions stored with no record of the model that made them are what ZiolkowskiJakub/DiGi.GIS.YOLO.UI#26 removed.</para>
        /// <returns>The readiness of this predictor - runnable, with the model's identity, when the model file is present and readable, otherwise not runnable, carrying the path it looked for.</returns>
        public DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness YearBuiltPredictorReadiness()
        {
            if (OrtoBuildingDetectionModel.IsModelAvailable)
            {
                string? modelSHA256 = OrtoBuildingDetectionModel.ModelSHA256;
                if (modelSHA256 is not null)
                {
                    return new DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness(true, years: OrtoBuildingDetectionModel.TrainedYears, radiuses: OrtoBuildingDetectionModel.TrainedRadiuses, modelId: modelSHA256);
                }

                return new DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness(
                    false,
                    [string.Format(System.Globalization.CultureInfo.InvariantCulture, "The year built model at {0} could not be read to identify it.", OrtoBuildingDetectionModel.ResolvedModelPath)],
                    years: OrtoBuildingDetectionModel.TrainedYears,
                    radiuses: OrtoBuildingDetectionModel.TrainedRadiuses);
            }

            return new DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness(
                false,
                [string.Format(System.Globalization.CultureInfo.InvariantCulture, "The year built model was not found at {0}. The trained model file must be present beside the runner.", OrtoBuildingDetectionModel.ResolvedModelPath)],
                years: OrtoBuildingDetectionModel.TrainedYears,
                radiuses: OrtoBuildingDetectionModel.TrainedRadiuses);
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
