using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    public interface IPlayer
    {
        public void ShowHand(); // Display all cards in players hand
        public void AddCard(ICard card); // Add card to players hand
        public void RemoveCard(); // Remove card from players hand
    }
}
