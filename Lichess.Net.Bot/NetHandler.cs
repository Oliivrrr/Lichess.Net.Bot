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
        static public LichessLobby getLobbyData(string url)
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

                return JsonConvert.DeserializeObject<LichessLobby>(doc.DocumentNode.SelectSingleNode("/html/body/script[4]").InnerText.Split('=')[3]);
            }
            catch
            {
                return null;
            }
        }

        static public LichessRound getRoundData(string url)
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

                return JsonConvert.DeserializeObject<LichessRound>(doc.DocumentNode.SelectSingleNode("/html/body/script[3]").InnerText.Split('=')[3]);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
