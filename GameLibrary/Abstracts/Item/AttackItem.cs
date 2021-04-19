using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Enums;
using GameLibrary.Helpers;
using GameLibrary.Interfaces;

namespace GameLibrary.Abstracts
{
    public abstract class AttackItem : IItem
    {
        public Position Position { get; set; }
        public bool IsLootable { get; set; } = true;
        public string Name { get; set; }
        public virtual int Damage { get; set; }
        public AttackEnum Type { get; set; }
        public RangeEnum Range { get; set; }

        protected AttackItem(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public AttackItem()
        {
        }
    }
}