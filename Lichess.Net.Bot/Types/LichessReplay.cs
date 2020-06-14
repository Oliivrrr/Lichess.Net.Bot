using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LichessNetBot.Types
{
    public partial class LichessReplay
    {
        [JsonProperty("data")]
        public ReplayData Data { get; set; }

        [JsonProperty("i18n")]
        public Dictionary<string, string> I18N { get; set; }

        [JsonProperty("chat")]
        public Chat Chat { get; set; }
    }

    public partial class ReplayData
    {
        [JsonProperty("game")]
        public GameReplay Game { get; set; }

        [JsonProperty("clock")]
        public Clock Clock { get; set; }

        [JsonProperty("correspondence")]
        public object Correspondence { get; set; }

        [JsonProperty("player")]
        public Player Player { get; set; }

        [JsonProperty("opponent")]
        public Opponent Opponent { get; set; }

        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        [JsonProperty("url")]
        public Url Url { get; set; }

        [JsonProperty("pref")]
        public Pref Pref { get; set; }

        [JsonProperty("evalPut")]
        public bool EvalPut { get; set; }

        [JsonProperty("steps")]
        public Step[] Steps { get; set; }
    }

    public partial class GameReplay
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("variant")]
        public Variant Variant { get; set; }

        [JsonProperty("speed")]
        public string Speed { get; set; }

        [JsonProperty("perf")]
        public string Perf { get; set; }

        [JsonProperty("rated")]
        public bool Rated { get; set; }

        [JsonProperty("initialFen")]
        public string InitialFen { get; set; }

        [JsonProperty("fen")]
        public string Fen { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("turns")]
        public long Turns { get; set; }

        [JsonProperty("startedAtTurn")]
        public long StartedAtTurn { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("createdAt")]
        public long CreatedAt { get; set; }

        [JsonProperty("lastMove")]
        public string LastMove { get; set; }

        [JsonProperty("opening")]
        public Opening Opening { get; set; }
    }

    public partial class Opening
    {
        [JsonProperty("eco")]
        public string Eco { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ply")]
        public long Ply { get; set; }
    }
}
