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

        public static EmbedBuilder inprogress(string[] game)
        {
            return new EmbedBuilder()
            .WithTitle($"{game[0]} is Playing against {game[1]}")
            .WithDescription($"\n[Spectate Game]({game[2]})")
            .WithColor(0x0074C6)
            .WithTimestamp(DateTime.Now)
            .WithFooter("Lichess.org", "https://upload.wikimedia.org/wikipedia/en/thumb/6/6d/Lichess_Logo_2019.png/250px-Lichess_Logo_2019.png")
            .WithImageUrl("https://imgur.com/lkgU4gi.png")
            .AddField("Started", $"{DateTime.Now.Date}", true);
        }

        public static EmbedBuilder replay(string[] game)
        {
            return new EmbedBuilder()
            .WithTitle($"{game[0]} is Playing against {game[1]}")
            .WithDescription($"\n[Spectate Game]({game[2]})")
            .WithColor(0xEAEAEA)
            .WithTimestamp(DateTime.Now)
            .WithFooter("Lichess.org", "https://upload.wikimedia.org/wikipedia/en/thumb/6/6d/Lichess_Logo_2019.png/250px-Lichess_Logo_2019.png")
            .WithImageUrl("https://imgur.com/lkgU4gi.png")
            .AddField("Winner", game[3], true)
            .AddField("Ended", $"{DateTime.Now.Date}", true);
        }

        public static EmbedBuilder loading()
        {
            return new EmbedBuilder()
            .WithTitle($"Loading Game Info...")
            .WithDescription($" ")
            .WithColor(0xEAEAEA)
            .WithTimestamp(DateTime.Now)
            .WithFooter("Lichess.org", "https://upload.wikimedia.org/wikipedia/en/thumb/6/6d/Lichess_Logo_2019.png/250px-Lichess_Logo_2019.png")
            .WithImageUrl("https://imgur.com/lkgU4gi.png")
            .AddField("Challenger", $"????", true)
            .AddField("Time", $"????", true)
            .AddField("Type", "????", true);
        }

        public static EmbedBuilder invalid()
        {
            return new EmbedBuilder()
            .WithTitle($"Invalid Link")
            .WithDescription($"The lichess link specified could not be found or loaded.")
            .WithColor(0x9B0000)
            .WithTimestamp(DateTime.Now)
            .WithFooter("Lichess.org", "https://upload.wikimedia.org/wikipedia/en/thumb/6/6d/Lichess_Logo_2019.png/250px-Lichess_Logo_2019.png");
        }
    }
}
