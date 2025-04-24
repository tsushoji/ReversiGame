using ReversiGameFunctionApp.Domain.Behaviours;
using ReversiGameFunctionApp.Models;
using ReversiGameFunctionApp.Models.Params;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ReversiGameFunctionApp.Domain
{
    public class ReturnStoneMain
    {
        private BoardListAndArrayConverter _interfaceConverter;
        private StoneModel _setBoard;
        private ReversiGameBoard _reversiGameBoard;

        /// <summary>
        /// New
        /// </summary>
        /// <param name="requestBody">Json文字列</param>
        public ReturnStoneMain(string requestBody)
        {
            _interfaceConverter = new BoardListAndArrayConverter();

            // StoneModelのプロパティ名と受け取るjsonのキー名の命名規約が一致していないため、大文字・小文字を区別しないように読み取り、取得する
            var arg = JsonSerializer.Deserialize<ReturnStoneInModel>(
                requestBody, 
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // 大文字・小文字を区別しない
                });

            // CS8604対策
            if (arg == null) 
            {
                throw new ArgumentException("パラメータが想定通り渡されておりません。");
            }
            if (arg.SetBoard == null)
            {
                throw new ArgumentException("パラメータ'setBoard'キーが想定通り渡されておりません。");
            }
            if (arg.Board == null)
            {
                throw new ArgumentException("パラメータ'board'キーが想定通り渡されておりません。");
            }

            _setBoard = arg.SetBoard;
            _reversiGameBoard = new ReversiGameBoard(_interfaceConverter.ConvertToArrayFromList(arg.Board));
        }
  

        /// <summary>
        /// メイン処理
        /// </summary>
        /// <returns>ひっくり返した後の盤面</returns>
        public List<StoneModel> DoProcess()
        {
            _reversiGameBoard.PutStone(_setBoard.Row, _setBoard.Col, _setBoard.Status);
            var turnedBoard = _reversiGameBoard.GetBoard();

            // Jsond返すときは、キー名をキャメルケースの命名規約で返す。
            return _interfaceConverter.ConvertToListFromArray(turnedBoard);
        }
    }
}
