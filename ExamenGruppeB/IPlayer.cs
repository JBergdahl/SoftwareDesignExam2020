using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public interface IPlayer
    {
        public string GetName();
        public void ShowHand();
        public void AddCard(ICard card);
        public void AddCardRange(params ICard[] card);
    }
}
