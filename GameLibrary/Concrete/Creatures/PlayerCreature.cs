using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Helpers;
using GameLibrary.Interfaces;

namespace GameLibrary.Concrete.Creatures
{
    public class PlayerCreature : Creature
    {
        public PlayerCreature(int hitPoints, string name, Position position) : base(hitPoints, name, position)
        {
        }

        public override void Hit(ICreature defender)
        {
            int damage = AttackItems.Damage;
            defender.ReceiveHit(damage);
            Console.WriteLine(defender.HitPoints > 0
                ? $"\nYou hit the {defender.Name} for {CalculateDamage(damage, defender)}, it has {defender.HitPoints} HP left"
                : $"\n{defender.Name} is dead!");
        }
    }
}