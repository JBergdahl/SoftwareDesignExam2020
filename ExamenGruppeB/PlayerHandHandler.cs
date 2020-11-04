using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    public class PlayerHandHandler
    {
        private readonly IPlayer _player;

        public PlayerHandHandler(IPlayer player)
        {
            if (player is Player castPlayer)
            {
                _player = castPlayer;
            }
        }

        public ICard CardToThrow()
        {
            for (var i = 1; i <= 20; i++)
            {
                ICard card;
                var castPlayer = (Player) _player;

                /*
                 * Check all suit counts if a count has a low value(check starts at 1).
                 * If it does, then we can safely throw this card to the dealer.
                 *
                 * Update suit count and remove from list when found.
                 */

                if (castPlayer.HeartCount == i)
                {
                    card = castPlayer.Hand.Find(c => c.GetSuit() == CardSuit.Heart && !(c is CardJoker)); // Find card with heart suit
                    castPlayer.HeartCount--; // Update HeartCount
                    castPlayer.Hand.Remove(card); // Remove card from list
                    return card; // Return card to be thrown away
                }

                if (castPlayer.DiamondCount == i)
                {
                    card = castPlayer.Hand.Find(c => c.GetSuit() == CardSuit.Diamond && !(c is CardJoker));
                    castPlayer.DiamondCount--;
                    castPlayer.Hand.Remove(card);
                    return card;
                }

                if (castPlayer.ClubCount == i)
                {
                    card = castPlayer.Hand.Find(c => c.GetSuit() == CardSuit.Club && !(c is CardJoker));
                    castPlayer.ClubCount--;
                    castPlayer.Hand.Remove(card);
                    return card;
                }

                if (castPlayer.SpadesCount == i)
                {
                    card = castPlayer.Hand.Find(c => c.GetSuit() == CardSuit.Spades && !(c is CardJoker));
                    castPlayer.SpadesCount--;
                    castPlayer.Hand.Remove(card);
                    return card;
                }
            }
            return null; // This shouldn't happen.
        }

        public void SuitCounter(ICard card)
        {
            /*
             * Update counter based on card suit type
             */
            var castPlayer = (Player)_player;

            switch (card.GetSuit())
            {
                case CardSuit.Heart:
                    castPlayer.HeartCount++;
                    break;
                case CardSuit.Diamond:
                    castPlayer.DiamondCount++;
                    break;
                case CardSuit.Club:
                    castPlayer.ClubCount++;
                    break;
                case CardSuit.Spades:
                    castPlayer.SpadesCount++;
                    break;
            }
        }
    }
}
