using System;
using StoryAdventure.Models;

namespace StoryAdventure
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("You see an abandoned house...");
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            Game newGame = new Game(name, 0);
            newGame.RunGame();
        }
    }
}
