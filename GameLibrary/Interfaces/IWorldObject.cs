using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Helpers;

namespace GameLibrary.Interfaces
{
    public interface IWorldObject
    {
        public Position Position { get; set; }
        public bool IsLootable { get; set; }
        public string Name { get; set; }
    }
}