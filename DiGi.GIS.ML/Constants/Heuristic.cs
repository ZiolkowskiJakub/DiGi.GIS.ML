using DiGi.Core.Classes;
using System.Globalization;

namespace DiGi.GIS.ML.Constants
{
    /// <summary>
    /// Provides the constants of the first-detection heuristic that predicts the year built (ZiolkowskiJakub/DiGi.GIS.ML#15).
    /// <para>A building is predicted to have been built in the first year the detector saw it with confidence at or above <see cref="Plausibility.ConfidentDetectionThreshold"/>, falling back to the first year it was seen at all. It replaced the <c>OrtoBuildingDetectionModel</c> regressor in production: scored on a county it was not trained on, every retrained regressor came out years too late, while this rule matched the labels of that county with MAE 0.15 - see <c>OrtoBuildingDetectionModel.provenance.md</c>.</para>
    /// </summary>
    public static class Heuristic
    {
        /// <summary>
        /// Gets the identity of the heuristic, stamped on every stored prediction in place of a model file's SHA-256.
        /// <para>It names the rule and its threshold, so a change to either reads as a different predictor in the stored history (ZiolkowskiJakub/DiGi.GIS.YOLO.UI#26).</para>
        /// </summary>
        public static string Id { get; } = string.Create(CultureInfo.InvariantCulture, $"first-confident-detection@{Plausibility.ConfidentDetectionThreshold}");

        /// <summary>
        /// Gets the years whose detection columns the heuristic reads.
        /// <para>The first of them is <see cref="Plausibility.FirstPredictionYear"/>. It is also the year range the predictor states as its contract, so a run whose options narrow the detection years - and would hide a building's first detection - is refused rather than predicted late.</para>
        /// </summary>
        public static Range<int> Years { get; } = new(Plausibility.FirstPredictionYear, 2025);
    }
}
