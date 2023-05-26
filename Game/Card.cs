using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// class with list of card names and attributes to use in game
    /// </summary>
    public class Card
    {
        //Name
        private string name;
        //MP (Mana Points) cost
        private int cost;
        //AP (Attack Points)
        private int ap;
        //DP (Defense Points)
        private int dp;
        //How many of them there are
        private int Quantity;

        //constructor for card types
        public Card(string name, int cost, int ap, int dp)
        {
            this.name = name;
            this.cost = cost;
            this.ap = ap;
            this.dp = dp;
        }

        //getter and setter for each variable:
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public string AP
        {
            get { return ap; }
            set { ap = value; }
        }

        public string DP
        {
            get { return dp; }
            set { dp = value; }
        }
    }

}