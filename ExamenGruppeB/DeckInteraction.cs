using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PG3302
{
    public abstract class DeckInteraction
    {
        private Deck _deck = Deck.GetDeck();
        private Random _rn;
        public ICard CardFromDeck(bool specialCard = true) // Remove one card from the top of the deck
        {
            _deck = Deck.GetDeck();
            _rn = new Random();
            if (_rn.Next(1, 14) == 1 && _deck.SpecialCards.Count != 0 && specialCard) // 1/13 chance to get a special card, must still be one available
            { 
                var card = _deck.SpecialCards[0]; // save first in list
                _deck.SpecialCards.RemoveAt(0); // remove first in list
                return card;
            }
            else
            {
                var card = _deck.NormalCards[0]; // save first in list
                _deck.NormalCards.RemoveAt(0); // remove first in list
                return card;
            }
        }

        public void CardToDeck(ICard card) // Add one card to the bottom of the deck
        {
            if (card is CardDecorator) // Special card
            {
                // Add card to list of special cards if card is an instance of a special card
                _deck.SpecialCards.Insert(_deck.SpecialCards.Count, card);
            }
            else
            {
                // Add card to list of normal cards
                // CHANGE TO ADD TO A RANDOM LOCATION IN LIST
                _deck.NormalCards.Insert(_deck.NormalCards.Count, card);
            }
        }
    }
}
