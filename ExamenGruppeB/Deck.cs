using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenGruppeB
{
    public sealed class Deck : DeckInteraction
    {
        // Singleton pattern, makes sure only one instance of Deck is created
        private static readonly Deck Instance = new Deck();
        public static Deck GetDeck()
        {
            return Instance;
        }

        public List<ICard> NormalCards { get; set; } // List with normal cards
        public List<ICard> SpecialCards { get; set; } // List with the special cards

        // Size of enum CardSuit - Used in loop
        private readonly int _cardSuitCount = Enum.GetNames(typeof(CardSuit)).Length;
        // Size of enum CardNumber - Used in loop
        private readonly int _cardNumberCount = Enum.GetNames(typeof(CardNumber)).Length;
        // Random number generator
        private readonly Random _rn = new Random();

        private Deck() //private??????????????????????????????????????????????
        {
            // Init list of cards
            NormalCards = new List<ICard>();
            // Init list of special cards
            SpecialCards = new List<ICard>();
            // Add cards to list
            NewDeck();
            // Shuffle deck
            ShuffleDeck();
        }

        private void NewDeck() // Creates sorted deck
        {
            // Loop through enum CardSuit
            for (var i = 1; i <= _cardSuitCount; i++)
            {
                // Random card to be a special card in each suit
                var specialCard = _rn.Next(1, 14);
                // Loop through enum CardNumber
                for (var j = 1; j <= _cardNumberCount; j++)
                {
                    // Call factory to create new card
                    var card = CardFactory.CreateNewCard(j, i, specialCard);

                    if (j == specialCard) 
                    {
                        // Add special card to deck
                        SpecialCards.Add(card);
                    }
                    else
                    {
                        // Add card to deck
                        NormalCards.Add(card);
                    }
                }
            }
        }
        private void ShuffleDeck()
        {
            // Shuffles cards and store new order to list
            NormalCards = NormalCards.OrderBy(x => Guid.NewGuid()).ToList();
            // Shuffles special cards and store new order to list
            SpecialCards = SpecialCards.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
