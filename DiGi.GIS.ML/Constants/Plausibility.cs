namespace DiGi.GIS.ML.Constants
{
    /// <summary>
    /// Provides the constants that bound a year built prediction by the imagery that first detected the building (ZiolkowskiJakub/DiGi.GIS.ML#14).
    /// </summary>
    public static class Plausibility
    {
        /// <summary>
        /// The confidence at or above which a year counts as a confident detection of the building.
        /// <para>This is the same bar the acceptance criteria of ZiolkowskiJakub/DiGi.GIS.ML#14 measure a prediction against: a building confidently seen in 2008 cannot have been built in 2013.</para>
        /// </summary>
        public const float ConfidentDetectionThreshold = 0.5F;

        /// <summary>
        /// The maximum share of predictions that may be later than their first confident detection year before a table is returned.
        /// <para>While the plausibility cap in <c>Query.PredictedYearBuilts</c> is in place this share is 0 by construction, so the threshold is a tripwire: a future change to the cap must not silently let an extrapolated score through again. It is set at 1 % to tolerate an isolated edge row rather than refusing a whole county for one.</para>
        /// <para>Calibrated against the raw (uncapped) shares measured on 2026 imagery: healthy and training counties run 4.0-15.6 %, while county 8956 - the county of ZiolkowskiJakub/DiGi.GIS.ML#14, whose model inputs extrapolate - ran 83.1 %.</para>
        /// </summary>
        public const double MaximumImplausibleShare = 0.01;

        /// <summary>
        /// The first year the orthophoto sequence emits per-year detection columns for.
        /// <para>A detection year is <see cref="FirstPredictionYear"/> plus the index of the first confidence column reporting the building, so this constant has to move with the sequence.</para>
        /// </summary>
        public const int FirstPredictionYear = 2008;
    }
}
