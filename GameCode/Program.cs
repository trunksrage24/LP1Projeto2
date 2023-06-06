using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCode
{
    public partial class Game
    {
        //Player 1
        private Player player1;
        //Player 2
        private Player player2;
        //Player 1's cards in the battlefield
        private List<Card> player1SetDownCards;
        //Player 2's cards in the battlefield
        private List<Card> player2SetDownCards;

        //Turn for counter for mana
        private int currentTurn;

        /// <summary>
        /// Game will call methods and define players
        /// </summary>
        public Game()
        {
            //Initialize players and their decks
            //Player 1
            player1 = new Player
            {
                //Health quantity
                HealthPoints = 10,
                //Starting mana
                ManaPoints = 1,
                //Deck 
                Deck = new List<Card>(),
                //Hand
                Hand = new List<Card>()
            };

            //Player2
            player2 = new Player
            {
                //Health quantity
                HealthPoints = 10,
                //Starting mana
                ManaPoints = 1,
                //Deck 
                Deck = new List<Card>(),
                //Hand
                Hand = new List<Card>()
            };

            //List of cards in battlefield for player 1
            player1SetDownCards = new List<Card>();
            //List of cards in battlefield for player 2
            player2SetDownCards = new List<Card>();
        }

    }
}