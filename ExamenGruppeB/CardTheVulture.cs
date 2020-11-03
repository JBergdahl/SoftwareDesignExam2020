using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ExamenGruppeB
{
    class CardTheVulture : CardDecorator
    {
        public CardTheVulture(ICard standardCard) : base(standardCard) { }

        public override string DisplayCard(string playerName)
        {
            ExtraMessage(playerName);
            return base.DisplayCard("") + " - Vulture! Extra card";
        }

        private void ExtraMessage(string playerName)
        {
            Console.WriteLine("Oh, the vulture. Grab another card you greedy " + playerName);
        }
    }
}
