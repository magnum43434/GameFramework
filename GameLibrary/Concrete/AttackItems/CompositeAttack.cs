using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Enums;
using GameLibrary.Helpers.Exceptions;

namespace GameLibrary.Concrete.AttackItems
{
    public class CompositeAttack : AttackItem
    {
        public CompositeAttack()
        {
            AttackItems = new List<AttackItem>();
        }

        public List<AttackItem> AttackItems { get; set; }

        public override int Damage
        {
            get { return AttackItems.Sum(x => x.Damage); }
        }

        public void AddAttackItem(AttackItem item)
        {
            var items = AttackItems.FindAll(x => x.Type == item.Type);
            if (items.Count < 2 && item.Type == AttackEnum.Sword)
            {
                AttackItems.Add(item);
            }
            else if (items.Count == 0 && item.Type == AttackEnum.Bow)
            {
                AttackItems.Add(item);
            }
            else
            {
                throw new ItemAlreadyEquipped("You cannot equip this item: " + item.Type + " as you already have a maximum of these items equipped");
            }
        }
    }
}