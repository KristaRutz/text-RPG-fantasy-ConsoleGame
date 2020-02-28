using System;
using System.Collections.Generic;

namespace TextAdventure.Models
{
  public class Location
  {
    public string Name { get; set; }
    public int VisitCount { get; set; }
    public List<string> Items { get; set; }

    public Location(string name, List<string> items)
    {
      Name = name;
      VisitCount = 0;
      Items = items;
    }

    public void Visit()
    {
      VisitCount++;
    }
  }
}