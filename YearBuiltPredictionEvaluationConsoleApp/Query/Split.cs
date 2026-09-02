using System;
using System.Collections.Generic;
using System.Text;

namespace DiGi.GIS.ML.EvaluationConsoleApp
{
    public static partial class Query
    {
        /// <summary>
        /// Decides which rows form the holdout, by hashing a key rather than by shuffling.
        /// <para>A seeded shuffle is only reproducible inside one runtime: the same seed gives different orders in .NET and in Python, and the framework is free to change its generator between versions. Hashing the key makes membership a property of the row, so the same holdout comes back on any machine, in any language, in any order, and two runs months apart stay comparable.</para>
        /// <para>The hash is FNV-1a over the UTF-8 bytes, written out here rather than taken from <c>string.GetHashCode</c>, which is randomised per process and would put the same building in a different half on every run.</para>
        /// <para>Pass the building reference to hold out roughly one row in five. Pass the subdivision identifier to hold out whole subdivisions instead, so no subdivision spans training and holdout - that is the control for a model memorising neighbourhoods rather than reading the imagery.</para>
        /// </summary>
        /// <param name="keys">The key of each row, in row order.</param>
        /// <param name="denominator">One row in this many joins the holdout. 5 gives a 20 percent holdout.</param>
        /// <returns>True for each row that belongs to the holdout, in row order.</returns>
        public static List<bool> Split(IEnumerable<string?>? keys, int denominator = 5)
        {
            List<bool> result = [];

            if (keys is null)
            {
                return result;
            }

            int denominator_Temp = denominator < 2 ? 2 : denominator;

            foreach (string? key in keys)
            {
                if (string.IsNullOrEmpty(key))
                {
                    result.Add(false);
                    continue;
                }

                uint hash = 2166136261;
                foreach (byte value in Encoding.UTF8.GetBytes(key!))
                {
                    hash ^= value;
                    hash *= 16777619;
                }

                result.Add(hash % (uint)denominator_Temp == 0);
            }

            return result;
        }
    }
}
