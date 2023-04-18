using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Runtime.CompilerServices;

namespace ViewsDemo.Common
{
    public static class CustomHtmlHelper
    {
        public static IHtmlContent Button(this IHtmlHelper helper, 
            string type, string value)
        {
            TagBuilder input = new TagBuilder("input");
            input.Attributes["type"] = type;
            input.Attributes["value"] = value;

            return input;
        }
    }
}
