using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PG3302
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
        // Card suit get and set
        public CardSuit CardSuit { get; private set; }
        //Card number get and set
        public CardNumber CardNumber { get; private set; }

        // Constructor
        public Card(int cardNumber, int cardSuit)
        {
            CardNumber = (CardNumber)cardNumber;
            CardSuit = (CardSuit)cardSuit;
        }

        public CardSuit GetSuit()
        {
            return CardSuit;
        }

        public CardNumber GetNumber()
        {
            return CardNumber;
    }

        public string DisplayCard(string playerName)
        {
            int cardValue = (int) CardNumber;
            // if Card is not a face card or an ace:
            // print value + suit
            if (cardValue <= 10 && cardValue > 1)
            {
                return cardValue + " of " + CardSuit;
            }

            // else:
            // print card name + suit
            return CardNumber + " of " + CardSuit;
        }
    }
}
