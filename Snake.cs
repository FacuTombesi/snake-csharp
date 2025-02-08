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

  public Move()
  {
    var head = (Body[0].x + Direction.x, Body[0].y + Direction.y);
    Body.Insert(0. head);
    Body.RemoveAt(Body.Cound - 1); // Remove the tail unless snake eats food
  }

  public Grow()
  {
    Body.Add(Body[Body.Cound + 1]);
  }
}