using DiGi.Core.IO.Table.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Predicts the construction year of each building from the imagery that detected it.
        /// <para>A building is predicted to have been built in the first year the detector saw it with confidence at or above <see cref="Constants.Plausibility.ConfidentDetectionThreshold"/>, falling back to the first year it was seen at all. A building the detector never saw has nothing to be dated by and is left out of the result rather than filled with a default, as <c>IYearBuiltPredictor.Predict</c> allows.</para>
        /// <para>This heuristic replaced the <c>OrtoBuildingDetectionModel</c> regressor (ZiolkowskiJakub/DiGi.GIS.ML#15). The regressor memorised the counties it was trained on - their location, and the pattern of orthophoto years each one has - and scored any other county years too late: on held-out county 80328 every retrain put 76-89 % of buildings after their first confident detection, while this rule matched its labels with MAE 0.15. The label is itself the first year a building appears in the orthophoto record, so the first detection is its direct estimate. The model and its tooling stay in the repository for a feature redesign that has to beat this rule on a held-out county first.</para>
        /// <para>The run reports how many buildings were dated from a confident detection, from a weaker one only, and how many were left out. It keeps the guard of ZiolkowskiJakub/DiGi.GIS.ML#14: the share of predictions later than their first confident detection year is 0 by construction here, and the table is refused if a future change lets it exceed <see cref="Constants.Plausibility.MaximumImplausibleShare"/>.</para>
        /// </summary>
        /// <param name="table">The table containing building features, including a reference column and the per-year <c>Prediction Confidence</c> columns.</param>
        /// <returns>A new table carrying the reference and predicted year built columns, one row per detected building, or null if the input table is null, lacks a reference column, or fails the plausibility guard.</returns>
        public static Table? PredictedYearBuilts(this Table? table)
        {
            if (table is null || table.ColumnCount == 0)
            {
                return null;
            }

            int index_Reference = table.ColumnIndex(GIS.IO.Constants.Column.Reference);
            if (index_Reference < 0)
            {
                return null;
            }

            Table result = new();
            result.AddColumn(GIS.IO.Constants.Column.Reference);
            result.AddColumn(GIS.IO.Constants.Column.PredictedYearBuilt);

            if (table.RowCount == 0)
            {
                return result;
            }

            List<int?> years_Confident = table.FirstConfidentDetectionYears();
            List<int?> years_Detected = table.FirstConfidentDetectionYears(0F);

            int rows_Confident = 0;
            int rows_DetectedOnly = 0;
            int rows_Undetected = 0;
            int predictions_AboveConfidentDetection = 0;

            for (int i = 0; i < table.RowCount; i++)
            {
                string? reference = table.GetValue<string>(i, index_Reference);
                if (string.IsNullOrWhiteSpace(reference))
                {
                    continue;
                }

                int? year_Confident = years_Confident[i];
                if ((year_Confident ?? years_Detected[i]) is not int year)
                {
                    rows_Undetected++;
                    continue;
                }

                if (year_Confident is int confident)
                {
                    rows_Confident++;

                    // Zero by construction. Counted so the guard below still trips if a change ever dates a building
                    // later than the imagery that confidently saw it - the defect of ZiolkowskiJakub/DiGi.GIS.ML#14.
                    if (year > confident)
                    {
                        predictions_AboveConfidentDetection++;
                    }
                }
                else
                {
                    rows_DetectedOnly++;
                }

                result.AddRow([reference, (ushort)year]);
            }

            Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"[INFO] year built: {rows_Confident} buildings dated by their first confident detection (confidence >= {Constants.Plausibility.ConfidentDetectionThreshold}), {rows_DetectedOnly} by a weaker detection only, {rows_Undetected} never detected and left out."));

            if (rows_Confident > 0)
            {
                double share = (double)predictions_AboveConfidentDetection / rows_Confident;
                if (!share.IsPlausibleShare())
                {
                    Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"[ERROR] year built plausibility guard: {share * 100:F1}% of predictions are later than the first confident detection year, over the {Constants.Plausibility.MaximumImplausibleShare * 100:F1}% maximum - refusing to return predicted year built values."));
                    return null;
                }
            }

            return result;
        }
    }
}
