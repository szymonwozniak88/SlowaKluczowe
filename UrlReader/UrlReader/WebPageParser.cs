using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UrlReader
{
    /// <summary>
    /// Parsowanie zawartości strony
    /// </summary>
    public class WebPageParser
    {
        /// <summary>
        /// Pobranie podstawowych danych o stronie
        /// </summary>
        /// <param name="WebPageModel"></param>
        /// <returns>"WebPageModel"</returns>
        public WebPageModel CompleteMainKeyWordsData(WebPageModel webPageModel)
        {
            HtmlAgilityPack.HtmlNodeCollection nodesKeyWords = webPageModel.htmlDocument.DocumentNode.SelectNodes("//meta[@name='keywords']");
            if (nodesKeyWords != null)
            {
                foreach (HtmlAgilityPack.HtmlNode nodeKeyWords in nodesKeyWords)
                {
                    IEnumerable<HtmlAgilityPack.HtmlAttribute> aa = nodeKeyWords.Attributes.AttributesWithName("content");

                    foreach (HtmlAgilityPack.HtmlAttribute x in aa)
                    {
                        webPageModel.listKeyWords.AddRange(x.Value.Split(','));
                    }
                }
            }
            webPageModel.body = webPageModel.htmlDocument.DocumentNode.InnerText;

            return webPageModel;
        }

        /// <summary>
        /// Uzupełnienie danych - statystyka na temat słów kluczowych
        /// </summary>
        /// <param name="WebPageModel"></param>
        /// <returns>"WebPageModel"</returns>
        public WebPageModel CompletePageStats(WebPageModel webPageModel)
        {
            foreach (string keyWord in webPageModel.listKeyWords)
            {
                int amountOfKeyWords = Regex.Matches(webPageModel.body, keyWord).Count;
                webPageModel.listKeyWordWithStats.Add(new KeyValuePair<string, int>(keyWord, amountOfKeyWords));
            }

            return webPageModel;
        }
    }
}
