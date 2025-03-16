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

                // ���N�G�X�g(JSON)��ǂ�
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                // JSON ���f�V���A���C�Y����
                var arg = JsonSerializer.Deserialize<InParam>(requestBody);

                // ���N�G�X�g�Ŏ擾�����Ֆʂ�W�J����
                var gameBoard = new OseroGameBoard(arg.board);

                // ���N�G�X�g�Ŏw�肳�ꂽ�ꏊ�ɐ΂�u��
                var isTurned = gameBoard.PutStone(arg.setBoard.row, arg.setBoard.col, arg.setBoard.status);

                // ���ʂ��Z�b�g����
                var turnedBoard = new OutParam()
                {
                    isTurned = isTurned,
                    board = gameBoard.GetBoard() 
                };

                // ���X�|���X��߂�
                var result = JsonSerializer.Serialize<OutParam>(turnedBoard, new JsonSerializerOptions { WriteIndented = true });
                return new ObjectResult(result)
                {
                    // 200��Ԃ�
                    StatusCode = StatusCodes.Status200OK
                };

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
        }
    }
}
