using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExamenGruppeB
{
    public class Player : ThreadProxy, IPlayer
    {
        public string Name { get; set; }
        public List<ICard> Hand { get; set; }
        private readonly object _lock;

        // Counters for suits:
        public int HeartCount { get; set; }
        public int DiamondCount { get; set; }
        public int ClubCount { get; set; }
        public int SpadesCount { get; set; }
        private bool _inQuarantine { get; set; }

        private readonly Dealer _dealer = Dealer.GetDealer();
        private readonly Deck _deck = Deck.GetDeck();
        private readonly GameBoard _gameBoard = GameBoard.GetGameBoard();

        public Player(string name, object Lock)
        {
            Name = name;
            _inQuarantine = false;
            Hand = new List<ICard>();
            _lock = Lock;
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
                    SuitCounter(card); // Update suit counter
                }
            }
        }

        public void RemoveCard()
        {
            var card = CardToThrow(); // Decide which cart to throw
            if (card != null)
            {
                Console.WriteLine(Name + " throwing card: " + card.GetNumber() + " of " + card.GetSuit());
                if (card is CardJoker)
                {
                    if (Math.Max(HeartCount, DiamondCount) > Math.Max(ClubCount, SpadesCount))
                    {
                        if (HeartCount > DiamondCount)
                        {
                            HeartCount--;
                        }
                        else
                        {
                            DiamondCount--;
                        }
                    }
                    else
                    {
                        if (ClubCount > SpadesCount)
                        {
                            ClubCount--;
                        }
                        else
                        {
                            SpadesCount--;
                        }
                    }
                }
            }
            _deck.CardToDeck(card); // Send card to dealer
        }

        private ICard CardToThrow()
        {
            for (var i = 1; i <= 20; i++)
            {
                ICard card;

                /*
                 * Check all suit counts if a count has a low value(check starts at 1).
                 * If it does, then we can safely throw this card to the dealer.
                 *
                 * Update suit count and remove from list when found.
                 */

                if (HeartCount == i)
                {
                    card = Hand.Find(c => c.GetSuit() == CardSuit.Heart && !(c is CardJoker)); // Find card with heart suit
                    HeartCount--; // Update HeartCount
                    Hand.Remove(card); // Remove card from list
                    return card; // Return card to be thrown away
                }

                if (DiamondCount == i)
                {
                    card = Hand.Find(c => c.GetSuit() == CardSuit.Diamond && !(c is CardJoker));
                    DiamondCount--;
                    Hand.Remove(card);
                    return card;
                }

                if (ClubCount == i)
                {
                    card = Hand.Find(c => c.GetSuit() == CardSuit.Club && !(c is CardJoker));
                    ClubCount--;
                    Hand.Remove(card);
                    return card;
                }

                if (SpadesCount == i)
                {
                    card = Hand.Find(c => c.GetSuit() == CardSuit.Spades && !(c is CardJoker));
                    SpadesCount--;
                    Hand.Remove(card);
                    return card;
                }
            }

            return null; // This shouldn't happen.
        }

        private void SuitCounter(ICard card)
        {
            /*
             * Update counter based on card suit type
             */
            switch (card.GetSuit())
            {
                case CardSuit.Heart:
                    HeartCount++;
                    break;
                case CardSuit.Diamond:
                    DiamondCount++;
                    break;
                case CardSuit.Club:
                    ClubCount++;
                    break;
                case CardSuit.Spades:
                    SpadesCount++;
                    break;
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
                        var card = _deck.CardFromDeck();
                        if (_inQuarantine)
                        {
                            Console.WriteLine("No card for you, " + Name);
                            _inQuarantine = false;
                        }
                        else if (!(card is CardDecorator))
                        {
                            AddCard(card); // Receive card from dealer
                            RemoveCard(); // Remove card from player hand
                        }
                        else
                        {
                            SpecialCardAction(card);
                        }

                        if (HeartCount >= 4 || DiamondCount >= 4 || ClubCount >= 4 ||
                            SpadesCount >= 4)
                        {
                            _gameBoard.GameEnd = true;
                        }
                    }
                }
                Thread.Sleep(20); // Pause before asking for next card
            }
        }

        public void SpecialCardAction(ICard card)
        {

            if (card is CardQuarantine)
            {
                card.DisplayCard(Name);
                _inQuarantine = true;
            }

            if (card is CardTheVulture)
            {
                AddCard(card);
                AddCard(_deck.CardFromDeck(true));
            }

            if (card is CardTheBomb)
            {
                card.DisplayCard(Name);
                _deck.CardToDeck(card);
                Hand.Remove(card);
                foreach (var cards in Hand)
                {
                    _deck.CardToDeck(cards);
                }
                Hand.Clear();
                HeartCount = 0;
                DiamondCount = 0;
                ClubCount = 0;
                SpadesCount = 0;
                AddCard(_deck.CardFromDeck(true));
                AddCard(_deck.CardFromDeck(true));
                AddCard(_deck.CardFromDeck(true));
                AddCard(_deck.CardFromDeck(true));
            }

            if (card is CardJoker)
            {
                AddCard(card);
                if (Math.Max(HeartCount, DiamondCount) > Math.Max(ClubCount,SpadesCount))
                {
                    if (HeartCount > DiamondCount)
                    {
                        HeartCount++;
                    }
                    else
                    {
                        DiamondCount++;
                    }
                }
                else
                {
                    if (ClubCount > SpadesCount)
                    {
                        ClubCount++;
                    }
                    else
                    {
                        SpadesCount++;
                    }
                }
                RemoveCard();
            }
        }
    }
}
