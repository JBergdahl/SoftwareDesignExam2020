using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    class Player
    {
        public List<Player> player_list = new List<Player>();
        {
            Console.WriteLine("How many players are playing? (2-4)");
            player_list.Add(new Player(Console.ReadLine()));
        }

        
        public string name;
        public List<Turns> turn_list = new List<Turns>();
        public Player(string _name)
        {
            name = _name;

        }

    
        
     
    }
}
