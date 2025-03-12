namespace ReversiGameFunctionxUTest.Helpers
{
    internal static class StringHelper
    {
        public static string RemoveBlank(string replacedString)
        {
            return replacedString.Replace(" ", string.Empty);
        }
    }
}