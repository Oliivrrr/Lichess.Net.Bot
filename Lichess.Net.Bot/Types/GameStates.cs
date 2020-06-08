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
        public static DiscordEmbedBuilder newgame(string[] data) // host, time, rating, type
        {
            return new DiscordEmbedBuilder()
            .WithTitle($"{data[0]} ({data[2]}) is Waiting for an Opponent...")
            .WithDescription($"\n[Join Game]({data[4]})")
            .WithColor(new DiscordColor(0x2C7F24))
            .WithTimestamp(DateTime.Now)
            .WithFooter("Lichess.org", "https://upload.wikimedia.org/wikipedia/en/thumb/6/6d/Lichess_Logo_2019.png/250px-Lichess_Logo_2019.png")
            .WithImageUrl("https://imgur.com/lkgU4gi.png")
            .AddField("Time", data[1], true)
            .AddField("Challenger", $"{data[0]} ({data[2]})", true)
            .AddField("Type", data[3], true);
        }
    }
}
