namespace Definux.Utilities.Options
{
    /// <summary>
    /// Implementation of Google ReCaptcha options.
    /// </summary>
    public class GoogleRecaptchaKeysOptions
    {
        /// <summary>
        /// <inheritdoc cref="RecaptchaKeys"/> Applicable for visible ReCaptcha.
        /// </summary>
        public RecaptchaKeys VisibleRecaptcha { get; set; }

        /// <summary>
        /// <inheritdoc cref="RecaptchaKeys"/> Applicable for invisible ReCaptcha.
        /// </summary>
        public RecaptchaKeys InvisibleRecaptcha { get; set; }
    }
}
