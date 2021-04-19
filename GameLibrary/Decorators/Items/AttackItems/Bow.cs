using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Enums;

namespace GameLibrary.Decorators.Items.AttackItems
{
    public class Bow : AttackItem
    {
        public Bow(string name, int damage, RangeEnum range) : base(name, damage)
        {
            Type = AttackEnum.Bow;
            Range = range;
        }
    }
}