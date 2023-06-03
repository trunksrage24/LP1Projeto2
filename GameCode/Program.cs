using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCode
{
    public class Game
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

        /// <summary>
        /// Cards inside the battlefield
        /// </summary>
        public void PrintSetDownCards()
        {
            //Player 1's cards in the battlefield
            Console.WriteLine("Player 1's Set Down Cards:");
            //Write their stats for each card inside the battlefield
            foreach (Card card in player1SetDownCards)
            {
                Console.WriteLine($"{card.Name} (Cost: {card.Cost}, Power: {card.AP}), Defense: {card.DP}");
            }

            //Player 2's cards in the battlefield
            Console.WriteLine("Player 2's Set Down Cards:");
            //Write their stats for each card inside the battlefield
            foreach (Card card in player2SetDownCards)
            {
                Console.WriteLine($"{card.Name} (Cost: {card.Cost}, Power: {card.AP}), Defense: {card.DP}");
            }
        }

        /// <summary>
        /// At the beginning of the game it will call these functions
        /// </summary>
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

        /// <summary>
        /// This will shuffle the cards before giving them to the players.
        /// </summary>
        /// <param name="player"></param>
        private void DeckShuffler(Player player)
        {
            //List of cards in cardlist
            List<Card> cardList = CardList(); 

            //Randomize
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
            //Cards given out
            List<Card> cardList = CardList();

            //6 cards from the draw
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
        /// You will place your cards here and also check your stats
        /// </summary>
        /// <param name="player"></param>
        public void PlayTurn(Player currentPlayer, Player opponent)
        {
            //Player stats are shown each turn
            currentPlayer.StartTurn();

            Console.WriteLine($"--- Player {(currentPlayer == player1 ? "1" : "2")} Turn ---");
            Console.WriteLine($"Player {(currentPlayer == player1 ? "1" : "2")} Health: {currentPlayer.HealthPoints}");
            Console.WriteLine($"Player {(currentPlayer == player1 ? "1" : "2")} Hand:");
            for (int i = 0; i < currentPlayer.Hand.Count; i++)
            {
                Card card = currentPlayer.Hand[i];
                Console.WriteLine($"{i + 1}. {card.Name} (Cost: {card.Cost}), (Power: {card.AP}), (Defense: {card.DP})");
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

                //Check if card number is valid
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

                // Add the card to the set down cards list
                if (currentPlayer == player1)
                {
                    player1SetDownCards.Add(card);
                }
                else if (currentPlayer == player2)
                {
                    player2SetDownCards.Add(card);
                }
            }

            //End of turn
            currentPlayer.EndTurn(currentTurn);
            
            
            //Permission to continue
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }


        /// <summary>
        /// This will begin the autonomous combat.
        /// </summary>
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
            deck.Add(new Card("Blind Minotaurs", 3, 1, 3, 1 ));
            deck.Add(new Card("Tim, The Wizard", 5, 6, 4, 1));
            deck.Add(new Card("Sharply Dressed", 4, 3, 3, 1));
            deck.Add(new Card("Blue Steel", 1, 1, 1, 2));

            return deck;
        }
    }
}