using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP1Projeto2
{
    /// <summary>
    /// Stats for each card
    /// </summary>
    public class Cards
    {
        //Name
        public string Name { get; set; }
        //MP (Mana Points) ccost
        public int Cost { get; set; }
        //AP (Attack Points)
        public int AttackPoints { get; set; }
        //DP (Defense Points)
        public int DefensePoints { get; set; }
        //How many of them there are
        public int Quantity { get; set; }
    }

}