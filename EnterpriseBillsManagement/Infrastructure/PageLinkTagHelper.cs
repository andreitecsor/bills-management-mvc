﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCStore.ViewModels;

namespace MVCStore.Infrastructure
{
    [HtmlTargetElement("div",Attributes="page-model")]
    public class PageLinkTagHelper:TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory=helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public PagingInfoViewModel? pageModel { get; set; }
        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(ViewContext != null && pageModel!=null)
            {

                var urlHelper=urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");
                for (int i = 1; i <= pageModel.TotalPage; i++)
                {
                    TagBuilder aTag=new TagBuilder("a");
                    aTag.Attributes["href"] = urlHelper.Action(PageAction, new { productPage = i });
                    aTag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(aTag);
                }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}