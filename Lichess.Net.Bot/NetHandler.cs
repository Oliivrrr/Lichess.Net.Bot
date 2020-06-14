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

        static public string[] getRoundData(string url)
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
                string rawText = doc.DocumentNode.SelectSingleNode("/html/body/div/main/div[1]/div[4]").InnerText;

                string rawText2 = doc.DocumentNode.SelectSingleNode("/html/body/div/main/div[1]/div[6]").InnerText;
                if (rawText2 == "&nbsp;")
                    rawText2 = "Anon";
                return new string[] { rawText, rawText2, url };
            }
            catch
            {
                return null;
            }
        }

        static public string[] getReplayData(string url)
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
                //string rawText = doc.DocumentNode.SelectSingleNode("/html/body/script[3]").InnerText.Split('=')[3].Substring(30);

                //return JsonConvert.DeserializeObject<LichessReplay>(string.Concat(rawText.Reverse().Skip(2).Reverse()));

                string rawText3 = "Empty";

                if(doc.DocumentNode.SelectSingleNode("/html/body/div[1]/main/div[3]/div[3]/div[3]") != null)
                    rawText3 = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/main/div[3]/div[3]/div[3]").InnerText;

                string rawText4 = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/main/aside/div/section[1]/div[2]/div[1]").InnerText;
                string rawText5 = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/main/aside/div/section[1]/div[2]/div[2]").InnerText;

                string winner = "";

                if (rawText3.Contains("White"))
                    winner = rawText4;
                else if (rawText3.Contains("Black"))
                    winner = rawText5;
                else
                    winner = "Game Was Aborted";

                return new string[] { rawText4, rawText5, url, winner};
            }
            catch
            {
                return null;
            }
        }
    }
}
