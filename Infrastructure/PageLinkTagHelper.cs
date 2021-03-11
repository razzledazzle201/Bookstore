using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    // applys to divs and is called page-helper
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>(); // Dictionary to collect common URL vlaues

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }



        // overloading is reusing the same name for a method while passing in more parameters
        // overriding is replacing an existing method with our own info
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                // dynamic number of numbers that link to available pages
                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["P"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction,
                    PageUrlValues);

                // styling the page numbers that are links
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    // if i == current page then use pageClssSelected else use PageClassNormal
                }

                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }
            // output everything created in the loop
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}