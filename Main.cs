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
                Hand = new List<Card>();
            }
        }
    
        /// <summary>
        /// Main loop.
        /// </summary>
        public void StartGame()
        {
            //shuffle the decks
            ShuffleDeck(player1);
            ShuffleDeck(player2);

            //Starting hand
            DrawInitialHand(player1);
            DrawInitialHand(player2);

            //Game loop, checks both players health and card quantity.
            while (player1.HealthPoints > 0 && player2.HealthPoints > 0 
            && (player1.Deck.Count > 0 || player1.Hand.Count > 0 |
            | player2.Deck.Count > 0 || player2.Hand.Count > 0))
            {
                //Player 1 places their cards first
                PlayTurn(player1);
                //Player 2 places their cards second
                PlayTurn(player2);
                //begin autonomous combat afterwards
                AttackPhase();
            }

            //Determine the winner
            //Player 1 Health lower or equal to 0
            if (player1.HealthPoints <= 0)
                //Player 2 wins
                Console.WriteLine("Player 2 wins!");
            //Player 2 Health lower or equal to 0
            else if (player2.HealthPoints <= 0)
                //Player 1 wins
                Console.WriteLine("Player 1 wins!");
            //If players health did not go all the way to 0
            else
            {
                //Check for highest HP in case both players have no cards left
                //Player 1 has more health than player 2
                if (player1.HealthPoints > player2.HealthPoints)
                    //Player 1 wins
                    Console.WriteLine("Player 1 wins!");
                //Player 2 has more health than player 1
                else if (player2.HealthPoints > player1.HealthPoints)
                    //Player 2 wins
                    Console.WriteLine("Player 2 wins!");
                //If they have the same amount of health
                else
                    //Draw
                    Console.WriteLine("It's a draw!");
            }
        }

        /// <summary>
        /// This will shuffle the cards before giving them to the players.
        /// </summary>
        /// <param name="player"></param>
        private void DeckShuffler(Player player)
        {
            //Use this to shuffle the deck
        }

        /// <summary>
        /// Starting hand
        /// </summary>
        /// <param name="player"></param>
        private void DrawInitialHand(Player player)
        {
            //Use this to give players their hand each turn.
        }

        /// <summary>
        /// You will place your cards here
        /// </summary>
        /// <param name="player"></param>
        private void PlayTurn(Player player)
        {
            //Placement/Magic Phase
            //ADD OPTIONS FOR PLAYERS TO CHOOSE FROM.
            //1. Card list -> 1-6 depending on your hand. -> Continue or finish?
            //2. Surrender
        }

        /// <summary>
        /// This will begin the autonomous combat.
        /// </summary>
        private void AttackPhase()
        {
            //Attack Phase
        }
    }
}