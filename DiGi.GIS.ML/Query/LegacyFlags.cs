using DiGi.Core.IO.Table.Classes;
using System.Collections.Generic;
using System.Globalization;

namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Reads the <c>Legacy</c> flag of each building from the <c>dataset_references.tsv</c> manifest written by the YOLO dataset builder (DiGi.GIS.YOLO.UI).
        /// <para>The columns are read by name: <c>Reference</c> and <c>Legacy</c>. The manifest is a file contract only - this library has no reference to DiGi.GIS.YOLO.UI. This method reads the flag, it does not re-derive it: the dataset builder decides which buildings <c>train8</c> saw.</para>
        /// <para>A manifest that lacks either column, or holds a <c>Legacy</c> value that is not a boolean, is refused with null rather than read as all-clean: a clean holdout that silently includes legacy buildings would report an inflated score as an unseen one.</para>
        /// </summary>
        /// <param name="table">The manifest table, or null.</param>
        /// <returns>The <c>Legacy</c> flag by reference, or null when the manifest is null, lacks a required column or holds an unreadable flag.</returns>
        public static Dictionary<string, bool>? LegacyFlags(this Table? table)
        {
            if (table is null)
            {
                return null;
            }

            int index_Reference = table.GetColumnIndex("Reference");
            int index_Legacy = table.GetColumnIndex("Legacy");
            if (index_Reference < 0 || index_Legacy < 0)
            {
                return null;
            }

            Dictionary<string, bool> result = [];
            for (int i = 0; i < table.RowCount; i++)
            {
                string? reference = table.GetValue<string>(i, index_Reference);
                if (string.IsNullOrWhiteSpace(reference))
                {
                    continue;
                }

                string? text = System.Convert.ToString(table.GetValue(i, index_Legacy), CultureInfo.InvariantCulture)?.Trim();
                if (!bool.TryParse(text, out bool legacy))
                {
                    return null;
                }

                result[reference!] = legacy;
            }

            return result;
        }
    }
}
