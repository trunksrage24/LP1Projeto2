using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP1Projeto2
{
    public class Game
    {
        //Create player 1 and 2
        private Player player1;
        private Player player2;

        /// <summary>
        /// Main loop
        /// </summary>
        public Game()
        {
            // Initialize players and their decks
            player1 = new Player
            {
                HealthPoints = 10,
                ManaPoints = 0,
                Deck = new List<Card>
                {
                    //Card List, will have to make it randomly generated
                    new Card { "Flying wand" }
                    //Add the rest of the cards to the deck
                }
                //Create new list using the cards generated
                Hand = new List<Card>();
            }

            //Repeat the process for player 1
            player2 = new Player
            {
                HealthPoints = 10,
                ManaPoints = 0,
                Deck = new List<Card>
                {
                    //Card List, will have to make it randomly generated
                    //Add cards for player 2
                }
                //Create new list using the cards generated
                Hand = new List<Card>()
            };
        }
    }

}