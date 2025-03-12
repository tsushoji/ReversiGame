namespace ReversiGameFunctionxUTest.Helpers
{
    internal static class StringHelper
    {
        public static string RemoveBlankAndNewLine(string replacedString)
        {
            return replacedString.Replace(" ", string.Empty)
                .Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty);
        }
    }
}