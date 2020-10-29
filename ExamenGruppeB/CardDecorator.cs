using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public abstract class CardDecorator : ICard
    {
        private readonly ICard _normalCard;

        protected CardDecorator(ICard normalCard)
        {
            _normalCard = normalCard;
        }
        public virtual string DisplayCard()
        {
            return _normalCard.DisplayCard();
        }
    }
}
