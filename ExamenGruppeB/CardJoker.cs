using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    public class CardJoker : CardDecorator
    {
        public CardJoker(ICard standardCard) : base(standardCard) { }

        public override string DisplayCard(string playerName)
        {
            return base.DisplayCard("") + " - Joker! +1 to your highest suit count"; 
        }

        public void CardJokerAction(ICard card, IPlayer player)
        {
            player.AddCard(card); // Adds this card to players hand

            var playerCast = (Player) player;

            /*
             * This code finds out what suit the player got the most of,
             * adds +1 to that suit.
             */
            if (Math.Max(playerCast.HeartCount, playerCast.DiamondCount) > Math.Max(playerCast.ClubCount, playerCast.SpadesCount))
            {
                if (playerCast.HeartCount > playerCast.DiamondCount)
                {
                    playerCast.HeartCount++;
                }
                else
                {
                    playerCast.DiamondCount++;
                }
            }
            else
            {
                if (playerCast.ClubCount > playerCast.SpadesCount)
                {
                    playerCast.ClubCount++;
                }
                else
                {
                    playerCast.SpadesCount++;
                }
            }
            player.RemoveCard(); // Call RemoveCard from this player
        }

        public void CardJokerRemove(ICard card, IPlayer player)
        {
            /*
             * Same as above but -1;
             * This code should never run because the player
             * should never throw away the joker.
             */
            var playerCast = (Player)player;
            if (Math.Max(playerCast.HeartCount, playerCast.DiamondCount) > Math.Max(playerCast.ClubCount, playerCast.SpadesCount))
            {
                if (playerCast.HeartCount > playerCast.DiamondCount)
                {
                    playerCast.HeartCount--;
                }
                else
                {
                    playerCast.DiamondCount--;
                }
            }
            else
            {
                if (playerCast.ClubCount > playerCast.SpadesCount)
                {
                    playerCast.ClubCount--;
                }
                else
                {
                    playerCast.SpadesCount--;
                }
            }
        }
    }
}
