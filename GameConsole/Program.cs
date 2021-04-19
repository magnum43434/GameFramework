using System;
using GameLibrary;

namespace GameConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Game game = new Game(20, 40);
            game.StartGame("Legolas Greenleaf", null, 15);
        }
    }
}