using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    class CardTheBomb : CardDecorator
    {
        public CardTheBomb(ICard standardCard) : base(standardCard) { }

        public override string DisplayCard()
        {
            ExtraMessage();
            return base.DisplayCard();
        }

        private void ExtraMessage()
        {
            Console.WriteLine("CardTheBomb!!");
        }
    }
}
