using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMLeagueBot.Commands.Modules.Misc
{
	public class CopyPastaModule : ModuleBase<SocketCommandContext>
	{
		private static List<string> CopyPastas { get; set; } = new List<string>();

		[Command("CopyPasta")]
		[Summary("Responds with a random copy pasta")]
		[Alias("cp")]
		public Task CopyPastaAsync()
			=> ReplyAsync(GetRandomCopyPasta());

		private string GetRandomCopyPasta()
		{
			if (CopyPastas.Count == 0)
			{
				LoadCopyPastas();
			}

			Random r = new Random();
			int randomIndex = r.Next(0, CopyPastas.Count);

			return CopyPastas[randomIndex];
		}

		private void LoadCopyPastas()
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "copypastas.txt");
			string[] allLines = File.ReadAllLines(path);

			string tempStringBuilder = string.Empty;

			for (int i = 0; i < allLines.Length; i++)
			{
				if (String.IsNullOrWhiteSpace(allLines[i]))
				{
					if (tempStringBuilder != string.Empty)
					{
						CopyPastas.Add(tempStringBuilder);
						tempStringBuilder = string.Empty;
					}
				}
				else
				{
					tempStringBuilder += allLines[i] + " ";
				}
			}
		}
	}
}
