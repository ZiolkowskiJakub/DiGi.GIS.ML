using System;

namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Rounds a raw regressor score to the year <see cref="PredictedYearBuilts"/> writes for it.
        /// <para>An exact half rounds down - a score of 2008.5 is 2008 - and the result is clamped to the <see cref="ushort"/> range the predicted year column stores. Anything that judges a raw score against a detection year rounds it here first, so a measurement and the deployed path cannot disagree by a rounding rule.</para>
        /// </summary>
        /// <param name="score">The raw score of the regressor.</param>
        /// <returns>The predicted year, within [0, <see cref="ushort.MaxValue"/>].</returns>
        public static int PredictedYear(this double score)
        {
            if (double.IsNaN(score))
            {
                return 0;
            }

            double floor = Math.Floor(score);
            double year = score - floor > 0.5 ? floor + 1 : floor;
            if (year < 0)
            {
                return 0;
            }

            if (year > ushort.MaxValue)
            {
                return ushort.MaxValue;
            }

            return (int)year;
        }
    }
}
