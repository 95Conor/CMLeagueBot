using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMLeagueBot.Commands.Modules
{
	public class SpongebobModule : ModuleBase<SocketCommandContext>
	{
		[Command("Spongebob")]
		[Summary("Responds with a spongebob-ified message")]
		[Alias("sb")]
		public Task SpongebobAsync([Remainder] [Summary("The text to spongebob-ify")] string echo)
			=> ReplyAsync(SpongeBobText(echo));

		private string SpongeBobText(string text)
		{
			string spongeBobText = string.Empty;

			if (!String.IsNullOrWhiteSpace(text))
			{
				char[] textAsChar = text.ToCharArray();

				for (int i = 0; i < text.Length; i++)
				{
					if (new Random().Next(0, 2) == 1)
					{
						spongeBobText += textAsChar[i].ToString().ToLower();
					}
					else
					{
						spongeBobText += textAsChar[i].ToString().ToUpper();
					}
				}
			}

			return spongeBobText;
		}
	}
}
