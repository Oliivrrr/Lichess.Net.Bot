using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using LichessNetBot.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LichessNetBot.Commands
{
    public class ChessCommands : BaseCommandModule
    {
        [Command("startgame")]
        [Description("Starts a Chess Game.")]
        public async Task startGame(CommandContext ctx, [Description("Lichess Game Link  eg. lichess.org/I8qK10LA")] string lichessurl)
        {
            LichessGame data = NetHandler.getGameData(lichessurl);
            if (data != null)
                await ctx.Channel.SendMessageAsync("", false, GameStates.newgame(data));
            else
            {
                await ctx.Channel.SendMessageAsync("Invalid Lichess Game URL");
            }
        }
    }
}