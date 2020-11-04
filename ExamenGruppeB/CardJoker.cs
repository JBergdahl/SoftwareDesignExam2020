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
            player.AddCard(card);
            var playerCast = (Player) player;
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
            player.RemoveCard();
        }

        public void CardJokerRemove(ICard card, IPlayer player)
        {
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
