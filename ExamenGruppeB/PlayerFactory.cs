using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public static class PlayerFactory
    {
        public static Player CreateNewPlayer(int num)
        {
            var player = new Player("Player" + num);
            return player;
        }
    }
}
