﻿using CMLeagueBot.Commands;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMLeagueBot.Core
{
    public partial class DiscordDirector
    {
        internal DiscordSocketClient _client { get; set; } = new DiscordSocketClient();

        private IMessageChannel _channel
        {
            get
            {
                return (IMessageChannel)_client.GetChannel(Credentials.ChannelID);
            }
        }

        public async Task LoginAsync()
        {
            await _client.LoginAsync(TokenType.Bot, Credentials.Token);

            await _client.StartAsync();

            // The below may be necessary if we're going to allow commands and follow the organisational pattern 
            // If we create our own timer to check riot API at intervals, we can run in this method and call SendMessage whenever we want

            // Block this task until the program is closed.
            // await Task.Delay(-1);
        }

        public async Task InitialiseCommandHandling()
        {
            CommandDirector director = new CommandDirector();
            await director.InstallCommandsAsync();
        }

        public async Task SendMessage(string message)
        {
            await _channel.SendMessageAsync(message);
        }
    }
}
