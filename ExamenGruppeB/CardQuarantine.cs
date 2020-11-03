using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    class CardQuarantine : CardDecorator
    {
        public CardQuarantine(ICard standardCard) : base(standardCard) { }

        public override string DisplayCard(string playerName)
        {
            ExtraMessage(playerName);
            return base.DisplayCard("");
        }

        private void ExtraMessage(string playerName)
        {
            Console.WriteLine("Quarantine. " + playerName + " you will get no card on your next visit..");
        }

        public void CardQuarantineAction(ICard card, IPlayer player)
        {
            var playerCast = (Player)player;
            card.DisplayCard(playerCast.Name);
            playerCast.InQuarantine = true;
        }
    }
}
