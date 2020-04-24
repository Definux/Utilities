using Definux.Utilities.DataAnnotations;
using Definux.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public static EnumValueItem GetEnumItemFromTypeByValue(int value, string enumTypeName)
        {
            EnumValueItem result = null;
            var enumValues = GetEnumValues(enumTypeName);
            if (enumValues != null && enumValues.Any(x => x.Value == value))
            {
                result = enumValues.FirstOrDefault(x => x.Value == value);
            }

            return result;
        }

        public static IEnumerable<EnumValueItem> GetEnumValues(string enumTypeName)
        {
            try
            {
                var enumType = GetEnumType(enumTypeName);
                if (enumType == null)
                {
                    return null;
                }

                return GetEnumValueItems(enumType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static IEnumerable<EnumValueItem> GetEnumValueItems(Type enumType)
        {
            try
            {
                if (enumType.BaseType != typeof(Enum))
                {
                    return null;
                }

                List<EnumValueItem> result = new List<EnumValueItem>();

                var enumValues = enumType.GetEnumValues();
                foreach (var value in enumValues)
                {
                    int enumValue = (int)(Enum.Parse(enumType, value.ToString()));
                    var memberInfo = enumType.GetMember(enumType.GetEnumName(value));
                    var keyAttribute = memberInfo[0]
                        .GetCustomAttributes(typeof(EnumKeyAttribute), false)
                        .FirstOrDefault() as EnumKeyAttribute;

                    string name = value.ToString();
                    string key = StringFunctions.ConvertToKey(enumType.Name + name);

                    if (keyAttribute != null)
                    {
                        key = keyAttribute.Key;
                    }

                    result.Add(new EnumValueItem
                    {
                        Value = enumValue,
                        Name = name,
                        Key = key
                    });
                }

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Type GetEnumType(string enumName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = assembly.GetType(enumName);
                if (type == null)
                {
                    continue;
                }

                if (type.IsEnum)
                {
                    return type;
                }
            }

            return null;
        }
    }
}
