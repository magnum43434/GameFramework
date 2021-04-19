using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Helpers.Exceptions;

namespace GameLibrary.Concrete.DefenceItems
{
    public class CompositeDefence : DefenceItem
    {
        public List<DefenceItem> DefenceItems { get; set; }

        public CompositeDefence()
        {
            DefenceItems = new List<DefenceItem>();
        }

        public override int ReduceHitPoints
        {
            get
            {
                return DefenceItems.Sum(x => x.ReduceHitPoints);
            }
            set { base.ReduceHitPoints = value; }
        }

        public void AddDefenceItem(DefenceItem item)
        {
            if (!DefenceItems.Contains(DefenceItems.Find(x => x.Type == item.Type)))
            {
                DefenceItems.Add(item);
            }
            else
            {
                throw new ItemAlreadyEquipped("You cannot equip another item of the same type!");
            }
        }
    }
}