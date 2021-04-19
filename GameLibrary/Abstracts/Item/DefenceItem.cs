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
    public abstract class DefenceItem : IItem
    {
        public Position Position { get; set; }
        public bool IsLootable { get; set; } = true;
        public string Name { get; set; }
        public virtual int ReduceHitPoints { get; set; }
        public DefenceEnum Type { get; set; }

        protected DefenceItem(string name, int reduceHitPoints)
        {
            Name = name;
            ReduceHitPoints = reduceHitPoints;
        }

        public DefenceItem()
        {
        }
    }
}