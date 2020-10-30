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
            ICard card = _deck.CardFromDeck();
            ICard card2 = _deck.CardFromDeck();
            ICard card3 = _deck.CardFromDeck();
            ICard card4 = _deck.CardFromDeck();
            ICard card5 = _deck.CardFromDeck();
            Console.WriteLine("Number of cards in deck: " + _deck.NormalCards.Count);
            Console.WriteLine("Number of cards in deck: " + _deck.SpecialCards.Count);
            Console.WriteLine("******************************************************");
            _deck.CardToDeckRange(card, card2, card3, card4, card5);
            Console.WriteLine("Number of cards in deck: " + _deck.NormalCards.Count);
            Console.WriteLine("Number of cards in deck: " + _deck.SpecialCards.Count);
            Console.WriteLine("******************************************************");
            Console.WriteLine("Last of normal cards: " + _deck.NormalCards[_deck.NormalCards.Count - 1].DisplayCard());
            Console.WriteLine("Last of special cards: " + _deck.SpecialCards[_deck.SpecialCards.Count - 1].DisplayCard());
        }
    }
}
