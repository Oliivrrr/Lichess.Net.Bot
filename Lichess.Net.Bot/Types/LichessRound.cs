using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LichessNetBot.Types
{
    public partial class LichessRound
    {
        [JsonProperty("data")]
        public RoundData Data { get; set; }

        [JsonProperty("i18n")]
        public Dictionary<string, string> I18N { get; set; }

        [JsonProperty("chat")]
        public Chat Chat { get; set; }
    }

    public partial class Chat
    {
        [JsonProperty("data")]
        public ChatData Data { get; set; }

        [JsonProperty("i18n")]
        public I18N I18N { get; set; }

        [JsonProperty("writeable")]
        public bool Writeable { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("permissions")]
        public Permissions Permissions { get; set; }
    }

    public partial class ChatData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lines")]
        public object[] Lines { get; set; }

        [JsonProperty("userId")]
        public object UserId { get; set; }

        [JsonProperty("resourceId")]
        public string ResourceId { get; set; }

        [JsonProperty("loginRequired")]
        public bool LoginRequired { get; set; }
    }

    public partial class I18N
    {
        [JsonProperty("talkInChat")]
        public string TalkInChat { get; set; }

        [JsonProperty("toggleTheChat")]
        public string ToggleTheChat { get; set; }

        [JsonProperty("loginToChat")]
        public string LoginToChat { get; set; }

        [JsonProperty("youHaveBeenTimedOut")]
        public string YouHaveBeenTimedOut { get; set; }
    }

    public partial class Permissions
    {
        [JsonProperty("local")]
        public bool Local { get; set; }
    }

    public partial class RoundData
    {
        [JsonProperty("game")]
        public Game Game { get; set; }

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

    public partial class Clock
    {
        [JsonProperty("running")]
        public bool Running { get; set; }

        [JsonProperty("initial")]
        public long Initial { get; set; }

        [JsonProperty("increment")]
        public long Increment { get; set; }

        [JsonProperty("white")]
        public long White { get; set; }

        [JsonProperty("black")]
        public long Black { get; set; }

        [JsonProperty("emerg")]
        public long Emerg { get; set; }

        [JsonProperty("moretime")]
        public long Moretime { get; set; }
    }

    public partial class Game
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

        [JsonProperty("winner")]
        public string Winner { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Opponent
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("provisional")]
        public bool Provisional { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("spectator")]
        public bool Spectator { get; set; }

        [JsonProperty("onGame")]
        public bool OnGame { get; set; }
    }

    public partial class Player
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("provisional")]
        public bool Provisional { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("spectator")]
        public bool Spectator { get; set; }

        [JsonProperty("onGame")]
        public bool OnGame { get; set; }
    }

    public partial class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("online")]
        public bool Online { get; set; }

        [JsonProperty("perfs")]
        public Perfs Perfs { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }

    public partial class Perfs
    {
        [JsonProperty("blitz")]
        public Blitz Blitz { get; set; }
    }

    public partial class Blitz
    {
        [JsonProperty("games")]
        public long Games { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("rd")]
        public long Rd { get; set; }

        [JsonProperty("prog")]
        public long Prog { get; set; }

        [JsonProperty("prov")]
        public bool Prov { get; set; }
    }

    public partial class Profile
    {
        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public partial class Pref
    {
        [JsonProperty("animationDuration")]
        public long AnimationDuration { get; set; }

        [JsonProperty("coords")]
        public long Coords { get; set; }

        [JsonProperty("resizeHandle")]
        public long ResizeHandle { get; set; }

        [JsonProperty("replay")]
        public long Replay { get; set; }

        [JsonProperty("clockTenths")]
        public long ClockTenths { get; set; }

        [JsonProperty("clockBar")]
        public bool ClockBar { get; set; }

        [JsonProperty("highlight")]
        public bool Highlight { get; set; }

        [JsonProperty("destination")]
        public bool Destination { get; set; }

        [JsonProperty("rookCastle")]
        public bool RookCastle { get; set; }

        [JsonProperty("showCaptured")]
        public bool ShowCaptured { get; set; }
    }

    public partial class Step
    {
        [JsonProperty("ply")]
        public long Ply { get; set; }

        [JsonProperty("uci")]
        public object Uci { get; set; }

        [JsonProperty("san")]
        public object San { get; set; }

        [JsonProperty("fen")]
        public string Fen { get; set; }
    }

    public partial class Url
    {
        [JsonProperty("socket")]
        public string Socket { get; set; }

        [JsonProperty("round")]
        public string Round { get; set; }
    }
}
