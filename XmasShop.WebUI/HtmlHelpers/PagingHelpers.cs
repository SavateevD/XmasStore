using System;
using System.Text;
using System.Web.Mvc;
using XmasShop.WebUI.Models;

namespace XmasShop.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        /// <summary>
        /// Расширяющий метод PageLinks() генерирует HTML-разметку для набора ссылок на страницы 
        /// с использованием информации предоставленной в объекте PagingInfo.
        /// 
        /// Параметр Func принимает делегат, который применяется для генерации ссылок, 
        /// обеспечивающич просмотр других страниц.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pagingInfo"></param>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tagLi = new TagBuilder("li");
                tagLi.AddCssClass("page-item");
                tagLi.InnerHtml = addAtag(i, pageUrl);
                if (i == pagingInfo.CurrentPage)
                {
                    tagLi.AddCssClass("active");
                }
                result.Append(tagLi.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
        static string addAtag(int i, Func<int, string> pageUrl)
        {
            TagBuilder tagA = new TagBuilder("a");
            tagA.MergeAttribute("href", pageUrl(i));
            tagA.InnerHtml = i.ToString();

            tagA.MergeAttribute("data-ajax-mode", "replace");
            tagA.MergeAttribute("data-ajax", "true");
            tagA.MergeAttribute("data-ajax-update", "#main-row");


            tagA.AddCssClass("page-link rounded-0");
            return tagA.ToString();
        }
    }
}