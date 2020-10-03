using System;

namespace Definux.Utilities.DataAnnotations
{
    /// <summary>
    /// Attribute that add additional information to enumeration.
    /// </summary>
    public class EnumKeyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumKeyAttribute"/> class.
        /// </summary>
        /// <param name="key"></param>
        public EnumKeyAttribute(string key)
        {
            this.Key = key;
        }

        /// <summary>
        /// Key of the enumeration.
        /// </summary>
        public string Key { get; }
    }
}
