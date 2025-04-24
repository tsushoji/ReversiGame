using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ReversiGameFunctionApp.Domain;
using ReversiGameFunctionApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ReversiGameFunctionApp.Triggers
{
    internal class ReturnStoneTrigger
    {
        private readonly ILogger<ReturnStoneTrigger> _logger;

        /// <summary>
        /// New
        /// </summary>
        /// <param name="logger"></param>
        public ReturnStoneTrigger(ILogger<ReturnStoneTrigger> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 実行処理
        /// </summary>
        /// <param name="req">リクエスト</param>
        /// <returns>レスポンス</returns>
        [FunctionName("ReturnStoneOpenAPIFunction")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<StoneModel>), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.InternalServerError, contentType: "application/json", bodyType: typeof(string), Description = "Internal Server Error")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            try
            {
                _logger.LogInformation("C# HTTP trigger function processed a request.");

                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                // 200を返す
                return new OkObjectResult(new ReturnStoneMain(requestBody).DoProcess());
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                // サーバーエラー500を返す
                return new ObjectResult("Internal Server Error")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
