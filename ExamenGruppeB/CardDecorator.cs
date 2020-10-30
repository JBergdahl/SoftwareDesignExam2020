using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
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
        public virtual string DisplayCard()
        {
            return _standardCard.DisplayCard();
        }
    }
}
