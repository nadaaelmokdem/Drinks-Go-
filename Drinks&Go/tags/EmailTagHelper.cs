using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Drinks_Go.tags
{
    public class EmailTagHelper : TagHelper
    {
        public string Email { get; set; }
        public string Text { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; // Replaces <email> with <a> tag
            output.Attributes.SetAttribute("href", $"mailto:{Email}");
            output.Content.SetContent(string.IsNullOrEmpty(Text) ? Email : Text);
        }
      }
}
