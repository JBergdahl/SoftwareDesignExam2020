using System;
using System.Collections.Generic;
using System.Text;

namespace PG3302
{
    public static class PlayerFactory
    {
        public static Player CreateNewPlayer(int num, object objectLock)
        {
            // Create new player with name + lock from game board
            var player = new Player("Player" + num, objectLock);
            return player;
        }
    }
}
