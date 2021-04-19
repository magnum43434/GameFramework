using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Concrete.Creatures;
using GameLibrary.Decorators.Creatures;
using GameLibrary.Handlers.ConfigFileHelper;
using GameLibrary.Handlers.Logging;
using GameLibrary.Helpers;
using GameLibrary.Helpers.Exceptions;

namespace GameLibrary.Factories
{
    public class CreatureFactory
    {
        private readonly World _world;
        private JsonTraceListener _logger;
        private Random rnd = new Random();
        private XmlConfigurations config;
        public List<string> NameArr { get; set; }

        public CreatureFactory(World world, JsonTraceListener logger)
        {
            config = XMLReader.ReadGameConfiguration<XmlConfigurations>();
            _logger = logger;
            _world = world;
            if (config is null || config.EnemyNamesList.Count == 0)
            {
                NameArr = new List<string>() { "Orc", "Troll", "Dark Elf" };
            }
            else
            {
                NameArr = new List<string>();
                for (int x = 0; x < config.EnemyNamesList.Count; x++)
                {
                    NameArr.Add(config.EnemyNamesList[x].Name);
                }
            }
            _logger.WriteLine("Initializing Creature Factory");
        }

        /// <summary>
        /// Creates a new player
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="pos">The position the player will spawn at</param>
        /// <returns></returns>
        public Creature CreatePlayerCreature(string name, Position? pos)
        {
            try
            {
                pos = GeneratePosition(pos);
            }
            catch (PositionAlreadyOccupiedException e)
            {
                _logger.WriteLine("Failed to create PlayerCreature on specified position Error:");
                _logger.WriteLine(e);
                //CreatePlayerCreature(name, null);
                throw e;
            }
            Creature creature = new PlayerCreature(200, name, pos);
            _logger.WriteLine($"Created Creature {creature}");
            return creature;
        }

        /// <summary>
        /// Creates a new creature
        /// </summary>
        /// <param name="rank"> The rank of your Creature can be boss, lieutenant, defaults to minion </param>
        /// <param name="pos">The position you want your creature to spawn at</param>
        /// <returns></returns>
        public Creature CreateEnemyCreature(string rank, Position? pos)
        {
            try
            {
                Creature creature;
                pos = GeneratePosition(pos);
                EnemyCreature baseCreature = new EnemyCreature(rnd.Next(20, 100), NameArr[rnd.Next(0, NameArr.Count)], pos);
                switch (rank)
                {
                    case "boss":
                        creature = new BossEnemy(baseCreature);
                        _logger.WriteLine($"Created Enemy Creature {creature.Name}");
                        return creature;

                    case "lieutenant":
                        creature = new LieutenantEnemy(baseCreature);
                        _logger.WriteLine($"Created Enemy Creature {creature.Name}");
                        return creature;

                    default:
                        creature = new MinionEnemy(baseCreature);
                        _logger.WriteLine($"Created Enemy Creature {creature.Name}");
                        return creature;
                }
            }
            catch (PositionAlreadyOccupiedException e)
            {
                _logger.WriteLine("Failed to create EnemyCreature on specified position Error:");
                _logger.WriteLine(e);
                //CreateEnemyCreature(rank, null);
                throw e;
            }
        }

        /// <summary>
        /// This method uses Recursion to generate a new position, if a position is already used it will run again recursively
        /// </summary>
        /// <param name="pos">The position to place a creature at</param>
        /// <returns></returns>
        private Position GeneratePosition(Position? pos)
        {
            var tempPos = pos;
            pos ??= new Position(rnd.Next(1, _world.MaxX - 1), rnd.Next(1, _world.MaxY - 1));
            return (_world.WorldPlayGround[pos.X, pos.Y].Creature == null)
                ? pos
                : (tempPos != null)
                    ? throw new PositionAlreadyOccupiedException("The position you selected is already occupied by a creature")
                    : GeneratePosition(null);
        }
    }
}