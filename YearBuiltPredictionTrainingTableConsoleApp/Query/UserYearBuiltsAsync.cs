using DiGi.GIS.WebAPI.Classes;
using DiGi.WebAPI.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.ML.ConsoleApp
{
    public static partial class Query
    {
        /// <summary>
        /// Reads the year built labels of the named county in one request, projected on the server.
        /// <para>The endpoint answers the finished label dictionary - reference to year - and the full year history of a record never crosses the connection. That is the whole point over the incumbent path, which ships the entire stored history of every record of the county for the sake of one <c>short</c> per labelled building.</para>
        /// <para>The label selection is the server&apos;s and is the one <c>DiGi.GIS.ML.Query.YearBuiltLabels</c> makes on the same object: the user entry where the deserialized object holds one, otherwise its first non-prediction entry - the object's entries being a dictionary keyed by source, of which the last entry in stored order per source is what it answers - and the oldest labelled row of a multi-row reference. Keeping the selection in one place - the SQL - is what lets <c>YearBuiltLabels</c> stay the parity oracle instead of a second implementation of the same rule.</para>
        /// <para>Null means the read failed, and that includes the endpoint not being on the build the host runs: the deployed host lags the repository, so until it carries <c>useryearbuiltbycountyid</c> every call answers 404 and this returns null, which the caller reads as "use the incumbent path". An empty dictionary is a county that holds no label, which the caller skips.</para>
        /// </summary>
        /// <param name="gisWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to communicate with the WebAPI.</param>
        /// <param name="countyId">The identifier of the county row to read. A county identifier, never a four character county code.</param>
        /// <param name="postOptions">Optional configuration options for the request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>A task returning the year of each labelled reference held, empty when the county holds no label, or null when the county could not be read.</returns>
        public static async Task<Dictionary<string, short>?> UserYearBuiltsAsync(this GISWebAPIManager? gisWebAPIManager, int countyId, PostOptions? postOptions = null, CancellationToken cancellationToken = default)
        {
            if (gisWebAPIManager is null || countyId <= 0)
            {
                return null;
            }

            HttpClient? httpClient = gisWebAPIManager.CreateHttpClient<YearBuiltDataController>(nameof(YearBuiltDataController.GetUserYearBuiltsByCountyIdAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "HttpClient or path for {Method} could not be resolved", nameof(YearBuiltDataController.GetUserYearBuiltsByCountyIdAsync));
                return null;
            }

            string? json;
            try
            {
                string requestUri = new UrlBuilder(path).AddParameter("countyid", countyId).ToString();
                PostResponse<string?> postResponse = await DiGi.WebAPI.Query.GetAsync<string>(httpClient, requestUri, postOptions ?? new PostOptions() { RequestResult = true, Delay = TimeSpan.FromSeconds(60) });
                json = postResponse is not null && postResponse.Succeeded ? postResponse.Result : null;
            }
            catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
            {
                // This catch also reads the 404 of a host that does not run the endpoint yet: the caller
                // answers the incumbent path then, and the run is no different from the one before.
                Serilog.Modify.Log(exception, "The year built labels could not be read for county {CountyId}", countyId);
                return null;
            }

            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }

            // The endpoint answers an object of reference to year. Parsed by hand rather than through the
            // generic conversion, because the answer is a dictionary and nothing in the object model declares
            // one: a type the serializer would have to invent for the wire.
            if (JsonNode.Parse(json!) is not JsonObject jsonObject)
            {
                return null;
            }

            Dictionary<string, short> result = [];
            foreach (KeyValuePair<string, JsonNode?> keyValuePair in jsonObject)
            {
                if (keyValuePair.Value is not null && short.TryParse(keyValuePair.Value.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out short year))
                {
                    result[keyValuePair.Key] = year;
                }
            }

            return result;
        }
    }
}
