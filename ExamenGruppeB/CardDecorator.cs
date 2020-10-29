using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    // All the special cards will inherit from this CardDecorator abstract class
    // This can be added to any card in the CardFactory
    public abstract class CardDecorator : ICard
    {
        // Original card to be a special card
        private readonly ICard _normalCard;

        protected CardDecorator(ICard normalCard)
        {
            _normalCard = normalCard;
        }

        // Print out cards suit + number
        public virtual string DisplayCard()
        {
            return _normalCard.DisplayCard();
        }
    }
}
