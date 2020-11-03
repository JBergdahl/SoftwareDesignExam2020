using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public class Dealer
    {
        // Singleton pattern, makes sure only one instance of Dealer is created
        private static readonly Dealer Instance = new Dealer();
        public static Dealer GetDealer()
        {
            return Instance;
        }

        private readonly Deck _deck = Deck.GetDeck(); // Deck instance

        public ICard GiveCard()
        {
            return _deck.CardFromDeck();
        }

        public void TakeCard(ICard card)
        {
            //_deck.CardToDeck(card);
        }
    }
}
