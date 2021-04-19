using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;

namespace GameLibrary.Decorators.Creatures
{
    public class LieutenantEnemy : EnemyDecorator
    {
        public LieutenantEnemy(Creature creature) : base(creature)
        {
            Name = $"An important lieutenant {creature.Name}";
            HitPoints += 20;
        }
    }
}