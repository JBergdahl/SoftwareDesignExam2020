using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    public class CardQuarantine : CardDecorator
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
            /*
             * Display card + extra message.
             * Puts this player in quarantine.
             */
            var deck = Deck.GetDeck();
            var playerCast = (Player)player;
            card.DisplayCard(playerCast.Name);
            deck.CardToDeck(card);
            playerCast.InQuarantine = true;
        }
    }
}
