namespace Definux.Utilities.Options
{
    public class ExternalOAuth2ProviderOptions
    {
        public FacebookOAuth2Settings FacebookSettings { get; set; }

        public GoogleOAuth2Settings GoogleSettings { get; set; }
    }

    public class FacebookOAuth2Settings
    {
        public string AppId { get; set; }

        public string AppSecret { get; set; }
    }

    public class GoogleOAuth2Settings
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
