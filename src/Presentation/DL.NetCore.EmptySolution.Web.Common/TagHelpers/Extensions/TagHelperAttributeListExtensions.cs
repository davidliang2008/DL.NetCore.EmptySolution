using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DL.NetCore.EmptySolution.Web.Common.TagHelpers.Extensions
{
    public static class TagHelperAttributeListExtensions
    {
        public static void AddCssClass(this TagHelperAttributeList attributeList, string cssClass)
        {
            const string classAttribute = "class";

            var existingCssClassValue = attributeList
                .FirstOrDefault(x => x.Name == classAttribute)?.Value.ToString();

            // If the class attribute doesn't exist, or the class attribute
            // value is empty, just add the CSS class to class attribute
            if (String.IsNullOrEmpty(existingCssClassValue))
            {
                attributeList.SetAttribute(classAttribute, cssClass);
            }

            // Here I use Regular Expression to check if the existing css class
            // value has the css class already. If yes, you don't need to add
            // that css class again. Otherwise you just add the css class along
            // with the existing value.
            // \b indicates a word boundary, as you only want to check if
            // the css class exists as a whole word.  
            else if (!Regex.IsMatch(existingCssClassValue, $@"\b{ cssClass }\b", RegexOptions.IgnoreCase))
            {
                attributeList.SetAttribute(classAttribute, $"{ cssClass } { existingCssClassValue }");
            }
        }
    }
}
