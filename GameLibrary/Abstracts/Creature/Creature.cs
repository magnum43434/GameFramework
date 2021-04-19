using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Concrete.AttackItems;
using GameLibrary.Concrete.DefenceItems;
using GameLibrary.Helpers;
using GameLibrary.Helpers.Observer;
using GameLibrary.Interfaces;

namespace GameLibrary.Abstracts
{
    public abstract class Creature : ICreature
    {
        private int _hitPoints;
        public string Name { get; set; }

        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                if (_hitPoints <= 0)
                {
                    DeathObserver.OnDeath(this);
                }
            }
        }

        public Position Position { get; set; }
        public CompositeDefence DefenceItems { get; set; }
        public CompositeAttack AttackItems { get; set; }

        protected Creature(int hitPoints, string name, Position position)
        {
            HitPoints = hitPoints;
            Name = name;
            Position = position;
            AttackItems = new CompositeAttack();
            DefenceItems = new CompositeDefence();
        }

        public abstract void Hit(ICreature defender);

        protected int CalculateDamage(int damage, ICreature defender)
        {
            var dmg = (damage - defender.DefenceItems.ReduceHitPoints);
            return dmg > 0 ? dmg : 0;
        }

        public void ReceiveHit(int damage)
        {
            if (DefenceItems.DefenceItems.Count != 0)
            {
                var dmg = damage - DefenceItems.ReduceHitPoints;
                if (dmg > 0) HitPoints -= dmg;
            }
            else HitPoints -= damage;
        }

        public virtual List<IItem> OnDeath()
        {
            List<IItem> droppedItems = new List<IItem>();
            if (this.AttackItems.AttackItems.Count != 0)
            {
                droppedItems.AddRange(AttackItems.AttackItems);
            }
            if (this.AttackItems.AttackItems.Count != 0)
            {
                droppedItems.AddRange(DefenceItems.DefenceItems);
            }
            else
            {
                droppedItems = null;
            }
            return droppedItems;
        }
    }
}