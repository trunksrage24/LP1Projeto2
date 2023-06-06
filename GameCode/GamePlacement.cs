using System;
using System.Collections.Generic;

namespace GameCode
{
    public partial class Game
    {
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
    }
}
