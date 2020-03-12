using System;

namespace Definux.Utilities.DataAnnotations
{
    public class EnumKeyAttribute : Attribute
    {
        public EnumKeyAttribute(string key)
        {
            Key = key;
        }

        public string Key { get; }
    }
}
