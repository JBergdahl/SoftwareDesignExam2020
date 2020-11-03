using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    class CardTheBomb : CardDecorator
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
            card.DisplayCard(playerCast.Name);
            deck.CardToDeck(card);
            playerCast.Hand.Remove(card);
            foreach (var cards in playerCast.Hand)
            {
                deck.CardToDeck(cards);
            }
            playerCast.Hand.Clear();
            playerCast.HeartCount = 0;
            playerCast.DiamondCount = 0;
            playerCast.ClubCount = 0;
            playerCast.SpadesCount = 0;
            playerCast.AddCard(deck.CardFromDeck(true));
            playerCast.AddCard(deck.CardFromDeck(true));
            playerCast.AddCard(deck.CardFromDeck(true));
            playerCast.AddCard(deck.CardFromDeck(true));
        }
    }
}
