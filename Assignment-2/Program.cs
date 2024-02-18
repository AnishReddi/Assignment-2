using System;

namespace GemCollectionGame
{
    class Program
    {
        static string[,] board = new string[6, 6];
        static int[,] gems = new int[6, 6];
        static int[,] obstacles = new int[6, 6];
        static int[] player1Position = new int[2] { 0, 0 };
        static int[] player2Position = new int[2] { 5, 5 };
        static int player1Gems = 0;
        static int player2Gems = 0;
        static int totalGems = 5;
        static int maxMoves = 15;
        static int maxObstacles = 0;

        static void Main(string[] args)
        {
            InitializeBoard();
            PlaceGems();
            PlaceObstacles();
            board[player1Position[0], player1Position[1]] = "P1";
            board[player2Position[0], player2Position[1]] = "P2";
            DisplayBoard();
            PlayGame();
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    board[i, j] = "-";
                }
            }
        }

        static void PlaceGems()
        {
            Random rnd = new Random();
            int gemsPlaced = 0;
            while (gemsPlaced < totalGems)
            {
                int x = rnd.Next(0, 6);
                int y = rnd.Next(0, 6);
                if (gems[x, y] == 0)
                {
                    gems[x, y] = 1;
                    board[x, y] = "G";
                    gemsPlaced++;
                }
            }
        }


        static void PlaceObstacles()
        {
            Random rnd = new Random();
            int obstaclesPlaced = 0;
            while (obstaclesPlaced < maxObstacles)
            {
                int x = rnd.Next(0, 6);
                int y = rnd.Next(0, 6);
                if (x != 0 || y != 0)
                {
                    if (x != 0 || y != 0)
                    {
                        if (obstacles[x, y] == 0)
                        {
                            obstacles[x, y] = 1;
                            board[x, y] = "O";
                            obstaclesPlaced++;
                        }
                    }
                }
            }
        }
        static void DisplayBoard()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void PlayGame()
        {
            bool gameOver = false;
            int currentPlayer = 1;
            int moves = 0;

            while (!gameOver)
            {
                Console.WriteLine($"Player {currentPlayer}'s turn:");
                if (currentPlayer == 1)
                    PlayTurn(player1Position, ref player1Gems, "P1");
                else
                    PlayTurn(player2Position, ref player2Gems, "P2");

                moves++;

                if (player1Gems + player2Gems == totalGems * 2 || moves >= maxMoves)
                    gameOver = true;

                currentPlayer = currentPlayer == 1 ? 2 : 1;
            }
            Console.WriteLine("Game Over!");

            if (player1Gems > player2Gems)
                Console.WriteLine($"Player 1 wins with {player1Gems} gems!");
            else if (player2Gems > player1Gems)
                Console.WriteLine($"Player 2 wins with {player2Gems} gems!");
            else
                Console.WriteLine($"It's a tie! Both players have collected {player1Gems} gems!");
        }

        static void PlayTurn(int[] playerPosition, ref int playerGems, string playerSymbol)
        {
            DisplayBoard();
            Console.WriteLine("enter movement (u/d/l/r):");
            string move = Console.ReadKey().Key.ToString().ToUpper();
            Console.WriteLine();

            int newX= playerPosition[0];
            int newY = playerPosition[1];

            switch (move)
            {

            }
        }
    }
}
    
    
    
    


