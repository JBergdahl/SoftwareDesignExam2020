using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    public static class PlayerFactory
    {
        public static Player CreateNewPlayer(int num, object Lock)
        {
            var player = new Player("Player" + num, Lock);
            return player;
        }
    }
}
