using System;
using System.Collections.Generic;

public class Snake
{
  public List<(int x, int y)> Body { get; private set; }
  public (int x, int y) Direction { get; set; }

  public Snake()
  {
    Body = new List<(int, int)> { (10, 10) }; // Set initial position
    Direction = (1, 0); // Moving right initially
  }


}