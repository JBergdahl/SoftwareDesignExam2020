using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    public class CardTheBomb : CardDecorator
    {
        public CardTheBomb(ICard standardCard) : base(standardCard) { }

        public override string DisplayCard(string playerName)
        {
            ExtraMessage(playerName);
            return base.DisplayCard("");
        }

        private void ExtraMessage(string playerName)
        {
            Console.WriteLine("Ooops " + playerName + ". You drew the bomb. Gimme all your cards!");
        }

        public void CardTheBombAction(ICard card, IPlayer player)
        {
            var deck = Deck.GetDeck();
            var playerCast = (Player)player;

            card.DisplayCard(playerCast.Name); // Display card
            deck.CardToDeck(card); // Put this card back into the deck
            //playerCast.Hand.Remove(card);
            foreach (var cards in playerCast.Hand)
            {
                deck.CardToDeck(cards); // Put all players cards back into the deck
            }
            playerCast.Hand.Clear(); // Remove all cards from player
            // Set all suit counts to 0
            playerCast.HeartCount = 0;
            playerCast.DiamondCount = 0;
            playerCast.ClubCount = 0;
            playerCast.SpadesCount = 0;
            // Receive 4 new cards from the deck and add them to the players hand
            // special card == false
            playerCast.AddCard(deck.CardFromDeck(false));
            playerCast.AddCard(deck.CardFromDeck(false));
            playerCast.AddCard(deck.CardFromDeck(false));
            playerCast.AddCard(deck.CardFromDeck(false));
        }
    }
}
