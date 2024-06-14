using System;

namespace TicTacToe
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // Positions on the board
        static int player = 1; // By default player 1 starts
        static int choice; // User choice for position
        static int flag = 0; // 1 means someone has won, -1 means draw, 0 means match is still running

        static int[,] winningCombinations = new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 3, 6, 9 },
            { 1, 5, 9 },
            { 3, 5, 7 }
        };

        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); // Whenever loop restarts we clear the console

                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Turn: Player 2");
                }
                else
                {
                    Console.WriteLine("Turn: Player 1");
                }
                Console.WriteLine("\n");

                Board(); // Calling the board function
                
                // Check if the position where the user wants to mark is not already taken
                choice = int.Parse(Console.ReadLine());

                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, the row {0} is already marked with a {1}.", choice, arr[choice]);
                    Console.WriteLine("\n");
                }
                flag = CheckWin(); // Check whether someone has won or not
            }
            while (flag != 1 && flag != -1);

            Console.Clear(); // When a match is over clear the console
            Board(); // Show the final board

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            Console.ReadLine();
        }

        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        private static int CheckWin()
        {
            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                if (arr[winningCombinations[i, 0]] == arr[winningCombinations[i, 1]] &&
                    arr[winningCombinations[i, 1]] == arr[winningCombinations[i, 2]])
                {
                    return 1;
                }
            }

            if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' &&
                arr[4] != '4' && arr[5] != '5' && arr[6] != '6' &&
                arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }

            return 0;
        }
    }
}
