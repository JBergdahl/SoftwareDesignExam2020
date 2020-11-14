using System;

namespace PG3302
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameBoard = GameBoard.GetGameBoard(); // Get new game board
            gameBoard.Play(); // Start game
            Console.ReadKey(true);
        }
    }
}
