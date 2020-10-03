namespace Definux.Utilities.Objects
{
    /// <summary>
    /// Implementation of object that contains just a value of type.
    /// </summary>
    /// <typeparam name="T">Type of the value.</typeparam>
    public class SingleValueObject<T>
    {
        /// <summary>
        /// Value of the object.
        /// </summary>
        public T Value { get; set; }
    }
}
