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
        /// ���s����
        /// </summary>
        /// <param name="req">���N�G�X�g</param>
        /// <returns>���X�|���X</returns>
        [Function("ReturnStoneFunction")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            var turnedBoardJson = string.Empty;

            try
            {
                _logger.LogInformation("C# HTTP trigger function processed a request.");

                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                turnedBoardJson = new ReturnStoneMain(requestBody).DoProcess();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                // �T�[�o�[�G���[500��Ԃ�
                return new ObjectResult("Internal Server Error")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            // 200��Ԃ�
            return new OkObjectResult(turnedBoardJson);
        }
    }
}
