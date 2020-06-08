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
        static public LichessGame getGameData(string url)
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

                return JsonConvert.DeserializeObject<LichessGame>(doc.DocumentNode.SelectSingleNode("/html/body/script[4]").InnerText.Split('=')[3]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
