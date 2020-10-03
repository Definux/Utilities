using System;
using Definux.Utilities.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace Definux.Utilities.DataAnnotations
{
    /// <summary>
    /// Validation attribute for invisible ReCaptcha.
    /// </summary>
    public class InvisibleReCaptchaValidateAttribute : ReCaptchaValidateAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvisibleReCaptchaValidateAttribute"/> class.
        /// </summary>
        /// <param name="googleRecaptchaKeysConfiguration"></param>
        /// <param name="hostingEnvironment"></param>
        public InvisibleReCaptchaValidateAttribute(IOptions<GoogleRecaptchaKeysOptions> googleRecaptchaKeysConfiguration, IHostingEnvironment hostingEnvironment)
            : base(googleRecaptchaKeysConfiguration, hostingEnvironment)
        {
            this.ReCaptchaSecret = new Lazy<string>(() => this.GoogleRecaptchaKeys.InvisibleRecaptcha.SecretKey);
            this.VerifyInDevelopment = this.GoogleRecaptchaKeys.InvisibleRecaptcha.VerifyInDevelopment;
        }
    }
}
