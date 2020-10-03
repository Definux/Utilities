namespace Definux.Utilities.Validation
{
    /// <summary>
    /// Result of chain of responsibility validation.
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Status of the validation.
        /// </summary>
        public bool Successed { get; set; }

        /// <summary>
        /// Message of the validation.
        /// </summary>
        public string Message { get; set; }
    }
}
