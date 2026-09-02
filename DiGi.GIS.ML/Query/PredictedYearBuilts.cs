using DiGi.Core.IO;
using DiGi.Core.IO.Table.Classes;
using DiGi_GIS_ML;
using System;
using System.Collections.Generic;

namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Scores building feature rows into a predicted construction year.
        /// <para>Every feature is read by the column it was trained against, resolved once for the whole table rather than per row. Resolution is by stored column slug first - the identifier the database and the WebAPI address a column by - and by display name second, so a table that came from a file rather than from the database still binds.</para>
        /// <para>A column the table does not carry reads as the type default, which is deliberate and has to stay that way: the training table is materialised the same way, so a feature absent at training and a feature absent at inference look identical to the model. Change one and the model sees a distribution it was never fitted on.</para>
        /// <para>The generated <see cref="OrtoBuildingDetectionModel.ModelInput"/> is the authority for this list. It is regenerated whenever the model is retrained, and the feature contract fact in DiGi.GIS.ML.xUnit fails if this and the allow-list stop agreeing.</para>
        /// </summary>
        /// <param name="table">The table containing building features, including a reference column.</param>
        /// <returns>A new table carrying the reference and predicted year built columns, or null if the input table is null or lacks a reference column.</returns>
        public static Table? PredictedYearBuilts(this Table? table)
        {
            if (table is null || table.Columns is null || table.ColumnCount == 0)
            {
                return null;
            }

            // Resolved once. Two lookups per column across a county of rows was measurable, and the
            // mapping cannot change while the table is being read.
            Dictionary<string, int> indexes_BySlug = [];
            Dictionary<string, int> indexes_ByName = [];

            List<Column> columns = [.. table.Columns];
            for (int i = 0; i < columns.Count; i++)
            {
                Column? column = columns[i];
                if (column is null)
                {
                    continue;
                }

                if (Core.IO.Query.UniqueId(column) is string slug && !string.IsNullOrWhiteSpace(slug))
                {
                    indexes_BySlug.TryAdd(slug, i);
                }

                if (column.Name is string name && !string.IsNullOrWhiteSpace(name))
                {
                    indexes_ByName.TryAdd(name, i);
                }
            }

            int Index(string name)
            {
                if (indexes_BySlug.TryGetValue(Core.IO.Query.UniqueId(new Column(name, typeof(string))) ?? name, out int index_Slug))
                {
                    return index_Slug;
                }

                return indexes_ByName.TryGetValue(name, out int index_Name) ? index_Name : -1;
            }

            int index_Reference = Index(GIS.IO.Constants.Column.Reference.Name ?? "Reference");
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

                float Single(string name)
                {
                    int index = Index(name);
                    return index < 0 ? 0F : row.GetValue(index, 0F);
                }

                string Text(string name)
                {
                    int index = Index(name);
                    return index < 0 ? string.Empty : row.GetValue(index, string.Empty) ?? string.Empty;
                }

                bool Boolean(string name)
                {
                    int index = Index(name);
                    return index >= 0 && row.GetValue(index, false);
                }

                OrtoBuildingDetectionModel.ModelInput modelInput = new()
                {
                    Floor_area = Single("Floor area"),
                    Total_area = Single("Total area"),
                    Storeys = Single("Storeys"),
                    Azimuth = Single("Azimuth"),
                    Cardinal_direction = Text("Cardinal direction"),
                    Internal_Point_X = Single("Internal Point X"),
                    Internal_Point_Y = Single("Internal Point Y"),
                    BoundingBox_X = Single("BoundingBox X"),
                    BoundingBox_Y = Single("BoundingBox Y"),
                    BoundingBox_width = Single("BoundingBox width"),
                    BoundingBox_height = Single("BoundingBox height"),
                    Isoperimetric_ratio = Single("Isoperimetric ratio"),
                    Rectangular_thinnes_ratio = Single("Rectangular thinnes ratio"),
                    Square_thinness_ratio = Single("Square thinness ratio"),
                    Thinness_ratio = Single("Thinness ratio"),
                    Convex_hull_thinness_ratio = Single("Convex hull thinness ratio"),
                    Calculated_Building_Shape = Text("Calculated Building Shape"),
                    Building_general_function = Text("Building general function"),
                    Building_specific_functions = Text("Building specific functions"),
                    Building_Phase = Text("Building Phase"),
                    Is_residential = Boolean("Is residential"),
                    Is_occupied = Boolean("Is occupied"),
                    Voivodeship_name = Text("Voivodeship name"),
                    County_name = Text("County name"),
                    County_Id = Single("County Id"),
                    Municipality_name = Text("Municipality name"),
                    Subdivision_name = Text("Subdivision name"),
                    Subdivision_Id = Single("Subdivision Id"),
                    Settlement_type = Text("Settlement type"),
                    Subdivision_occupancy = Single("Subdivision occupancy"),
                    Calculated_occupancy = Single("Calculated occupancy"),
                    Grid_cell_coverage__0_0_ = Single("Grid cell coverage [0,0]"),
                    Grid_cell_coverage__0_1_ = Single("Grid cell coverage [0,1]"),
                    Grid_cell_coverage__0_2_ = Single("Grid cell coverage [0,2]"),
                    Grid_cell_coverage__0_3_ = Single("Grid cell coverage [0,3]"),
                    Grid_cell_coverage__0_4_ = Single("Grid cell coverage [0,4]"),
                    Grid_cell_coverage__1_0_ = Single("Grid cell coverage [1,0]"),
                    Grid_cell_coverage__1_1_ = Single("Grid cell coverage [1,1]"),
                    Grid_cell_coverage__1_2_ = Single("Grid cell coverage [1,2]"),
                    Grid_cell_coverage__1_3_ = Single("Grid cell coverage [1,3]"),
                    Grid_cell_coverage__1_4_ = Single("Grid cell coverage [1,4]"),
                    Grid_cell_coverage__2_0_ = Single("Grid cell coverage [2,0]"),
                    Grid_cell_coverage__2_1_ = Single("Grid cell coverage [2,1]"),
                    Grid_cell_coverage__2_2_ = Single("Grid cell coverage [2,2]"),
                    Grid_cell_coverage__2_3_ = Single("Grid cell coverage [2,3]"),
                    Grid_cell_coverage__2_4_ = Single("Grid cell coverage [2,4]"),
                    Grid_cell_coverage__3_0_ = Single("Grid cell coverage [3,0]"),
                    Grid_cell_coverage__3_1_ = Single("Grid cell coverage [3,1]"),
                    Grid_cell_coverage__3_2_ = Single("Grid cell coverage [3,2]"),
                    Grid_cell_coverage__3_3_ = Single("Grid cell coverage [3,3]"),
                    Grid_cell_coverage__3_4_ = Single("Grid cell coverage [3,4]"),
                    Grid_cell_coverage__4_0_ = Single("Grid cell coverage [4,0]"),
                    Grid_cell_coverage__4_1_ = Single("Grid cell coverage [4,1]"),
                    Grid_cell_coverage__4_2_ = Single("Grid cell coverage [4,2]"),
                    Grid_cell_coverage__4_3_ = Single("Grid cell coverage [4,3]"),
                    Grid_cell_coverage__4_4_ = Single("Grid cell coverage [4,4]"),
                    Prediction_Confidence_2008 = Single("Prediction Confidence 2008"),
                    Prediction_BoundingBox_X_2008 = Single("Prediction BoundingBox X 2008"),
                    Prediction_BoundingBox_Y_2008 = Single("Prediction BoundingBox Y 2008"),
                    Prediction_BoundingBox_Width_2008 = Single("Prediction BoundingBox Width 2008"),
                    Prediction_BoundingBox_Height_2008 = Single("Prediction BoundingBox Height 2008"),
                    Prediction_Confidence_2009 = Single("Prediction Confidence 2009"),
                    Prediction_BoundingBox_X_2009 = Single("Prediction BoundingBox X 2009"),
                    Prediction_BoundingBox_Y_2009 = Single("Prediction BoundingBox Y 2009"),
                    Prediction_BoundingBox_Width_2009 = Single("Prediction BoundingBox Width 2009"),
                    Prediction_BoundingBox_Height_2009 = Single("Prediction BoundingBox Height 2009"),
                    Prediction_Confidence_2010 = Single("Prediction Confidence 2010"),
                    Prediction_BoundingBox_X_2010 = Single("Prediction BoundingBox X 2010"),
                    Prediction_BoundingBox_Y_2010 = Single("Prediction BoundingBox Y 2010"),
                    Prediction_BoundingBox_Width_2010 = Single("Prediction BoundingBox Width 2010"),
                    Prediction_BoundingBox_Height_2010 = Single("Prediction BoundingBox Height 2010"),
                    Prediction_Confidence_2011 = Single("Prediction Confidence 2011"),
                    Prediction_BoundingBox_X_2011 = Single("Prediction BoundingBox X 2011"),
                    Prediction_BoundingBox_Y_2011 = Single("Prediction BoundingBox Y 2011"),
                    Prediction_BoundingBox_Width_2011 = Single("Prediction BoundingBox Width 2011"),
                    Prediction_BoundingBox_Height_2011 = Single("Prediction BoundingBox Height 2011"),
                    Prediction_Confidence_2012 = Single("Prediction Confidence 2012"),
                    Prediction_BoundingBox_X_2012 = Single("Prediction BoundingBox X 2012"),
                    Prediction_BoundingBox_Y_2012 = Single("Prediction BoundingBox Y 2012"),
                    Prediction_BoundingBox_Width_2012 = Single("Prediction BoundingBox Width 2012"),
                    Prediction_BoundingBox_Height_2012 = Single("Prediction BoundingBox Height 2012"),
                    Prediction_Confidence_2013 = Single("Prediction Confidence 2013"),
                    Prediction_BoundingBox_X_2013 = Single("Prediction BoundingBox X 2013"),
                    Prediction_BoundingBox_Y_2013 = Single("Prediction BoundingBox Y 2013"),
                    Prediction_BoundingBox_Width_2013 = Single("Prediction BoundingBox Width 2013"),
                    Prediction_BoundingBox_Height_2013 = Single("Prediction BoundingBox Height 2013"),
                    Prediction_Confidence_2014 = Single("Prediction Confidence 2014"),
                    Prediction_BoundingBox_X_2014 = Single("Prediction BoundingBox X 2014"),
                    Prediction_BoundingBox_Y_2014 = Single("Prediction BoundingBox Y 2014"),
                    Prediction_BoundingBox_Width_2014 = Single("Prediction BoundingBox Width 2014"),
                    Prediction_BoundingBox_Height_2014 = Single("Prediction BoundingBox Height 2014"),
                    Prediction_Confidence_2015 = Single("Prediction Confidence 2015"),
                    Prediction_BoundingBox_X_2015 = Single("Prediction BoundingBox X 2015"),
                    Prediction_BoundingBox_Y_2015 = Single("Prediction BoundingBox Y 2015"),
                    Prediction_BoundingBox_Width_2015 = Single("Prediction BoundingBox Width 2015"),
                    Prediction_BoundingBox_Height_2015 = Single("Prediction BoundingBox Height 2015"),
                    Prediction_Confidence_2016 = Single("Prediction Confidence 2016"),
                    Prediction_BoundingBox_X_2016 = Single("Prediction BoundingBox X 2016"),
                    Prediction_BoundingBox_Y_2016 = Single("Prediction BoundingBox Y 2016"),
                    Prediction_BoundingBox_Width_2016 = Single("Prediction BoundingBox Width 2016"),
                    Prediction_BoundingBox_Height_2016 = Single("Prediction BoundingBox Height 2016"),
                    Prediction_Confidence_2017 = Single("Prediction Confidence 2017"),
                    Prediction_BoundingBox_X_2017 = Single("Prediction BoundingBox X 2017"),
                    Prediction_BoundingBox_Y_2017 = Single("Prediction BoundingBox Y 2017"),
                    Prediction_BoundingBox_Width_2017 = Single("Prediction BoundingBox Width 2017"),
                    Prediction_BoundingBox_Height_2017 = Single("Prediction BoundingBox Height 2017"),
                    Prediction_Confidence_2018 = Single("Prediction Confidence 2018"),
                    Prediction_BoundingBox_X_2018 = Single("Prediction BoundingBox X 2018"),
                    Prediction_BoundingBox_Y_2018 = Single("Prediction BoundingBox Y 2018"),
                    Prediction_BoundingBox_Width_2018 = Single("Prediction BoundingBox Width 2018"),
                    Prediction_BoundingBox_Height_2018 = Single("Prediction BoundingBox Height 2018"),
                    Prediction_Confidence_2019 = Single("Prediction Confidence 2019"),
                    Prediction_BoundingBox_X_2019 = Single("Prediction BoundingBox X 2019"),
                    Prediction_BoundingBox_Y_2019 = Single("Prediction BoundingBox Y 2019"),
                    Prediction_BoundingBox_Width_2019 = Single("Prediction BoundingBox Width 2019"),
                    Prediction_BoundingBox_Height_2019 = Single("Prediction BoundingBox Height 2019"),
                    Prediction_Confidence_2020 = Single("Prediction Confidence 2020"),
                    Prediction_BoundingBox_X_2020 = Single("Prediction BoundingBox X 2020"),
                    Prediction_BoundingBox_Y_2020 = Single("Prediction BoundingBox Y 2020"),
                    Prediction_BoundingBox_Width_2020 = Single("Prediction BoundingBox Width 2020"),
                    Prediction_BoundingBox_Height_2020 = Single("Prediction BoundingBox Height 2020"),
                    Prediction_Confidence_2021 = Single("Prediction Confidence 2021"),
                    Prediction_BoundingBox_X_2021 = Single("Prediction BoundingBox X 2021"),
                    Prediction_BoundingBox_Y_2021 = Single("Prediction BoundingBox Y 2021"),
                    Prediction_BoundingBox_Width_2021 = Single("Prediction BoundingBox Width 2021"),
                    Prediction_BoundingBox_Height_2021 = Single("Prediction BoundingBox Height 2021"),
                    Prediction_Confidence_2022 = Single("Prediction Confidence 2022"),
                    Prediction_BoundingBox_X_2022 = Single("Prediction BoundingBox X 2022"),
                    Prediction_BoundingBox_Y_2022 = Single("Prediction BoundingBox Y 2022"),
                    Prediction_BoundingBox_Width_2022 = Single("Prediction BoundingBox Width 2022"),
                    Prediction_BoundingBox_Height_2022 = Single("Prediction BoundingBox Height 2022"),
                    Prediction_Confidence_2023 = Single("Prediction Confidence 2023"),
                    Prediction_BoundingBox_X_2023 = Single("Prediction BoundingBox X 2023"),
                    Prediction_BoundingBox_Y_2023 = Single("Prediction BoundingBox Y 2023"),
                    Prediction_BoundingBox_Width_2023 = Single("Prediction BoundingBox Width 2023"),
                    Prediction_BoundingBox_Height_2023 = Single("Prediction BoundingBox Height 2023"),
                    Prediction_Confidence_2024 = Single("Prediction Confidence 2024"),
                    Prediction_BoundingBox_X_2024 = Single("Prediction BoundingBox X 2024"),
                    Prediction_BoundingBox_Y_2024 = Single("Prediction BoundingBox Y 2024"),
                    Prediction_BoundingBox_Width_2024 = Single("Prediction BoundingBox Width 2024"),
                    Prediction_BoundingBox_Height_2024 = Single("Prediction BoundingBox Height 2024"),
                    Prediction_Confidence_2025 = Single("Prediction Confidence 2025"),
                    Prediction_BoundingBox_X_2025 = Single("Prediction BoundingBox X 2025"),
                    Prediction_BoundingBox_Y_2025 = Single("Prediction BoundingBox Y 2025"),
                    Prediction_BoundingBox_Width_2025 = Single("Prediction BoundingBox Width 2025"),
                    Prediction_BoundingBox_Height_2025 = Single("Prediction BoundingBox Height 2025"),
                    Municipality_population_2008 = Single("Municipality population 2008"),
                    Municipality_population_2009 = Single("Municipality population 2009"),
                    Municipality_population_2010 = Single("Municipality population 2010"),
                    Municipality_population_2011 = Single("Municipality population 2011"),
                    Municipality_population_2012 = Single("Municipality population 2012"),
                    Municipality_population_2013 = Single("Municipality population 2013"),
                    Municipality_population_2014 = Single("Municipality population 2014"),
                    Municipality_population_2015 = Single("Municipality population 2015"),
                    Municipality_population_2016 = Single("Municipality population 2016"),
                    Municipality_population_2017 = Single("Municipality population 2017"),
                    Municipality_population_2018 = Single("Municipality population 2018"),
                    Municipality_population_2019 = Single("Municipality population 2019"),
                    Municipality_population_2020 = Single("Municipality population 2020"),
                    Municipality_population_2021 = Single("Municipality population 2021"),
                    Municipality_population_2022 = Single("Municipality population 2022"),
                    Municipality_population_2023 = Single("Municipality population 2023"),
                    Municipality_population_2024 = Single("Municipality population 2024"),
                    Municipality_population_2025 = Single("Municipality population 2025"),
                    Radial_Building_Coverage_Ratio_200m = Single("Radial Building Coverage Ratio 200m"),
                    Radial_Floor_Area_Ratio_200m = Single("Radial Floor Area Ratio 200m"),
                    Radial_Building_Coverage_Ratio_400m = Single("Radial Building Coverage Ratio 400m"),
                    Radial_Floor_Area_Ratio_400m = Single("Radial Floor Area Ratio 400m"),
                    Radial_Building_Coverage_Ratio_600m = Single("Radial Building Coverage Ratio 600m"),
                    Radial_Floor_Area_Ratio_600m = Single("Radial Floor Area Ratio 600m"),
                    Radial_Building_Coverage_Ratio_1000m = Single("Radial Building Coverage Ratio 1000m"),
                    Radial_Floor_Area_Ratio_1000m = Single("Radial Floor Area Ratio 1000m"),
                };

                OrtoBuildingDetectionModel.ModelOutput modelOutput = OrtoBuildingDetectionModel.Predict(modelInput);

                double score = modelOutput.Score;
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
