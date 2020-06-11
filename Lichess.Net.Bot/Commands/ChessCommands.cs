using LichessNetBot.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace LichessNetBot.Commands
{
    public class ChessCommands : ModuleBase<SocketCommandContext>
    {
        [Command("startgame")]
        public async Task startGame(string lichessurl)
        {
            bool lobby = true;
            bool inprogress = true;
            
            LichessLobby lobbydata = NetHandler.getLobbyData(lichessurl);
            if (lobbydata == null)
            {
                await Context.Channel.SendMessageAsync("Invalid Lichess Game URL");
                return;
            }

            var msg = await Context.Channel.SendMessageAsync("", false, GameStates.newgame(lobbydata).Build());

            while (lobby)
            {
                lobbydata = NetHandler.getLobbyData(lichessurl);

                if(lobbydata.Data.Challenge.Status == "cancelled")
                {
                    lobby = false;
                    await msg.ModifyAsync(x => x.Embed = GameStates.cancelled(lobbydata).Build());
                }
                await Task.Delay(7000);
            }

            var rounddata = NetHandler.getRoundData(lichessurl);

            while (inprogress)
            {
                rounddata = NetHandler.getRoundData(lichessurl);

                if (rounddata == null || rounddata.Data.Game.Status.Name != "started")
                {
                    inprogress = false;
                    await msg.ModifyAsync(x => x.Embed = GameStates.inprogress(rounddata).Build());
                }
                await Task.Delay(7000);
            }
            rounddata = NetHandler.getRoundData(lichessurl);
            await msg.ModifyAsync(x => x.Embed = GameStates.replay(rounddata).Build());
        }
    }
}