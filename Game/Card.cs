using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP1Projeto2
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
    //create list for card types
    List<Card> Deck = new List<Card>();
    //create each card type
    Deck.Add(new Card("Flying Wind", 1, 1, 1));
    Deck.Add(new Card("Severed Monkey Head", 1, 2, 1));
    Deck.Add(new Card("Mystical Rock Head", 2, 0, 5));
    Deck.Add(new Card("Lobster MCCrabs", 2, 1, 3));
    Deck.Add(new Card("Goblin Troll", 3, 3, 2));
    Deck.Add(new Card("Scorching Heatwave", 4, 5, 3));
    Deck.Add(new Card("Blind Minotaurs", 3, 1, 3));
    Deck.Add(new Card("Tim, The Wizard", 5, 6, 4));
    Deck.Add(new Card("Sharply Dressed", 4, 3, 3));
    Deck.Add(new Card("Blue Steel", 1, 1, 1));

    foreach (var card in Deck)
    {
        Console.WriteLine("Card: {0},{1},{2},{3}", card.Name, card.cost, 
                                                    card.ap, card.dp);
    }
}