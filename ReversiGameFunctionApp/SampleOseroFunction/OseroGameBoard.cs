using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleOseroFunction
{
    internal class OseroGameBoard
    {
        /// <summary>
        /// 盤面
        /// </summary>
        private int[,] _board;

        /// <summary>
        /// New
        /// </summary>
        /// <param name="board">初期のボード盤面</param>
        public OseroGameBoard(List<Cell> board)
        {
            _board = new int[8, 8];

            foreach (var cell in board)
            {
                var row = cell.row - 1;
                var col = cell.col - 1;
                var status = cell.status;

                _board[row, col] = status;
            }
        }

        /// <summary>
        /// 反転できる石があるかを確認し、反転できるなら反転できる石の個数を返す。（一方向分）
        /// </summary>
        /// <param name="status">置く石の色(1:黒 / 2:白)</param>
        /// <param name="startRow">石を置く位置 行番号 (1-8)</param>
        /// <param name="startColumn">石を置く位置 列番号 (1-8)</param>
        /// <param name="directionRow">縦側の走査方向(1:上から下 -1:下から上)</param>
        /// <param name="directionColumn">横側の走査方向(1:左から右 -1:右から左)</param>
        /// <returns>反転した石の数(=1-6)、またはエラーコード(<0)</returns>
        private int ScanDisc(int status, int startRow, int startColumn, int directionRow, int directionColumn)
        {
            if (_board[startRow, startColumn] != 0)
            {
                // Error1:置く場所にすでに石が置かれている
                return -1;
            }


            if ((directionRow == 1 && startRow >= 6) ||
                (directionRow == -1 && startRow <= 1) ||
                (directionColumn == 1 && startColumn >= 6) ||
                (directionColumn == -1 && startColumn <= 1))
            {
                // Error2:ここより先に反転する石はない
                return -2;
            }


            if (_board[startRow + 1 * directionRow, startColumn + 1 * directionColumn] == 0)
            {
                // Error3:隣に石が置かれていない
                return -3;
            }


            if (_board[startRow + 1 * directionRow, startColumn + 1 * directionColumn] == status)
            {
                //Error4:隣の石が同じ色
                return -4;
            }


            // ここまで来たら、置いた石の隣に、置いた石と違う色の石があることまでは確定。



            // 右に一つずつズレつつ、置いた石の色と同じ色の石を探す。
            for (int i = 2; i <= 7; i += 1)
            {
                if ((directionRow == 1 && startRow + i * directionRow > 8) ||
                    (directionRow == -1 && startRow + i * directionRow < 1) ||
                    (directionColumn == 1 && startColumn + i * directionColumn > 8) ||
                    (directionColumn == -1 && startColumn + i * directionColumn < 1))
                {
                    // Error5:置いた石と同じ色が見つからないまま、盤の外に出た
                    return -5;
                }

                if (_board[startRow + i * directionRow, startColumn + i * directionColumn] == 0)
                {
                    // Error6:置いた石と同じ色が見つからず、石の置かれていないところに来た
                    return -6;
                }


                if (_board[startRow + i * directionRow, startColumn + i * directionColumn] == status)
                {
                    // 同じ色の石が見つかった。OK!

                    return i;   // 反転される石の数を返す
                }

            }

            // Error7: 置いた石と同じ色が見つからず、端に到達した
            return -7;

        }

        /// <summary>
        /// 指定された個数の石を反転する
        /// </summary>
        /// <param name="status">置く石の色(1:黒 / 2:白)</param>
        /// <param name="startRow">石を置く位置 行番号 (1-8)</param>
        /// <param name="startColumn">石を置く位置 列番号 (1-8)</param>
        /// <param name="directionRow">縦側の走査方向(1:上から下 -1:下から上)</param>
        /// <param name="directionColumn">横側の走査方向(1:左から右 -1:右から左)</param>
        /// <param name="replaceCount">反転させる石の数</param>
        private void ReplaceDisc(int status, int startRow, int startColumn, int directionRow, int directionColumn, int replaceCount)
        {
            for (int i = 1; i <= replaceCount; i += 1)
            {
                _board[startRow + i * directionRow, startColumn + i * directionColumn] = status;
            }

        }

        /// <summary>
        /// 一方向の石の反転を行う
        /// </summary>
        /// <param name="status">置く石の色(1:黒 / 2:白)</param>
        /// <param name="startRow">石を置く位置 行番号 (1-8)</param>
        /// <param name="startColumn">石を置く位置 列番号 (1-8)</param>
        /// <param name="directionRow">縦側の走査方向(1:上から下 -1:下から上)</param>
        /// <param name="directionColumn">横側の走査方向(1:左から右 -1:右から左)</param>
        /// <returns>反転させた石の数</returns>
        private int Replace1Direction(int status, int startRow, int startColumn, int directionRow, int directionColumn)
        {
            // 反転できる石があるかを確認する
            var replaceCount = ScanDisc(status, startRow, startColumn, directionRow, directionColumn);

            //  反転できる石があった場合は、石を反転する
            if (replaceCount > 0)
            {
                ReplaceDisc(status, startRow, startColumn, directionRow, directionColumn, replaceCount);
                return replaceCount;
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// 石を置く
        /// </summary>
        /// <param name="row">石を置く位置 行番号 (1-8)</param>
        /// <param name="col">石を置く位置 列番号 (1-8)</param>
        /// <param name="status">置く石の色(1:黒 / 2:白)</param>
        /// <returns>true:成功 / false:失敗</returns>
        public bool PutStone(int row, int col, int status)
        {

            var startRow = row - 1;
            var startColumn = col - 1;

            var totalcount = 0;
            totalcount += Replace1Direction(status, startRow, startColumn, 0, 1);    // 右
            totalcount += Replace1Direction(status, startRow, startColumn, 1, 1);    // 右下
            totalcount += Replace1Direction(status, startRow, startColumn, 1, 0);    // 下
            totalcount += Replace1Direction(status, startRow, startColumn, 1, -1);   // 左下
            totalcount += Replace1Direction(status, startRow, startColumn, 0, -1);   // 左
            totalcount += Replace1Direction(status, startRow, startColumn, -1, -1);  // 左上
            totalcount += Replace1Direction(status, startRow, startColumn, -1, 0);   // 上
            totalcount += Replace1Direction(status, startRow, startColumn, -1, 1);   // 右上

            if (totalcount > 0)
            {
                _board[startRow, startColumn] = status;
                return true;
            }
            else
            {
                // ここには置けない
                return false;
            }

        }


        /// <summary>
        /// 現在の盤面を取得する
        /// </summary>
        /// <returns>盤面</returns>
        public List<Cell> GetBoard()
        {
            var cells = new List<Cell>();

            for (int row = 0; row < 8; row += 1)
            {
                for (int col = 0; col < 8; col += 1)
                {
                    var cell = new Cell();

                    cell.row = row + 1;
                    cell.col = col + 1;
                    cell.status = _board[row, col];

                    cells.Add(cell);
                }
            }

            return cells;
        }
    }

}
