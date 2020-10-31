using System;

namespace ExamenGruppeB
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameBoard = GameBoard.GetNewGameBoard();
            gameBoard.Play();
        }
    }
}
