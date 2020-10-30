using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    class CardTheVulture : CardDecorator
    {
        public CardTheVulture(ICard standardCard) : base(standardCard) { }

        public override string DisplayCard()
        {
            ExtraMessage();
            return base.DisplayCard();
        }

        private void ExtraMessage()
        {
            Console.WriteLine("CardTheVulture!!");
        }
    }
}
