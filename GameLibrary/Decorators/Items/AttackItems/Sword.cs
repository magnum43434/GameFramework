using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Enums;

namespace GameLibrary.Decorators.Items.AttackItems
{
    public class Sword : AttackItem
    {
        public Sword(string name, int damage) : base(name, damage)
        {
            Type = AttackEnum.Sword;
            Range = RangeEnum.Short;
        }
    }
}