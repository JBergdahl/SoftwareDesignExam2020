using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    class CardTheBomb : CardDecorator
    {
        public CardTheBomb(ICard standardCard) : base(standardCard) { }

        public override string DisplayCard(string playerName)
        {
            ExtraMessage(playerName);
            return base.DisplayCard("");
        }

        private void ExtraMessage(string playerName)
        {
            Console.WriteLine("Ooops " + playerName + ". You drew the bomb. Gimme all your cards!");
        }
    }
}
