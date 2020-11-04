using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    public class SpecialCardHandler
    {
        private static readonly SpecialCardHandler Instance = new SpecialCardHandler();
        public static SpecialCardHandler GetSpecialCardAction()
        {
            return Instance;
        }
        public void Action(ICard card, IPlayer player)
        {

            if (card is CardQuarantine castQuarantine)
            {
                castQuarantine.CardQuarantineAction(card, player);
            }

            if (card is CardTheVulture castVulture)
            {
                castVulture.CardTheVultureAction(card, player);
            }

            if (card is CardTheBomb castBomb)
            {
                castBomb.CardTheBombAction(card, player);
            }

            if (card is CardJoker castJoker)
            {
                castJoker.CardJokerAction(card, player);
            }
        }
    }
}
