using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    interface IDeckInteraction
    {
        void CardFromDeck(); // Remove one card from deck
        void CardFromDeckRange(); // Remove multiple cards from deck
        void CardToDeck(); // Add one card from deck
        void CardToDeckRange(); // Add multiple cards from deck
    }
}
