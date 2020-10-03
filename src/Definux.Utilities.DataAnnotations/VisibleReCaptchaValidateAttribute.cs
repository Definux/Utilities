using System;
using Definux.Utilities.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace Definux.Utilities.DataAnnotations
{
    /// <summary>
    /// Validation attribute for visible ReCaptcha.
    /// </summary>
    public class VisibleReCaptchaValidateAttribute : ReCaptchaValidateAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VisibleReCaptchaValidateAttribute"/> class.
        /// </summary>
        /// <param name="googleRecaptchaKeysConfiguration"></param>
        /// <param name="hostingEnvironment"></param>
        public VisibleReCaptchaValidateAttribute(IOptions<GoogleRecaptchaKeysOptions> googleRecaptchaKeysConfiguration, IHostingEnvironment hostingEnvironment)
            : base(googleRecaptchaKeysConfiguration, hostingEnvironment)
        {
            this.ReCaptchaSecret = new Lazy<string>(() => this.GoogleRecaptchaKeys.VisibleRecaptcha.SecretKey);
            this.VerifyInDevelopment = this.GoogleRecaptchaKeys.VisibleRecaptcha.VerifyInDevelopment;
        }
    }
}