using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LichessNetBot.Types
{
    public static class GameStates
    {
        public static DiscordEmbedBuilder newgame(LichessGame game)
        {
            return new DiscordEmbedBuilder()
            .WithTitle($"{game.Data.Challenge.Challenger.Name} ({game.Data.Challenge.Challenger.Rating}) is Waiting for an Opponent...")
            .WithDescription($"\n[Join Game](lichess.org/{game.XhrUrl})")
            .WithColor(new DiscordColor(0x2C7F24))
            .WithTimestamp(DateTime.Now)
            .WithFooter("Lichess.org", "https://upload.wikimedia.org/wikipedia/en/thumb/6/6d/Lichess_Logo_2019.png/250px-Lichess_Logo_2019.png")
            .WithImageUrl("https://imgur.com/lkgU4gi.png")
            .AddField("Challenger", $"{game.Data.Challenge.Challenger.Name} ({game.Data.Challenge.Challenger.Rating})", true)
            .AddField("Time", game.Data.Challenge.TimeControl.Show, true)
            .AddField("Type", game.Data.Challenge.Rated ? "Rated" : "Casual", true);
        }
    }
}
