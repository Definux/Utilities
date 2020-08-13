using System;
using System.Linq;

namespace Definux.Utilities.Objects
{
    public class CaseString
    {
        private string rawString;

        public CaseString(string rawString)
        {
            this.rawString = rawString;
            BuildStringTypes();
        }

        public string PascalCase { get; private set; }

        public string CamelCase { get; private set; }

        public string KebapCase { get; private set; }

        public string SnakeCase { get; private set; }

        public string SnakeCaseAllCaps { get; private set; }

        private void BuildStringTypes()
        {
            if (string.IsNullOrWhiteSpace(this.rawString))
            {
                throw new ArgumentException("Invalid raw string");
            }

            string words = this.rawString.Replace("_", " ");
            words = words.Replace("-", " ");
            string convertedString = words.Aggregate(string.Empty, (result, next) =>
            {
                if (char.IsUpper(next) && result.Length > 1)
                {
                    result += ' ';
                }
                return result + next;
            });

            string[] stringWords = convertedString.Split(' ');
            int counter = 0;
            foreach (var word in stringWords)
            {
                if (word.Length > 0)
                {
                    PascalCase += word.First().ToString().ToUpper() + (word.Length > 1 ? word.Substring(1).ToLower() : string.Empty);
                    if (counter == 0)
                    {
                        CamelCase += word.ToLower();
                        SnakeCase += word.ToLower();
                        SnakeCaseAllCaps += word.ToUpper();
                        KebapCase += word.ToLower();
                    }
                    else
                    {
                        CamelCase += word.First().ToString().ToUpper() + (word.Length > 1 ? word.Substring(1).ToLower() : string.Empty);
                        SnakeCase += $"_{word.ToLower()}";
                        SnakeCaseAllCaps += $"_{word.ToUpper()}";
                        KebapCase += $"-{word.ToLower()}";
                    }
                }
            }
        }
    }
}
