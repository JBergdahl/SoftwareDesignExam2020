﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PG3302
{
    class CardTheVulture : CardDecorator
    {
        public CardTheVulture(ICard standardCard) : base(standardCard) { }

        public override string DisplayCard(string playerName)
        {
            ExtraMessage(playerName);
            return base.DisplayCard("") + " - Vulture! Extra card";
        }

        private void ExtraMessage(string playerName)
        {
            Console.WriteLine("Oh, the vulture. Grab another card you greedy " + playerName);
        }

        public void CardTheVultureAction(ICard card, IPlayer player)
        {
            var deck = Deck.GetDeck();
            var playerCast = (Player)player;
            playerCast.AddCard(card);
            playerCast.AddCard(deck.CardFromDeck(true));
        }
    }
}
