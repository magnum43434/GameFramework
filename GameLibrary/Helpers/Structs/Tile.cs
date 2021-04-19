using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Enums;
using GameLibrary.Interfaces;

namespace GameLibrary.Helpers.Structs
{
    public struct Tile
    {
        public GroundTileEnum Ground { get; set; }
        public List<IWorldObject>? Object { get; set; }
        public Creature? Creature { get; set; }
    }
}