using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    public interface ICard
    {
        // Displays card number + suit. playerName is passed to card decorators
        string DisplayCard(string playerName = "");
        CardSuit GetSuit(); // Get card suit
        CardNumber GetNumber(); // Get card number
    }
}
