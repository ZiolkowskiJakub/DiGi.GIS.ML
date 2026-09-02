using DiGi.Core.Classes;
using System;
using System.IO;
using System.Reflection;

namespace DiGi.GIS.ML.ConsoleApp
{
    public static partial class Query
    {
        /// <summary>
        /// Reads the WebAPI authorization key from the deployed client configuration file.
        /// <para>Only the output root is probed. <c>CopyUserFiles</c> runs after <c>CopyFiles</c> and both flatten into it, so the git-ignored <c>user files</c> copy overwrites the committed default of the same name; a <c>bin\user files</c> folder is never produced, and probing for one would read as a working fallback while finding nothing.</para>
        /// </summary>
        /// <param name="path">Optional explicit path to the configuration file. Resolved against the output root when omitted.</param>
        /// <returns>The key if one is configured; otherwise null.</returns>
        public static string? Key(string? path = null)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                string? directory = null;
                try
                {
                    string? location = Assembly.GetExecutingAssembly().Location;
                    if (!string.IsNullOrWhiteSpace(location))
                    {
                        directory = System.IO.Path.GetDirectoryName(location);
                    }
                }
                catch
                {
                    // A single file application reports no location; the base directory answers for it.
                }

                if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
                {
                    directory = AppDomain.CurrentDomain.BaseDirectory;
                }

                if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
                {
                    return null;
                }

                path = System.IO.Path.Combine(directory, Constants.FileName.GISWebAPIClientConfigurationFile);
            }

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            ConfigurationFile? configurationFile = Core.Create.ConfigurationFile(path);
            if (configurationFile is null)
            {
                return null;
            }

            if (configurationFile.Dictionary.TryGetValue("Key", out string? key) && !string.IsNullOrWhiteSpace(key))
            {
                return key.Trim('"', ' ', '\t');
            }

            return null;
        }
    }
}
