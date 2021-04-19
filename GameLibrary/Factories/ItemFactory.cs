﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Decorators.Items.AttackItems;
using GameLibrary.Decorators.Items.DefenceItems;
using GameLibrary.Enums;
using GameLibrary.Interfaces;

namespace GameLibrary.Factories
{
    public class ItemFactory
    {/// <summary>
     /// Creates weapons
     /// </summary>
     /// <param name="itemType">What type of weapon you want, sword or bow</param>
     /// <param name="damage">The damage of the weapon</param>
     /// <param name="name">The name of the weapon</param>
     /// <param name="range">The range of the weapon</param>
     /// <returns></returns>
        public AttackItem CreateAttackItem(string itemType, string name, int damage, RangeEnum range = RangeEnum.Short)
        {
            switch (itemType)
            {
                case "sword":
                    return new Sword(name, damage);

                case "bow":
                    return new Bow(name, damage, range);

                default: return null;
            }
        }

        /// <summary>
        /// Creates armour
        /// </summary>
        /// <param name="itemType">What type of armour you want</param>
        /// <param name="name">The name of the armour</param>
        /// <param name="reduceDamage">The reduced damage of the weapon</param>
        /// <returns></returns>
        public DefenceItem CreateDefenceItem(string itemType, string name, int reduceDamage)
        {
            switch (itemType)
            {
                case "armour":
                    return new Armour(name, reduceDamage);

                case "boots":
                    return new Boots(name, reduceDamage);

                case "helmet":
                    return new Helmet(name, reduceDamage);

                case "shield":
                    return new Shield(name, reduceDamage);

                default: return null;
            }
        }
    }
}