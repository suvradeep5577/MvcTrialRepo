using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCTrial.Helper
{
    public class MyCustomTaghelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "suvradeep.sr@gmail.com");
            output.Content.SetContent("my-email");
        }
    }
}
