using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    public interface ICard
    {
        string DisplayCard(string playerName = "");
        CardSuit GetSuit();
        CardNumber GetNumber();
    }
}
