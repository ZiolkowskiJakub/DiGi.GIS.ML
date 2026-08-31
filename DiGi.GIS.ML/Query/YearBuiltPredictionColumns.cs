using DiGi.Core.Classes;
using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Retrieves the list of columns permitted as input features for the Year Built prediction machine learning model across the specified range of years.
        /// </summary>
        /// <param name="years">The range of years for detection and temporal features. Defaults to 2008..2025 when null.</param>
        /// <returns>A list of <see cref="Column"/> instances representing the allowed input features.</returns>
        public static List<Column> YearBuiltPredictionColumns(Range<int>? years = null)
        {
            Range<int> range_Years = years ?? new Range<int>(2008, 2025);

            List<Column> columns =
            [
                GIS.IO.Constants.Column.FloorArea,
                GIS.IO.Constants.Column.TotalArea,
                GIS.IO.Constants.Column.Storeys,
                GIS.IO.Constants.Column.Azimuth,
                GIS.IO.Constants.Column.CardinalDirection,
                GIS.IO.Constants.Column.InternalPointX,
                GIS.IO.Constants.Column.InternalPointY,
                GIS.IO.Constants.Column.BoundingBoxX,
                GIS.IO.Constants.Column.BoundingBoxY,
                GIS.IO.Constants.Column.BoundingBoxWidth,
                GIS.IO.Constants.Column.BoundingBoxHeight,
                GIS.IO.Constants.Column.IsoperimetricRatio,
                GIS.IO.Constants.Column.RectangularThinnessRatio,
                GIS.IO.Constants.Column.SquareThinnessRatio,
                GIS.IO.Constants.Column.ThinnessRatio,
                GIS.IO.Constants.Column.ConvexHullThinnessRatio,
                GIS.IO.Constants.Column.CalculatedBuildingShape,
                GIS.IO.Constants.Column.BuildingGeneralFunction,
                GIS.IO.Constants.Column.BuildingSpecificFunctions,
                GIS.IO.Constants.Column.BuildingPhase,
                GIS.IO.Constants.Column.IsResidential,
                GIS.IO.Constants.Column.IsOccupied,
                GIS.IO.Constants.Column.VoivodeshipName,
                GIS.IO.Constants.Column.CountyName,
                GIS.IO.Constants.Column.CountyId,
                GIS.IO.Constants.Column.MunicipalityName,
                GIS.IO.Constants.Column.SubdivisionName,
                GIS.IO.Constants.Column.SubdivisionId,
                GIS.IO.Constants.Column.SettlementType,
                GIS.IO.Constants.Column.SubdivisionOccupancy,
                GIS.IO.Constants.Column.CalculatedOccupancy
            ];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    columns.Add(GIS.IO.Create.Column_GridCellCoverage(i, j));
                }
            }

            columns.AddRange(GIS.IO.Create.Columns_YearBuilt(range_Years));

            return columns;
        }
    }
}
