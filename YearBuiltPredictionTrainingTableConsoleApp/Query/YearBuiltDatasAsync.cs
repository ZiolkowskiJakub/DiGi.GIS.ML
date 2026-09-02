using DiGi.GIS.Classes;
using DiGi.GIS.WebAPI.Classes;
using DiGi.WebAPI.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.ML.ConsoleApp
{
    public static partial class Query
    {
        /// <summary>
        /// Reads every stored year built datum of a county, in pages.
        /// <para>Both endpoints landed on 2026-09-02 (DiGi.GIS.WebAPI#21). Before them the table answered one reference at a time, which made reading a county of labels tens of thousands of round trips and made national label coverage unmeasurable.</para>
        /// <para>The references come first because there is no way to know which buildings carry a stored year without asking, and asking building by building is the thing the bulk read exists to replace.</para>
        /// </summary>
        /// <param name="gisWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to communicate with the WebAPI.</param>
        /// <param name="countyId">The identifier of the county to read. A county identifier, never a four character county code.</param>
        /// <param name="referenceBatchSize">References per request, capped by the endpoint at 10000.</param>
        /// <param name="postOptions">Optional configuration options for the requests.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>A task returning the stored year built data, or null when the county could not be read. Null and an empty list mean different things: the first is a failed read, the second a county with no stored years.</returns>
        public static async Task<List<YearBuiltData>?> YearBuiltDatasAsync(this GISWebAPIManager? gisWebAPIManager, int countyId, int referenceBatchSize = 10000, PostOptions? postOptions = null, CancellationToken cancellationToken = default)
        {
            if (gisWebAPIManager is null || countyId <= 0)
            {
                return null;
            }

            PostOptions postOptions_Temp = postOptions ?? new PostOptions() { RequestResult = true, Delay = TimeSpan.FromSeconds(60) };

            HttpClient? httpClient_References = gisWebAPIManager.CreateHttpClient<YearBuiltDataController>(nameof(YearBuiltDataController.GetReferencesByCountyIdAsync), out string? path_References);
            if (httpClient_References is null || string.IsNullOrWhiteSpace(path_References))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "HttpClient or path for {Method} could not be resolved", nameof(YearBuiltDataController.GetReferencesByCountyIdAsync));
                return null;
            }

            List<string>? references;
            try
            {
                string requestUri = new UrlBuilder(path_References).AddParameter("countyid", countyId).ToString();
                PostResponse<List<string>?> postResponse = await DiGi.WebAPI.Query.GetAsync<List<string>>(httpClient_References, requestUri, postOptions_Temp);
                references = postResponse is not null && postResponse.Succeeded ? postResponse.Result : null;
            }
            catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
            {
                Serilog.Modify.Log(exception, "The year built references could not be read for county {CountyId}", countyId);
                return null;
            }

            List<YearBuiltData> result = [];
            if (references is null || references.Count == 0)
            {
                return result;
            }

            HttpClient? httpClient_Items = gisWebAPIManager.CreateHttpClient<YearBuiltDataController>(nameof(YearBuiltDataController.GetItemsByReferencesAsync), out string? path_Items);
            if (httpClient_Items is null || string.IsNullOrWhiteSpace(path_Items))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "HttpClient or path for {Method} could not be resolved", nameof(YearBuiltDataController.GetItemsByReferencesAsync));
                return null;
            }

            int batchSize = referenceBatchSize < 1 ? 1 : Math.Min(referenceBatchSize, Constants.Count.Reference_Maximum);

            for (int i = 0; i < references.Count; i += batchSize)
            {
                cancellationToken.ThrowIfCancellationRequested();

                JsonArray jsonArray = [];
                for (int j = i; j < Math.Min(i + batchSize, references.Count); j++)
                {
                    if (!string.IsNullOrWhiteSpace(references[j]))
                    {
                        jsonArray.Add(references[j]);
                    }
                }

                if (jsonArray.Count == 0)
                {
                    continue;
                }

                HttpContent? httpContent = await GIS.WebAPI.Create.HttpContent(jsonArray.ToJsonString(), cancellationToken);
                if (httpContent is null)
                {
                    return null;
                }

                string? json;
                try
                {
                    string requestUri = new UrlBuilder(path_Items).AddParameter("countyid", countyId).ToString();
                    PostResponse<string?> postResponse = await DiGi.WebAPI.Modify.PostAsync<string>(httpClient_Items, requestUri, httpContent, postOptions_Temp);
                    json = postResponse is not null && postResponse.Succeeded ? postResponse.Result : null;
                }
                catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
                {
                    Serilog.Modify.Log(exception, "The year built data could not be read for county {CountyId} over {Count} references", countyId, jsonArray.Count);
                    return null;
                }

                if (string.IsNullOrWhiteSpace(json))
                {
                    continue;
                }

                if (Core.Convert.ToDiGi<YearBuiltData>(json!) is List<YearBuiltData> yearBuiltDatas)
                {
                    result.AddRange(yearBuiltDatas);
                }
            }

            return result;
        }
    }
}
