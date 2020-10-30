using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public class CardJoker : CardDecorator
    {
        public CardJoker(ICard standardCard) : base(standardCard) { }

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
