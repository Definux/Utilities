using System;
using System.Collections.Generic;
using System.Linq;
using Definux.Utilities.DataAnnotations;
using Definux.Utilities.Objects;

namespace Definux.Utilities.Functions
{
    /// <summary>
    /// Functions for enumerations.
    /// </summary>
    public static class EnumFunctions
    {
        /// <summary>
        /// Converts enumeration type to dictionary with values and names of the enumeration.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
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
                result[(int)Enum.Parse(enumType, value.ToString())] = StringFunctions.SplitWordsByCapitalLetters(value.ToString());
            }

            return result;
        }

        /// <summary>
        /// Gets <see cref="EnumValueItem"/> from the enumeration value and assembly type name.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="enumTypeName"></param>
        /// <returns></returns>
        public static EnumValueItem GetEnumItemFromTypeByValue(int value, string enumTypeName)
        {
            EnumValueItem result = null;
            var enumValues = GetEnumValueItems(enumTypeName);
            if (enumValues != null && enumValues.Any(x => x.Value == value))
            {
                result = enumValues.FirstOrDefault(x => x.Value == value);
            }

            return result;
        }

        /// <summary>
        /// Gets collection of <see cref="EnumValueItem"/> for specified enumeration assembly type name.
        /// </summary>
        /// <param name="enumTypeName"></param>
        /// <returns></returns>
        public static IEnumerable<EnumValueItem> GetEnumValueItems(string enumTypeName)
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

        /// <summary>
        /// Gets collection of <see cref="EnumValueItem"/> for specified enumeration type.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
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
                    int enumValue = (int)Enum.Parse(enumType, value.ToString());
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
                        Key = key,
                    });
                }

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets enumeration type from the enumeration assembly name.
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
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
