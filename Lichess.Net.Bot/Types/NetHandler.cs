using HtmlAgilityPack;
using Newtonsoft.Json;
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
            try
            {
                var contents = string.Empty;
                using (var client = new WebClient())
                {
                    contents = client.DownloadString(url);
                }

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(contents);

                var gameData = JsonConvert.DeserializeObject<Temperatures>(doc.DocumentNode.SelectSingleNode("/html/body/script[4]").InnerText.Split('=')[3]);

                return new string[] { gameData.Data.Challenge.Challenger.Name, gameData.Data.Challenge.TimeControl.Show, gameData.Data.Challenge.Challenger.Rating.ToString(), gameData.Data.Challenge.Rated ? "Rated" : "Casual", url };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
