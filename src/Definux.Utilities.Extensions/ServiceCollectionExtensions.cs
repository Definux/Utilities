using Definux.Utilities.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Definux.Utilities.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Load options from appsettings.json.
        /// </summary>
        /// <typeparam name="TOptions">Option object that implement the option configuration.</typeparam>
        /// <param name="services"></param>
        /// <param name="sectionName">Name of the section where are defined the options.</param>
        /// <returns></returns>
        public static IServiceCollection LoadOptions<TOptions>(this IServiceCollection services, string sectionName)
            where TOptions : class
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            services.Configure<TOptions>(configuration.GetSection(sectionName));

            return services;
        }

        /// <summary>
        /// Load Google ReCaptcha options from appsettings.json.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sectionName">Name of the section where are defined Google ReCaptcha options. Default value is the name of option class.</param>
        /// <returns></returns>
        public static IServiceCollection LoadGoogleRecaptchaOptions(this IServiceCollection services, string sectionName = nameof(GoogleRecaptchaKeysOptions))
        {
            return services.LoadOptions<GoogleRecaptchaKeysOptions>(sectionName);
        }

        /// <summary>
        /// Load SMTP options from appsettings.json.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sectionName">Name of the section where are defined SMTP options. Default value is the name of option class.</param>
        /// <returns></returns>
        public static IServiceCollection LoadSmtpOptions(this IServiceCollection services, string sectionName = nameof(SmtpOptions))
        {
            return services.LoadOptions<SmtpOptions>(sectionName);
        }

        /// <summary>
        /// Load OAuth2 options from appsettings.json.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sectionName">Name of the section where are defined external OAuth2 providers options. Default value is the name of option class.</param>
        /// <returns></returns>
        public static IServiceCollection LoadOAuth2Options(this IServiceCollection services, string sectionName = nameof(ExternalOAuth2ProviderOptions))
        {
            return services.LoadOptions<ExternalOAuth2ProviderOptions>(sectionName);
        }

        /// <summary>
        /// Load JWT options from appsettings.json.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sectionName">Name of the section where are defined JWT options. Default value is the name of option class.</param>
        /// <returns></returns>
        public static IServiceCollection LoadJwtOptions(this IServiceCollection services, string sectionName = nameof(JsonWebTokenOptions))
        {
            return services.LoadOptions<JsonWebTokenOptions>(sectionName);
        }

        /// <summary>
        /// Get loaded options from appsettings.json.
        /// </summary>
        /// <typeparam name="TOptions">Option object that implement the option configuration.</typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static TOptions GetOptions<TOptions>(this IServiceCollection services)
            where TOptions : class, new()
        {
            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetService<IOptions<TOptions>>();

            return options?.Value;
        }

        /// <summary>
        /// Get loaded Google ReCaptcha options from appsettings.json.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static GoogleRecaptchaKeysOptions GetGoogleRecaptchaOptions(this IServiceCollection services)
        {
            return services.GetOptions<GoogleRecaptchaKeysOptions>();
        }

        /// <summary>
        /// Get loaded SMTP options from appsettings.json.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static SmtpOptions GetSmtpOptions(this IServiceCollection services)
        {
            return services.GetOptions<SmtpOptions>();
        }

        /// <summary>
        /// Get loaded OAuth2 options from appsettings.json.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ExternalOAuth2ProviderOptions GetOAuth2Options(this IServiceCollection services)
        {
            return services.GetOptions<ExternalOAuth2ProviderOptions>();
        }

        /// <summary>
        /// Get loaded JWT options from appsettings.json.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static JsonWebTokenOptions GetJwtOptions(this IServiceCollection services)
        {
            return services.GetOptions<JsonWebTokenOptions>();
        }
    }
}
