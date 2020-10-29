using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    class CardTheBomb : CardDecorator
    {
        public CardTheBomb(ICard normalCard) : base(normalCard) { }

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
