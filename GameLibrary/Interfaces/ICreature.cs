using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Concrete.AttackItems;
using GameLibrary.Concrete.DefenceItems;

namespace GameLibrary.Interfaces
{
    public interface ICreature
    {
        string Name { get; set; }
        int HitPoints { get; set; }

        abstract void Hit(ICreature defender);

        abstract void ReceiveHit(int damage);

        public CompositeDefence DefenceItems { get; set; }
        public CompositeAttack AttackItems { get; set; }
    }
}