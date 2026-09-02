using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace DiGi.GIS.ML.EvaluationConsoleApp
{
    public static partial class Query
    {
        /// <summary>
        /// Scores every row of a delimited training table with a saved ML.NET model.
        /// <para>The loader is built from the model&apos;s own input schema rather than from a generated <c>ModelInput</c> class, so any model trained on this table can be scored without compiling its generated code alongside. A column the model wants and the file does not have is loaded as a default, which is what the inference path does too.</para>
        /// </summary>
        /// <param name="path_Model">The saved model.</param>
        /// <param name="path_Table">The tab separated training table, with a header row.</param>
        /// <param name="names_String">Columns the model reads as text. The saved input schema cannot be trusted for this - it reports a categorical column as Single while the transform chain that follows maps it as String, and the mismatch surfaces only when the chain runs.</param>
        /// <param name="names_Boolean">Columns the model reads as a boolean.</param>
        /// <param name="scoreColumnName">The output column carrying the prediction. ML.NET regression names it Score.</param>
        /// <returns>The predicted value of each row, in file order, or null when the model or the table could not be read.</returns>
        public static List<double?>? Scores(string? path_Model, string? path_Table, IEnumerable<string>? names_String = null, IEnumerable<string>? names_Boolean = null, string scoreColumnName = "Score")
        {
            if (string.IsNullOrWhiteSpace(path_Model) || !File.Exists(path_Model) || string.IsNullOrWhiteSpace(path_Table) || !File.Exists(path_Table))
            {
                return null;
            }

            MLContext mLContext = new();

            ITransformer transformer = mLContext.Model.Load(path_Model!, out DataViewSchema dataViewSchema_Input);

            // Read through a using rather than a bare enumerator: the loader opens the same file again
            // below, and an undisposed lazy reader holds the handle until it is collected.
            string[] names_Header = [];
            using (IEnumerator<string> enumerator = File.ReadLines(path_Table!).GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    names_Header = enumerator.Current.Split('\t');
                }
            }

            if (names_Header.Length == 0)
            {
                return null;
            }

            HashSet<string> set_String = names_String is null ? [] : [.. names_String];
            HashSet<string> set_Boolean = names_Boolean is null ? [] : [.. names_Boolean];

            Dictionary<string, int> indexes = [];
            for (int i = 0; i < names_Header.Length; i++)
            {
                indexes[names_Header[i]] = i;
            }

            List<TextLoader.Column> columns = [];
            foreach (DataViewSchema.Column column in dataViewSchema_Input)
            {
                if (!indexes.TryGetValue(column.Name, out int index))
                {
                    continue;
                }

                DataKind dataKind = set_String.Contains(column.Name) ? DataKind.String
                    : set_Boolean.Contains(column.Name) ? DataKind.Boolean
                    : column.Type.RawType == typeof(string) ? DataKind.String
                    : column.Type.RawType == typeof(bool) ? DataKind.Boolean
                    : DataKind.Single;

                columns.Add(new TextLoader.Column(column.Name, dataKind, index));
            }

            if (columns.Count == 0)
            {
                return null;
            }

            TextLoader textLoader = mLContext.Data.CreateTextLoader(new TextLoader.Options
            {
                Columns = [.. columns],
                Separators = ['\t'],
                HasHeader = true,
                AllowQuoting = false,
                TrimWhitespace = true,
            });

            IDataView dataView = transformer.Transform(textLoader.Load(path_Table!));

            List<double?> result = [];
            foreach (float score in dataView.GetColumn<float>(scoreColumnName))
            {
                result.Add(float.IsNaN(score) || float.IsInfinity(score) ? null : score);
            }

            return result;
        }
    }
}
