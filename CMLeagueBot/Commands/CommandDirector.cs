using CMLeagueBot.Core;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMLeagueBot.Commands
{
    public class CommandDirector
    {
        private DiscordSocketClient _client
        {
            get
            {
                return DiscordDirector.GetDirector()._client;
            }
        }

        private CommandService _commandService { get; set; } = new CommandService(new CommandServiceConfig()
        {
            //DefaultRunMode = RunMode.Async,
            CaseSensitiveCommands = false
        });

        public async Task InstallCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;

            await _commandService.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),
                                            services: null);
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if (message == null)
            {
                return;
            }

            int argPos = 0;

            if (!(message.HasCharPrefix('!', ref argPos) ||
                message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
            {
                return;
            }

            var context = new SocketCommandContext(_client, message);

            await _commandService.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: null);
        }
    }
}
