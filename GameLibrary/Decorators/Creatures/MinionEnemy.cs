using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;

namespace GameLibrary.Decorators.Creatures
{
    public class MinionEnemy : EnemyDecorator
    {
        public MinionEnemy(Creature creature) : base(creature)
        {
            Name = $"A small {creature.Name}";
            HitPoints -= 5;
        }
    }
}