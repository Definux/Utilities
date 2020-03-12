using Definux.Utilities.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Definux.Utilities.DataAnnotations
{
    public class VisibleReCaptchaValidateAttribute : ReCaptchaValidateAttribute
    {
        public VisibleReCaptchaValidateAttribute(IOptions<GoogleRecaptchaKeysOptions> googleRecaptchaKeysConfiguration, IHostingEnvironment hostingEnvironment) : base(googleRecaptchaKeysConfiguration, hostingEnvironment)
        {
            this.reCaptchaSecret = new Lazy<string>(() => this.googleRecaptchaKeys.VisibleRecaptcha.SecretKey);
        }
    }

    public class InvisibleReCaptchaValidateAttribute : ReCaptchaValidateAttribute
    {
        public InvisibleReCaptchaValidateAttribute(IOptions<GoogleRecaptchaKeysOptions> googleRecaptchaKeysConfiguration, IHostingEnvironment hostingEnvironment) : base(googleRecaptchaKeysConfiguration, hostingEnvironment)
        {
            this.reCaptchaSecret = new Lazy<string>(() => this.googleRecaptchaKeys.InvisibleRecaptcha.SecretKey);
        }
    }

    public abstract class ReCaptchaValidateAttribute : ActionFilterAttribute
    {
        public const string ReCaptchaModelErrorKey = "ReCaptcha";
        private const string RecaptchaResponseTokenKey = "g-recaptcha-response";
        private const string ApiVerificationEndpoint = "https://www.google.com/recaptcha/api/siteverify";
        protected readonly GoogleRecaptchaKeysOptions googleRecaptchaKeys;
        protected Lazy<string> reCaptchaSecret;
        private readonly IHostingEnvironment hostingEnvironment;

        public ReCaptchaValidateAttribute(IOptions<GoogleRecaptchaKeysOptions> googleRecaptchaKeysConfiguration, IHostingEnvironment hostingEnvironment)
        {
            this.googleRecaptchaKeys = googleRecaptchaKeysConfiguration.Value;
            this.hostingEnvironment = hostingEnvironment;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await DoReCaptchaValidation(context);
            await base.OnActionExecutionAsync(context, next);
        }

        private async Task DoReCaptchaValidation(ActionExecutingContext context)
        {
            if (this.hostingEnvironment.IsDevelopment())
            {
                return;
            }

            if (!context.HttpContext.Request.HasFormContentType)
            {
                AddModelError(context, "No reCaptcha Token Found");
                return;
            }
            string token = context.HttpContext.Request.Form[RecaptchaResponseTokenKey];
            if (string.IsNullOrWhiteSpace(token))
            {
                AddModelError(context, "No reCaptcha Token Found");
            }
            else
            {
                await ValidateRecaptcha(context, token);
            }
        }
        private static void AddModelError(ActionExecutingContext context, string error)
        {
            context.ModelState.AddModelError(ReCaptchaModelErrorKey, error.ToString());
        }

        private async Task ValidateRecaptcha(ActionExecutingContext context, string token)
        {
            using (var webClient = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("secret", this.reCaptchaSecret.Value),
                    new KeyValuePair<string, string>("response", token)
                });
                HttpResponseMessage response = await webClient.PostAsync(ApiVerificationEndpoint, content);
                string json = await response.Content.ReadAsStringAsync();
                var reCaptchaResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(json);
                if (reCaptchaResponse == null)
                {
                    AddModelError(context, "Unable To Read Response From Server");
                }
                else if (!reCaptchaResponse.Success)
                {
                    AddModelError(context, "Invalid reCaptcha");
                }
            }
        }
    }

    public class ReCaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("challenge_ts")]
        public string ChallengeTs { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("errorcodes")]
        public string[] ErrorCodes { get; set; }
    }
}
