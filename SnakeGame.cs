using System;
using System.Threading;

public class SnakeGame
{
  private Snake _snake;
  private Food _food;
  private const int Width = 20;
  private const int Height = 20;
  private bool _isGameOver;

  public SnakeGame()
  {
    _snake = new Snake();
    _food = new Food();
    _food.GenerateNewPosition(Width, Height);
    _isGameOver = false;
  }

  public void Run()
  {
    Console.CursorVisible = false;

    while (!_isGameOver)
    {
      Draw();
      Input();
      Update();
      Thread.Sleep(100); // Game speed
    }

    Console.Clear();
    Console.WriteLine("Game Over!");
  }

  public void Draw()
  {
    Console.Clear();

    // Draw borders
    for (int i = 0; i <= Width; i++)
      Console.Write("#");
    Console.WriteLine();

    for (int y = 0; y < Height; y++)
    {
      Console.Write("#");
      for (int x = 0; x < Width; x++)
      {
        if (_snake.Body.Contains((x, y)))
        {
          Console.Write("0");
        }
        else if ((x, y) == _food.Position)
        {
          Console.Write("F");
        }
        else
        {
          Console.Write(" ");
        }
      }
      Console.Write("#");
      Console.WriteLine();
    }

    for (int i = 0; i <= Width; i++)
      Console.Write("#");
    Console.WriteLine();
  }

  private void Input()
  {
    if (!Console.KeyAvailable) return;

    var key = Console.ReadKey(true).Key;

    switch (key)
    {
      case ConsoleKey.UpArrow when _snake.Direction != (0, 1):
        _snake.Direction = (0, -1);
        break;
      case ConsoleKey.DownArrow when _snake.Direction != (0, -1):
        _snake.Direction = (0, 1);
        break;
      case ConsoleKey.LeftArrow when _snake.Direction != (1, 0):
        _snake.Direction = (-1, 0);
        break;
      case ConsoleKey.RightArrow when _snake.Direction != (-1, 0):
        _snake.Direction = (1, 0);
        break;
    }
  }

  private void Update()
  {
    _snake.Move();

    // Check for food collision
    if (_snake.Body[0] == _food.Position)
    {
      _snake.Grow();
      _food.GenerateNewPosition(Width, Height);
    }

    // Check for wall collision
    var head = _snake.Body[0];

    if (head.x < 0 || head.x >= Width || head.y < 0 || head.y >= Height)
    {
      _isGameOver = true;
    }

    // Check for snake collision
    for (int i = 1; i < _snake.Body.Count; i++)
    {
      if (head == _snake.Body[i])
      {
        _isGameOver = true;
      }
    }
  }
}