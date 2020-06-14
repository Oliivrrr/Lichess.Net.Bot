using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LichessNetBot.Commands;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace LichessNetBot
{
    public class Bot
    {
        public DiscordSocketClient Client { get; private set; }
        public CommandService Commands { get; private set; }
        public IServiceProvider Services { get; private set; }

        ConfigJson configJson;

        public async Task RunAsync()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            Client = new DiscordSocketClient();

            Commands = new CommandService();

            Services = new ServiceCollection()
                .AddSingleton(Client)
                .AddSingleton(Commands)
                .BuildServiceProvider();

            Client.Log += Client_Log;

            await RegisterCommands();

            await Client.LoginAsync(TokenType.Bot, configJson.Token);

        }

        private Task Client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommands()
        {
            Client.MessageReceived += HandleCommandsAsync;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), Services);
        }

        private async Task HandleCommandsAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var ctx = new SocketCommandContext(Client, message);
            if (message.Author.IsBot)
                return;

            int argPos = 0;

            if(message.HasStringPrefix(configJson.Prefix, ref argPos))
            {
                var result = await Commands.ExecuteAsync(ctx, argPos, Services);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            }
        }
    }
}