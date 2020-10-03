namespace Definux.Utilities.Options
{
    /// <summary>
    /// Implementation of Google ReCaptcha keys options.
    /// </summary>
    public class RecaptchaKeys
    {
        /// <summary>
        /// Site key.
        /// </summary>
        public string SiteKey { get; set; }

        /// <summary>
        /// Secret key.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Verify the ReCaptcha in development environment.
        /// </summary>
        public bool VerifyInDevelopment { get; set; }
    }
}
