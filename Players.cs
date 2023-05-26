using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP1Projeto2
{
    /// <summary>
    /// Stats for each player
    /// </summary>
    public class Player
    {
        //Health
        public int HealthPoints { get; set; }
        //MP 
        public int ManaPoints { get; set; }
        //List of 20 cards
        public List<Card> Deck { get; set; }
        //List of 6 cards
        public List<Card> Hand { get; set; }
    }
}