using DiGi.Core;
using DiGi.Core.IO.Table.Classes;

namespace DiGi.GIS.ML.Constants
{
    /// <summary>
    /// Provides the columns that exist only in the Year Built prediction training table.
    /// </summary>
    public static class Column
    {
        /// <summary>
        /// The construction year the model is trained against.
        /// <para>The label's source is the stored <c>User year built</c> column of <c>building_data</c> - <c>DiGi.GIS.IO.Constants.Column.UserYearBuilt</c> - not the <c>year_built_data</c> table the label used to come from. This training-table column stays deliberately out of that catalogue: it is a training-table column, not a <c>building_data</c> column, and keeping it out of <c>DiGi.GIS.IO.Constants.Column</c> keeps it out of <c>gis/buildingdata/columns</c>, the typology pickers and every feature projection.</para>
        /// <para>The name and the <c>short</c> type match the label the incumbent model was trained against, so the regenerated <c>.mbconfig</c> keeps one <c>LabelColumn</c> across the retrain.</para>
        /// </summary>
        public static ExtendedColumn YearBuilt = new("Year built", typeof(short), GIS.IO.Enums.Category.YearBuit.Description(), "Construction year the Year Built prediction model is trained against, sourced from the User year built column of building_data");
    }
}
