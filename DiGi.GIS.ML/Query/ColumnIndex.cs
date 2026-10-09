using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;

namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Finds the index of a column in a table by its stored column slug first and by its display name second.
        /// <para>The slug is the identifier the database and the WebAPI address a column by, so a table read through the API binds whatever its display names are; the display name is the fallback for a table that came from a file. This is the resolution the deployed scoring path has always used.</para>
        /// </summary>
        /// <param name="table">The table to search, or null.</param>
        /// <param name="column">The column to find, or null.</param>
        /// <returns>The index of the column, or -1 when the table or the column is null or the table does not carry it.</returns>
        public static int ColumnIndex(this Table? table, Column? column)
        {
            if (table is null || column is null || table.ColumnCount == 0)
            {
                return -1;
            }

            List<Column> columns = [.. table.Columns];

            if (Core.IO.Query.UniqueId(column) is string slug && !string.IsNullOrWhiteSpace(slug))
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    if (columns[i] is Column column_Table && Core.IO.Query.UniqueId(column_Table) == slug)
                    {
                        return i;
                    }
                }
            }

            if (column.Name is string name && !string.IsNullOrWhiteSpace(name))
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    if (columns[i] is Column column_Table && column_Table.Name == name)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
