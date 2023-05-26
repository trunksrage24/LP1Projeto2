using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCode
{
    public class Game
    {
        private Player player1;
        private Player player2;

        private int currentTurn;

        public Game()
        {
            // Initialize players and their decks
            player1 = new Player
            {
                HealthPoints = 10,
                ManaPoints = 0,
                Deck = new List<Card>
                {
                    // Card List, will have to make it randomly generated
                    new Card("Flying wand", 1, 1, 1, 4)
                    // Add the rest of the cards to the deck
                },
                Hand = new List<Card>()
            };

            // Repeat the process for player 2
            player2 = new Player
            {
                HealthPoints = 10,
                ManaPoints = 0,
                Deck = new List<Card>
                {
                    // Card List, will have to make it randomly generated
                    // Add cards for player 2
                },
                Hand = new List<Card>()
            };
        }

        public void StartGame()
        {

            currentTurn = 1; // Initialize current turn to 1

            // Shuffle the decks
            DeckShuffler(player1);
            DeckShuffler(player2);

            // Starting hand
            DrawInitialHand(player1);
            DrawInitialHand(player2);

            //Starting hand
            DrawInitialHand(player1);
            DrawInitialHand(player2);

            //Game loop, checks both players health and card quantity.
            while (player1.HealthPoints > 0 && player2.HealthPoints > 0 
            && (player1.Deck.Count > 0 || player1.Hand.Count > 0 || 
            player2.Deck.Count > 0 || player2.Hand.Count > 0))
            {
                //Player 1 places their cards first

                //begin autonomous combat afterwards
                AttackPhase();

                PlayTurn(player1, currentTurn);
                PlayTurn(player2, currentTurn);

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
            CardList(); // Populate the deck with cards

            // Use this to shuffle the deck
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
        private void PlayTurn(Player player, int currentTurn)
        {
            Console.WriteLine($"Player {(player == player1 ? "1" : "2")}'s turn");
            Console.WriteLine("Placement Phase");

            int maxMana = Math.Min(player.MaxMana, 5); // Maximum mana for this turn
            int availableMana = Math.Min(player.ManaPoints, maxMana); // Available mana to spend

            int cardsToPlay = Math.Min(player.Hand.Count, availableMana);

            for (int i = 0; i < cardsToPlay; i++)
            {
                Card card = player.Hand[i];

                Console.WriteLine($"Player {(player == player1 ? "1" : "2")} puts down {card.Name}");
                // Add logic to handle the placement of the card

                // Update player's mana points and remove the card from their hand
                player.ManaPoints -= card.Cost;
                player.Hand.RemoveAt(i);
            }

            // Increment turn counter
            currentTurn++;

            // Update maximum mana for this turn
            if (currentTurn <= 5)
                player.MaxMana++;

            Console.WriteLine("End turn? 1, Continue 2");
            string input = Console.ReadLine();

            if (input == "1")
                return;
            else if (input == "2")
                PlayTurn(player == player1 ? player2 : player1, currentTurn);
            else
                Console.WriteLine("Invalid input. Continuing turn.");

            // Add logic for other options in the placement phase
        }




        /// <summary>
        /// This will begin the autonomous combat.
        /// </summary>
        private void AttackPhase()
        {
            //Attack Phase
        }

        private void CardList()
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
            deck.Add(new Card("Blind Minotaurs", 3, 1, 3, 1 ));
            deck.Add(new Card("Tim, The Wizard", 5, 6, 4, 1));
            deck.Add(new Card("Sharply Dressed", 4, 3, 3, 1));
            deck.Add(new Card("Blue Steel", 1, 1, 1, 2));

            foreach (Card card in deck)
            {
                Console.WriteLine("Card: {0}, {1}, {2}, {3}", card.Name, card.Cost.ToString(), card.AP.ToString(), card.DP.ToString());
            }
        }

    }
}