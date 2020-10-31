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
        private List<Player> Players { get; set; }
        public GameBoard()
        { 
            _deck = Deck.GetNewDeck(); // Init deck
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
                Players.Add(PlayerFactory.CreateNewPlayer(j)); // Create players based on input
            }
        }

        public void Play()
        {
            Console.WriteLine("Hi, and welcome to this wonderful card game!");
            Console.WriteLine("How many players? (2-4)");
            CreatePlayers();

            foreach (var player in Players)
            {
                Console.WriteLine(player.Name);
            }
        }
    }
}
