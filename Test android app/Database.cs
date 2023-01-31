
//using Android.Media;
//using Java.Lang;
//using Microsoft.UI.Xaml;
//using Foundation;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Test_android_app;

public class Database
{
    //public Dictionary<int,string> data = new Dictionary<int,string>();

    public gameData selectedData;
    public static string selectedGame;

    public class playerData
    {
        public string name = "Billy";
        public string id;
        public bool brainDamage;
        public static playerData New(string id)
        {
            playerData newPlayer = new playerData();
            newPlayer.id = id;
            newPlayer.name = id;
            return newPlayer;
        }
    }

    public class gameData
    {
        public string date = "1/1/1970";//default date
        public string name = "Label";//default name
        public string searcherText = "Label (1/1/1970)";
        public playerData[] players = new Database.playerData[16];//Array of playerdata; allows for up to 16 players
        public void addPlayer(string id)
        {
            //Find next open slot in our list
            int nextIndex = 0;
            foreach (var _ in players)
            {
               if (_ != null)
                    nextIndex++;
               else
                    break;

            }
            if (nextIndex <= 16)
            {
                players[nextIndex] = playerData.New(id);
                Debug.WriteLine("number.");
                Debug.WriteLine(nextIndex);
                Debug.WriteLine("...");
            }
            else
                Debug.WriteLine("ERR: Too many players for game data.");
            
        }
        public void delPlayer(string name)//TODO:  Make name and id one thing, then make it so that two people cannot have the same name
        {
            bool found = false;
            for (int i=0; i<players.Length; i++)
            {
                if (players[i] == null)
                    return;
                else
                    if (players[i].name == name)
                    players[i] = null;
                found = true;
            }
            if (found==false)
                Debug.WriteLine("Couldn't find a player to delete!");
        }
        public static gameData newGame(string date,string name)//Not used yet, but you cannot make new variables mid-iterator
        {
            gameData newgame = new gameData();
            newgame.date = date;
            newgame.name = name;
            newgame.searcherText = name + " (" + date + ")";
            data.Add(data.Count, newgame);
            return newgame;
        }

    }

    public static Dictionary<int, gameData> data = new Dictionary<int, gameData>();

    //Load data from file
    public static void loadData()
    {
       // gameData newdata = gameData.newGame(DateTime.UtcNow.Date.ToString("MM/dd/yyyy"),"test");// "11/17/2022");
       // data.Add(1,newdata);
    }

    //Send data to other classes
    public static Dictionary<int,gameData> readDatabase()
    {
        return data;
    }
    //TODO:  Properly document classes, as was done in computer science I
    public static gameData findGameData(string name)
    {
        Debug.WriteLine("Searching");
        foreach (KeyValuePair<int, gameData> entry in data)
        {
            Debug.WriteLine(entry.Value?.searcherText);
            Debug.WriteLine(name);
            Debug.WriteLine("Query");
            if (entry.Value?.searcherText == name)
                {
                return entry.Value;
            }
        }
        Debug.WriteLine("NO ENTRY FOUND");
        return null;
    }
}