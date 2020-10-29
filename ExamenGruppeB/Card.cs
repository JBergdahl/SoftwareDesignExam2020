using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public enum CardSuit
    {
        Heart = 1,
        Diamond,
        Club,
        Spades
    }

    public enum CardNumber
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    class Card : ICard
    {
        public CardSuit CardSuit { get; set; }
        public CardNumber CardNumber { get; set; }

        public Card(int cardNumber, int cardSuit)
        {
            CardNumber = (CardNumber)cardNumber;
            CardSuit = (CardSuit)cardSuit;
        }

        public string DisplayCard()
        {
            int cardValue = (int) CardNumber;
            // if Card is not a face card or an ace:
            // print value + suit
            if (cardValue <= 10 && cardValue > 1)
            {
                return cardValue + " of " + CardSuit.ToString();
            }

            // else:
            // print card name + suit
            return CardNumber.ToString() + " of " + CardSuit.ToString();
        }
    }
}
