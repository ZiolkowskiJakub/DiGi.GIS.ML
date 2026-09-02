using DiGi.Core.IO.Table.Classes;
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
        /// Reads the stored building data of the named references as a table, projected to the named columns.
        /// <para>The projection is an allow-list rather than a filter, and it is the same allow-list the inference pipeline projects through - <c>DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns</c>. Asking for every column instead would hand the trainer the pipeline&apos;s own output column back as a feature, which reads as a large accuracy gain rather than as a defect.</para>
        /// <para>Deliberately mirrors <c>DiGi.GIS.YOLO.UI.Query.BuildingDataTableAsync</c> rather than referencing it: that assembly targets <c>net10.0-windows7.0</c> and carries the image export, and a training table assembler has no business loading <c>System.Drawing</c>. The contract the two must agree on is the column list, and that is shared rather than copied.</para>
        /// </summary>
        /// <param name="gisWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to communicate with the WebAPI.</param>
        /// <param name="countyId">The identifier of the county row the references belong to.</param>
        /// <param name="references">The building references to read, at most the endpoint&apos;s cap.</param>
        /// <param name="columnUniqueIds">The unique identifiers of the columns to project. Null or empty asks for every column, which this never wants.</param>
        /// <param name="postOptions">Optional configuration options for the request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>A task returning the projected table, or null when it could not be read.</returns>
        public static async Task<Table?> BuildingDataTableAsync(this GISWebAPIManager? gisWebAPIManager, int countyId, IEnumerable<string>? references, IEnumerable<string>? columnUniqueIds, PostOptions? postOptions = null, CancellationToken cancellationToken = default)
        {
            if (gisWebAPIManager is null || references is null)
            {
                return null;
            }

            JsonArray jsonArray_References = [];
            foreach (string reference in references)
            {
                if (!string.IsNullOrWhiteSpace(reference))
                {
                    jsonArray_References.Add(reference);
                }
            }

            if (jsonArray_References.Count == 0)
            {
                return null;
            }

            JsonArray jsonArray_ColumnUniqueIds = [];
            if (columnUniqueIds is not null)
            {
                foreach (string columnUniqueId in columnUniqueIds)
                {
                    if (!string.IsNullOrWhiteSpace(columnUniqueId))
                    {
                        jsonArray_ColumnUniqueIds.Add(columnUniqueId);
                    }
                }
            }

            HttpClient? httpClient = gisWebAPIManager.CreateHttpClient<BuildingDataController>(nameof(BuildingDataController.GetTableByBuildingDataByReferencesParameterAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "HttpClient or path for {Method} could not be resolved", nameof(BuildingDataController.GetTableByBuildingDataByReferencesParameterAsync));
                return null;
            }

            // Built member by member from the parameter type rather than serialized from an instance of it, so a
            // member renamed on the server side stops compiling here instead of quietly binding to nothing.
            JsonObject jsonObject = new()
            {
                [nameof(BuildingDataByReferencesParameter.ColumnUniqueIds)] = jsonArray_ColumnUniqueIds,
                [nameof(BuildingDataByReferencesParameter.CountyId)] = countyId,
                [nameof(BuildingDataByReferencesParameter.References)] = jsonArray_References
            };

            HttpContent? httpContent = await GIS.WebAPI.Create.HttpContent(jsonObject.ToJsonString(), cancellationToken);
            if (httpContent is null)
            {
                return null;
            }

            string? json;
            try
            {
                PostResponse<string?> postResponse = await DiGi.WebAPI.Modify.PostAsync<string>(httpClient, path, httpContent, postOptions ?? new PostOptions() { RequestResult = true, Delay = TimeSpan.FromSeconds(60) });

                json = postResponse is not null && postResponse.Succeeded ? postResponse.Result : null;
            }
            catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
            {
                Serilog.Modify.Log(exception, "The building data table could not be read for county {CountyId} over {Count} references", countyId, jsonArray_References.Count);
                return null;
            }

            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }

            return GIS.WebAPI.Create.Table(JsonNode.Parse(json!) as JsonObject);
        }
    }
}
