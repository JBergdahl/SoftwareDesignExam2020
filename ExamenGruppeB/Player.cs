using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public List<ICard> Hand { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<ICard>();
        }

        public void ShowHand()
        {
            foreach (var card in Hand)
            {
                Console.WriteLine(card.DisplayCard());
            }
        }
    }
}
