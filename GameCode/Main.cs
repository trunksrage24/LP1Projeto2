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
            //Initialize players and their decks
            player1 = new Player
            {
                HealthPoints = 10,
                ManaPoints = 1,
                Deck = new List<Card>(),
                Hand = new List<Card>()
            };

            //Repeat the process for player 2
            player2 = new Player
            {
                HealthPoints = 10,
                ManaPoints = 1,
                Deck = new List<Card>(),
                Hand = new List<Card>()
            };
        }

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


                PlayTurn(player1, player2);
                AttackPhase();

                if (player2.HealthPoints <= 0)
                    break; // Player 2 has lost, exit the loop

                PlayTurn(player2, player1); // Player 2 takes a turn
                AttackPhase();

                if (player1.HealthPoints <= 0)
                    break; // Player 1 has lost, exit the loop

                player1.UpdateMana();
                player2.UpdateMana();


            }

            // Determine the winner
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

        /// <summary>
        /// This will shuffle the cards before giving them to the players.
        /// </summary>
        /// <param name="player"></param>
        private void DeckShuffler(Player player)
        {
            List<Card> cardList = CardList(); 

            Random random = new Random();
            //Maximum cards to draw per turn
            int totalCards = Math.Min(6, cardList.Count); 

            for (int i = 0; i < totalCards; i++)
            {
                int randomIndex = random.Next(cardList.Count);
                Card card = cardList[randomIndex];

                //Check if the card is still available (quantity > 0)
                if (card.Quantity > 0)
                {
                    player.Deck.Add(card);

                    //Decrease the quantity of the card in the card list
                    card.Quantity--;

                    //Remove the card from the card list if quantity = 0
                    if (card.Quantity == 0)
                    {
                        cardList.RemoveAt(randomIndex);
                    }
                }
                else
                {
                    //If the card is no longer available, repeat the iteration
                    i--;
                }
            }
}

        /// <summary>
        /// Randomly Generated Starting hand
        /// </summary>
        /// <param name="player"></param>
        private void DrawInitialHand(Player player)
        {
            List<Card> cardList = CardList();

            int cardsToDraw = Math.Min(6, player.Deck.Count);

            for (int i = 0; i < cardsToDraw; i++)
            {
                if (player.Deck.Count == 0)
                {
                    Console.WriteLine($"Player {(player == player1 ? "1" : "2")}'s deck is empty.");
                    break;
                }

                Random random = new Random();
                int randomIndex = random.Next(player.Deck.Count);
                Card card = player.Deck[randomIndex];
                player.Hand.Add(card);

                //Decrease the quantity of the card in the card list
                card.Quantity--;

                //Remove the card from the card list if its quantity reaches zero
                if (card.Quantity == 0)
                {
                    cardList.Remove(card);
                }

                //Remove the card from the player's deck
                player.Deck.RemoveAt(randomIndex);

                Console.WriteLine($"Player {(player == player1 ? "1" : "2")} draws {card.Name}");
            }
        }

        /// <summary>
        /// You will place your cards here
        /// </summary>
        /// <param name="player"></param>
        public void PlayTurn(Player currentPlayer, Player opponent)
        {
            currentPlayer.StartTurn();

            Console.WriteLine($"--- Player {(currentPlayer == player1 ? "1" : "2")} Turn ---");
            Console.WriteLine($"Player {(currentPlayer == player1 ? "1" : "2")} Hand:");
            for (int i = 0; i < currentPlayer.Hand.Count; i++)
            {
                Card card = currentPlayer.Hand[i];
                Console.WriteLine($"{i + 1}. {card.Name} (Cost: {card.Cost}, Power: {card.AP})");
            }

            // Placement Phase
            Console.WriteLine("Placement Phase:");
            while (currentPlayer.Hand.Count > 0)
            {
                Console.WriteLine($"Player {(currentPlayer == player1 ? "1" : "2")} Mana: {currentPlayer.ManaPoints}");
                Console.WriteLine("Enter the number of the card you want to play (or 0 to end placement phase):");
                int cardNumber = int.Parse(Console.ReadLine()) - 1;

                // Check if player wants to end the placement phase
                if (cardNumber == -1)
                {
                    break;
                }

                // Check if card number is valid
                if (cardNumber < 0 || cardNumber >= currentPlayer.Hand.Count)
                {
                    Console.WriteLine("Invalid card number. Please try again.");
                    continue;
                }

                Card card = currentPlayer.Hand[cardNumber];

                //Check if player has enough available mana to play the card
                if (card.Cost > currentPlayer.ManaPoints)
                {
                    Console.WriteLine($"Player {(currentPlayer == player1 ? "1" : "2")} does not have enough mana to play {card.Name}.");
                    continue; // Skip playing this card and move to the next one
                }

                Console.WriteLine($"Player {(currentPlayer == player1 ? "1" : "2")} puts down {card.Name}");

                //Update player's mana points and remove the card from their hand
                currentPlayer.ManaPoints -= card.Cost;
                currentPlayer.Hand.RemoveAt(cardNumber);
            }

            // Attack Phase
            Console.WriteLine("Attack Phase:");
            // ...

            // End of turn
            currentPlayer.EndTurn(currentTurn);

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }



        /// <summary>
        /// This will begin the autonomous combat.
        /// </summary>
        private void AttackPhase()
        {
            //Attack Phase
        }

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
            deck.Add(new Card("Blind Minotaurs", 3, 1, 3, 1 ));
            deck.Add(new Card("Tim, The Wizard", 5, 6, 4, 1));
            deck.Add(new Card("Sharply Dressed", 4, 3, 3, 1));
            deck.Add(new Card("Blue Steel", 1, 1, 1, 2));

            return deck;
        }
    }
}