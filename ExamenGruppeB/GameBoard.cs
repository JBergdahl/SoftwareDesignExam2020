﻿using System;
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
            Console.WriteLine("Number of cards in deck: " + _deck.NormalCards.Capacity);
            Console.WriteLine("******************************************************");
            _deck.SpecialCards.ForEach(c => Console.WriteLine(c.DisplayCard()));
            Console.WriteLine("Number of cards in deck: " + _deck.SpecialCards.Capacity);
        }
    }
}
