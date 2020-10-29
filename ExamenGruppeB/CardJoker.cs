using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public class CardJoker : CardDecorator
    {
        public CardJoker(ICard normalCard) : base(normalCard) { }

        public override string DisplayCard()
        {
            ExtraMessage();
            return base.DisplayCard(); 
        }

        private void ExtraMessage()
        {
            Console.WriteLine("JOKER!!");
        }
    }
}
