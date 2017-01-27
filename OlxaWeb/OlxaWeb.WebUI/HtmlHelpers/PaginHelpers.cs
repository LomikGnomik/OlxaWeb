﻿using OlxaWeb.WebUI.Models;
using System;
using System.Text;
using System.Web.Mvc;


namespace OlxaWeb.WebUI.HtmlHelpers
{
    public static class PaginHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                      PagingInfo pagingInfo,
                                      Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-default");
                   
                }
               // tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

    }
}