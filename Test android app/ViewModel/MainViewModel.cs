using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Test_android_app.ViewModel;

public partial class MainViewModel : ObservableObject
 {
     public MainViewModel()
    {
        Items = new ObservableCollection<string>();
        //For some reason this HAS to be called Items, and HAS to be an ObservableCollection<string>
        // Database.readDatabase();//
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;//Renaming this breaks the references of "Text" below????????
    //Database.gameData selectedGameData;

    [RelayCommand]
    void Add()
    {
        //Add our new item
        if (string.IsNullOrWhiteSpace(Text))
            return;
        string sText = Text + " (" + DateTime.UtcNow.Date.ToString("MM/dd/yyyy") + ")";
        items.Add(sText);
        // selectedGameData = Database.gameData.newGame(Text);
        Database.gameData.newGame(DateTime.UtcNow.Date.ToString("MM/dd/yyyy"),Text);
        Text = string.Empty;
    }
    [RelayCommand]
    void Delete(string s)
    {
        if(Items.Contains(s))
        {
            Items.Remove(s);
        }
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        Database.selectedGame = s;
        await Shell.Current.GoToAsync($"{nameof(GameDataPage)}?Titletext={s}&Text2={"hello"}");//12:14 in video 6 for how to do this with complex data types
    }//&selectedGameData={selectedGameData}
}