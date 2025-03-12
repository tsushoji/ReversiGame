using Newtonsoft.Json.Linq;
using ReversiGameFunctionApp.Domain.Behaviours;
using ReversiGameFunctionApp.Models;

namespace ReversiGameFunctionApp.Domain
{
    internal class ReturnStoneMain
    {
        private StoneModel _setBoard;
        private ReversiGameBoard _reversiGameBoard;

        /// <summary>
        /// New
        /// </summary>
        /// <param name="requestBody">リクエストボディ</param>
        public ReturnStoneMain(string requestBody)
        {
            JObject jsonObject = JObject.Parse(requestBody);

            _setBoard = GetSetBoard(requestBody);
            _reversiGameBoard = new ReversiGameBoard(jsonObject);
        }

        /// <summary>
        /// メイン処理
        /// </summary>
        /// <returns>ひっくり返した後の盤面</returns>
        public string DoProcess()
        {
            var result = _reversiGameBoard.PutStone(_setBoard.Row, _setBoard.Col, _setBoard.Status);
            var turnedBoard = _reversiGameBoard.GetBoard();

            return JsonHelper.Convert<StoneModel>(turnedBoard);
        }

        /// <summary>
        /// セットした盤面を取得
        /// </summary>
        /// <param name="requestBody">リクエストボディ</param>
        /// <returns></returns>
        private StoneModel GetSetBoard(string requestBody)
        {
            JObject setBoardJsonObject = JObject.Parse(requestBody);
            var setBoardJson = JObject.Parse(setBoardJsonObject.ToString());

            return new FromJsonToModelConverter().ConvertToBoardModel(setBoardJson);
        }
    }
}
