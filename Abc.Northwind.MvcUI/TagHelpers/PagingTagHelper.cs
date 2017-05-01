using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.MvcUI.TagHelpers
{
    //View import kendi tag helerimizi yazıcaz.
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper : TagHelper
    {
        //Bize burda kaç sayfa, pagesize bilgisi, kategori bilgisi html tarafından gelecek. Bu yüzden prop
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }


        //TagHelper
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.Append("<ul class='pagination'>");
            for (int i = 1; i < PageCount + 1; i++)
            {
                stringBuild.AppendFormat("<li class='{0}'>", i == CurrentPage ? "active" : "");
                stringBuild.AppendFormat("<a href='/Product/index?Page={0}&Category={1}'>{2}</a>", i, CurrentCategory, i);
                stringBuild.Append("</li>");
            }
            output.Content.SetHtmlContent(stringBuild.ToString());

            base.Process(context, output);
        }
    }
}
