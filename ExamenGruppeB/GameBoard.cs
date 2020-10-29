using System;
using System.Collections.Generic;
using System.Text;
using deck;

namespace ExamenGruppeB
{
    class GameBoard
    {
        private static readonly GameBoard Instance = new GameBoard();

        private readonly Deck _deck;
        private readonly Random _rn;
        public GameBoard()
        { 
            _deck = Deck.GetNewDeck();
            _rn = new Random();
        }
        public void Play()
        {
            _deck.CardsInDeck.ForEach(c => Console.WriteLine(c.DisplayCard()));
            Console.WriteLine("Number of cards in deck: " + _deck.CardsInDeck.Capacity);
        }

        public static GameBoard GetNewGameBoard()
        {
            return Instance;
        }
    }
}
