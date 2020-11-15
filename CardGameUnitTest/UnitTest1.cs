using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PG3302;

namespace CardGameUnitTest
{
    public class Tests
    {
        [Test]
        public void TestDeck()
        {
            var deck = Deck.GetDeck();
            var deck2 = Deck.GetDeck();

            // Same instance
            Assert.AreSame(deck, deck2);
            // Deck counts
            var normalCount = deck.NormalCards.Count;
            var specialCount = deck.SpecialCards.Count;
            Assert.AreEqual(48, normalCount);
            Assert.AreEqual(4, specialCount);
        }

        [Test]
        public void TestPlayerAddCard_SuitCounter()
        {
            var player = new Player("player", this);
            var player2 = new Player("player2", this);

            // Not same instance
            Assert.AreNotSame(player, player2);
            // Player hand at start
            Assert.AreEqual(0, player.Hand.Count);

            // Hearts count test
            var card = new Card(1, 1);
            var card1 = new Card(2, 1);
            var card2 = new Card(3, 1);
            var card3 = new Card(4, 1);
            Assert.AreEqual(0, player.HeartCount);
            player.AddCard(card);
            player.AddCard(card1);
            player.AddCard(card2);
            player.AddCard(card3);
            Assert.AreEqual(4, player.HeartCount);
            Assert.AreEqual(4, player.Hand.Count);

            // Diamonds count test
            var card4 = new Card(1, 2);
            var card5 = new Card(2, 2);
            var card6 = new Card(3, 2);
            var card7 = new Card(4, 2);
            Assert.AreEqual(0, player.DiamondCount);
            player.AddCard(card4);
            player.AddCard(card5);
            player.AddCard(card6);
            player.AddCard(card7);
            Assert.AreEqual(4, player.DiamondCount);
            Assert.AreEqual(8, player.Hand.Count);

            // Clubs count test
            var card8 = new Card(1, 3);
            var card9 = new Card(2, 3);
            var card10 = new Card(3, 3);
            var card11 = new Card(4, 3);
            Assert.AreEqual(0, player.ClubCount);
            player.AddCard(card8);
            player.AddCard(card9);
            player.AddCard(card10);
            player.AddCard(card11);
            Assert.AreEqual(4, player.ClubCount);
            Assert.AreEqual(12, player.Hand.Count);

            // Spades count test
            var card12 = new Card(1, 4);
            var card13 = new Card(2, 4);
            var card14 = new Card(3, 4);
            var card15 = new Card(4, 4);
            Assert.AreEqual(0, player.SpadesCount);
            player.AddCard(card12);
            player.AddCard(card13);
            player.AddCard(card14);
            player.AddCard(card15);
            Assert.AreEqual(4, player.SpadesCount);
            Assert.AreEqual(16, player.Hand.Count);
        }

        [Test]
        public void TestPlayerCardLogic()
        {
            var player = new Player("player", this);
            var playerHandHandler = new PlayerHandHandler(player);
            List<ICard> cardList = player.Hand;

            // Add 3 hearts + 1 diamonds
            var card = new Card(1, 2);
            var card1 = new Card(2, 1);
            var card2 = new Card(3, 1);
            var card3 = new Card(1, 1);
            player.AddCard(card);
            player.AddCard(card1);
            player.AddCard(card2);
            player.AddCard(card3);
            var cardToThrow = playerHandHandler.CardToThrow();
            // Diamond removed, 3 hearts remain
            Assert.AreEqual(card, cardToThrow);
            Assert.Contains(card1, cardList);
            Assert.Contains(card2, cardList);
            Assert.Contains(card3, cardList);

            player.Hand.Clear();
            player.SpadesCount = 0;
            player.HeartCount = 0;
            player.ClubCount = 0;
            player.DiamondCount = 0;

            // Add 3 spades + 1 heart
            var card4 = new Card(1, 4);
            var card5 = new Card(2, 1);
            var card6 = new Card(3, 4);
            var card7 = new Card(1, 4);
            player.AddCard(card4);
            player.AddCard(card5);
            player.AddCard(card6);
            player.AddCard(card7);
            var cardToThrow2 = playerHandHandler.CardToThrow();
            // heart removed, 3 spades remain
            Assert.AreEqual(card5, cardToThrow2);
            Assert.Contains(card4, cardList);
            Assert.Contains(card6, cardList);
            Assert.Contains(card7, cardList);
        }

        [Test]
        public void TestSpecialCards()
        {
            var player = new Player("player", this);
            var specialCardHandler = new SpecialCardHandler();

            // Create joker card of Ace of spades
            var card = new Card(1, 4);
            var joker = new CardJoker(card);
            player.HeartCount = 2;
            player.SpadesCount = 1;
            player.DiamondCount = 1;
            player.ClubCount = 1;
            // Ace of spades increases hearts count +1
            specialCardHandler.Action(joker, player);
            Assert.AreEqual(3, player.HeartCount);

            // Create vulture card
            var card2 = new Card(2, 2);
            var cardTheVulture = new CardTheVulture(card2);
            // Total card count should increase with 2, vulture + extra card
            Assert.AreEqual(1, player.Hand.Count);
            specialCardHandler.Action(cardTheVulture, player);
            Assert.AreEqual(3, player.Hand.Count);
        }
    }
}