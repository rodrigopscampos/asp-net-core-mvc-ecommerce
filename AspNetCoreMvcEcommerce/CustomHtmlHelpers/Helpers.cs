using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreMvcEcommerce.CustomHtmlHelpers
{
    public static class Helpers
    {
        public static HtmlString Strong(this IHtmlHelper html, string expression)
        {
            return new HtmlString("<strong>" + expression + "</strong>");
        }
    }
}