using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LichessNetBot.Types
{
    public class NetHandler
    {
        static public string[] getLinkInfo(string url)
        {
            string host = string.Empty;
            string time = string.Empty;
            string rating = string.Empty;
            string type = string.Empty;

            var contents = string.Empty;
            using (var client = new WebClient())
            {
                contents = client.DownloadString(url);
            }


            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(contents);

            host = doc.DocumentNode.SelectNodes("//main/h1/a").FirstOrDefault(x => x.Attributes.Contains("href")).InnerText;
            time = doc.DocumentNode.SelectSingleNode("//main/div/div[1]/div").InnerText + doc.DocumentNode.SelectSingleNode("//main/div/div[1]/div/span").InnerText; 
            rating = doc.DocumentNode.SelectSingleNode("//main/h1").InnerText.TrimStart(' ');
            type = doc.DocumentNode.SelectSingleNode("//main/div/div[2]").InnerText;



            return new string[] { host, time, rating, type };
        }
    }
}
