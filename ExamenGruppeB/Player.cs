using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public class Player : IPlayer
    {
        public string Name { get; private set; }
        private List<ICard> _hand { get; }

        public Player(string name)
        {
            Name = name;
            _hand = new List<ICard>();
        }

        public string GetName()
        {
            return Name;
        }

        public void ShowHand()
        {
            foreach (var card in _hand)
            {
                Console.WriteLine(card.DisplayCard());
            }
        }

        public void AddCard(ICard card)
        {
            _hand.Add(card);
        }

        public void AddCardRange(params ICard[] cards)
        {
            _hand.AddRange(cards);
        }
    }
}
