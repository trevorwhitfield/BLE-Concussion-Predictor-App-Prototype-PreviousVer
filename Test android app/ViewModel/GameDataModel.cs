using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Test_android_app.ViewModel;

[QueryProperty("Titletext", "Titletext")]
[QueryProperty("Entrytext", "Entrytext")]
public partial class GameDataModel : ObservableObject
{
    private Database.gameData game;

    /*
     * NOTES ON STRUCTURE:  Currently have a database built on arrays and an items list for each screen built on
     * ObservableCollections.  Arrays are easy to work with.  ObservableCollections are not but are required to use the libraries needed for
     * .net MAUI
     */

    public GameDataModel()
    {
        Items = new ObservableCollection<string>();
        game = Database.findGameData(Database.selectedGame);//Set the current game.  I belive this code is always ran when this is loaded
        Database.playerData[] Helmets = game.players;
        for (int i = 0; i < Helmets.Length; i++)
        {
            if (Helmets[i] == null)
                return;
            else
                //Items.Insert(Items.Count, Helmets[i].name);
                Items.Add(Helmets[i].name);
        }
    }

    [ObservableProperty]
    string titletext;

    [ObservableProperty]
    string entrytext;

    [ObservableProperty]
    ObservableCollection<string> items;

    [RelayCommand]
    void Add()
    {
        //Add our new item
        Debug.WriteLine("Helmet added to UI.");
        //below code is just for testing
        items.Add("Helmet "+ Entrytext);
        Debug.WriteLine("Helmet added to database.");
        game.addPlayer("Helmet " + Entrytext);
        Entrytext = string.Empty;
    }
    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
            game.delPlayer(s);
        }
    }
    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");//TODO:  Make it give a warning when adding a helmet if bluetooth is turned off.  See vid 7 of the tutorial
    }

    /*[RelayCommand]
    async Task Tap(string s)
    {
        Database.selectedGame = s;
        await Shell.Current.GoToAsync($"{nameof(HelmetSummary)}?Titletext={"YOO"}");//12:14 in video 6 for how to do this with complex data types
    }//&selectedGameData={selectedGameData}*/
}
