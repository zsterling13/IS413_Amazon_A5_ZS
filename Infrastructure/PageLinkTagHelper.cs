using IS413_Amazon_A5_ZS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Infrastructure
{
    //The following is an class that is used to dynamically create div tags that also have the page-model attribute
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        //A private element that helps to modify the url of the page dynamically
        private IUrlHelperFactory _urlHelperFactory;

        //Basically a setter method for the urlHelperFactory variable
        public PageLinkTagHelper (IUrlHelperFactory hp)
        {
            _urlHelperFactory = hp;
        }

        //ViewContext Info
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        //An object modeled after the PagingInfo class
        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        //Boolean value to ensure that div tags can use classes with the PageLinkTagHelper model. Default is false.
        public bool PageClassesEnabled { get; set; } = false;

        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }

        //Overrriding method
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            //Instruct to build new div tags
            TagBuilder result = new TagBuilder("div");

            //Run a for loop for every page that dynamically adds page navigation to the html of each page
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { page = i });
                tag.InnerHtml.Append(i.ToString());

                //If statement to allow for bootstrap and CSS to affect the dynamically-created links
                if(PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                result.InnerHtml.AppendHtml(tag);
            }

            //output the appended html
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
