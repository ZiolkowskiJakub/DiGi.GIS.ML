using System.Collections.Generic;

namespace DiGi.GIS.ML
{
    public static partial class Query
    {
        /// <summary>
        /// Narrows a holdout to the buildings the detector's previous training cannot have seen.
        /// <para>A row is clean when it is in the holdout and its reference is in the manifest with <c>Legacy = false</c>. A reference absent from the manifest is unknown, not clean, and is left out.</para>
        /// </summary>
        /// <param name="references">The building reference of each row, in row order.</param>
        /// <param name="holdouts">True for each row in the holdout, in row order, as returned by <c>DiGi.GIS.IO.Query.Holdouts</c>.</param>
        /// <param name="legacyFlags">The <c>Legacy</c> flag by reference, as returned by <see cref="LegacyFlags(DiGi.Core.IO.Table.Classes.Table?)"/>.</param>
        /// <returns>True for each clean holdout row, in row order. Empty when any argument is null.</returns>
        public static List<bool> CleanHoldouts(this IEnumerable<string?>? references, IEnumerable<bool>? holdouts, Dictionary<string, bool>? legacyFlags)
        {
            List<bool> result = [];
            if (references is null || holdouts is null || legacyFlags is null)
            {
                return result;
            }

            using IEnumerator<bool> enumerator = holdouts.GetEnumerator();
            foreach (string? reference in references)
            {
                bool holdout = enumerator.MoveNext() && enumerator.Current;
                result.Add(holdout && reference is not null && legacyFlags.TryGetValue(reference, out bool legacy) && !legacy);
            }

            return result;
        }
    }
}
