using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LichessNetBot.Types
{
    public partial class LichessGame
    {
        [JsonProperty("socketUrl")]
        public string SocketUrl { get; set; }

        [JsonProperty("xhrUrl")]
        public string XhrUrl { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("challenge")]
        public Challenge Challenge { get; set; }

        [JsonProperty("socketVersion")]
        public long SocketVersion { get; set; }
    }

    public partial class Challenge
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("challenger")]
        public Challenger Challenger { get; set; }

        [JsonProperty("destUser")]
        public object DestUser { get; set; }

        [JsonProperty("variant")]
        public Variant Variant { get; set; }

        [JsonProperty("rated")]
        public bool Rated { get; set; }

        [JsonProperty("speed")]
        public string Speed { get; set; }

        [JsonProperty("timeControl")]
        public TimeControl TimeControl { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("perf")]
        public Perf Perf { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }
    }

    public partial class Challenger
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("provisional")]
        public bool Provisional { get; set; }

        [JsonProperty("online")]
        public bool Online { get; set; }

        [JsonProperty("lag")]
        public long Lag { get; set; }
    }

    public partial class Perf
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class TimeControl
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("increment")]
        public long Increment { get; set; }

        [JsonProperty("show")]
        public string Show { get; set; }
    }

    public partial class Variant
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }
    }
}
