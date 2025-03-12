using System.Text.Json;

namespace ReversiGameFunctionApp.Domain.Behaviours
{
    internal static class JsonHelper
    {
        /// <summary>
        /// モデルリストからJson文字列へ変換
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">モデルリスト</param>
        /// <returns>json文字列</returns>
        public static string Convert<T>(List<T> items)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return JsonSerializer.Serialize(items, options);
        }
    }
}

