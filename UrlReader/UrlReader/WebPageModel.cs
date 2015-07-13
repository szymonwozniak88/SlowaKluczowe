using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlReader
{
    /// <summary>
    /// Przechowywanie danych dotyczących strony
    /// </summary>
    public class WebPageModel
    {
        public WebPageModel(string adresUrl)
        {
            this.urlAdress = adresUrl;
        }

        //Dane strony
        public string urlAdress = "";
        public string body = "";

        //Kompletne dane strony
        public HtmlAgilityPack.HtmlDocument htmlDocument;

        //Dane statystyczne - słowa kluczowe
        public List<string> listKeyWords = new List<string>();
        public List<KeyValuePair<string, int>> listKeyWordWithStats = new List<KeyValuePair<string, int>>();
    }
}
