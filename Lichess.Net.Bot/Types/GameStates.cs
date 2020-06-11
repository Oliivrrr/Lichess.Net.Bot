using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace LichessNetBot.Types
{
    public static class GameStates
    {
        public static EmbedBuilder newgame(LichessLobby game)
        {
            return new EmbedBuilder()
            .WithTitle($"{game.Data.Challenge.Challenger.Name} ({game.Data.Challenge.Challenger.Rating}) is Waiting for an Opponent...")
            .WithDescription($"\n[Join Game]({game.Data.Challenge.Url})")
            .WithColor(0x2C7F24)
            .WithTimestamp(DateTime.Now)
            .WithFooter("Lichess.org", "https://upload.wikimedia.org/wikipedia/en/thumb/6/6d/Lichess_Logo_2019.png/250px-Lichess_Logo_2019.png")
            .WithImageUrl("https://imgur.com/lkgU4gi.png")
            .AddField("Challenger", $"{game.Data.Challenge.Challenger.Name} ({game.Data.Challenge.Challenger.Rating})", true)
            .AddField("Time", game.Data.Challenge.TimeControl.Show, true)
            .AddField("Type", game.Data.Challenge.Rated ? "Rated" : "Casual", true);
        }

        public static EmbedBuilder cancelled(LichessLobby game)
        {
            return new EmbedBuilder()
            .WithTitle($"{game.Data.Challenge.Challenger.Name} ({game.Data.Challenge.Challenger.Rating}) Cancelled")
            .WithDescription($"\nGame was Cancelled")
            .WithColor(0x9B0000)
            .WithTimestamp(DateTime.Now)
            .WithFooter("Lichess.org", "https://upload.wikimedia.org/wikipedia/en/thumb/6/6d/Lichess_Logo_2019.png/250px-Lichess_Logo_2019.png")
            .WithImageUrl("https://imgur.com/lkgU4gi.png")
            .AddField("Challenger", $"{game.Data.Challenge.Challenger.Name} ({game.Data.Challenge.Challenger.Rating})", true)
            .AddField("Time", game.Data.Challenge.TimeControl.Show, true)
            .AddField("Type", game.Data.Challenge.Rated ? "Rated" : "Casual", true);
        }

        public static EmbedBuilder inprogress(LichessRound game)
        {
            return new EmbedBuilder()
            .WithTitle($"{game.Data.Player.User.Username} ({game.Data.Player.Rating}) is Playing against {game.Data.Opponent.Name} ({game.Data.Opponent.Rating})")
            .WithDescription($"\n[Spectate]({game.Data.Url})")
            .WithColor(0x0074C6)
            .WithTimestamp(DateTime.Now)
            .WithFooter("Lichess.org", "https://upload.wikimedia.org/wikipedia/en/thumb/6/6d/Lichess_Logo_2019.png/250px-Lichess_Logo_2019.png")
            .WithImageUrl("https://imgur.com/lkgU4gi.png")
            .AddField("Challenger", $"{game.Data.Player.User.Username} ({game.Data.Player.Rating})", true)
            .AddField("Time", $"Black: {game.Data.Clock.Black} White: {game.Data.Clock.White}", true)
            .AddField("Type", game.Data.Game.Rated ? "Rated" : "Casual", true);
        }

        public static EmbedBuilder replay(LichessRound game)
        {
            return new EmbedBuilder()
            .WithTitle($"{game.Data.Player.User.Username} ({game.Data.Player.Rating}) vs {game.Data.Opponent.Name} ({game.Data.Opponent.Rating})")
            .WithDescription($"\n[Watch Replay]({game.Data.Url})")
            .WithColor(0xEAEAEA)
            .WithTimestamp(DateTime.Now)
            .WithFooter("Lichess.org", "https://upload.wikimedia.org/wikipedia/en/thumb/6/6d/Lichess_Logo_2019.png/250px-Lichess_Logo_2019.png")
            .WithImageUrl("https://imgur.com/lkgU4gi.png")
            .AddField("Challenger", $"{game.Data.Player.User.Username} ({game.Data.Player.Rating})", true)
            .AddField("Winner", $"{game.Data.Game.Winner}", true)
            .AddField("Type", game.Data.Game.Rated ? "Rated" : "Casual", true);
        }
    }
}
