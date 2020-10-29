using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    static class CardFactory
    {
        public static ICard CreateNewCard(int cardNumber, int cardSuit, int specialCard)
        {
            Random rn = new Random();
            Deck deck = Deck.GetNewDeck();

            const int joker = 1;
            const int theBomb = 2;
            const int theVulture = 3;
            const int quarantine = 4;

            ICard Card = new Card(cardNumber, cardSuit);
            if (cardNumber == specialCard && cardSuit == joker)
            {
                Card = new CardJoker(Card);
            }
            else if (cardNumber == specialCard && cardSuit == theBomb)
            {
                Card = new CardTheBomb(Card);
            }
            else if (cardNumber == specialCard && cardSuit == theVulture)
            {
                Card = new CardTheVulture(Card);
            }
            else if (cardNumber == specialCard && cardSuit == quarantine)
            {
                Card = new CardQuarantine(Card);
            }
            return Card;
        }
    }
}
