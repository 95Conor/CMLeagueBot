using System;
using System.Threading.Tasks;
using CMLeagueBot.Core;

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

				Console.WriteLine("Logging in...");

				await director.LoginAsync();

				Console.WriteLine("Initialising command handling...");

				await director.InitialiseCommandHandling();

				Console.WriteLine("Bot successfully running...");

				Console.ReadKey();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error encountered within asynchrous main method with detail: {ex.Message}");
			}
		}
	}
}
