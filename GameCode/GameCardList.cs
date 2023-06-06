using System;
using System.Collections.Generic;

namespace GameCode
{
    public partial class Game
    {
        /// <summary>
        /// Card deck list
        /// </summary>
        /// <returns></returns>
        private List<Card> CardList()
        {
            // Create list for card types
            List<Card> deck = new List<Card>();

            // Create each card type and add it to the deck
            deck.Add(new Card("Flying Wind", 1, 1, 1, 4));
            deck.Add(new Card("Severed Monkey Head", 1, 2, 1, 4));
            deck.Add(new Card("Mystical Rock Head", 2, 0, 5, 2));
            deck.Add(new Card("Lobster MCCrabs", 2, 1, 3, 2));
            deck.Add(new Card("Goblin Troll", 3, 3, 2, 2));
            deck.Add(new Card("Scorching Heatwave", 4, 5, 3, 1));
            deck.Add(new Card("Blind Minotaurs", 3, 1, 3, 1));
            deck.Add(new Card("Tim, The Wizard", 5, 6, 4, 1));
            deck.Add(new Card("Sharply Dressed", 4, 3, 3, 1));
            deck.Add(new Card("Blue Steel", 1, 1, 1, 2));

            return deck;
        }
    }
}
