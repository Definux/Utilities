using Definux.Utilities.Functions;
using Microsoft.AspNetCore.Html;

namespace Definux.Utilities.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IHtmlContent"/>.
    /// </summary>
    public static class HtmlExtensions
    {
        /// <summary>
        /// <inheritdoc cref="HtmlFunctions.GetStringFromHtmlContent(IHtmlContent)"/>
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public static string RenderTag(this IHtmlContent output)
        {
            return HtmlFunctions.GetStringFromHtmlContent(output);
        }
    }
}
