using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    class CardQuarantine : CardDecorator
    {
        public CardQuarantine(ICard standardCard) : base(standardCard) { }

        public override string DisplayCard()
        {
            ExtraMessage();
            return base.DisplayCard();
        }

        private void ExtraMessage()
        {
            Console.WriteLine("CardQuarantine!!");
        }
    }
}
