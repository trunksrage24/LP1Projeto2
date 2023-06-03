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
        //Health of player
        public int HealthPoints { get; set; }
        //MP or Mana that player can use per turn
        public int ManaPoints { get; set; }
        //Maximum MP for each turn
        public int MaxMana { get; set; }
        //List of 20 cards
        public List<Card> Deck { get; set; }
        //List of 6 cards
        public List<Card> Hand { get; set; }

        public bool IsTurn { get; private set; }

        public List<Card> CombatList { get; set; } = new List<Card>();

        /// <summary>
        /// Mana increment and check if turn is true
        /// </summary>
        public void StartTurn()
        {
            //If the turn is true then the game continues
            IsTurn = true;
            //Max mana will increase +1 every turn until 5
            MaxMana = Math.Min(5, MaxMana + 1); 
            //Mana points utilized in game, will update every turn to be Max.
            ManaPoints = MaxMana;
        }

        /// <summary>
        /// If turn is false
        /// </summary>
        /// <param name="turnCount"></param>
        public void EndTurn(int turnCount)
        {
            //If turn ends then allows for other processes.
            IsTurn = false;
            //Allow processes to play
            Console.WriteLine($"Player {(IsTurn ? 1 : 2)} ends their turn.");
            
        }
    }
}