using DL.NetCore.EmptySolution.Web.Common.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace DL.NetCore.EmptySolution.Web.Common.TagHelpers
{
    [HtmlTargetElement("label", Attributes = ForAttributeName)]
    public class LabelRequiredTagHelper : LabelTagHelper
    {
        private const string ForAttributeName = "asp-for";
        private const string RequiredCssClass = "required";

        public LabelRequiredTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            if (For.Metadata.IsRequired)
            {
                output.Attributes.AddCssClass(RequiredCssClass);
            }
        }
    }
}
