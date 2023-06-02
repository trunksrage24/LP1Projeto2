using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCode
{
    /// <summary>
    /// Stats for each player
    /// </summary>
    public class Player
    {
        //Health
        public int HealthPoints { get; set; }
        //MP 
        public int ManaPoints { get; set; }
        //Maximum MP for the current turn
        public int MaxMana { get; set; }
        //List of 20 cards
        public List<Card> Deck { get; set; }
        //List of 6 cards
        public List<Card> Hand { get; set; }

        public bool IsTurn { get; private set; }

        public List<Card> CombatList { get; set; } = new List<Card>();

        public void StartTurn()
        {
            IsTurn = true;
            MaxMana = Math.Min(5, MaxMana + 1); //Increase MaxMana by 1 up to a maximum of 5
            ManaPoints = MaxMana;
        }

        public void EndTurn(int turnCount)
        {
            IsTurn = false;
            Console.WriteLine($"Player {(IsTurn ? 1 : 2)} ends their turn.");
            // Add any logic you need to perform at the end of the turn
        }
    }
}