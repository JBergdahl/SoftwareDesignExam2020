using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public static class CardFactory
    {
        public static ICard CreateNewCard(int cardNumber, int cardSuit, int specialCard)
        {
            // Which suit will be a special card
            const int joker = 1; // Heart
            const int theBomb = 2; // Diamond
            const int theVulture = 3; // Club
            const int quarantine = 4; // Spade

            // New standard card
            ICard card = new Card(cardNumber, cardSuit);

            // Add card decoration to special cards
            if (cardNumber == specialCard && cardSuit == joker)
            {
                card = new CardJoker(card);
            }
            else if (cardNumber == specialCard && cardSuit == theBomb)
            {
                card = new CardTheBomb(card);
            }
            else if (cardNumber == specialCard && cardSuit == theVulture)
            {
                card = new CardTheVulture(card);
            }
            else if (cardNumber == specialCard && cardSuit == quarantine)
            {
                card = new CardQuarantine(card);
            }

            // Return card or special card
            return card;
        }
    }
}
