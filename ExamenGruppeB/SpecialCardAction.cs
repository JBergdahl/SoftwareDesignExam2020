using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    class SpecialCardAction
    {
        private static readonly SpecialCardAction Instance = new SpecialCardAction();
        public static SpecialCardAction GetSpecialCardAction()
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
