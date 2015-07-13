using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace UrlReader
{
    /// <summary>
    /// Pobieranie zawartości strony
    /// </summary>
    public class WebPageGetter
    {             
        /// <summary>
        /// Pobranie danych z url
        /// </summary>
        /// <param name="WebPageModel"></param>
        /// <returns>"WebPageModel"</returns>
        public WebPageModel GetDataFromUrl(WebPageModel webPageModel)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(webPageModel.urlAdress);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();

                    webPageModel.htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    webPageModel.htmlDocument.Load(receiveStream, true);
                    response.Close();                  
                }
            }
            catch(Exception e)
            {
                if (e is WebException)
                    MessageBox.Show("Strona o podanym adresie url nie istnieje");
                else
                    MessageBox.Show("Wystąpił błąd: " + e.Message);
            }

            return webPageModel;
        }
    }
}
