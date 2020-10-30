using System;
using System.Collections.Generic;
using System.Text;
using deck;

namespace ExamenGruppeB
{
    class GameBoard
    {
        // Singleton pattern, makes sure only one instance of GameBoard is created
        private static readonly GameBoard Instance = new GameBoard();
        public static GameBoard GetNewGameBoard()
        {
            return Instance;
        }

        private readonly Deck _deck;
        private readonly Random _rn;
        public GameBoard()
        { 
            _deck = Deck.GetNewDeck();
            _rn = new Random();
        }
        public void Play()
        {
            _deck.NormalCards.ForEach(c => Console.WriteLine(c.DisplayCard()));
            Console.WriteLine("Number of cards in deck: " + _deck.NormalCards.Count);
            Console.WriteLine("******************************************************");
            _deck.SpecialCards.ForEach(c => Console.WriteLine(c.DisplayCard()));
            Console.WriteLine("Number of cards in deck: " + _deck.SpecialCards.Count);
            Console.WriteLine("******************************************************");
            List<ICard> card = _deck.CardFromDeckRange(5);
            card.ForEach(c => Console.WriteLine(c.DisplayCard()));
            Console.WriteLine("Number of cards in deck: " + _deck.NormalCards.Count);
            Console.WriteLine("Number of cards in deck: " + _deck.SpecialCards.Count);
            Console.WriteLine("******************************************************");
            _deck.CardToDeckRange(card[0], card[1], card[2], card[3], card[4]);
            Console.WriteLine("Number of cards in deck: " + _deck.NormalCards.Count);
            Console.WriteLine("Number of cards in deck: " + _deck.SpecialCards.Count);
            Console.WriteLine("******************************************************");
            Console.WriteLine("Last of normal cards: " + _deck.NormalCards[_deck.NormalCards.Count - 1].DisplayCard());
            Console.WriteLine("Last of special cards: " + _deck.SpecialCards[_deck.SpecialCards.Count - 1].DisplayCard());
        }
    }
}
