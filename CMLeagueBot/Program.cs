using System;
using System.Threading.Tasks;
using CMLeagueBot.Director;

namespace CMLeagueBot
{
	public class Program
	{
		public static void Main(string[] args)
			=> new Program().MainAsync().GetAwaiter().GetResult();

		public async Task MainAsync()
		{
			try
			{
				Console.WriteLine("Starting bot...");

				DiscordDirector director = DiscordDirector.GetDirector();

				Console.WriteLine("Hit any key to login...");
				Console.ReadKey();

				await director.LoginAsync();

				Console.ReadKey();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error encountered within asynchrous main method with detail: {ex.Message}");
			}
		}
	}
}
