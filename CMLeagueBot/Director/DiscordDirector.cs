using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMLeagueBot.Director
{
    public partial class DiscordDirector
    {
        private DiscordSocketClient _client { get; set; } = new DiscordSocketClient();

        public async Task LoginAsync()
        {
            await _client.LoginAsync(TokenType.Bot, Credentials.Token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
    }
}
