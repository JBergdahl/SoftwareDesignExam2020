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
            _deck = Deck.GetNewDeck();
        }

        private void CreatePlayers(int num)
        {
            Players = new List<Player>();
            for (var i = 1; i <= num; i++)
            {
                Players.Add(PlayerFactory.CreateNewPlayer(i));
            }
        }

        public void Play()
        {
            Console.WriteLine("Hi, and welcome to this wonderful card game!");
            Console.WriteLine("How many players? (2-4)");
            int i = Convert.ToInt32(Console.ReadLine());
            CreatePlayers(i);
            foreach (var player in Players)
            {
                Console.WriteLine(player.Name);
            }
        }
    }
}
