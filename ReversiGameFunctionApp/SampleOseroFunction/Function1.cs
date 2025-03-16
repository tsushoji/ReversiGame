using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SampleOseroFunction
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req">http request</param>
        /// <returns>http response</returns>
        [Function("Function1")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            try
            {
                _logger.LogInformation("C# HTTP trigger function processed a request.");

                // リクエスト(JSON)を読む
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                // JSON をデシリアライズする
                var arg = JsonSerializer.Deserialize<InParam>(requestBody);

                // リクエストで取得した盤面を展開する
                var gameBoard = new OseroGameBoard(arg.board);

                // リクエストで指定された場所に石を置く
                var isTurned = gameBoard.PutStone(arg.setBoard.row, arg.setBoard.col, arg.setBoard.status);

                // 結果をセットする
                var turnedBoard = new OutParam()
                {
                    isTurned = isTurned,
                    board = gameBoard.GetBoard() 
                };

                // レスポンスを戻す
                var result = JsonSerializer.Serialize<OutParam>(turnedBoard, new JsonSerializerOptions { WriteIndented = true });
                return new ObjectResult(result)
                {
                    // 200を返す
                    StatusCode = StatusCodes.Status200OK
                };

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
