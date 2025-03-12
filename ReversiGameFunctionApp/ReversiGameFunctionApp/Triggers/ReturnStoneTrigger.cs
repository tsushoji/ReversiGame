using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ReversiGameFunctionApp.Behaviours;
using ReversiGameFunctionApp.Models;

namespace ReversiGameFunctionApp.Triggers
{
    public class ReturnStoneTrigger
    {
        private readonly ILogger<ReturnStoneTrigger> _logger;

        public ReturnStoneTrigger(ILogger<ReturnStoneTrigger> logger)
        {
            _logger = logger;
        }

        [Function("ReturnStoneFunction")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            var turnedBoardJson = string.Empty;

            try
            {
                _logger.LogInformation("C# HTTP trigger function processed a request.");

                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                var jsonObject = JObject.Parse(requestBody);

                var preBoardJsonArray = (JArray)jsonObject["board"];
                var setBoardJson = JObject.Parse(jsonObject["setBoard"].ToString());

                var boardList = new FromJsonToModelConverter().ConvertToBoardModelList(preBoardJsonArray);
                var setBoard = new FromJsonToModelConverter().ConvertToBoardModel(setBoardJson);

                // TODO: ひっくり返す処理追加
                //var turnedBoard = new List<BoardModel>();
                //turnedBoard.Add(new BoardModel
                //{
                //    Row = 1,
                //    Col = 1,
                //    Status = 0,
                //});

                //turnedBoard.Add(new BoardModel
                //{
                //    Row = 1,
                //    Col = 2,
                //    Status = 1,
                //});

                var gameBoard = new ReversiGameBoard(boardList);
                var result = gameBoard.PutStone(setBoard.Row, setBoard.Col, setBoard.Status);
                var turnedBoard = gameBoard.GetBoard();

                turnedBoardJson = new FromModelToJsonConverter().Convert<BoardModel>(turnedBoard);
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

            // 200を返す
            return new OkObjectResult(turnedBoardJson);
        }
    }
}
