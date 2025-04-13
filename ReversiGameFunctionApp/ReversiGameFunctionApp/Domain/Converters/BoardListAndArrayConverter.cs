using ReversiGameFunctionApp.Models;

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
        /// Jsonオブジェクトから碁石モデルへ変換
        /// </summary>
        /// <param name="board">盤面配列</param>
        /// <returns>json配列</returns>
        public List<StoneModel> ConvertToListFromArray(int[,] boardArray)
        {
            var boardList = new List<StoneModel>();

            for (int i = 1; i < boardArray.GetLength(0); i++)
            {
                for (int j = 1; j < boardArray.GetLength(1); j++)
                {
                    boardList.Add(new StoneModel { Row = i, Col = j, Status = boardArray[i, j] });
                }
            }

            return boardList;
        }
    }
}

