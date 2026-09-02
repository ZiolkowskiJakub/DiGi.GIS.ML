using DiGi.GIS.ML.Classes;
using System;
using System.Collections.Generic;

namespace DiGi.GIS.ML
{
    public static partial class Create
    {
        /// <summary>
        /// Measures how closely a set of predicted construction years reproduced the known ones.
        /// <para>The two sequences are read in step and a pair is used only when both sides have a value, so a predictor that declines to answer for some buildings is measured on what it did answer rather than being charged a default. The count on the result says how many pairs that was, which is what makes two results comparable.</para>
        /// <para>R squared is computed against the variance of the supplied known years rather than of the whole dataset, so it describes this holdout and no other. It comes back as <see cref="double.NaN"/> when every known year in the holdout is the same value, because there is then no variance to explain and any number would be an artefact.</para>
        /// </summary>
        /// <param name="name">The predictor these measures describe.</param>
        /// <param name="splitName">The holdout the measures are being taken on.</param>
        /// <param name="years">The known construction years.</param>
        /// <param name="years_Predicted">The predicted construction years, in the same order.</param>
        /// <returns>The measures, or null when there is no pair to measure.</returns>
        public static YearBuiltPredictionAccuracyResult? YearBuiltPredictionAccuracyResult(string? name, string? splitName, IEnumerable<double?>? years, IEnumerable<double?>? years_Predicted)
        {
            if (years is null || years_Predicted is null)
            {
                return null;
            }

            List<double> values = [];
            List<double> values_Predicted = [];

            using (IEnumerator<double?> enumerator = years.GetEnumerator())
            using (IEnumerator<double?> enumerator_Predicted = years_Predicted.GetEnumerator())
            {
                while (enumerator.MoveNext() && enumerator_Predicted.MoveNext())
                {
                    if (enumerator.Current is double value && enumerator_Predicted.Current is double value_Predicted)
                    {
                        values.Add(value);
                        values_Predicted.Add(value_Predicted);
                    }
                }
            }

            if (values.Count == 0)
            {
                return null;
            }

            double sum = 0;
            foreach (double value in values)
            {
                sum += value;
            }

            double mean = sum / values.Count;

            double sumAbsolute = 0;
            double sumSquared = 0;
            double sumSquared_Total = 0;

            for (int i = 0; i < values.Count; i++)
            {
                double difference = values[i] - values_Predicted[i];
                sumAbsolute += Math.Abs(difference);
                sumSquared += difference * difference;

                double difference_Mean = values[i] - mean;
                sumSquared_Total += difference_Mean * difference_Mean;
            }

            double meanAbsoluteError = sumAbsolute / values.Count;
            double rootMeanSquaredError = Math.Sqrt(sumSquared / values.Count);
            double rSquared = sumSquared_Total == 0 ? double.NaN : 1 - (sumSquared / sumSquared_Total);

            return new YearBuiltPredictionAccuracyResult(name, splitName, values.Count, meanAbsoluteError, rootMeanSquaredError, rSquared);
        }
    }
}
