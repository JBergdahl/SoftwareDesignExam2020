using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public interface ICard
    {
        string DisplayCard(string playerName = "");
        CardSuit GetSuit();
        CardNumber GetNumber();
    }
}
