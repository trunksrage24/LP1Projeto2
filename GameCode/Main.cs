using System;

namespace GameCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            
            Console.WriteLine("Welcome to this card game!");
            Console.WriteLine("Type 'play' to start the game.");
            
            string response = Console.ReadLine();

            if (response.ToLower() == "play")
            {
                game.StartGame();
            }
        }
    }
}