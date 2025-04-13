using ReversiGameFunctionApp.Domain;
using ReversiGameFunctionxUTest.Helpers;

namespace ReversiGameFunctionxUTest
{
    public class ReturnStoneMainUTest
    {
        [Fact]
        public void ReturnStone()
        {
            // Arrange
            var requestBodyJson_1 = @"
            {
                ""board"":
                    [
                        {""row"":1, ""col"":1, ""status"":0},
                        {""row"":1, ""col"":2, ""status"":0},
                        {""row"":1, ""col"":3, ""status"":0},
                        {""row"":1, ""col"":4, ""status"":0},
                        {""row"":1, ""col"":5, ""status"":0},
                        {""row"":1, ""col"":6, ""status"":0},
                        {""row"":1, ""col"":7, ""status"":0},
                        {""row"":1, ""col"":8, ""status"":0},

                        {""row"":2, ""col"":1, ""status"":0},
                        {""row"":2, ""col"":2, ""status"":0},
                        {""row"":2, ""col"":3, ""status"":0},
                        {""row"":2, ""col"":4, ""status"":0},
                        {""row"":2, ""col"":5, ""status"":0},
                        {""row"":2, ""col"":6, ""status"":0},
                        {""row"":2, ""col"":7, ""status"":0},
                        {""row"":2, ""col"":8, ""status"":0},

                        {""row"":3, ""col"":1, ""status"":0},
                        {""row"":3, ""col"":2, ""status"":0},
                        {""row"":3, ""col"":3, ""status"":0},
                        {""row"":3, ""col"":4, ""status"":0},
                        {""row"":3, ""col"":5, ""status"":0},
                        {""row"":3, ""col"":6, ""status"":0},
                        {""row"":3, ""col"":7, ""status"":0},
                        {""row"":3, ""col"":8, ""status"":0},

                        {""row"":4, ""col"":1, ""status"":0},
                        {""row"":4, ""col"":2, ""status"":0},
                        {""row"":4, ""col"":3, ""status"":0},
                        {""row"":4, ""col"":4, ""status"":2},
                        {""row"":4, ""col"":5, ""status"":1},
                        {""row"":4, ""col"":6, ""status"":0},
                        {""row"":4, ""col"":7, ""status"":0},
                        {""row"":4, ""col"":8, ""status"":0},

                        {""row"":5, ""col"":1, ""status"":0},
                        {""row"":5, ""col"":2, ""status"":0},
                        {""row"":5, ""col"":3, ""status"":0},
                        {""row"":5, ""col"":4, ""status"":1},
                        {""row"":5, ""col"":5, ""status"":2},
                        {""row"":5, ""col"":6, ""status"":0},
                        {""row"":5, ""col"":7, ""status"":0},
                        {""row"":5, ""col"":8, ""status"":0},

                        {""row"":6, ""col"":1, ""status"":0},
                        {""row"":6, ""col"":2, ""status"":0},
                        {""row"":6, ""col"":3, ""status"":0},
                        {""row"":6, ""col"":4, ""status"":0},
                        {""row"":6, ""col"":5, ""status"":0},
                        {""row"":6, ""col"":6, ""status"":0},
                        {""row"":6, ""col"":7, ""status"":0},
                        {""row"":6, ""col"":8, ""status"":0},

                        {""row"":7, ""col"":1, ""status"":0},
                        {""row"":7, ""col"":2, ""status"":0},
                        {""row"":7, ""col"":3, ""status"":0},
                        {""row"":7, ""col"":4, ""status"":0},
                        {""row"":7, ""col"":5, ""status"":0},
                        {""row"":7, ""col"":6, ""status"":0},
                        {""row"":7, ""col"":7, ""status"":0},
                        {""row"":7, ""col"":8, ""status"":0},

                        {""row"":8, ""col"":1, ""status"":0},
                        {""row"":8, ""col"":2, ""status"":0},
                        {""row"":8, ""col"":3, ""status"":0},
                        {""row"":8, ""col"":4, ""status"":0},
                        {""row"":8, ""col"":5, ""status"":0},
                        {""row"":8, ""col"":6, ""status"":0},
                        {""row"":8, ""col"":7, ""status"":0},
                        {""row"":8, ""col"":8, ""status"":0}
                    ],
                ""setBoard"": {""row"":3, ""col"":4, ""status"":1}
            }";
            var goalAfterBoardJson_1 = @"
            [
                {""row"":1, ""col"":1, ""status"":0},
                {""row"":1, ""col"":2, ""status"":0},
                {""row"":1, ""col"":3, ""status"":0},
                {""row"":1, ""col"":4, ""status"":0},
                {""row"":1, ""col"":5, ""status"":0},
                {""row"":1, ""col"":6, ""status"":0},
                {""row"":1, ""col"":7, ""status"":0},
                {""row"":1, ""col"":8, ""status"":0},

                {""row"":2, ""col"":1, ""status"":0},
                {""row"":2, ""col"":2, ""status"":0},
                {""row"":2, ""col"":3, ""status"":0},
                {""row"":2, ""col"":4, ""status"":0},
                {""row"":2, ""col"":5, ""status"":0},
                {""row"":2, ""col"":6, ""status"":0},
                {""row"":2, ""col"":7, ""status"":0},
                {""row"":2, ""col"":8, ""status"":0},

                {""row"":3, ""col"":1, ""status"":0},
                {""row"":3, ""col"":2, ""status"":0},
                {""row"":3, ""col"":3, ""status"":0},
                {""row"":3, ""col"":4, ""status"":1},
                {""row"":3, ""col"":5, ""status"":0},
                {""row"":3, ""col"":6, ""status"":0},
                {""row"":3, ""col"":7, ""status"":0},
                {""row"":3, ""col"":8, ""status"":0},

                {""row"":4, ""col"":1, ""status"":0},
                {""row"":4, ""col"":2, ""status"":0},
                {""row"":4, ""col"":3, ""status"":0},
                {""row"":4, ""col"":4, ""status"":1},
                {""row"":4, ""col"":5, ""status"":1},
                {""row"":4, ""col"":6, ""status"":0},
                {""row"":4, ""col"":7, ""status"":0},
                {""row"":4, ""col"":8, ""status"":0},

                {""row"":5, ""col"":1, ""status"":0},
                {""row"":5, ""col"":2, ""status"":0},
                {""row"":5, ""col"":3, ""status"":0},
                {""row"":5, ""col"":4, ""status"":1},
                {""row"":5, ""col"":5, ""status"":2},
                {""row"":5, ""col"":6, ""status"":0},
                {""row"":5, ""col"":7, ""status"":0},
                {""row"":5, ""col"":8, ""status"":0},

                {""row"":6, ""col"":1, ""status"":0},
                {""row"":6, ""col"":2, ""status"":0},
                {""row"":6, ""col"":3, ""status"":0},
                {""row"":6, ""col"":4, ""status"":0},
                {""row"":6, ""col"":5, ""status"":0},
                {""row"":6, ""col"":6, ""status"":0},
                {""row"":6, ""col"":7, ""status"":0},
                {""row"":6, ""col"":8, ""status"":0},

                {""row"":7, ""col"":1, ""status"":0},
                {""row"":7, ""col"":2, ""status"":0},
                {""row"":7, ""col"":3, ""status"":0},
                {""row"":7, ""col"":4, ""status"":0},
                {""row"":7, ""col"":5, ""status"":0},
                {""row"":7, ""col"":6, ""status"":0},
                {""row"":7, ""col"":7, ""status"":0},
                {""row"":7, ""col"":8, ""status"":0},

                {""row"":8, ""col"":1, ""status"":0},
                {""row"":8, ""col"":2, ""status"":0},
                {""row"":8, ""col"":3, ""status"":0},
                {""row"":8, ""col"":4, ""status"":0},
                {""row"":8, ""col"":5, ""status"":0},
                {""row"":8, ""col"":6, ""status"":0},
                {""row"":8, ""col"":7, ""status"":0},
                {""row"":8, ""col"":8, ""status"":0}
            ]";

            // Act
            var targetAfterBoardList_1 = new ReturnStoneMain(requestBodyJson_1).DoProcess();
            var targetAfterBoardJson_1 = JsonHelper.ConvertFromListWIthCamelCase(targetAfterBoardList_1);

            // Assert
            // 空白文字列を置換して、アサート
            Assert.Equal(StringHelper.RemoveBlankAndNewLine(goalAfterBoardJson_1), StringHelper.RemoveBlankAndNewLine(targetAfterBoardJson_1));

            // Arrange
            var requestBodyJson_2 = @"
            {
                ""board"":
                    [
                        {""row"":1, ""col"":1, ""status"":0},
                        {""row"":1, ""col"":2, ""status"":0},
                        {""row"":1, ""col"":3, ""status"":0},
                        {""row"":1, ""col"":4, ""status"":0},
                        {""row"":1, ""col"":5, ""status"":0},
                        {""row"":1, ""col"":6, ""status"":0},
                        {""row"":1, ""col"":7, ""status"":0},
                        {""row"":1, ""col"":8, ""status"":0},

                        {""row"":2, ""col"":1, ""status"":0},
                        {""row"":2, ""col"":2, ""status"":0},
                        {""row"":2, ""col"":3, ""status"":0},
                        {""row"":2, ""col"":4, ""status"":0},
                        {""row"":2, ""col"":5, ""status"":0},
                        {""row"":2, ""col"":6, ""status"":0},
                        {""row"":2, ""col"":7, ""status"":0},
                        {""row"":2, ""col"":8, ""status"":0},

                        {""row"":3, ""col"":1, ""status"":0},
                        {""row"":3, ""col"":2, ""status"":0},
                        {""row"":3, ""col"":3, ""status"":0},
                        {""row"":3, ""col"":4, ""status"":1},
                        {""row"":3, ""col"":5, ""status"":0},
                        {""row"":3, ""col"":6, ""status"":0},
                        {""row"":3, ""col"":7, ""status"":0},
                        {""row"":3, ""col"":8, ""status"":0},

                        {""row"":4, ""col"":1, ""status"":0},
                        {""row"":4, ""col"":2, ""status"":0},
                        {""row"":4, ""col"":3, ""status"":0},
                        {""row"":4, ""col"":4, ""status"":1},
                        {""row"":4, ""col"":5, ""status"":1},
                        {""row"":4, ""col"":6, ""status"":0},
                        {""row"":4, ""col"":7, ""status"":0},
                        {""row"":4, ""col"":8, ""status"":0},

                        {""row"":5, ""col"":1, ""status"":0},
                        {""row"":5, ""col"":2, ""status"":0},
                        {""row"":5, ""col"":3, ""status"":0},
                        {""row"":5, ""col"":4, ""status"":1},
                        {""row"":5, ""col"":5, ""status"":2},
                        {""row"":5, ""col"":6, ""status"":0},
                        {""row"":5, ""col"":7, ""status"":0},
                        {""row"":5, ""col"":8, ""status"":0},

                        {""row"":6, ""col"":1, ""status"":0},
                        {""row"":6, ""col"":2, ""status"":0},
                        {""row"":6, ""col"":3, ""status"":0},
                        {""row"":6, ""col"":4, ""status"":0},
                        {""row"":6, ""col"":5, ""status"":0},
                        {""row"":6, ""col"":6, ""status"":0},
                        {""row"":6, ""col"":7, ""status"":0},
                        {""row"":6, ""col"":8, ""status"":0},

                        {""row"":7, ""col"":1, ""status"":0},
                        {""row"":7, ""col"":2, ""status"":0},
                        {""row"":7, ""col"":3, ""status"":0},
                        {""row"":7, ""col"":4, ""status"":0},
                        {""row"":7, ""col"":5, ""status"":0},
                        {""row"":7, ""col"":6, ""status"":0},
                        {""row"":7, ""col"":7, ""status"":0},
                        {""row"":7, ""col"":8, ""status"":0},

                        {""row"":8, ""col"":1, ""status"":0},
                        {""row"":8, ""col"":2, ""status"":0},
                        {""row"":8, ""col"":3, ""status"":0},
                        {""row"":8, ""col"":4, ""status"":0},
                        {""row"":8, ""col"":5, ""status"":0},
                        {""row"":8, ""col"":6, ""status"":0},
                        {""row"":8, ""col"":7, ""status"":0},
                        {""row"":8, ""col"":8, ""status"":0}
                    ],
                ""setBoard"": {""row"":3, ""col"":5, ""status"":2}
            }";
            var goalAfterBoardJson_2 = @"
            [
                {""row"":1, ""col"":1, ""status"":0},
                {""row"":1, ""col"":2, ""status"":0},
                {""row"":1, ""col"":3, ""status"":0},
                {""row"":1, ""col"":4, ""status"":0},
                {""row"":1, ""col"":5, ""status"":0},
                {""row"":1, ""col"":6, ""status"":0},
                {""row"":1, ""col"":7, ""status"":0},
                {""row"":1, ""col"":8, ""status"":0},

                {""row"":2, ""col"":1, ""status"":0},
                {""row"":2, ""col"":2, ""status"":0},
                {""row"":2, ""col"":3, ""status"":0},
                {""row"":2, ""col"":4, ""status"":0},
                {""row"":2, ""col"":5, ""status"":0},
                {""row"":2, ""col"":6, ""status"":0},
                {""row"":2, ""col"":7, ""status"":0},
                {""row"":2, ""col"":8, ""status"":0},

                {""row"":3, ""col"":1, ""status"":0},
                {""row"":3, ""col"":2, ""status"":0},
                {""row"":3, ""col"":3, ""status"":0},
                {""row"":3, ""col"":4, ""status"":1},
                {""row"":3, ""col"":5, ""status"":2},
                {""row"":3, ""col"":6, ""status"":0},
                {""row"":3, ""col"":7, ""status"":0},
                {""row"":3, ""col"":8, ""status"":0},

                {""row"":4, ""col"":1, ""status"":0},
                {""row"":4, ""col"":2, ""status"":0},
                {""row"":4, ""col"":3, ""status"":0},
                {""row"":4, ""col"":4, ""status"":1},
                {""row"":4, ""col"":5, ""status"":2},
                {""row"":4, ""col"":6, ""status"":0},
                {""row"":4, ""col"":7, ""status"":0},
                {""row"":4, ""col"":8, ""status"":0},

                {""row"":5, ""col"":1, ""status"":0},
                {""row"":5, ""col"":2, ""status"":0},
                {""row"":5, ""col"":3, ""status"":0},
                {""row"":5, ""col"":4, ""status"":1},
                {""row"":5, ""col"":5, ""status"":2},
                {""row"":5, ""col"":6, ""status"":0},
                {""row"":5, ""col"":7, ""status"":0},
                {""row"":5, ""col"":8, ""status"":0},

                {""row"":6, ""col"":1, ""status"":0},
                {""row"":6, ""col"":2, ""status"":0},
                {""row"":6, ""col"":3, ""status"":0},
                {""row"":6, ""col"":4, ""status"":0},
                {""row"":6, ""col"":5, ""status"":0},
                {""row"":6, ""col"":6, ""status"":0},
                {""row"":6, ""col"":7, ""status"":0},
                {""row"":6, ""col"":8, ""status"":0},

                {""row"":7, ""col"":1, ""status"":0},
                {""row"":7, ""col"":2, ""status"":0},
                {""row"":7, ""col"":3, ""status"":0},
                {""row"":7, ""col"":4, ""status"":0},
                {""row"":7, ""col"":5, ""status"":0},
                {""row"":7, ""col"":6, ""status"":0},
                {""row"":7, ""col"":7, ""status"":0},
                {""row"":7, ""col"":8, ""status"":0},

                {""row"":8, ""col"":1, ""status"":0},
                {""row"":8, ""col"":2, ""status"":0},
                {""row"":8, ""col"":3, ""status"":0},
                {""row"":8, ""col"":4, ""status"":0},
                {""row"":8, ""col"":5, ""status"":0},
                {""row"":8, ""col"":6, ""status"":0},
                {""row"":8, ""col"":7, ""status"":0},
                {""row"":8, ""col"":8, ""status"":0}
            ]";

            // Act
            var targetAfterBoardList_2 = new ReturnStoneMain(requestBodyJson_2).DoProcess();
            var targetAfterBoardJson_2 = JsonHelper.ConvertFromListWIthCamelCase(targetAfterBoardList_2);

            // Assert
            // 空白文字列を置換して、アサート
            Assert.Equal(StringHelper.RemoveBlankAndNewLine(goalAfterBoardJson_2), StringHelper.RemoveBlankAndNewLine(targetAfterBoardJson_2));

        }
    }
}