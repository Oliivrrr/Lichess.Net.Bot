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
            var msg = await Context.Channel.SendMessageAsync("", false, GameStates.loading().Build());

            LichessLobby lobbydata = NetHandler.getLobbyData(lichessurl);

            string[] replaydata = new string[] { };

            if (lobbydata == null)
            {
                await msg.ModifyAsync(x => x.Embed = GameStates.invalid().Build());
                return;
            }
            
            await msg.ModifyAsync(x => x.Embed = GameStates.newgame(lobbydata).Build());

            while (true)
            {
                lobbydata = NetHandler.getLobbyData(lichessurl);
                if (lobbydata == null)
                    break;

                if (lobbydata.Data.Challenge.Status == "canceled")
                {
                    await msg.ModifyAsync(x => x.Embed = GameStates.cancelled(lobbydata).Build());
                    return;
                }
                await Task.Delay(7000);

            }

            var rounddata = NetHandler.getRoundData(lichessurl);
            await msg.ModifyAsync(x => x.Embed = GameStates.inprogress(rounddata).Build());

            while (true)
            {
                replaydata = NetHandler.getReplayData(lichessurl);

                if (!replaydata[3].Contains("Abort"))
                {
                    break;
                }

                await Task.Delay(7000);
            }

            await msg.ModifyAsync(x => x.Embed = GameStates.replay(replaydata).Build());
            return;
        }
    }
}