using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public interface IPlayer
    {
        public void ShowHand();
        public void AddCard(ICard card);
        public void RemoveCard();
    }
}
