using System;

namespace GemCollectionGame
{
    class Program
    {
        static char[,] board = new char[6, 6];
        static int[,]  gems = new int[6, 6];
        static int[,]  obstacles = new int[6, 6];
        static int[] player1position = new int[2];
        static int[] player2position = new int[2];
        static int player1gems = 0;
        static int player2gems = 0;
        static int totalgems = 5;
        static int maxMoves = 15;

        static void Main(string[] args)
        {
            InitializeBoard();
            PlaceGems();
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        static void PlaceGems()
        {
            Random rnd = new Random();
            int gemsPlaced = 0;
            while (gemsPlaced < totalgems)
            {
                int x = rnd.Next(0, 6);
                int y = rnd.Next(0, 6);
                if (gems[x, y] == 0)
                {
                    gems[x, y] = 1;
                    board[x, y] = 'G';
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
                int x= rnd.Next(0, 6);
                int y = rnd.Next(0, 6); 
                if(x !=0 || y !=0)
                {
                    if 
                }
            }
        }
    }
    
        

    


}