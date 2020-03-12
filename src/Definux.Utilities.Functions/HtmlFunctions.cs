using Microsoft.AspNetCore.Html;
using System.IO;
using System.Text.Encodings.Web;

namespace Definux.Utilities.Functions
{
    public static class HtmlFunctions
    {
        public static string GetStringFromHtmlContent(IHtmlContent content)
        {
            using (StringWriter writer = new StringWriter())
            {
                content.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }

        public static string RenderTag(this IHtmlContent output)
        {
            using (var writer = new StringWriter())
            {
                output.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }
    }
}
