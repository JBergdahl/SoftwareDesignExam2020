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

        public bool GameEnd { get; set; }
        private readonly Deck _deck;
        public List<Player> Players { get; set; }
        private readonly object _lock = new object(); // Object lock for multi threading 
        public GameBoard()
        {
            GameEnd = false;
            _deck = Deck.GetDeck(); // Init deck
        }

        public void Play()
        {
            Console.WriteLine("Hi, and welcome to this wonderful card game!");
            Console.WriteLine("How many players? (2-4)");
            CreatePlayers();
            PlayerInit();

            while (!GameEnd)
            {
                // Wait for game to finish
                Thread.Sleep(1000);
            }

            foreach (var players in Players)
            {
                // Stop player threads
                players.Stop();
            }
            
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
                    break; // Break out of while loop if input is 2, 3 or 4
                }
                Console.WriteLine("Invalid input");
            } while (true);

            for (var j = 1; j <= i; j++)
            {
                Players.Add(PlayerFactory.CreateNewPlayer(j, _lock)); // Create players based on input
            }
            foreach (var player in Players)
            {
                // Callback method setup
                player.Winner += Player_Winner;
            }
        }

        private void PlayerInit()
        {
            for (var i = 0; i < 4; i++)
            {
                // Deal start cards to players
                foreach (var player in Players)
                {
                    player.AddCard(_deck.CardFromDeck(false));
                }
            }

            foreach (var player in Players)
            {
                // Start player threads
                player.Start(player.Name);
            }

            foreach (var player in Players)
            {
                Console.WriteLine(player.Name + " requesting cards");
            }
        }

        // Callback method
        // Invoked by player
        private void Player_Winner(object sender, Player player)
        {
            // Winner info output:
            Console.WriteLine("\nWe have a winner!:");
            Console.WriteLine(player.Name + " current hand:");
            player.ShowHand();
        }
    }
}
