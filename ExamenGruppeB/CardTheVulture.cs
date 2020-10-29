using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    class CardTheVulture : CardDecorator
    {
        public CardTheVulture(ICard normalCard) : base(normalCard) { }

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
