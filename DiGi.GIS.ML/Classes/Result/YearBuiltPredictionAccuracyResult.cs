using DiGi.Core.Classes;
using DiGi.GIS.ML.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.ML.Classes
{
    /// <summary>
    /// Reports how closely one predictor reproduced the known construction years of a set of buildings.
    /// <para>Carries the three measures together on purpose. R squared alone is misleading on this label: it is measured against the variance of the holdout, and 84 percent of these rows carry the same year, so a predictor can score well while being wrong in years. The mean absolute error says how far out it is in the unit anyone cares about, and the root mean squared error says whether the misses are many small ones or a few large ones.</para>
    /// <para>The name of the predictor and the name of the split are both carried, because a number is only comparable against another measured the same way - a random holdout and a holdout grouped by subdivision answer different questions of the same model.</para>
    /// </summary>
    public class YearBuiltPredictionAccuracyResult : SerializableResult, IGISMLSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Name))]
        private readonly string? name;

        [JsonInclude, JsonPropertyName(nameof(SplitName))]
        private readonly string? splitName;

        [JsonInclude, JsonPropertyName(nameof(Count))]
        private readonly int count;

        [JsonInclude, JsonPropertyName(nameof(MeanAbsoluteError))]
        private readonly double meanAbsoluteError;

        [JsonInclude, JsonPropertyName(nameof(RootMeanSquaredError))]
        private readonly double rootMeanSquaredError;

        [JsonInclude, JsonPropertyName(nameof(RSquared))]
        private readonly double rSquared;

        /// <summary>
        /// Initializes a new instance of the <see cref="YearBuiltPredictionAccuracyResult"/> class.
        /// <para>Assigns only. The measures are computed by <c>Create.YearBuiltPredictionAccuracyResult</c>, which is where a caller without pre-computed values goes.</para>
        /// </summary>
        /// <param name="name">The predictor these measures describe.</param>
        /// <param name="splitName">The holdout the measures were taken on.</param>
        /// <param name="count">The number of scored buildings.</param>
        /// <param name="meanAbsoluteError">The mean absolute error, in years.</param>
        /// <param name="rootMeanSquaredError">The root mean squared error, in years.</param>
        /// <param name="rSquared">The coefficient of determination.</param>
        public YearBuiltPredictionAccuracyResult(string? name, string? splitName, int count, double meanAbsoluteError, double rootMeanSquaredError, double rSquared)
        {
            this.name = name;
            this.splitName = splitName;
            this.count = count;
            this.meanAbsoluteError = meanAbsoluteError;
            this.rootMeanSquaredError = rootMeanSquaredError;
            this.rSquared = rSquared;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YearBuiltPredictionAccuracyResult"/> class by copying values from an existing instance.
        /// </summary>
        /// <param name="yearBuiltPredictionAccuracyResult">The source to copy from.</param>
        public YearBuiltPredictionAccuracyResult(YearBuiltPredictionAccuracyResult? yearBuiltPredictionAccuracyResult)
            : base(yearBuiltPredictionAccuracyResult)
        {
            if (yearBuiltPredictionAccuracyResult is not null)
            {
                name = yearBuiltPredictionAccuracyResult.name;
                splitName = yearBuiltPredictionAccuracyResult.splitName;
                count = yearBuiltPredictionAccuracyResult.count;
                meanAbsoluteError = yearBuiltPredictionAccuracyResult.meanAbsoluteError;
                rootMeanSquaredError = yearBuiltPredictionAccuracyResult.rootMeanSquaredError;
                rSquared = yearBuiltPredictionAccuracyResult.rSquared;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YearBuiltPredictionAccuracyResult"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data.</param>
        public YearBuiltPredictionAccuracyResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the predictor these measures describe.
        /// </summary>
        [JsonIgnore]
        public string? Name => name;

        /// <summary>
        /// Gets the holdout the measures were taken on.
        /// </summary>
        [JsonIgnore]
        public string? SplitName => splitName;

        /// <summary>
        /// Gets the number of scored buildings.
        /// </summary>
        [JsonIgnore]
        public int Count => count;

        /// <summary>
        /// Gets the mean absolute error, in years.
        /// </summary>
        [JsonIgnore]
        public double MeanAbsoluteError => meanAbsoluteError;

        /// <summary>
        /// Gets the root mean squared error, in years.
        /// </summary>
        [JsonIgnore]
        public double RootMeanSquaredError => rootMeanSquaredError;

        /// <summary>
        /// Gets the coefficient of determination.
        /// </summary>
        [JsonIgnore]
        public double RSquared => rSquared;
    }
}
