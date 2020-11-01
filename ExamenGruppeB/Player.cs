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

        // Counters for suits:
        public int HeartCount { get; set; }
        public int DiamondCount { get; set; }
        public int ClubCount { get; set; }
        public int SpadesCount { get; set; }

        private readonly Dealer _dealer = Dealer.GetDealer();

        public Player(string name)
        {
            Name = name;
            Hand = new List<ICard>();
        }

        // Outputs current hand of player
        public void ShowHand()
        {
            foreach (var card in Hand)
            {
                Console.WriteLine(card.DisplayCard());
            }
        }

        public void AddCard(ICard card)
        {
            Hand.Add(card); // Add passed card to list
            if (card != null)
            {
                Console.WriteLine(this.Name + " receiving card: " + card.DisplayCard());
            }
            SuitCounter(card); // Update suit counter
        }

        public void RemoveCard()
        {
            var card = CardToThrow(); // Decide which cart to throw
            if (card != null)
            {
                Console.WriteLine(this.Name + " throwing card: " + card.DisplayCard());
            }
            _dealer.TakeCard(card); // Send card to dealer
        }

        private ICard CardToThrow()
        {
            for (var i = 1; i <= 5; i++)
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
                    card = Hand.Find(c => c.GetSuit() == CardSuit.Heart); // Find card with heart suit
                    HeartCount--; // Update HeartCount
                    Hand.Remove(card); // Remove card from list
                    return card; // Return card to be thrown away
                }

                if (DiamondCount == i)
                {
                    card = Hand.Find(c => c.GetSuit() == CardSuit.Diamond);
                    DiamondCount--;
                    Hand.Remove(card);
                    return card;
                }

                if (ClubCount == i)
                {
                    card = Hand.Find(c => c.GetSuit() == CardSuit.Club);
                    ClubCount--;
                    Hand.Remove(card);
                    return card;
                }

                if (SpadesCount == i)
                {
                    card = Hand.Find(c => c.GetSuit() == CardSuit.Spades);
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

        protected override void Task()
        {
            while (_dealer.HasCards && _running)
            {
                AddCard(_dealer.GiveCard());
                RemoveCard();
                Thread.Sleep(10);
            }
        }
    }
}
