using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Concrete.Creatures;

namespace GameLibrary.Abstracts
{
    public class EnemyDecorator : EnemyCreature
    {
        public Creature Creature { get; set; }

        public EnemyDecorator(Creature creature) : base(creature.HitPoints, creature.Name, creature.Position)
        {
            Creature = creature;
            Position = creature.Position;
        }
    }
}