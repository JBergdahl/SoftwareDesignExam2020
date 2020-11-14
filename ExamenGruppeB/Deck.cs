using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PG3302
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

        private Deck()
        {
            // Init list of cards
            NormalCards = new List<ICard>();
            // Init list of special cards
            SpecialCards = new List<ICard>();
            // Add cards to list
            NewDeck();
            // Shuffle deck
            //ShuffleDeck();
        }

        private void NewDeck() // Creates sorted deck
        {
            // Create method to randomize which suit starts being created so a special card is assigned at random
            var iNumber = 0;
            int[] numbersArray = { 1, 2, 3, 4 };
            var rn = new Random();

            while (iNumber < numbersArray.Length)
            {

                // Store  element
                var temp = numbersArray[iNumber];

                // Get a random number 0 - 4
                var index = rn.Next(0, numbersArray.Length);

                // Swap elements at i and index position
                numbersArray[iNumber] = numbersArray[index];
                numbersArray[index] = temp;

                // Increment counter
                iNumber++;
            }

            // Variables to check if a type of special card has been assigned
            var jokerAssorted = false;
            var theBombAssorted = false;
            var theVultureAssorted = false;
            var quarantineAssorted = false;

            // Loop through enum CardSuit
            for (var i = 0; i <= _cardSuitCount - 1; i++)
            {
                // Random card to be a special card in each suit
                var specialCard = _rn.Next(1, 14);
                // Loop through enum CardNumber
                for (var j = 1; j <= _cardNumberCount; j++)
                {
                    // Call factory to create new card
                    var card = CardFactory.CreateNewCard(j, numbersArray[i]);

                    // Add card decoration to special cards
                    if (j == specialCard && !jokerAssorted)
                    {
                        card = new CardJoker(card);
                        jokerAssorted = true;
                    }
                    else if (j == specialCard && !theBombAssorted)
                    {
                        card = new CardTheBomb(card);
                        theBombAssorted = true;
                    }
                    else if (j == specialCard && !theVultureAssorted)
                    {
                        card = new CardTheVulture(card);
                        theVultureAssorted = true;
                    }
                    else if (j == specialCard && !quarantineAssorted)
                    {
                        card = new CardQuarantine(card);
                        quarantineAssorted = true;
                    }


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
            // Shuffle both decks
            ShuffleDeck(SpecialCards);
            ShuffleDeck(NormalCards);
        }
        private void ShuffleDeck(List<ICard> cards)
        {

            for (var i = 0; i < cards.Count; i++)
            {
                // Store card element
                var temp = cards[i];

                // Get a random number 0 - 51
                var index = _rn.Next(0, cards.Count);

                // Swap elements at i and index position
                cards[i] = cards[index];
                cards[index] = temp;
            }
        }
    }
}
