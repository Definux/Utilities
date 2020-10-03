namespace Definux.Utilities.Objects
{
    /// <summary>
    /// Implementation of result that contains a success status.
    /// </summary>
    public class SimpleResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleResult"/> class.
        /// </summary>
        /// <param name="successed"></param>
        public SimpleResult(bool successed = false)
        {
            this.Successed = successed;
        }

        /// <summary>
        /// Predefined successfull result.
        /// </summary>
        public static SimpleResult SuccessfulResult => new SimpleResult(true);

        /// <summary>
        /// Predefined unsuccessfull result.
        /// </summary>
        public static SimpleResult UnsuccessfulResult => new SimpleResult(false);

        /// <summary>
        /// Status of the result.
        /// </summary>
        public bool Successed { get; set; }
    }
}
