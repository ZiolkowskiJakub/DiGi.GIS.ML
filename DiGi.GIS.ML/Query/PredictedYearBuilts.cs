using DiGi.Core;
using DiGi.Core.IO.Table.Classes;
using DiGi_GIS_ML;
using System;
using System.Collections.Generic;

namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Scores building feature rows using the machine learning year built prediction model.
        /// <para>Binds input features by column unique identifier first, with fallback to display names to support both database and tabular formats.</para>
        /// </summary>
        /// <param name="table">The table containing building features, including a reference column.</param>
        /// <returns>A new table containing the reference and predicted year built columns, or null if the input table is null or lacks a reference column.</returns>
        public static Table? PredictedYearBuilts(this Table? table)
        {
            if (table is null || table.Columns is null || table.ColumnCount == 0)
            {
                return null;
            }

            List<Column> columns = [.. table.Columns];

            int GetFeatureColumnIndex(Column? targetColumn, params string[] alternativeNames)
            {
                if (targetColumn is null)
                {
                    return -1;
                }

                string? targetUniqueId = targetColumn.UniqueId();

                if (!string.IsNullOrWhiteSpace(targetUniqueId))
                {
                    for (int i = 0; i < columns.Count; i++)
                    {
                        Column? column = columns[i];
                        if (column is not null && string.Equals(column.UniqueId(), targetUniqueId, StringComparison.Ordinal))
                        {
                            return i;
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(targetColumn.Name))
                {
                    for (int i = 0; i < columns.Count; i++)
                    {
                        Column? column = columns[i];
                        if (column is not null && string.Equals(column.Name, targetColumn.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            return i;
                        }
                    }
                }

                if (alternativeNames is not null && alternativeNames.Length > 0)
                {
                    for (int i = 0; i < columns.Count; i++)
                    {
                        Column? column = columns[i];
                        if (column is null || string.IsNullOrWhiteSpace(column.Name))
                        {
                            continue;
                        }

                        for (int j = 0; j < alternativeNames.Length; j++)
                        {
                            if (string.Equals(column.Name, alternativeNames[j], StringComparison.OrdinalIgnoreCase))
                            {
                                return i;
                            }
                        }
                    }
                }

                return -1;
            }

            int index_Reference = GetFeatureColumnIndex(IO.Constants.Column.Reference, "Reference");
            if (index_Reference < 0)
            {
                return null;
            }

            int index_BuildingGeneralFunction = GetFeatureColumnIndex(IO.Constants.Column.BuildingGeneralFunction, "Building General Function", "Building general function");
            int index_BuildingPhase = GetFeatureColumnIndex(IO.Constants.Column.BuildingPhase, "Building Phase", "Building phase");
            int index_Storeys = GetFeatureColumnIndex(IO.Constants.Column.Storeys, "Storeys", "Storey");
            int index_Area = GetFeatureColumnIndex(IO.Constants.Column.FloorArea, "Area", "Floor area", "Total area");
            int index_Location_X = GetFeatureColumnIndex(IO.Constants.Column.InternalPointX, "Location X", "Location_X", "Internal Point X", "Internal point x");
            int index_Location_Y = GetFeatureColumnIndex(IO.Constants.Column.InternalPointY, "Location Y", "Location_Y", "Internal Point Y", "Internal point y");
            int index_Voivodeship = GetFeatureColumnIndex(IO.Constants.Column.VoivodeshipName, "Voivodeship", "Voivodeship name");
            int index_County = GetFeatureColumnIndex(IO.Constants.Column.CountyId, "County", "County Id", "County Name", "County name");
            int index_Municipality = GetFeatureColumnIndex(IO.Constants.Column.MunicipalityName, "Municipality", "Municipality name");
            int index_Subdivision = GetFeatureColumnIndex(IO.Constants.Column.SubdivisionId, "Subdivision", "Subdivision Id", "Subdivision Name", "Subdivision name");
            int index_SubdivisionCalculatedOccupancy = GetFeatureColumnIndex(IO.Constants.Column.CalculatedOccupancy, "Subdivision Calculated Occupancy", "Calculated occupancy");
            int index_SubdivisionCalculatedOccupancyArea = GetFeatureColumnIndex(IO.Constants.Column.SubdivisionOccupancy, "Subdivision Calculated Occupancy Area", "Subdivision occupancy");
            int index_BoundingBox_X = GetFeatureColumnIndex(IO.Constants.Column.BoundingBoxX, "BoundingBox X", "Bounding Box X");
            int index_BoundingBox_Y = GetFeatureColumnIndex(IO.Constants.Column.BoundingBoxY, "BoundingBox Y", "Bounding Box Y");
            int index_BoundingBox_Width = GetFeatureColumnIndex(IO.Constants.Column.BoundingBoxWidth, "BoundingBox Width", "Bounding Box Width");
            int index_BoundingBox_Height = GetFeatureColumnIndex(IO.Constants.Column.BoundingBoxHeight, "BoundingBox Height", "Bounding Box Height");

            int[] indices_Population = new int[18];
            int[] indices_PredictionConfidence = new int[18];
            int[] indices_PredictionBBoxX = new int[18];
            int[] indices_PredictionBBoxY = new int[18];
            int[] indices_PredictionBBoxWidth = new int[18];
            int[] indices_PredictionBBoxHeight = new int[18];

            for (int year = 2008; year <= 2025; year++)
            {
                int offset = year - 2008;
                indices_Population[offset] = GetFeatureColumnIndex(IO.Create.Column_Population(year), $"Polpulation {year}", $"Population {year}", $"Municipality population {year}");
                indices_PredictionConfidence[offset] = GetFeatureColumnIndex(IO.Create.Column_PredictionYearBuit(IO.Constants.ColumnNamePrefix.PredictionConfidence, year), $"Prediction Confidence {year}");
                indices_PredictionBBoxX[offset] = GetFeatureColumnIndex(IO.Create.Column_PredictionYearBuit(IO.Constants.ColumnNamePrefix.PredictionBoundingBoxX, year), $"Prediction BoundingBox X {year}", $"Prediction Bounding Box X {year}");
                indices_PredictionBBoxY[offset] = GetFeatureColumnIndex(IO.Create.Column_PredictionYearBuit(IO.Constants.ColumnNamePrefix.PredictionBoundingBoxY, year), $"Prediction BoundingBox Y {year}", $"Prediction Bounding Box Y {year}");
                indices_PredictionBBoxWidth[offset] = GetFeatureColumnIndex(IO.Create.Column_PredictionYearBuit(IO.Constants.ColumnNamePrefix.PredictionBoundingBoxWidth, year), $"Prediction BoundingBox Width {year}", $"Prediction Bounding Box Width {year}");
                indices_PredictionBBoxHeight[offset] = GetFeatureColumnIndex(IO.Create.Column_PredictionYearBuit(IO.Constants.ColumnNamePrefix.PredictionBoundingBoxHeight, year), $"Prediction BoundingBox Height {year}", $"Prediction Bounding Box Height {year}");
            }

            Table result = new();
            result.AddColumn(IO.Constants.Column.Reference);
            result.AddColumn(IO.Constants.Column.PredictedYearBuilt);

            if (table.RowCount == 0)
            {
                return result;
            }

            for (int i = 0; i < table.RowCount; i++)
            {
                Row? row = table.GetRow(i);
                if (row is null)
                {
                    continue;
                }

                string? reference = row.GetValue(index_Reference, string.Empty);
                if (string.IsNullOrWhiteSpace(reference))
                {
                    continue;
                }

                OrtoBuildingDetectionModel.ModelInput modelInput = new()
                {
                    Reference = reference,
                    Building_General_Function = row.GetValue(index_BuildingGeneralFunction, -1F),
                    Building_Phase = row.GetValue(index_BuildingPhase, -1F),
                    Storeys = row.GetValue(index_Storeys, 0F),
                    Area = row.GetValue(index_Area, 0F),
                    Location_X = row.GetValue(index_Location_X, 0F),
                    Location_Y = row.GetValue(index_Location_Y, 0F),
                    Voivodeship = row.GetValue(index_Voivodeship, -1F),
                    County = row.GetValue(index_County, -1F),
                    Municipality = row.GetValue(index_Municipality, -1F),
                    Subdivision = row.GetValue(index_Subdivision, -1F),
                    Subdivision_Calculated_Occupancy = row.GetValue(index_SubdivisionCalculatedOccupancy, 0F),
                    Subdivision_Calculated_Occupancy_Area = row.GetValue(index_SubdivisionCalculatedOccupancyArea, 0F),
                    BoundingBox_X = row.GetValue(index_BoundingBox_X, 0F),
                    BoundingBox_Y = row.GetValue(index_BoundingBox_Y, 0F),
                    BoundingBox_Width = row.GetValue(index_BoundingBox_Width, 0F),
                    BoundingBox_Height = row.GetValue(index_BoundingBox_Height, 0F),

                    Polpulation_2008 = row.GetValue(indices_Population[0], 0F),
                    Polpulation_2009 = row.GetValue(indices_Population[1], 0F),
                    Polpulation_2010 = row.GetValue(indices_Population[2], 0F),
                    Polpulation_2011 = row.GetValue(indices_Population[3], 0F),
                    Polpulation_2012 = row.GetValue(indices_Population[4], 0F),
                    Polpulation_2013 = row.GetValue(indices_Population[5], 0F),
                    Polpulation_2014 = row.GetValue(indices_Population[6], 0F),
                    Polpulation_2015 = row.GetValue(indices_Population[7], 0F),
                    Polpulation_2016 = row.GetValue(indices_Population[8], 0F),
                    Polpulation_2017 = row.GetValue(indices_Population[9], 0F),
                    Polpulation_2018 = row.GetValue(indices_Population[10], 0F),
                    Polpulation_2019 = row.GetValue(indices_Population[11], 0F),
                    Polpulation_2020 = row.GetValue(indices_Population[12], 0F),
                    Polpulation_2021 = row.GetValue(indices_Population[13], 0F),
                    Polpulation_2022 = row.GetValue(indices_Population[14], 0F),
                    Polpulation_2023 = row.GetValue(indices_Population[15], 0F),
                    Polpulation_2024 = row.GetValue(indices_Population[16], 0F),
                    Polpulation_2025 = row.GetValue(indices_Population[17], 0F),

                    Prediction_Confidence_2008 = row.GetValue(indices_PredictionConfidence[0], 0F),
                    Prediction_BoundingBox_X_2008 = row.GetValue(indices_PredictionBBoxX[0], 0F),
                    Prediction_BoundingBox_Y_2008 = row.GetValue(indices_PredictionBBoxY[0], 0F),
                    Prediction_BoundingBox_Width_2008 = row.GetValue(indices_PredictionBBoxWidth[0], 0F),
                    Prediction_BoundingBox_Height_2008 = row.GetValue(indices_PredictionBBoxHeight[0], 0F),

                    Prediction_Confidence_2009 = row.GetValue(indices_PredictionConfidence[1], 0F),
                    Prediction_BoundingBox_X_2009 = row.GetValue(indices_PredictionBBoxX[1], 0F),
                    Prediction_BoundingBox_Y_2009 = row.GetValue(indices_PredictionBBoxY[1], 0F),
                    Prediction_BoundingBox_Width_2009 = row.GetValue(indices_PredictionBBoxWidth[1], 0F),
                    Prediction_BoundingBox_Height_2009 = row.GetValue(indices_PredictionBBoxHeight[1], 0F),

                    Prediction_Confidence_2010 = row.GetValue(indices_PredictionConfidence[2], 0F),
                    Prediction_BoundingBox_X_2010 = row.GetValue(indices_PredictionBBoxX[2], 0F),
                    Prediction_BoundingBox_Y_2010 = row.GetValue(indices_PredictionBBoxY[2], 0F),
                    Prediction_BoundingBox_Width_2010 = row.GetValue(indices_PredictionBBoxWidth[2], 0F),
                    Prediction_BoundingBox_Height_2010 = row.GetValue(indices_PredictionBBoxHeight[2], 0F),

                    Prediction_Confidence_2011 = row.GetValue(indices_PredictionConfidence[3], 0F),
                    Prediction_BoundingBox_X_2011 = row.GetValue(indices_PredictionBBoxX[3], 0F),
                    Prediction_BoundingBox_Y_2011 = row.GetValue(indices_PredictionBBoxY[3], 0F),
                    Prediction_BoundingBox_Width_2011 = row.GetValue(indices_PredictionBBoxWidth[3], 0F),
                    Prediction_BoundingBox_Height_2011 = row.GetValue(indices_PredictionBBoxHeight[3], 0F),

                    Prediction_Confidence_2012 = row.GetValue(indices_PredictionConfidence[4], 0F),
                    Prediction_BoundingBox_X_2012 = row.GetValue(indices_PredictionBBoxX[4], 0F),
                    Prediction_BoundingBox_Y_2012 = row.GetValue(indices_PredictionBBoxY[4], 0F),
                    Prediction_BoundingBox_Width_2012 = row.GetValue(indices_PredictionBBoxWidth[4], 0F),
                    Prediction_BoundingBox_Height_2012 = row.GetValue(indices_PredictionBBoxHeight[4], 0F),

                    Prediction_Confidence_2013 = row.GetValue(indices_PredictionConfidence[5], 0F),
                    Prediction_BoundingBox_X_2013 = row.GetValue(indices_PredictionBBoxX[5], 0F),
                    Prediction_BoundingBox_Y_2013 = row.GetValue(indices_PredictionBBoxY[5], 0F),
                    Prediction_BoundingBox_Width_2013 = row.GetValue(indices_PredictionBBoxWidth[5], 0F),
                    Prediction_BoundingBox_Height_2013 = row.GetValue(indices_PredictionBBoxHeight[5], 0F),

                    Prediction_Confidence_2014 = row.GetValue(indices_PredictionConfidence[6], 0F),
                    Prediction_BoundingBox_X_2014 = row.GetValue(indices_PredictionBBoxX[6], 0F),
                    Prediction_BoundingBox_Y_2014 = row.GetValue(indices_PredictionBBoxY[6], 0F),
                    Prediction_BoundingBox_Width_2014 = row.GetValue(indices_PredictionBBoxWidth[6], 0F),
                    Prediction_BoundingBox_Height_2014 = row.GetValue(indices_PredictionBBoxHeight[6], 0F),

                    Prediction_Confidence_2015 = row.GetValue(indices_PredictionConfidence[7], 0F),
                    Prediction_BoundingBox_X_2015 = row.GetValue(indices_PredictionBBoxX[7], 0F),
                    Prediction_BoundingBox_Y_2015 = row.GetValue(indices_PredictionBBoxY[7], 0F),
                    Prediction_BoundingBox_Width_2015 = row.GetValue(indices_PredictionBBoxWidth[7], 0F),
                    Prediction_BoundingBox_Height_2015 = row.GetValue(indices_PredictionBBoxHeight[7], 0F),

                    Prediction_Confidence_2016 = row.GetValue(indices_PredictionConfidence[8], 0F),
                    Prediction_BoundingBox_X_2016 = row.GetValue(indices_PredictionBBoxX[8], 0F),
                    Prediction_BoundingBox_Y_2016 = row.GetValue(indices_PredictionBBoxY[8], 0F),
                    Prediction_BoundingBox_Width_2016 = row.GetValue(indices_PredictionBBoxWidth[8], 0F),
                    Prediction_BoundingBox_Height_2016 = row.GetValue(indices_PredictionBBoxHeight[8], 0F),

                    Prediction_Confidence_2017 = row.GetValue(indices_PredictionConfidence[9], 0F),
                    Prediction_BoundingBox_X_2017 = row.GetValue(indices_PredictionBBoxX[9], 0F),
                    Prediction_BoundingBox_Y_2017 = row.GetValue(indices_PredictionBBoxY[9], 0F),
                    Prediction_BoundingBox_Width_2017 = row.GetValue(indices_PredictionBBoxWidth[9], 0F),
                    Prediction_BoundingBox_Height_2017 = row.GetValue(indices_PredictionBBoxHeight[9], 0F),

                    Prediction_Confidence_2018 = row.GetValue(indices_PredictionConfidence[10], 0F),
                    Prediction_BoundingBox_X_2018 = row.GetValue(indices_PredictionBBoxX[10], 0F),
                    Prediction_BoundingBox_Y_2018 = row.GetValue(indices_PredictionBBoxY[10], 0F),
                    Prediction_BoundingBox_Width_2018 = row.GetValue(indices_PredictionBBoxWidth[10], 0F),
                    Prediction_BoundingBox_Height_2018 = row.GetValue(indices_PredictionBBoxHeight[10], 0F),

                    Prediction_Confidence_2019 = row.GetValue(indices_PredictionConfidence[11], 0F),
                    Prediction_BoundingBox_X_2019 = row.GetValue(indices_PredictionBBoxX[11], 0F),
                    Prediction_BoundingBox_Y_2019 = row.GetValue(indices_PredictionBBoxY[11], 0F),
                    Prediction_BoundingBox_Width_2019 = row.GetValue(indices_PredictionBBoxWidth[11], 0F),
                    Prediction_BoundingBox_Height_2019 = row.GetValue(indices_PredictionBBoxHeight[11], 0F),

                    Prediction_Confidence_2020 = row.GetValue(indices_PredictionConfidence[12], 0F),
                    Prediction_BoundingBox_X_2020 = row.GetValue(indices_PredictionBBoxX[12], 0F),
                    Prediction_BoundingBox_Y_2020 = row.GetValue(indices_PredictionBBoxY[12], 0F),
                    Prediction_BoundingBox_Width_2020 = row.GetValue(indices_PredictionBBoxWidth[12], 0F),
                    Prediction_BoundingBox_Height_2020 = row.GetValue(indices_PredictionBBoxHeight[12], 0F),

                    Prediction_Confidence_2021 = row.GetValue(indices_PredictionConfidence[13], 0F),
                    Prediction_BoundingBox_X_2021 = row.GetValue(indices_PredictionBBoxX[13], 0F),
                    Prediction_BoundingBox_Y_2021 = row.GetValue(indices_PredictionBBoxY[13], 0F),
                    Prediction_BoundingBox_Width_2021 = row.GetValue(indices_PredictionBBoxWidth[13], 0F),
                    Prediction_BoundingBox_Height_2021 = row.GetValue(indices_PredictionBBoxHeight[13], 0F),

                    Prediction_Confidence_2022 = row.GetValue(indices_PredictionConfidence[14], 0F),
                    Prediction_BoundingBox_X_2022 = row.GetValue(indices_PredictionBBoxX[14], 0F),
                    Prediction_BoundingBox_Y_2022 = row.GetValue(indices_PredictionBBoxY[14], 0F),
                    Prediction_BoundingBox_Width_2022 = row.GetValue(indices_PredictionBBoxWidth[14], 0F),
                    Prediction_BoundingBox_Height_2022 = row.GetValue(indices_PredictionBBoxHeight[14], 0F),

                    Prediction_Confidence_2023 = row.GetValue(indices_PredictionConfidence[15], 0F),
                    Prediction_BoundingBox_X_2023 = row.GetValue(indices_PredictionBBoxX[15], 0F),
                    Prediction_BoundingBox_Y_2023 = row.GetValue(indices_PredictionBBoxY[15], 0F),
                    Prediction_BoundingBox_Width_2023 = row.GetValue(indices_PredictionBBoxWidth[15], 0F),
                    Prediction_BoundingBox_Height_2023 = row.GetValue(indices_PredictionBBoxHeight[15], 0F),

                    Prediction_Confidence_2024 = row.GetValue(indices_PredictionConfidence[16], 0F),
                    Prediction_BoundingBox_X_2024 = row.GetValue(indices_PredictionBBoxX[16], 0F),
                    Prediction_BoundingBox_Y_2024 = row.GetValue(indices_PredictionBBoxY[16], 0F),
                    Prediction_BoundingBox_Width_2024 = row.GetValue(indices_PredictionBBoxWidth[16], 0F),
                    Prediction_BoundingBox_Height_2024 = row.GetValue(indices_PredictionBBoxHeight[16], 0F),

                    Prediction_Confidence_2025 = row.GetValue(indices_PredictionConfidence[17], 0F),
                    Prediction_BoundingBox_X_2025 = row.GetValue(indices_PredictionBBoxX[17], 0F),
                    Prediction_BoundingBox_Y_2025 = row.GetValue(indices_PredictionBBoxY[17], 0F),
                    Prediction_BoundingBox_Width_2025 = row.GetValue(indices_PredictionBBoxWidth[17], 0F),
                    Prediction_BoundingBox_Height_2025 = row.GetValue(indices_PredictionBBoxHeight[17], 0F)
                };

                OrtoBuildingDetectionModel.ModelOutput predictionResult = OrtoBuildingDetectionModel.Predict(modelInput);
                double score = predictionResult.Score;
                int floor = (int)Math.Floor(score);
                int year = score - floor > 0.5 ? floor + 1 : floor;
                if (year < 0)
                {
                    year = 0;
                }
                else if (year > ushort.MaxValue)
                {
                    year = ushort.MaxValue;
                }

                result.AddRow([reference, (ushort)year]);
            }

            return result;
        }
    }
}
