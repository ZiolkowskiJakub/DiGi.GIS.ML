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
        /// <para>This column is deliberately not declared in <c>DiGi.GIS.IO.Constants.Column</c>. Every column there is a stored <c>building_data</c> column, and this one is not: the label lives in the <c>year_built_data</c> table and reaches the training table only because the assembly puts it there. Declaring it beside the stored columns would invite someone to write it into <c>building_data</c>, which is the shape the leakage guards exist to prevent.</para>
        /// <para>The name matches the label the incumbent model was trained against, so the regenerated <c>.mbconfig</c> keeps one <c>LabelColumn</c> across the retrain.</para>
        /// </summary>
        public static ExtendedColumn YearBuilt = new("Year built", typeof(short), GIS.IO.Enums.Category.YearBuit.Description(), "Construction year the Year Built prediction model is trained against, sourced from a non-prediction entry of the stored year built data");
    }
}
