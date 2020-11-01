using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using deck;

namespace ExamenGruppeB
{
    public class GameBoard
    {
        // Singleton pattern, makes sure only one instance of GameBoard is created
        private static readonly GameBoard Instance = new GameBoard();
        public static GameBoard GetGameBoard()
        {
            return Instance;
        }

        private readonly Deck _deck;
        private List<Player> _players;
        private readonly Dealer _dealer;
        public GameBoard()
        { 
            _deck = Deck.GetDeck(); // Init deck
            _dealer = Dealer.GetDealer();
        }

        private void CreatePlayers()
        {
            _players = new List<Player>(); // Init list of players
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
                _players.Add(PlayerFactory.CreateNewPlayer(j)); // Create players based on input
            }
        }

        public void Play()
        {
            Console.WriteLine("Hi, and welcome to this wonderful card game!");
            Console.WriteLine("How many players? (2-4)");
            CreatePlayers();

            foreach (var player in _players)
            {
                player.AddCard(_deck.CardFromDeck());
                player.AddCard(_deck.CardFromDeck());
                player.AddCard(_deck.CardFromDeck());
                player.AddCard(_deck.CardFromDeck());
            }

            _dealer.Start();
            foreach (var player in _players)
            {
                player.Start();
            }
            Thread.Sleep(1000);

            foreach (var player in _players)
            {
                player.Stop();
            }
            _dealer.Stop();

            foreach (var player in _players)
            {
                player.ShowHand();
            }

            /*
            _players[0].AddCard(_deck.CardFromDeck());
            _players[0].AddCard(_deck.CardFromDeck());
            _players[0].AddCard(_deck.CardFromDeck());
            _players[0].AddCard(_deck.CardFromDeck());
            Console.WriteLine(_players[0].HeartCount);
            Console.WriteLine(_players[0].DiamondCount);
            Console.WriteLine(_players[0].ClubCount);
            Console.WriteLine(_players[0].SpadesCount);
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("***************************************");
                _players[0].AddCard(_deck.CardFromDeck());
                _players[0].RemoveCard();
                Console.WriteLine(_players[0].HeartCount);
                Console.WriteLine(_players[0].DiamondCount);
                Console.WriteLine(_players[0].ClubCount);
                Console.WriteLine(_players[0].SpadesCount);
                Console.WriteLine("***************************************");
            }
            _players[0].ShowHand();
            */
        }
    }
}
