using System;

public class Food
{
  private Random _random = new Random();

  public (int x, int y) Position { get; private set; }

  public void GenerateNewPosition(int width, int height)
  {
    Position = (_random.Next(1, width - 1), _random.Next(1, height - 1));
  }
}