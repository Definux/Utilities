namespace Definux.Utilities.Options
{
    public class GoogleRecaptchaKeysOptions
    {
        public RecaptchaKeys VisibleRecaptcha { get; set; }

        public RecaptchaKeys InvisibleRecaptcha { get; set; }
    }

    public class RecaptchaKeys
    {
        public string SiteKey { get; set; }

        public string SecretKey { get; set; }
    }
}
