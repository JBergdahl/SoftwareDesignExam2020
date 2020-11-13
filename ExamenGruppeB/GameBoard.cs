using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using deck;

namespace PG3302
{
    public class GameBoard
    {
        // Singleton pattern, makes sure only one instance of GameBoard is created
        private static readonly GameBoard Instance = new GameBoard();
        public static GameBoard GetGameBoard()
        {
            return Instance;
        }

        public bool GameEnd = false;
        private readonly Deck _deck;
        public List<Player> Players;
        private readonly object _lock = new object(); // Object lock for multi threading 
        public GameBoard()
        { 
            _deck = Deck.GetDeck(); // Init deck
        }

        private void CreatePlayers()
        {
            Players = new List<Player>(); // Init list of players
            int i; // Player input saved in i

            do
            {
                var input = Console.ReadLine(); // Read input
                int.TryParse(input, out i); // Validation
                if (i >= 2 && i <= 4)
                {
                    break; // Break out of while loop if input is between 2 and 4
                }
            } while (true);

            for (var j = 1; j <= i; j++)
            {
                Players.Add(PlayerFactory.CreateNewPlayer(j, _lock)); // Create players based on input
            }
        }

        public void Play()
        {
            Console.WriteLine("Hi, and welcome to this wonderful card game!");
            Console.WriteLine("How many players? (2-4)");
            CreatePlayers();

            for (var i = 0; i < 4; i++)
            {
                foreach (var player in Players)
                {
                    player.AddCard(_deck.CardFromDeck(false));
                }
            }

            foreach (var player in Players)
            {
                player.Start(player.Name);
            }

            foreach (var player in Players)
            {
                Console.WriteLine(player.Name + " requesting cards");
            }

            while (!GameEnd)
            {
                // Waiting for win condition
            }

            foreach (var player in Players)
            {
                player.Stop();
            }

            foreach (var player in Players)
            {
                Console.WriteLine("\n" + player.Name + ":");
                player.ShowHand();
            }
            Console.WriteLine("\n");
            foreach (var player in Players)
            {
                Console.WriteLine(player.Hand.Count);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Cards left in normal deck: " + _deck.NormalCards.Count);
            Console.WriteLine("Cards left in special deck: " + _deck.SpecialCards.Count);

            foreach (var card in _deck.SpecialCards)
            {
                Console.WriteLine(card.GetNumber() + " " + card.GetSuit());
            }
        }
    }
}
