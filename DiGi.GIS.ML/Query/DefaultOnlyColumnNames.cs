using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Names the columns of a table that carry the same value in every row.
        /// <para>Written as the acceptance check on an assembled training table. A feature column that never varies teaches the regressor nothing, and on this pipeline it has a specific and expensive cause: the detection and population columns are created by runs rather than by code, so a table assembled before those runs is a full looking file in which 108 of 172 features are the default. LightGbm fits it without complaining and the resulting metrics look ordinary.</para>
        /// <para>A hit is not automatically a defect - a single county genuinely shares one <c>County name</c>, and a rarely populated feature can be constant on a small sample. It is a list to explain, not a list to fail on blindly.</para>
        /// </summary>
        /// <param name="table">The table to inspect.</param>
        /// <returns>The names of the columns that never vary, in column order. Empty when every column varies, or when the table has fewer than two rows to compare.</returns>
        public static List<string> DefaultOnlyColumnNames(this Table? table)
        {
            List<string> result = [];

            if (table is null || table.ColumnCount == 0 || table.RowCount < 2)
            {
                return result;
            }

            for (int i = 0; i < table.ColumnCount; i++)
            {
                object? value_First = table.GetValue(0, i);
                bool constant = true;

                for (int j = 1; j < table.RowCount; j++)
                {
                    object? value = table.GetValue(j, i);

                    if (value is null != value_First is null || (value is not null && !value.Equals(value_First)))
                    {
                        constant = false;
                        break;
                    }
                }

                if (constant && table.GetColumn(i)?.Name is string name && !string.IsNullOrWhiteSpace(name))
                {
                    result.Add(name);
                }
            }

            return result;
        }
    }
}
