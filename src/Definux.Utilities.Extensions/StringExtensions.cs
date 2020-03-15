using Definux.Utilities.Functions;
using System.Linq;

namespace Definux.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string ToPluralString(this string targetString)
        {
            string resultString = $"{targetString}s";
            if (targetString.EndsWith("s", System.StringComparison.OrdinalIgnoreCase) ||
                targetString.EndsWith("sh", System.StringComparison.OrdinalIgnoreCase) ||
                targetString.EndsWith("ch", System.StringComparison.OrdinalIgnoreCase) ||
                targetString.EndsWith("x", System.StringComparison.OrdinalIgnoreCase) ||
                targetString.EndsWith("z", System.StringComparison.OrdinalIgnoreCase))
            {
                resultString = $"{targetString}es";
            }

            return resultString;
        }

        public static string ToFirstUpper(this string stringValue)
        {
            return stringValue.First().ToString().ToUpper() + stringValue.Substring(1);
        }

        public static string ToFirstLower(this string stringValue)
        {
            return stringValue.First().ToString().ToLower() + stringValue.Substring(1);
        }

        public static string SplitWordsByCapitalLetters(this string targetString)
        {
            return StringFunctions.SplitWordsByCapitalLetters(targetString);
        }

        public static string ConvertToKey(this string targetString)
        {
            return StringFunctions.ConvertToKey(targetString);
        }
    }
}
