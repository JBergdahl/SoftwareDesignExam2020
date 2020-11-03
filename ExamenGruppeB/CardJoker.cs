using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public class CardJoker : CardDecorator
    {
        public CardJoker(ICard standardCard) : base(standardCard) { }

        public override string DisplayCard(string playerName)
        {
            //ExtraMessage();
            return base.DisplayCard("") + " - Joker! +1 to your highest suit count"; 
        }

        private void ExtraMessage()
        {
            Console.WriteLine("JOKER!!");
        }
    }
}
