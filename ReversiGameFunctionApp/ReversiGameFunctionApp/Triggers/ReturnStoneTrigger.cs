using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ReversiGameFunctionApp.Domain;

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
        [Function("ReturnStoneFunction")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
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
