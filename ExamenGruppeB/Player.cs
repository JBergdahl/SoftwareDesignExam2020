using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PG3302
{
    public class Player : ThreadProxy, IPlayer
    {
        public string Name { get; private set; }
        public List<ICard> Hand { get; set; } // List of player cards
        private readonly object _lock; // Passed from game board

        public event EventHandler<Player> Winner;

        // Counters for suits:
        public int HeartCount { get; set; }
        public int DiamondCount { get; set; }
        public int ClubCount { get; set; }
        public int SpadesCount { get; set; }
        // Quarantine status:
        public bool InQuarantine { get; set; }

        private readonly Deck _deck = Deck.GetDeck();
        private readonly GameBoard _gameBoard = GameBoard.GetGameBoard();
        private readonly SpecialCardHandler _specialCardHandler = SpecialCardHandler.GetSpecialCardAction();
        private readonly PlayerHandHandler _playerHandHandler;

        public Player(string name, object objectLock)
        {
            Name = name; // Set name
            InQuarantine = false; // Start not in quarantine
            Hand = new List<ICard>(); // Create new list
            _playerHandHandler = new PlayerHandHandler(this); // Player hand handler
            _lock = objectLock; // Lock from game board
        }

        // Outputs current hand of player
        public void ShowHand()
        {
            foreach (var card in Hand)
            {
                // Print number + suit if not a face card
                if ((int) card.GetNumber() > 1 && (int) card.GetNumber() <= 10)
                {
                    Console.WriteLine((int)card.GetNumber() + " of " + card.GetSuit());
                }
                // Print face + suit
                else
                {
                    Console.WriteLine(card.GetNumber() + " of " + card.GetSuit());
                }
            }
        }

        public void AddCard(ICard card)
        {
            if (card != null)
            {
                Hand.Add(card); // Add passed card to list
                Console.WriteLine(Name + " receiving card: " + card.DisplayCard(Name));
                if (!(card is CardJoker))
                {
                    _playerHandHandler.SuitCounter(card); // Update suit counter
                }
            }
        }

        public void RemoveCard()
        {
            var card = _playerHandHandler.CardToThrow(); // Decide which cart to throw
            if (card != null)
            {
                Console.WriteLine(Name + " throwing card: " + card.GetNumber() + " of " + card.GetSuit());
                if (card is CardJoker cardCast)
                {
                    cardCast.CardJokerRemove(card, this); // This shouldn't happen
                }
                _deck.CardToDeck(card); // Send card to dealer
            }
        }

        protected override void Task() // Multi threading task
        {
            while (Running)
            {
                lock (_lock) // Lock from game board, shared by all players
                {
                    if (!_gameBoard.GameEnd) // Game hasn't ended
                    {
                        if (InQuarantine) // Is player in quarantine?
                        {
                            Console.WriteLine("No card for you, " + Name);
                            InQuarantine = false; // No longer in quarantine
                        }
                        else
                        {
                            var card = _deck.CardFromDeck(); // Receive card from deck
                            if (card != null)
                            {
                                if (!(card is CardDecorator)) // Normal card
                                {
                                    AddCard(card); // Add card to player hand
                                    RemoveCard(); // Remove card from player hand
                                }
                                else // Special card action
                                {
                                    _specialCardHandler.Action(card, this);
                                }

                                // Check if player has 4 or more of the same suit = win
                                if (HeartCount >= 4 || DiamondCount >= 4 || ClubCount >= 4 ||
                                    SpadesCount >= 4)
                                {
                                    Winner?.Invoke(this, this); // Invoke callback method in GameBoard
                                    _gameBoard.GameEnd = true; // End game
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(20); // Pause before asking for next card
            }
        }

    }
}
