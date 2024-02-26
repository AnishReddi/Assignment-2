using System;
class Program
{

    static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}


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

    public bool IsValidMove(Player player, char direction)
    {
        // Gets the current position of the player
        int x = player.Position.X;
        int y = player.Position.Y;

        switch (direction)
        {
            case 'U':
                y--;
                break;
            case 'D':
                y++;
                break;
            case 'L':
                x--;
                break;
            case 'R':
                x++;
                break;
            default:
                break;
        }

        if (x >= 0 && x < 6 && y >= 0 && y < 6 && Grid[y, x].Occupant != "O") // checks if the new postion is within board boundary and does not contain an obstalce
        {
            return true;    // returns true for a valid move                 
        }
        return false;      // returns false for a valid move
    }

    public void CollectGem(Player player)
    {
        Cell cell = Grid[player.Position.Y, player.Position.X]; // gets the cell at the player current position on the board
        if (cell.Occupant == "G")
        {
            player.GemCount++;
            cell.Occupant = "-";
        }
    }
}

public class Game
{

    private Board board;
    private Player player1;
    private Player player2;
    private Player currentTurn;
    private int totalTurns;

    public Game()
    {
        board = new Board();
        player1 = new Player("P1", new Position(0, 0));
        player2 = new Player("P2", new Position(5, 5));
        currentTurn = player1;
        totalTurns = 0;

        InitializeGame();
    }

    private void InitializeGame()
    {
        // Add gems to the board
        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {
            int x = random.Next(0, 6);
            int y = random.Next(0, 6);
            if (board.Grid[y, x].Occupant == "-")
            {
                board.Grid[y, x].Occupant = "G";
            }
            else
            {
                i--;
            }
        }

        // Add obstacles to the board
        for (int i = 0; i < 5; i++)
        {
            int x = random.Next(0, 6);
            int y = random.Next(0, 6);
            if (board.Grid[y, x].Occupant == "-")
            {
                board.Grid[y, x].Occupant = "O";
            }
            else
            {
                i--;
            }
        }
    }

    public void Start()
    {
        while (!IsGameOver())   // Loop to continue the game until its over
        {
            Console.WriteLine($"Turn {totalTurns + 1}: {currentTurn.Name}'s turn");
            board.Display(player1, player2);

            Console.WriteLine("Enter move (U/D/L/R): ");
            char move = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (board.IsValidMove(currentTurn, move)) // Checks if the move is valid
            {
                currentTurn.Move(move);
                board.CollectGem(currentTurn);
                totalTurns++;
                SwitchTurn();
            }
            else
            {
                Console.WriteLine("Invalid move");
            }
        }

        AnnounceWinner();
    }

    private void SwitchTurn()
    {
        currentTurn = currentTurn == player1 ? player2 : player1; // Switching turns between players
    }

    private bool IsGameOver() // Checks if the total number of turns is greater or equal to 30
    {
        return totalTurns >= 30;
    }

    private void AnnounceWinner() // Announces the winner after reaching a total of 30 moves
    {
        Console.WriteLine("Game over!");
        Console.WriteLine($"P1 gems: {player1.GemCount}");
        Console.WriteLine($"P2 gems: {player2.GemCount}");
        if (player1.GemCount > player2.GemCount)
        {
            Console.WriteLine("P1 wins!");
        }
        else if (player1.GemCount < player2.GemCount)
        {
            Console.WriteLine("P2 wins!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }
}

