using System.Linq;

namespace Definux.Utilities.Functions
{
    public static class StringFunctions
    {
        /// <summary>
        /// Split pascal case word to separate words.
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Convert pascal case word into a key format word (upper and snake case).
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string ConvertToKey(string words)
        {
            words = words.Replace("_", "");
            string key = words.Aggregate(string.Empty, (result, next) =>
            {
                if (char.IsUpper(next) && result.Length > 1)
                {
                    result += '_';
                }
                return result + next;
            });

            return key.ToUpper();
        }
    }
}
