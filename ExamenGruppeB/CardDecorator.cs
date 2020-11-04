using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    // All the special cards will inherit from this CardDecorator abstract class
    // This can be added to any standard card in the CardFactory
    public abstract class CardDecorator : ICard
    {
        // Original card to be a special card
        private readonly ICard _standardCard;

        protected CardDecorator(ICard standardCard)
        {
            _standardCard = standardCard;
        }

        // Print out cards suit + number
        public virtual string DisplayCard(string playerName)
        {
            return _standardCard.DisplayCard(playerName);
        }

        public virtual CardSuit GetSuit()
        {
            return _standardCard.GetSuit();
        }

        public virtual CardNumber GetNumber()
        {
            return _standardCard.GetNumber();
        }
    }
}
