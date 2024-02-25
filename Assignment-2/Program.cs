using System;

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)  // Constructor of Position class
    {
        X = x;
        Y = y;
    }
}
public class Player
{
    public string Name { get; }  // Set only once during object initialisation
    public Position Position { get; set; } // Represents the current position of a player and Allows to be modified as the player moves
    public int GemCount { get; set; } //Represents the number of gems collected, Increments when gems are collected

    public Player(string name, Position position) // Constructor of Player class
    {
        // Initialise Name, Position, Gems.
        Name = name;
        Position = position;
        GemCount = 0;
    }
    public void Move(char direction) // Movement keys
    {
        switch (direction)
        {
            case 'U':
                Position.Y--;
                break;
            case 'D':
                Position.Y++;
                break;
            case 'L':
                Position.X--;
                break;
            case 'R':
                Position.X++;
                break;
            default:
                break;
        }
    }
}