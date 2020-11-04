using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    public interface IPlayer
    {
        public void ShowHand();
        public void AddCard(ICard card);
        public void RemoveCard();
    }
}
