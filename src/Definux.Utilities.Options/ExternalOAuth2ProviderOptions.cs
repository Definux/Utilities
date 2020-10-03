namespace Definux.Utilities.Options
{
    /// <summary>
    /// Implementation of external OAuth2 provider options.
    /// </summary>
    public class ExternalOAuth2ProviderOptions
    {
        /// <inheritdoc cref="FacebookOAuth2Settings"/>
        public FacebookOAuth2Settings FacebookSettings { get; set; }

        /// <inheritdoc cref="GoogleOAuth2Settings"/>
        public GoogleOAuth2Settings GoogleSettings { get; set; }
    }
}
