using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace UrlReader
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebPageModel webPageModel = new WebPageModel(urlTextBox.Text);
            WebPageGetter webPageGetter = new WebPageGetter();
            WebPageParser webPageParser = new WebPageParser();
            webPageModel = webPageGetter.GetDataFromUrl(webPageModel);
            webPageModel = webPageParser.CompleteMainKeyWordsData(webPageModel);
            webPageModel = webPageParser.CompletePageStats(webPageModel);
            richTextBox1.Text = PrepareInformationToDisplay(webPageModel);
        }

        /// <summary>
        /// Przygotowanie informacji dotyczącej url do wyświetlenia
        /// słów kluczowych
        /// </summary>
        /// <param name="WebPageModel"></param>
        /// <returns>string - słowny opis dotyczący słów kluczowych</returns>
        private string PrepareInformationToDisplay(WebPageModel webPageModel)
        {
            //lista słów kluczowych
            string textKeyWords = "";
            textKeyWords = "Lista słów kluczowych: ";
            foreach (string keyWord in webPageModel.listKeyWords)
            {
                textKeyWords = textKeyWords +  keyWord + ", ";
            }
            textKeyWords =  textKeyWords.Substring(0, textKeyWords.Length - 2);

            //statystyka słów kluczowych
            string textKeyWordsStats = "";
            textKeyWordsStats = "Statystyka słów kluczowych: ";
            foreach (KeyValuePair<string, int> keyWordStats in webPageModel.listKeyWordWithStats)
            {
                textKeyWordsStats =  textKeyWordsStats +
                                     Environment.NewLine + 
                                     keyWordStats.Key + " : " + 
                                     keyWordStats.Value;
            }
            
            return textKeyWords + 
                   Environment.NewLine + 
                   Environment.NewLine + 
                   textKeyWordsStats ;
        }
    }
}
