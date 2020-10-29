using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenGruppeB
{
    public sealed class Deck
    {
        // Singleton pattern, makes sure only one instance of Deck is created
        private static readonly Deck Instance = new Deck();
        public static Deck GetNewDeck()
        {
            return Instance;
        }

        public List<ICard> CardsInDeck { get; set; }
        // Size of enum CardSuit - Used in loop
        private readonly int _cardSuitCount = System.Enum.GetNames(typeof(CardSuit)).Length;
        // Size of enum CardNumber - Used in loop
        private readonly int _cardNumberCount = System.Enum.GetNames(typeof(CardNumber)).Length;
        // Random number generator
        private readonly Random _rn = new Random();

        public Deck()
        {
            // Init list of cards
            CardsInDeck = new List<ICard>();
            // Add cards to list
            NewDeck();
            // Shuffle deck
            ShuffleDeck();
        }

        private void NewDeck()
        {
            // Loop through enum CardSuit
            for (int i = 1; i <= _cardSuitCount; i++)
            {
                int specialCard = _rn.Next(13) + 1;
                // Loop through enum CardNumber
                for (int j = 1; j <= _cardNumberCount; j++)
                {
                    // Call factory to create new card
                    ICard card = CardFactory.CreateNewCard(j, i, specialCard);
                    // Add card to deck
                    CardsInDeck.Add(card);
                }
            }
        }
        private void ShuffleDeck()
        {
            // Shuffles card and store new order to list
            CardsInDeck = CardsInDeck.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
