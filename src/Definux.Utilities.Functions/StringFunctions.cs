using System.Linq;

namespace Definux.Utilities.Functions
{
    public static class StringFunctions
    {
        public static string SplitWordsByCapitalLetters(string words)
        {
            words = words.Replace("_", "");
            return words.Aggregate(string.Empty, (result, next) =>
            {
                if (char.IsUpper(next) && result.Length > 1)
                {
                    result += ' ';
                }
                return result + next;
            });
        }
    }
}
