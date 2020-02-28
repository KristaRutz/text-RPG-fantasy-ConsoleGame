using System;
using System.Collections.Generic;
using TextAdventure.Models;

public class Program
{

  public static Game game;
  public static Location home = new Location("home", new List<string>(){"food", "water"});
  public static Location forest = new Location("forest", new List<string>(){"stick", "berries"});
  public static Location castle = new Location("castle", new List<string>(){"gold"});
  public static Location market = new Location("market", new List<string>(){"gold", "medicine"});
  public static Location currentLoc = home;


  public static void Main()
  {
    // DisplayLocationInfo(castle);
    // DisplayLocationInfo(market);
    StartAdventure();
    ChooseLocation();
  }

  public static void DisplayLocationInfo(Location loc)
  {
    Console.WriteLine(loc.Name);
    for (int index = 0; index < loc.Items.Count; index++)
    {
      Console.WriteLine(loc.Items[index]);
    }
    Console.WriteLine(loc.VisitCount);
  }

  public static void StartAdventure()
    {
      Console.WriteLine("Welcome to the adventure of your life.");
      Console.WriteLine("Enter name");
      string playerName = Console.ReadLine();
      string difficulty = SetDifficulty();
      game = new Game(playerName, difficulty, currentLoc);
      SetInitialItems();

      Console.WriteLine($"{game.Difficulty.ToUpper()} MODE");
      Console.WriteLine($"Your name is {game.PlayerName} and you have a {game.Items[0]}.");
    }

  public static string SetDifficulty()
  {
    Console.WriteLine("Enter difficulty level: [easy/medium/hard]");
    string difficulty = Console.ReadLine().ToLower();

    if (difficulty == "hard" || difficulty == "medium" || difficulty == "easy")
    {
      Console.WriteLine(difficulty);
      return difficulty;
    }
    else
    {
      Console.WriteLine(difficulty);
      return SetDifficulty();
    }
  }

  public static void SetInitialItems()
  {
    Console.WriteLine("Choose an item: [sword/bow/staff]");

    string item = Console.ReadLine().ToLower();
    if (item == "sword" || item == "bow" || item == "staff")
    {
      game.AddItem(item);
    } 
    else if (item == "gun")
    {
      game.AddItem("gun");
    }
    else 
    {
      game.AddItem("rock");
    }
  }

  public static void ChooseLocation()
  {
    Console.WriteLine("Where would you like to go? [market/castle/forest]");
    string currentLocation = Console.ReadLine().ToLower();

    if (currentLocation == "market")
    {
      currentLoc = market;
    }
    else if (currentLocation == "castle")
    {
      currentLoc = castle;
    }
    else if (currentLocation == "forest")
    {
      currentLoc = forest;
    } 
    else 
    {
      Console.WriteLine("You just walked in a circle!");
      ChooseLocation();
    }
    EnterLocation(currentLoc);
  }

  public static void EnterLocation(Location location){

    location.VisitCount++;

    if (location.VisitCount == 1)
    {
      Console.WriteLine($"Welcome to the {currentLoc.Name}. You look around and take in the view.");
    } 
    else
    {
      Console.WriteLine($"Welcome back to the {currentLoc.Name}.");
    }
    Menu();
  }

  public static void Menu()
  {
    Console.WriteLine($"Type '1' to travel to a new location, Type '2' to search for items, Type '3' to use your items");
    string choice = Console.ReadLine();
    if (choice == "1")
    {
      ChooseLocation();
    }
    else if (choice == "2")
    {
      // search for items
    }
    else if (choice == "3")
    {
      UseItems();
    } 
    else 
    {
      Console.WriteLine("Please choose an option");
      Menu();
    }
  }

  public static void UseItems()
  {
    Console.WriteLine("The moral of the story is to use what you have. You win!!");
  }
}