using System;
using System.Collections.Generic;

namespace GameCode
{
    public partial class Game
    {
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
    }
}
