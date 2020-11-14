using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    public static class CardFactory
    {
        public static ICard CreateNewCard(int cardNumber, int cardSuit)
        {

            ICard card = new Card(cardNumber, cardSuit);
            // Return card
            return card;
        }
    }
}
