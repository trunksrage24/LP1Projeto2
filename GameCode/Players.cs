using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCode
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
        //Maximum MP for the current turn
        public int MaxMana { get; set; }
        //List of 20 cards
        public List<Card> Deck { get; set; }
        //List of 6 cards
        public List<Card> Hand { get; set; }
    }
}