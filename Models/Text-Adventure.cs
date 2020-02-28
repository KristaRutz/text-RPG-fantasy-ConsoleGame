using System;
using System.Collections.Generic;

namespace TextAdventure.Models
{
  public class Game
  {
    public string PlayerName { get; set; }
    public string Difficulty { get; set; }
    public List<string> Items { get; set; }
    public Location CurrentLocation { get; set; }

    public Game(string playerName, string difficulty, Location location)
    {
      PlayerName = playerName;
      Difficulty = difficulty;
      Items = new List<string>();
      CurrentLocation = location;
    }

    public void AddItem(string item)
    {
      Items.Add(item);
    }
  }
}