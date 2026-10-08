namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Tells whether a share of predictions later than their first confident detection year is within the plausibility maximum.
        /// <para>This is the refusal condition of the plausibility guard in <see cref="PredictedYearBuilts"/>. The share is allowed to sit exactly at <see cref="Constants.Plausibility.MaximumImplausibleShare"/>; only a share over it makes the run refuse. After the plausibility cap runs, the share is 0 by construction, so the predicate exists to pin the boundary - a future change that lets an extrapolated score through again must cross this line visibly rather than drift with it.</para>
        /// </summary>
        /// <param name="share">The share of scored rows whose predicted year is later than their first confident detection year.</param>
        /// <returns>True when the share is within the maximum; false when the run must refuse to return predictions.</returns>
        public static bool IsPlausibleShare(this double share)
        {
            return share <= Constants.Plausibility.MaximumImplausibleShare;
        }
    }
}
