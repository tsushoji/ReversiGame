using Newtonsoft.Json.Linq;
using ReversiGameFunctionApp.Domain.Behaviours;

namespace ReversiGameFunctionApp.Models
{
    internal class BoardModel
    {
        private List<StoneModel> _boad;
        /// <summary>
        /// New
        /// </summary>
        /// <param name="jsonObject">Jオブジェクト</param>
        public BoardModel(JObject jsonObject)
        {
            if (jsonObject["board"] == null)
            {
                throw new ArgumentException("The 'board' key is missing or is null.");
            }

            JArray? preBoardJsonArray = jsonObject["board"] as JArray;
            if (preBoardJsonArray == null)
            {
                throw new ArgumentException("The 'board' key is missing or is null.");
            }

            _boad = new FromJsonToModelConverter().ConvertToBoardModelList(preBoardJsonArray);
        }

        /// <summary>
        /// 碁石ステータスを取得
        /// </summary>
        /// <param name="row">縦位置</param>
        /// <param name="col">横位置</param>
        /// <returns>指定した位置の碁石ステータス</returns>
        public int GetStoneStatus(int row, int col)
        {
            return _boad[GetStoneIndex(row, col)].Status;
        }

        /// <summary>
        /// 碁石のステータスを設定
        /// </summary>
        /// <param name="row">縦位置</param>
        /// <param name="col">横位置</param>
        /// <param name="status">ステータス</param>
        public void SetStoneStatus(int row, int col, int status)
        {
            var updateStoneIndex = GetStoneIndex(row, col);
            var updateStone = _boad[updateStoneIndex];
            updateStone.Status = status;

            _boad[updateStoneIndex] = updateStone;
        }

        /// <summary>
        /// 盤面を取得
        /// </summary>
        /// <returns>盤面</returns>
        public List<StoneModel> GetBoard()
        {
            return _boad;
        }

        /// <summary>
        /// 碁石の盤面(リスト)のインデックスを取得
        /// </summary>
        /// <param name="row">縦位置</param>
        /// <param name="col">横位置</param>
        /// <returns>指定した位置の碁石の盤面(リスト)インデックス</returns>
        /// <exception cref="Exception"></exception>
        private int GetStoneIndex(int row, int col)
        {
            var filterStoneIndex = _boad.FindIndex(s => s.Row == row && s.Col == col);

            if (filterStoneIndex == -1)
            {
                // 石が取得できないとき、ロジックが矛盾しているため、例外をスローする。
                throw new Exception();
            }

            return filterStoneIndex;
        }
    }
}

