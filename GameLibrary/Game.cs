using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Concrete.Creatures;
using GameLibrary.Enums;
using GameLibrary.Factories;
using GameLibrary.Handlers.Logging;
using GameLibrary.Helpers;
using GameLibrary.Helpers.Exceptions;
using GameLibrary.Helpers.WorldGenerator;

namespace GameLibrary
{
    public class Game
    {
        public ItemFactory ItemFactory { get; set; }
        public CreatureFactory CreatureFactory { get; set; }
        public World World;
        public JsonTraceListener Logger { get; set; }
        public Controller Controller { get; set; }
        private WorldDrawing _draw;
        public Creature Player;
        private Random rnd;

        public Game(int worldMaxX, int worldMaxY)
        {
            Logger = new JsonTraceListener();
            World = new World(worldMaxX, worldMaxY);
            ItemFactory = new ItemFactory();
            CreatureFactory = new CreatureFactory(World, Logger);
            Controller = new Controller(ref World);
            rnd = new Random();
            _draw = new WorldDrawing(World);
        }

        public void SetUpEnemyCreatures(int amountOfEnemies)
        {
            var rndRank = rnd.Next(0, 3);
            string rankString = "";
            if (rndRank == 1) rankString = "boss";
            if (rndRank == 2) rankString = "lieutenant";
            if (rndRank == 3) rankString = "minion";
            var creature = CreatureFactory.CreateEnemyCreature(rankString, null);
            creature.AttackItems.AddAttackItem(ItemFactory.CreateAttackItem("sword", "Orchrist", 15, RangeEnum.Short));
            creature.DefenceItems.AddDefenceItem(ItemFactory.CreateDefenceItem("armour", "BreastPlate of Salazar", 10));
            creature.DefenceItems.AddDefenceItem(ItemFactory.CreateDefenceItem("boots", "Boots of Thunder", 2));

            World.WorldPlayGround[creature.Position.X, creature.Position.Y].Creature = creature;
            if (amountOfEnemies - 1 > 0)
            {
                SetUpEnemyCreatures(--amountOfEnemies);
            }
        }

        public void SetUpPlayer(string name, Position? position)
        {
            Player = CreatureFactory.CreatePlayerCreature(name, position);
            Player.AttackItems.AddAttackItem(ItemFactory.CreateAttackItem("bow", "Bow of the Galadhrim", 25, RangeEnum.Long));
            Player.AttackItems.AddAttackItem(ItemFactory.CreateAttackItem("sword", "Dual long knives", 50, RangeEnum.Short));
            Player.DefenceItems.AddDefenceItem(ItemFactory.CreateDefenceItem("armour", "Leather coat", 25));
            Player.DefenceItems.AddDefenceItem(ItemFactory.CreateDefenceItem("boots", "Leather boots", 15));
            World.WorldPlayGround[Player.Position.X, Player.Position.Y].Creature = Player;
        }

        private void RemoveCreaturesOnRestart()
        {
            for (int x = 0; x < World.WorldPlayGround.GetLength(0); x++)
            {
                for (int y = 0; y < World.WorldPlayGround.GetLength(1); y++)
                {
                    if (World.WorldPlayGround[x, y].Creature is EnemyCreature)
                    {
                        World.WorldPlayGround[x, y].Creature = null;
                    }
                }
            }
        }

        public void StartGame(string playerName, Position pos, int amountOfEnemies)
        {
            SetUpPlayer(playerName, pos);
            SetUpEnemyCreatures(amountOfEnemies);

            while (true)
            {
                try
                {
                    Console.WriteLine(_draw.DrawWorld(ref World.WorldPlayGround, ref Player));
                    char directionControl = Console.ReadKey().KeyChar;
                    Controller.PlayerController(Controller.ConvertInput(Convert.ToChar(directionControl)), ref Player);
                }
                catch (Exception e)
                {
                    if (e.GetType() == typeof(IllegalMoveException))
                    {
                        Console.WriteLine("Illegal move");
                    }
                    else if (e.GetType() == typeof(YouAreDeadException))
                    {
                        Console.Clear();
                        Console.WriteLine("Ohh no you are dead, press a button to restart");
                        Console.ReadKey();
                        RemoveCreaturesOnRestart();
                        StartGame("Bilbo", null, 5);
                    }
                }
            }
        }
    }
}