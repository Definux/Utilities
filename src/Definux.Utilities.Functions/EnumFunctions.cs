using System;
using System.Collections.Generic;

namespace Definux.Utilities.Functions
{
    public static class EnumFunctions
    {
        public static Dictionary<int, string> GetEnumList(Type enumType)
        {
            if (enumType.BaseType != typeof(Enum))
            {
                return null;
            }
            var enumValues = enumType.GetEnumValues();
            Dictionary<int, string> result = new Dictionary<int, string>();
            foreach (var value in enumValues)
            {
                result[(int)(Enum.Parse(enumType, value.ToString()))] = StringFunctions.SplitWordsByCapitalLetters(value.ToString());
            }
            return result;
        }
    }
}
