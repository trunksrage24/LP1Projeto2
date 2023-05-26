using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCode
{
    /// <summary>
    /// Class with card attributes to use in the game
    /// </summary>
    public class Card
    {
        private string name;
        private int cost;
        private int ap;
        private int dp;
        private int quantity;

        // Constructor for card types
        public Card(string name, int cost, int ap, int dp, int quantity)
        {
            this.name = name;
            this.cost = cost;
            this.ap = ap;
            this.dp = dp;
            this.quantity = quantity;
        }

        // Getter and setter for each variable:
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public int AP
        {
            get { return ap; }
            set { ap = value; }
        }

        public int DP
        {
            get { return dp; }
            set { dp = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}
