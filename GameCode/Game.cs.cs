using System;
using System.Collections.Generic;

namespace GameCode
{
    public partial class Game
    {
        // Existing fields and constructor

        public void StartGame()
        {
            currentTurn = 1; 

            //Shuffle the decks before giving out cards
            DeckShuffler(player1);
            DeckShuffler(player2);

            //Starting hand for each player
            DrawInitialHand(player1);
            DrawInitialHand(player2);

            //Game loop, checks both players' health and card quantity
            while (player1.HealthPoints > 0 && player2.HealthPoints > 0
                && (player1.Deck.Count > 0 || player1.Hand.Count > 0
                || player2.Deck.Count > 0 || player2.Hand.Count > 0))
            {
                //Player 1's turn
                PlayTurn(player1, player2);
                Console.WriteLine(player1.HealthPoints);
                Console.WriteLine("\n" , "---------------" , "\n");
                if (player2.HealthPoints <= 0)
                    break; // Player 2 has lost, exit the loop

                //Player 2's turn
                PlayTurn(player2, player1); // Player 2 takes a turn
                Console.WriteLine("\n" , "---------------" , "\n");
                if (player1.HealthPoints <= 0)
                    break; // Player 1 has lost, exit the loop

                PrintSetDownCards();
                Console.WriteLine("\n" , "---------------" , "\n");

                //All cards in battlefield will fight
                AttackPhase();

                //ask if players want to quit
                Console.WriteLine("Type in \"quit\" if you want to quit");
                if (Console.ReadLine().ToLower() == "quit")
                {
                    //Goodbye message
                    Console.WriteLine("Exiting the game. Thanks for playing!");
                    Environment.Exit(0);
                }

            }

            //Determine the winner
            if (player1.HealthPoints <= 0 && player2.HealthPoints <= 0)
            {
                Console.WriteLine("It's a draw!");
            }
            else if (player1.HealthPoints <= 0)
            {
                Console.WriteLine("Player 2 wins!");
            }
            else if (player2.HealthPoints <= 0)
            {
                Console.WriteLine("Player 1 wins!");
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        private void AttackPhase()
        {
            //Create a list to hold defeated cards
            var defeatedCards = new List<Card>();

            //Player 1's cards attack Player 2's cards
            foreach (var card1 in player1SetDownCards)
            {
                foreach (var card2 in player2SetDownCards)
                {
                    card2.DP -= card1.AP;
                    card1.DP -= card2.AP;

                    // Check if Player 2's card is defeated
                    if (card2.DP <= 0)
                    {
                        defeatedCards.Add(card2);
                    }

                    // Check if Player 1's card is defeated
                    if (card1.DP <= 0)
                    {
                        defeatedCards.Add(card1);
                    }
                }
            }

            //Remove defeated cards from Player 2's set down cards
            foreach (var card in defeatedCards)
            {
                player2SetDownCards.Remove(card);
            }

            //Remove defeated cards from Player 1's set down cards
            foreach (var card in defeatedCards)
            {
                player1SetDownCards.Remove(card);
            }

            //Player 1's surviving cards attack Player 2's health
            foreach (var card in player1SetDownCards)
            {
                if (player2.HealthPoints <= 0)
                {
                    break;
                }

                player2.HealthPoints -= card.AP;
            }

            // Player 2's surviving cards attack Player 1's health
            foreach (var card in player2SetDownCards)
            {
                if (player1.HealthPoints <= 0)
                {
                    break;
                }

                player1.HealthPoints -= card.AP;
            }
        }
    }
}
