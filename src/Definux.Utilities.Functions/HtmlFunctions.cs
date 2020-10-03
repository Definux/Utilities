using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;

namespace Definux.Utilities.Functions
{
    /// <summary>
    /// Functions for <see cref="IHtmlContent"/>.
    /// </summary>
    public static class HtmlFunctions
    {
        /// <summary>
        /// Gets string from <see cref="IHtmlContent"/>.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetStringFromHtmlContent(IHtmlContent content)
        {
            using (StringWriter writer = new StringWriter())
            {
                content.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }
    }
}
