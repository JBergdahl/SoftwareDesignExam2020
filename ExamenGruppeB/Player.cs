using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PG3302
{
    public class Player : ThreadProxy, IPlayer
    {
        public string Name { get; private set; }
        public List<ICard> Hand { get; set; }
        private readonly object _lock;

        // Counters for suits:
        public int HeartCount { get; set; }
        public int DiamondCount { get; set; }
        public int ClubCount { get; set; }
        public int SpadesCount { get; set; }
        public bool InQuarantine { get; set; }

        private readonly Deck _deck = Deck.GetDeck();
        private readonly GameBoard _gameBoard = GameBoard.GetGameBoard();
        private readonly SpecialCardHandler _specialCardHandler = SpecialCardHandler.GetSpecialCardAction();
        private readonly PlayerHandHandler _playerHandHandler;

        public Player(string name, object objectLock)
        {
            Name = name;
            InQuarantine = false;
            Hand = new List<ICard>();
            _playerHandHandler = new PlayerHandHandler(this);
            _lock = objectLock;
        }

        // Outputs current hand of player
        public void ShowHand()
        {
            foreach (var card in Hand)
            {
                if ((int) card.GetNumber() > 1 && (int) card.GetNumber() <= 10)
                {
                    Console.WriteLine((int)card.GetNumber() + " of " + card.GetSuit());
                }
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
            while (_running)
            {
                lock (_lock)
                {
                    if (!_gameBoard.GameEnd)
                    {
                        var card = _deck.CardFromDeck(); // Receive card from deck
                        if (card != null)
                        {
                            if (InQuarantine)
                            {
                                Console.WriteLine("No card for you, " + Name);
                                InQuarantine = false;
                            }
                            else if (!(card is CardDecorator)) // Normal card
                            {
                                AddCard(card); // Add card to player hand
                                RemoveCard(); // Remove card from player hand
                            }
                            else // Special card
                            {
                                _specialCardHandler.Action(card, this);
                            }

                            if (HeartCount >= 4 || DiamondCount >= 4 || ClubCount >= 4 ||
                                SpadesCount >= 4)
                            {
                                _gameBoard.GameEnd = true;
                            }
                        }
                    }
                }
                Thread.Sleep(20); // Pause before asking for next card
            }
        }

    }
}
