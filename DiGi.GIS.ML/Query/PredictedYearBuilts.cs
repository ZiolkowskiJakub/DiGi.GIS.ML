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
        /// <para>Every feature is read by the column it was trained against, and every one of those columns is resolved once for the whole table before a single row is read. Resolution is by stored column slug first - the identifier the database and the WebAPI address a column by - and by display name second, so a table that came from a file rather than from the database still binds.</para>
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

            // Every feature resolved once for the whole table. Resolving inside the row loop meant a Column
            // allocation and a slug computation per feature per row - 172 of them against 20 241 rows is
            // three and a half million of each, for a mapping that cannot change while the table is read.
            int index_Floor_area = Index("Floor area");
            int index_Total_area = Index("Total area");
            int index_Storeys = Index("Storeys");
            int index_Azimuth = Index("Azimuth");
            int index_Cardinal_direction = Index("Cardinal direction");
            int index_Internal_Point_X = Index("Internal Point X");
            int index_Internal_Point_Y = Index("Internal Point Y");
            int index_BoundingBox_X = Index("BoundingBox X");
            int index_BoundingBox_Y = Index("BoundingBox Y");
            int index_BoundingBox_width = Index("BoundingBox width");
            int index_BoundingBox_height = Index("BoundingBox height");
            int index_Isoperimetric_ratio = Index("Isoperimetric ratio");
            int index_Rectangular_thinnes_ratio = Index("Rectangular thinnes ratio");
            int index_Square_thinness_ratio = Index("Square thinness ratio");
            int index_Thinness_ratio = Index("Thinness ratio");
            int index_Convex_hull_thinness_ratio = Index("Convex hull thinness ratio");
            int index_Calculated_Building_Shape = Index("Calculated Building Shape");
            int index_Building_general_function = Index("Building general function");
            int index_Building_specific_functions = Index("Building specific functions");
            int index_Building_Phase = Index("Building Phase");
            int index_Is_residential = Index("Is residential");
            int index_Is_occupied = Index("Is occupied");
            int index_Voivodeship_name = Index("Voivodeship name");
            int index_County_name = Index("County name");
            int index_County_Id = Index("County Id");
            int index_Municipality_name = Index("Municipality name");
            int index_Subdivision_name = Index("Subdivision name");
            int index_Subdivision_Id = Index("Subdivision Id");
            int index_Settlement_type = Index("Settlement type");
            int index_Subdivision_occupancy = Index("Subdivision occupancy");
            int index_Calculated_occupancy = Index("Calculated occupancy");
            int index_Grid_cell_coverage__0_0_ = Index("Grid cell coverage [0,0]");
            int index_Grid_cell_coverage__0_1_ = Index("Grid cell coverage [0,1]");
            int index_Grid_cell_coverage__0_2_ = Index("Grid cell coverage [0,2]");
            int index_Grid_cell_coverage__0_3_ = Index("Grid cell coverage [0,3]");
            int index_Grid_cell_coverage__0_4_ = Index("Grid cell coverage [0,4]");
            int index_Grid_cell_coverage__1_0_ = Index("Grid cell coverage [1,0]");
            int index_Grid_cell_coverage__1_1_ = Index("Grid cell coverage [1,1]");
            int index_Grid_cell_coverage__1_2_ = Index("Grid cell coverage [1,2]");
            int index_Grid_cell_coverage__1_3_ = Index("Grid cell coverage [1,3]");
            int index_Grid_cell_coverage__1_4_ = Index("Grid cell coverage [1,4]");
            int index_Grid_cell_coverage__2_0_ = Index("Grid cell coverage [2,0]");
            int index_Grid_cell_coverage__2_1_ = Index("Grid cell coverage [2,1]");
            int index_Grid_cell_coverage__2_2_ = Index("Grid cell coverage [2,2]");
            int index_Grid_cell_coverage__2_3_ = Index("Grid cell coverage [2,3]");
            int index_Grid_cell_coverage__2_4_ = Index("Grid cell coverage [2,4]");
            int index_Grid_cell_coverage__3_0_ = Index("Grid cell coverage [3,0]");
            int index_Grid_cell_coverage__3_1_ = Index("Grid cell coverage [3,1]");
            int index_Grid_cell_coverage__3_2_ = Index("Grid cell coverage [3,2]");
            int index_Grid_cell_coverage__3_3_ = Index("Grid cell coverage [3,3]");
            int index_Grid_cell_coverage__3_4_ = Index("Grid cell coverage [3,4]");
            int index_Grid_cell_coverage__4_0_ = Index("Grid cell coverage [4,0]");
            int index_Grid_cell_coverage__4_1_ = Index("Grid cell coverage [4,1]");
            int index_Grid_cell_coverage__4_2_ = Index("Grid cell coverage [4,2]");
            int index_Grid_cell_coverage__4_3_ = Index("Grid cell coverage [4,3]");
            int index_Grid_cell_coverage__4_4_ = Index("Grid cell coverage [4,4]");
            int index_Prediction_Confidence_2008 = Index("Prediction Confidence 2008");
            int index_Prediction_BoundingBox_X_2008 = Index("Prediction BoundingBox X 2008");
            int index_Prediction_BoundingBox_Y_2008 = Index("Prediction BoundingBox Y 2008");
            int index_Prediction_BoundingBox_Width_2008 = Index("Prediction BoundingBox Width 2008");
            int index_Prediction_BoundingBox_Height_2008 = Index("Prediction BoundingBox Height 2008");
            int index_Prediction_Confidence_2009 = Index("Prediction Confidence 2009");
            int index_Prediction_BoundingBox_X_2009 = Index("Prediction BoundingBox X 2009");
            int index_Prediction_BoundingBox_Y_2009 = Index("Prediction BoundingBox Y 2009");
            int index_Prediction_BoundingBox_Width_2009 = Index("Prediction BoundingBox Width 2009");
            int index_Prediction_BoundingBox_Height_2009 = Index("Prediction BoundingBox Height 2009");
            int index_Prediction_Confidence_2010 = Index("Prediction Confidence 2010");
            int index_Prediction_BoundingBox_X_2010 = Index("Prediction BoundingBox X 2010");
            int index_Prediction_BoundingBox_Y_2010 = Index("Prediction BoundingBox Y 2010");
            int index_Prediction_BoundingBox_Width_2010 = Index("Prediction BoundingBox Width 2010");
            int index_Prediction_BoundingBox_Height_2010 = Index("Prediction BoundingBox Height 2010");
            int index_Prediction_Confidence_2011 = Index("Prediction Confidence 2011");
            int index_Prediction_BoundingBox_X_2011 = Index("Prediction BoundingBox X 2011");
            int index_Prediction_BoundingBox_Y_2011 = Index("Prediction BoundingBox Y 2011");
            int index_Prediction_BoundingBox_Width_2011 = Index("Prediction BoundingBox Width 2011");
            int index_Prediction_BoundingBox_Height_2011 = Index("Prediction BoundingBox Height 2011");
            int index_Prediction_Confidence_2012 = Index("Prediction Confidence 2012");
            int index_Prediction_BoundingBox_X_2012 = Index("Prediction BoundingBox X 2012");
            int index_Prediction_BoundingBox_Y_2012 = Index("Prediction BoundingBox Y 2012");
            int index_Prediction_BoundingBox_Width_2012 = Index("Prediction BoundingBox Width 2012");
            int index_Prediction_BoundingBox_Height_2012 = Index("Prediction BoundingBox Height 2012");
            int index_Prediction_Confidence_2013 = Index("Prediction Confidence 2013");
            int index_Prediction_BoundingBox_X_2013 = Index("Prediction BoundingBox X 2013");
            int index_Prediction_BoundingBox_Y_2013 = Index("Prediction BoundingBox Y 2013");
            int index_Prediction_BoundingBox_Width_2013 = Index("Prediction BoundingBox Width 2013");
            int index_Prediction_BoundingBox_Height_2013 = Index("Prediction BoundingBox Height 2013");
            int index_Prediction_Confidence_2014 = Index("Prediction Confidence 2014");
            int index_Prediction_BoundingBox_X_2014 = Index("Prediction BoundingBox X 2014");
            int index_Prediction_BoundingBox_Y_2014 = Index("Prediction BoundingBox Y 2014");
            int index_Prediction_BoundingBox_Width_2014 = Index("Prediction BoundingBox Width 2014");
            int index_Prediction_BoundingBox_Height_2014 = Index("Prediction BoundingBox Height 2014");
            int index_Prediction_Confidence_2015 = Index("Prediction Confidence 2015");
            int index_Prediction_BoundingBox_X_2015 = Index("Prediction BoundingBox X 2015");
            int index_Prediction_BoundingBox_Y_2015 = Index("Prediction BoundingBox Y 2015");
            int index_Prediction_BoundingBox_Width_2015 = Index("Prediction BoundingBox Width 2015");
            int index_Prediction_BoundingBox_Height_2015 = Index("Prediction BoundingBox Height 2015");
            int index_Prediction_Confidence_2016 = Index("Prediction Confidence 2016");
            int index_Prediction_BoundingBox_X_2016 = Index("Prediction BoundingBox X 2016");
            int index_Prediction_BoundingBox_Y_2016 = Index("Prediction BoundingBox Y 2016");
            int index_Prediction_BoundingBox_Width_2016 = Index("Prediction BoundingBox Width 2016");
            int index_Prediction_BoundingBox_Height_2016 = Index("Prediction BoundingBox Height 2016");
            int index_Prediction_Confidence_2017 = Index("Prediction Confidence 2017");
            int index_Prediction_BoundingBox_X_2017 = Index("Prediction BoundingBox X 2017");
            int index_Prediction_BoundingBox_Y_2017 = Index("Prediction BoundingBox Y 2017");
            int index_Prediction_BoundingBox_Width_2017 = Index("Prediction BoundingBox Width 2017");
            int index_Prediction_BoundingBox_Height_2017 = Index("Prediction BoundingBox Height 2017");
            int index_Prediction_Confidence_2018 = Index("Prediction Confidence 2018");
            int index_Prediction_BoundingBox_X_2018 = Index("Prediction BoundingBox X 2018");
            int index_Prediction_BoundingBox_Y_2018 = Index("Prediction BoundingBox Y 2018");
            int index_Prediction_BoundingBox_Width_2018 = Index("Prediction BoundingBox Width 2018");
            int index_Prediction_BoundingBox_Height_2018 = Index("Prediction BoundingBox Height 2018");
            int index_Prediction_Confidence_2019 = Index("Prediction Confidence 2019");
            int index_Prediction_BoundingBox_X_2019 = Index("Prediction BoundingBox X 2019");
            int index_Prediction_BoundingBox_Y_2019 = Index("Prediction BoundingBox Y 2019");
            int index_Prediction_BoundingBox_Width_2019 = Index("Prediction BoundingBox Width 2019");
            int index_Prediction_BoundingBox_Height_2019 = Index("Prediction BoundingBox Height 2019");
            int index_Prediction_Confidence_2020 = Index("Prediction Confidence 2020");
            int index_Prediction_BoundingBox_X_2020 = Index("Prediction BoundingBox X 2020");
            int index_Prediction_BoundingBox_Y_2020 = Index("Prediction BoundingBox Y 2020");
            int index_Prediction_BoundingBox_Width_2020 = Index("Prediction BoundingBox Width 2020");
            int index_Prediction_BoundingBox_Height_2020 = Index("Prediction BoundingBox Height 2020");
            int index_Prediction_Confidence_2021 = Index("Prediction Confidence 2021");
            int index_Prediction_BoundingBox_X_2021 = Index("Prediction BoundingBox X 2021");
            int index_Prediction_BoundingBox_Y_2021 = Index("Prediction BoundingBox Y 2021");
            int index_Prediction_BoundingBox_Width_2021 = Index("Prediction BoundingBox Width 2021");
            int index_Prediction_BoundingBox_Height_2021 = Index("Prediction BoundingBox Height 2021");
            int index_Prediction_Confidence_2022 = Index("Prediction Confidence 2022");
            int index_Prediction_BoundingBox_X_2022 = Index("Prediction BoundingBox X 2022");
            int index_Prediction_BoundingBox_Y_2022 = Index("Prediction BoundingBox Y 2022");
            int index_Prediction_BoundingBox_Width_2022 = Index("Prediction BoundingBox Width 2022");
            int index_Prediction_BoundingBox_Height_2022 = Index("Prediction BoundingBox Height 2022");
            int index_Prediction_Confidence_2023 = Index("Prediction Confidence 2023");
            int index_Prediction_BoundingBox_X_2023 = Index("Prediction BoundingBox X 2023");
            int index_Prediction_BoundingBox_Y_2023 = Index("Prediction BoundingBox Y 2023");
            int index_Prediction_BoundingBox_Width_2023 = Index("Prediction BoundingBox Width 2023");
            int index_Prediction_BoundingBox_Height_2023 = Index("Prediction BoundingBox Height 2023");
            int index_Prediction_Confidence_2024 = Index("Prediction Confidence 2024");
            int index_Prediction_BoundingBox_X_2024 = Index("Prediction BoundingBox X 2024");
            int index_Prediction_BoundingBox_Y_2024 = Index("Prediction BoundingBox Y 2024");
            int index_Prediction_BoundingBox_Width_2024 = Index("Prediction BoundingBox Width 2024");
            int index_Prediction_BoundingBox_Height_2024 = Index("Prediction BoundingBox Height 2024");
            int index_Prediction_Confidence_2025 = Index("Prediction Confidence 2025");
            int index_Prediction_BoundingBox_X_2025 = Index("Prediction BoundingBox X 2025");
            int index_Prediction_BoundingBox_Y_2025 = Index("Prediction BoundingBox Y 2025");
            int index_Prediction_BoundingBox_Width_2025 = Index("Prediction BoundingBox Width 2025");
            int index_Prediction_BoundingBox_Height_2025 = Index("Prediction BoundingBox Height 2025");
            int index_Municipality_population_2008 = Index("Municipality population 2008");
            int index_Municipality_population_2009 = Index("Municipality population 2009");
            int index_Municipality_population_2010 = Index("Municipality population 2010");
            int index_Municipality_population_2011 = Index("Municipality population 2011");
            int index_Municipality_population_2012 = Index("Municipality population 2012");
            int index_Municipality_population_2013 = Index("Municipality population 2013");
            int index_Municipality_population_2014 = Index("Municipality population 2014");
            int index_Municipality_population_2015 = Index("Municipality population 2015");
            int index_Municipality_population_2016 = Index("Municipality population 2016");
            int index_Municipality_population_2017 = Index("Municipality population 2017");
            int index_Municipality_population_2018 = Index("Municipality population 2018");
            int index_Municipality_population_2019 = Index("Municipality population 2019");
            int index_Municipality_population_2020 = Index("Municipality population 2020");
            int index_Municipality_population_2021 = Index("Municipality population 2021");
            int index_Municipality_population_2022 = Index("Municipality population 2022");
            int index_Municipality_population_2023 = Index("Municipality population 2023");
            int index_Municipality_population_2024 = Index("Municipality population 2024");
            int index_Municipality_population_2025 = Index("Municipality population 2025");
            int index_Radial_Building_Coverage_Ratio_200m = Index("Radial Building Coverage Ratio 200m");
            int index_Radial_Floor_Area_Ratio_200m = Index("Radial Floor Area Ratio 200m");
            int index_Radial_Building_Coverage_Ratio_400m = Index("Radial Building Coverage Ratio 400m");
            int index_Radial_Floor_Area_Ratio_400m = Index("Radial Floor Area Ratio 400m");
            int index_Radial_Building_Coverage_Ratio_600m = Index("Radial Building Coverage Ratio 600m");
            int index_Radial_Floor_Area_Ratio_600m = Index("Radial Floor Area Ratio 600m");
            int index_Radial_Building_Coverage_Ratio_1000m = Index("Radial Building Coverage Ratio 1000m");
            int index_Radial_Floor_Area_Ratio_1000m = Index("Radial Floor Area Ratio 1000m");

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

                float Single(int index)
                {
                    return index < 0 ? 0F : row.GetValue(index, 0F);
                }

                string Text(int index)
                {
                    return index < 0 ? string.Empty : row.GetValue(index, string.Empty) ?? string.Empty;
                }

                bool Boolean(int index)
                {
                    return index >= 0 && row.GetValue(index, false);
                }

                OrtoBuildingDetectionModel.ModelInput modelInput = new()
                {
                    Floor_area = Single(index_Floor_area),
                    Total_area = Single(index_Total_area),
                    Storeys = Single(index_Storeys),
                    Azimuth = Single(index_Azimuth),
                    Cardinal_direction = Text(index_Cardinal_direction),
                    Internal_Point_X = Single(index_Internal_Point_X),
                    Internal_Point_Y = Single(index_Internal_Point_Y),
                    BoundingBox_X = Single(index_BoundingBox_X),
                    BoundingBox_Y = Single(index_BoundingBox_Y),
                    BoundingBox_width = Single(index_BoundingBox_width),
                    BoundingBox_height = Single(index_BoundingBox_height),
                    Isoperimetric_ratio = Single(index_Isoperimetric_ratio),
                    Rectangular_thinnes_ratio = Single(index_Rectangular_thinnes_ratio),
                    Square_thinness_ratio = Single(index_Square_thinness_ratio),
                    Thinness_ratio = Single(index_Thinness_ratio),
                    Convex_hull_thinness_ratio = Single(index_Convex_hull_thinness_ratio),
                    Calculated_Building_Shape = Text(index_Calculated_Building_Shape),
                    Building_general_function = Text(index_Building_general_function),
                    Building_specific_functions = Text(index_Building_specific_functions),
                    Building_Phase = Text(index_Building_Phase),
                    Is_residential = Boolean(index_Is_residential),
                    Is_occupied = Boolean(index_Is_occupied),
                    Voivodeship_name = Text(index_Voivodeship_name),
                    County_name = Text(index_County_name),
                    County_Id = Single(index_County_Id),
                    Municipality_name = Text(index_Municipality_name),
                    Subdivision_name = Text(index_Subdivision_name),
                    Subdivision_Id = Single(index_Subdivision_Id),
                    Settlement_type = Text(index_Settlement_type),
                    Subdivision_occupancy = Single(index_Subdivision_occupancy),
                    Calculated_occupancy = Single(index_Calculated_occupancy),
                    Grid_cell_coverage__0_0_ = Single(index_Grid_cell_coverage__0_0_),
                    Grid_cell_coverage__0_1_ = Single(index_Grid_cell_coverage__0_1_),
                    Grid_cell_coverage__0_2_ = Single(index_Grid_cell_coverage__0_2_),
                    Grid_cell_coverage__0_3_ = Single(index_Grid_cell_coverage__0_3_),
                    Grid_cell_coverage__0_4_ = Single(index_Grid_cell_coverage__0_4_),
                    Grid_cell_coverage__1_0_ = Single(index_Grid_cell_coverage__1_0_),
                    Grid_cell_coverage__1_1_ = Single(index_Grid_cell_coverage__1_1_),
                    Grid_cell_coverage__1_2_ = Single(index_Grid_cell_coverage__1_2_),
                    Grid_cell_coverage__1_3_ = Single(index_Grid_cell_coverage__1_3_),
                    Grid_cell_coverage__1_4_ = Single(index_Grid_cell_coverage__1_4_),
                    Grid_cell_coverage__2_0_ = Single(index_Grid_cell_coverage__2_0_),
                    Grid_cell_coverage__2_1_ = Single(index_Grid_cell_coverage__2_1_),
                    Grid_cell_coverage__2_2_ = Single(index_Grid_cell_coverage__2_2_),
                    Grid_cell_coverage__2_3_ = Single(index_Grid_cell_coverage__2_3_),
                    Grid_cell_coverage__2_4_ = Single(index_Grid_cell_coverage__2_4_),
                    Grid_cell_coverage__3_0_ = Single(index_Grid_cell_coverage__3_0_),
                    Grid_cell_coverage__3_1_ = Single(index_Grid_cell_coverage__3_1_),
                    Grid_cell_coverage__3_2_ = Single(index_Grid_cell_coverage__3_2_),
                    Grid_cell_coverage__3_3_ = Single(index_Grid_cell_coverage__3_3_),
                    Grid_cell_coverage__3_4_ = Single(index_Grid_cell_coverage__3_4_),
                    Grid_cell_coverage__4_0_ = Single(index_Grid_cell_coverage__4_0_),
                    Grid_cell_coverage__4_1_ = Single(index_Grid_cell_coverage__4_1_),
                    Grid_cell_coverage__4_2_ = Single(index_Grid_cell_coverage__4_2_),
                    Grid_cell_coverage__4_3_ = Single(index_Grid_cell_coverage__4_3_),
                    Grid_cell_coverage__4_4_ = Single(index_Grid_cell_coverage__4_4_),
                    Prediction_Confidence_2008 = Single(index_Prediction_Confidence_2008),
                    Prediction_BoundingBox_X_2008 = Single(index_Prediction_BoundingBox_X_2008),
                    Prediction_BoundingBox_Y_2008 = Single(index_Prediction_BoundingBox_Y_2008),
                    Prediction_BoundingBox_Width_2008 = Single(index_Prediction_BoundingBox_Width_2008),
                    Prediction_BoundingBox_Height_2008 = Single(index_Prediction_BoundingBox_Height_2008),
                    Prediction_Confidence_2009 = Single(index_Prediction_Confidence_2009),
                    Prediction_BoundingBox_X_2009 = Single(index_Prediction_BoundingBox_X_2009),
                    Prediction_BoundingBox_Y_2009 = Single(index_Prediction_BoundingBox_Y_2009),
                    Prediction_BoundingBox_Width_2009 = Single(index_Prediction_BoundingBox_Width_2009),
                    Prediction_BoundingBox_Height_2009 = Single(index_Prediction_BoundingBox_Height_2009),
                    Prediction_Confidence_2010 = Single(index_Prediction_Confidence_2010),
                    Prediction_BoundingBox_X_2010 = Single(index_Prediction_BoundingBox_X_2010),
                    Prediction_BoundingBox_Y_2010 = Single(index_Prediction_BoundingBox_Y_2010),
                    Prediction_BoundingBox_Width_2010 = Single(index_Prediction_BoundingBox_Width_2010),
                    Prediction_BoundingBox_Height_2010 = Single(index_Prediction_BoundingBox_Height_2010),
                    Prediction_Confidence_2011 = Single(index_Prediction_Confidence_2011),
                    Prediction_BoundingBox_X_2011 = Single(index_Prediction_BoundingBox_X_2011),
                    Prediction_BoundingBox_Y_2011 = Single(index_Prediction_BoundingBox_Y_2011),
                    Prediction_BoundingBox_Width_2011 = Single(index_Prediction_BoundingBox_Width_2011),
                    Prediction_BoundingBox_Height_2011 = Single(index_Prediction_BoundingBox_Height_2011),
                    Prediction_Confidence_2012 = Single(index_Prediction_Confidence_2012),
                    Prediction_BoundingBox_X_2012 = Single(index_Prediction_BoundingBox_X_2012),
                    Prediction_BoundingBox_Y_2012 = Single(index_Prediction_BoundingBox_Y_2012),
                    Prediction_BoundingBox_Width_2012 = Single(index_Prediction_BoundingBox_Width_2012),
                    Prediction_BoundingBox_Height_2012 = Single(index_Prediction_BoundingBox_Height_2012),
                    Prediction_Confidence_2013 = Single(index_Prediction_Confidence_2013),
                    Prediction_BoundingBox_X_2013 = Single(index_Prediction_BoundingBox_X_2013),
                    Prediction_BoundingBox_Y_2013 = Single(index_Prediction_BoundingBox_Y_2013),
                    Prediction_BoundingBox_Width_2013 = Single(index_Prediction_BoundingBox_Width_2013),
                    Prediction_BoundingBox_Height_2013 = Single(index_Prediction_BoundingBox_Height_2013),
                    Prediction_Confidence_2014 = Single(index_Prediction_Confidence_2014),
                    Prediction_BoundingBox_X_2014 = Single(index_Prediction_BoundingBox_X_2014),
                    Prediction_BoundingBox_Y_2014 = Single(index_Prediction_BoundingBox_Y_2014),
                    Prediction_BoundingBox_Width_2014 = Single(index_Prediction_BoundingBox_Width_2014),
                    Prediction_BoundingBox_Height_2014 = Single(index_Prediction_BoundingBox_Height_2014),
                    Prediction_Confidence_2015 = Single(index_Prediction_Confidence_2015),
                    Prediction_BoundingBox_X_2015 = Single(index_Prediction_BoundingBox_X_2015),
                    Prediction_BoundingBox_Y_2015 = Single(index_Prediction_BoundingBox_Y_2015),
                    Prediction_BoundingBox_Width_2015 = Single(index_Prediction_BoundingBox_Width_2015),
                    Prediction_BoundingBox_Height_2015 = Single(index_Prediction_BoundingBox_Height_2015),
                    Prediction_Confidence_2016 = Single(index_Prediction_Confidence_2016),
                    Prediction_BoundingBox_X_2016 = Single(index_Prediction_BoundingBox_X_2016),
                    Prediction_BoundingBox_Y_2016 = Single(index_Prediction_BoundingBox_Y_2016),
                    Prediction_BoundingBox_Width_2016 = Single(index_Prediction_BoundingBox_Width_2016),
                    Prediction_BoundingBox_Height_2016 = Single(index_Prediction_BoundingBox_Height_2016),
                    Prediction_Confidence_2017 = Single(index_Prediction_Confidence_2017),
                    Prediction_BoundingBox_X_2017 = Single(index_Prediction_BoundingBox_X_2017),
                    Prediction_BoundingBox_Y_2017 = Single(index_Prediction_BoundingBox_Y_2017),
                    Prediction_BoundingBox_Width_2017 = Single(index_Prediction_BoundingBox_Width_2017),
                    Prediction_BoundingBox_Height_2017 = Single(index_Prediction_BoundingBox_Height_2017),
                    Prediction_Confidence_2018 = Single(index_Prediction_Confidence_2018),
                    Prediction_BoundingBox_X_2018 = Single(index_Prediction_BoundingBox_X_2018),
                    Prediction_BoundingBox_Y_2018 = Single(index_Prediction_BoundingBox_Y_2018),
                    Prediction_BoundingBox_Width_2018 = Single(index_Prediction_BoundingBox_Width_2018),
                    Prediction_BoundingBox_Height_2018 = Single(index_Prediction_BoundingBox_Height_2018),
                    Prediction_Confidence_2019 = Single(index_Prediction_Confidence_2019),
                    Prediction_BoundingBox_X_2019 = Single(index_Prediction_BoundingBox_X_2019),
                    Prediction_BoundingBox_Y_2019 = Single(index_Prediction_BoundingBox_Y_2019),
                    Prediction_BoundingBox_Width_2019 = Single(index_Prediction_BoundingBox_Width_2019),
                    Prediction_BoundingBox_Height_2019 = Single(index_Prediction_BoundingBox_Height_2019),
                    Prediction_Confidence_2020 = Single(index_Prediction_Confidence_2020),
                    Prediction_BoundingBox_X_2020 = Single(index_Prediction_BoundingBox_X_2020),
                    Prediction_BoundingBox_Y_2020 = Single(index_Prediction_BoundingBox_Y_2020),
                    Prediction_BoundingBox_Width_2020 = Single(index_Prediction_BoundingBox_Width_2020),
                    Prediction_BoundingBox_Height_2020 = Single(index_Prediction_BoundingBox_Height_2020),
                    Prediction_Confidence_2021 = Single(index_Prediction_Confidence_2021),
                    Prediction_BoundingBox_X_2021 = Single(index_Prediction_BoundingBox_X_2021),
                    Prediction_BoundingBox_Y_2021 = Single(index_Prediction_BoundingBox_Y_2021),
                    Prediction_BoundingBox_Width_2021 = Single(index_Prediction_BoundingBox_Width_2021),
                    Prediction_BoundingBox_Height_2021 = Single(index_Prediction_BoundingBox_Height_2021),
                    Prediction_Confidence_2022 = Single(index_Prediction_Confidence_2022),
                    Prediction_BoundingBox_X_2022 = Single(index_Prediction_BoundingBox_X_2022),
                    Prediction_BoundingBox_Y_2022 = Single(index_Prediction_BoundingBox_Y_2022),
                    Prediction_BoundingBox_Width_2022 = Single(index_Prediction_BoundingBox_Width_2022),
                    Prediction_BoundingBox_Height_2022 = Single(index_Prediction_BoundingBox_Height_2022),
                    Prediction_Confidence_2023 = Single(index_Prediction_Confidence_2023),
                    Prediction_BoundingBox_X_2023 = Single(index_Prediction_BoundingBox_X_2023),
                    Prediction_BoundingBox_Y_2023 = Single(index_Prediction_BoundingBox_Y_2023),
                    Prediction_BoundingBox_Width_2023 = Single(index_Prediction_BoundingBox_Width_2023),
                    Prediction_BoundingBox_Height_2023 = Single(index_Prediction_BoundingBox_Height_2023),
                    Prediction_Confidence_2024 = Single(index_Prediction_Confidence_2024),
                    Prediction_BoundingBox_X_2024 = Single(index_Prediction_BoundingBox_X_2024),
                    Prediction_BoundingBox_Y_2024 = Single(index_Prediction_BoundingBox_Y_2024),
                    Prediction_BoundingBox_Width_2024 = Single(index_Prediction_BoundingBox_Width_2024),
                    Prediction_BoundingBox_Height_2024 = Single(index_Prediction_BoundingBox_Height_2024),
                    Prediction_Confidence_2025 = Single(index_Prediction_Confidence_2025),
                    Prediction_BoundingBox_X_2025 = Single(index_Prediction_BoundingBox_X_2025),
                    Prediction_BoundingBox_Y_2025 = Single(index_Prediction_BoundingBox_Y_2025),
                    Prediction_BoundingBox_Width_2025 = Single(index_Prediction_BoundingBox_Width_2025),
                    Prediction_BoundingBox_Height_2025 = Single(index_Prediction_BoundingBox_Height_2025),
                    Municipality_population_2008 = Single(index_Municipality_population_2008),
                    Municipality_population_2009 = Single(index_Municipality_population_2009),
                    Municipality_population_2010 = Single(index_Municipality_population_2010),
                    Municipality_population_2011 = Single(index_Municipality_population_2011),
                    Municipality_population_2012 = Single(index_Municipality_population_2012),
                    Municipality_population_2013 = Single(index_Municipality_population_2013),
                    Municipality_population_2014 = Single(index_Municipality_population_2014),
                    Municipality_population_2015 = Single(index_Municipality_population_2015),
                    Municipality_population_2016 = Single(index_Municipality_population_2016),
                    Municipality_population_2017 = Single(index_Municipality_population_2017),
                    Municipality_population_2018 = Single(index_Municipality_population_2018),
                    Municipality_population_2019 = Single(index_Municipality_population_2019),
                    Municipality_population_2020 = Single(index_Municipality_population_2020),
                    Municipality_population_2021 = Single(index_Municipality_population_2021),
                    Municipality_population_2022 = Single(index_Municipality_population_2022),
                    Municipality_population_2023 = Single(index_Municipality_population_2023),
                    Municipality_population_2024 = Single(index_Municipality_population_2024),
                    Municipality_population_2025 = Single(index_Municipality_population_2025),
                    Radial_Building_Coverage_Ratio_200m = Single(index_Radial_Building_Coverage_Ratio_200m),
                    Radial_Floor_Area_Ratio_200m = Single(index_Radial_Floor_Area_Ratio_200m),
                    Radial_Building_Coverage_Ratio_400m = Single(index_Radial_Building_Coverage_Ratio_400m),
                    Radial_Floor_Area_Ratio_400m = Single(index_Radial_Floor_Area_Ratio_400m),
                    Radial_Building_Coverage_Ratio_600m = Single(index_Radial_Building_Coverage_Ratio_600m),
                    Radial_Floor_Area_Ratio_600m = Single(index_Radial_Floor_Area_Ratio_600m),
                    Radial_Building_Coverage_Ratio_1000m = Single(index_Radial_Building_Coverage_Ratio_1000m),
                    Radial_Floor_Area_Ratio_1000m = Single(index_Radial_Floor_Area_Ratio_1000m),
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
