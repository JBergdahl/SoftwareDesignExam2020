using System;

namespace PG3302
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameBoard = GameBoard.GetGameBoard();
            gameBoard.Play();
        }
    }
}
