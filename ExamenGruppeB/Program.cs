using System;

namespace ExamenGruppeB
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard gameBoard = GameBoard.GetNewGameBoard();
            gameBoard.Play();

            /*
             *  private ICard GetRandomCard()
                {
                    var index = _rn.Next(_deck.CardsInDeck.Count);
                    return _deck.CardsInDeck[index];
                }
             */
        }
    }
}
