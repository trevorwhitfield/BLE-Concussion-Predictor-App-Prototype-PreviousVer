using Microsoft.Extensions.Logging;
using Test_android_app.ViewModel;
using System.Diagnostics;//Necessary for printing stuff to output
//using Xamarin.Google.Crypto.Tink.Subtle;  // Why was this added?  I swear I didn't

namespace Test_android_app;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

//#if DEBUG
//		builder.Logging.AddDebug();
//#endif

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<GameDataPage>();
        builder.Services.AddTransient<GameDataModel>();

		//Load data
		Database.loadData();
        Debug.WriteLine("Reading database...");
		//Look through each game's data
		foreach (var entry in Database.readDatabase())
		{
			Debug.WriteLine("Game ID: {0}, Date: {1}", entry.Key, entry.Value.date);

			entry.Value.addPlayer("Debug");
			//Grab the list of players and iterate through it
			int currentIndex = 1;
			foreach (Database.playerData player in entry.Value.players)
			{
				if (player != null)//Since the array is always sized for 16 players, we must ignore ones that are not set up
				{
					Debug.WriteLine("Device ID: {0}, Concussed: {1}", currentIndex, player.brainDamage);
					currentIndex++;
				}
			}
		}
        return builder.Build();
	}
}
