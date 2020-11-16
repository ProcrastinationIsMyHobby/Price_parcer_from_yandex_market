using AngleSharp.Html.Dom;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;

namespace Market.Entity
{
    class Parser
    {
        public static async Task<string> Parse()
        {
            var config = Configuration.Default.WithDefaultLoader();
            string url = "https://market.yandex.ru/product--operativnaia-pamiat-corsair-cmk16gx4m2b3200c16/13021713";

            List<string> vs = new List<string>();

            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(url);
            var elements = document.QuerySelectorAll("div").Where(
                element => element.ClassName != null &&
                element.ClassName.Contains("_3NaXxl-HYN"));
            
            foreach(var element in elements)
            {
                vs.Add(element.TextContent);
            }

            if (vs.Count == 0)
            {
                return "ban";
            }

            return vs[0];
        }
        
    }
}
