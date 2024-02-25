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
public class Cell // represents what occupies the cell on the board
{
    public string Occupant { get; set; }

    public Cell(string occupant = "-") // Constructor of cell class
    {
        Occupant = occupant;
    }
}
public class Board
{
    public Cell[,] Grid { get; }

    public Board()               // Constructor of board class
    {
        Grid = new Cell[6, 6];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Grid[i, j] = new Cell();
            }
        }
    }
    public void Display(Player player1, Player player2)
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (player1.Position.X == j && player1.Position.Y == i) // Checks if the current cell matches with P1 position
                {
                    Console.Write("P1 ");
                }
                else if (player2.Position.X == j && player2.Position.Y == i) //  Checks if the current cell matches with P2 position
                {
                    Console.Write("P2 ");
                }
                else
                {
                    string occupant = Grid[i, j].Occupant;  // If a cll doesnt contain a player, it checks the occupant
                    if (occupant == "G")                    // Displays "G" if a cell cointains gem
                    {
                        Console.Write("G ");
                    }
                    else if (occupant == "O")               // Displays "O" if a cell cointains gem
                    {
                        Console.Write("O ");
                    }
                    else
                    {
                        Console.Write("- ");               // Displays "-" if a cell is empty
                    }
                }
            }
            Console.WriteLine();                           // Move to next line after displaying each row 
        }
    }
