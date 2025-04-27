using ReversiGameFunctionApp.Models;
using ReversiGameInProcessFunctionApp.Models;
using System.Collections.Generic;

namespace ReversiGameFunctionApp.Domain.Behaviours
{
    internal class BoardListAndArrayConverter
    {
        /// <summary>
        /// New
        /// </summary>
        public BoardListAndArrayConverter() { }

        /// <summary>
        /// 盤面リストから盤面配列へ変換
        /// </summary>
        /// <param name="board">盤面リスト</param>
        /// <returns>盤面配列</returns>
        public int[,] ConvertToArrayFromList(List<StoneModel> board)
        {
            var result = new int[9, 9];

            foreach (var stone in board)
            {
                var row = stone.Row;
                var col = stone.Col;
                var status = stone.Status;

                result[row, col] = status;
            }

            return result;
        }

        /// <summary>
        /// 配列からアウトプット碁石モデルリストへ変換
        /// </summary>
        /// <param name="board">盤面配列</param>
        /// <param name="board">碁石を置くことができたかどうか</param>
        /// <returns>アウトプット碁石モデルリスト</returns>
        public List<OutStoneModel> ConvertToOutputListFromArray(int[,] boardArray, bool isPutStone)
        {
            var outBoardList = new List<OutStoneModel>();

            for (int i = 1; i < boardArray.GetLength(0); i++)
            {
                for (int j = 1; j < boardArray.GetLength(1); j++)
                {
                    outBoardList.Add(new OutStoneModel { Row = i, Col = j, Status = boardArray[i, j], IsPutStone = isPutStone });
                }
            }

            return outBoardList;
        }
    }
}

