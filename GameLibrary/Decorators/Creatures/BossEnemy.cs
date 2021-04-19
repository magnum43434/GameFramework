using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;

namespace GameLibrary.Decorators.Creatures
{
    public class BossEnemy : EnemyDecorator
    {
        public BossEnemy(Creature creature) : base(creature)
        {
            Name = $"A very big dangerous boss {creature.Name}";
            HitPoints += 200;
        }
    }
}