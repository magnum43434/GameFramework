using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Concrete.Creatures;
using GameLibrary.Helpers.Exceptions;
using GameLibrary.Helpers.Observer;
using GameLibrary.Helpers.Structs;
using GameLibrary.Interfaces;

namespace GameLibrary
{
    public class World : IObserver
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        private List<IWorldObject> WorldObjects;

        public Tile[,] WorldPlayGround;
        public DeathObserver DeathObserver { get; set; } = new DeathObserver();

        public World(int maxX, int maxY)
        {
            WorldObjects = new List<IWorldObject>();
            MaxX = maxX;
            MaxY = maxY;
            WorldPlayGround = new Tile[maxX, maxY];
            DeathObserver.AddObserver(this);
        }

        public void Notify(Creature creature)
        {
            //dropping items upon death
            var droppedItems = creature.OnDeath();
            if (droppedItems != null && WorldPlayGround[creature.Position.X, creature.Position.Y].Object == null)
            {
                WorldPlayGround[creature.Position.X, creature.Position.Y].Object = new List<IWorldObject>() { };
                WorldPlayGround[creature.Position.X, creature.Position.Y].Object.AddRange(droppedItems);
            }
            //else if(droppedItems != null)
            //{
            //    WorldPlayGround[creature.Position.X, creature.Position.Y].Object.AddRange(droppedItems);
            //}
            //Destroys the creature
            if (creature.GetType() == typeof(PlayerCreature))
            {
                throw new YouAreDeadException("The player has died");
            }
            WorldPlayGround[creature.Position.X, creature.Position.Y].Creature = null;
        }
    }
}