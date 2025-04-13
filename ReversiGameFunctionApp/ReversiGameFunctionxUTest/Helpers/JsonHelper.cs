using System.Text.Json;

namespace ReversiGameFunctionxUTest.Helpers
{
    internal static class JsonHelper
    {
        public static string ConvertFromListWIthCamelCase<T>(List<T> list)
        {
            return JsonSerializer.Serialize(
                list,
                new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase // キー名がキャメルケース
                });
        }
    }
}