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
        //Name of the card
        private string name;
        //How much mana it costs
        private int cost;
        //Attack to reduce DP and health of player
        private int ap;
        //Defense against AP
        private int dp;
        //How many there are
        private int quantity;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="ap"></param>
        /// <param name="dp"></param>
        /// <param name="quantity"></param>
        public Card(string name, int cost, int ap, int dp, int quantity)
        {
            this.name = name;
            this.cost = cost;
            this.ap = ap;
            this.dp = dp;
            this.quantity = quantity;
        }

        //Get and set the name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //Get and set the cost
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        //Get and set the attack power
        public int AP
        {
            get { return ap; }
            set { ap = value; }
        }

        //Get and set the defense power
        public int DP
        {
            get { return dp; }
            set { dp = value; }
        }

        //Get and set the quantity
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}
