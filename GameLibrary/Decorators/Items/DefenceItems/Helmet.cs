using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Enums;

namespace GameLibrary.Decorators.Items.DefenceItems
{
    public class Helmet : DefenceItem
    {
        public Helmet(string name, int reduceHitPoints) : base(name, reduceHitPoints)
        {
            Type = DefenceEnum.Helmet;
        }
    }
}