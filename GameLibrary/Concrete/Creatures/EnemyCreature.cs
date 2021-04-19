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
    public class EnemyCreature : Creature
    {
        public EnemyCreature(int hitPoints, string name, Position position) : base(hitPoints, name, position)
        {
        }

        public override void Hit(ICreature defender)
        {
            int damage = AttackItems.Damage;
            defender.ReceiveHit(damage);
            Console.WriteLine(defender.HitPoints > 0
                ? $"{defender.Name} have been hit for {CalculateDamage(damage, defender)}, you have {defender.HitPoints} HP left"
                : $"Ohh NO! {defender.Name} is dead!");
        }
    }
}