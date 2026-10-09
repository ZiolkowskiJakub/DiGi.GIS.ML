namespace DiGi.GIS.ML.Constants
{
    /// <summary>
    /// Provides the constants that date and bound a year built prediction by the imagery that first detected the building (ZiolkowskiJakub/DiGi.GIS.ML#14, #15).
    /// </summary>
    public static class Plausibility
    {
        /// <summary>
        /// The confidence at or above which a year counts as a confident detection of the building.
        /// <para>The first year at or above it is the year built the heuristic of <c>Query.PredictedYearBuilts</c> predicts, and the bar the acceptance criteria of ZiolkowskiJakub/DiGi.GIS.ML#14 measure a prediction against: a building confidently seen in 2008 cannot have been built in 2013.</para>
        /// </summary>
        public const float ConfidentDetectionThreshold = 0.5F;

        /// <summary>
        /// The maximum share of predictions that may be later than their first confident detection year before a table is returned.
        /// <para>The first-detection heuristic of <c>Query.PredictedYearBuilts</c> makes this share 0 by construction, so the threshold is a tripwire: a future predictor must not silently let an extrapolated score through again. It is set at 1 % to tolerate an isolated edge row rather than refusing a whole county for one.</para>
        /// <para>For scale: the retired <c>OrtoBuildingDetectionModel</c> regressor ran 4.0-15.6 % on the counties it was trained on and 83.1 % on county 8956 (ZiolkowskiJakub/DiGi.GIS.ML#14); retrained without county 80328 it ran 76-89 % on it (ZiolkowskiJakub/DiGi.GIS.ML#15).</para>
        /// </summary>
        public const double MaximumImplausibleShare = 0.01;

        /// <summary>
        /// The first year the orthophoto sequence emits per-year detection columns for.
        /// <para>A detection year is <see cref="FirstPredictionYear"/> plus the index of the first confidence column reporting the building, so this constant has to move with the sequence.</para>
        /// </summary>
        public const int FirstPredictionYear = 2008;
    }
}
