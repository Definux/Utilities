namespace Definux.Utilities.Objects
{
    /// <summary>
    /// Implementation of enumeration with additional key for the purposes of translation is necessary.
    /// </summary>
    public class EnumValueItem
    {
        /// <summary>
        /// Name of the enumeration item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the enumeration item.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// The additional key of the enumeration item.
        /// </summary>
        public string Key { get; set; }
    }
}
