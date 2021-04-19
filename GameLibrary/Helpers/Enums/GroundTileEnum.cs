using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Enums
{
    public enum GroundTileEnum
    {
        EmptyGround = '.',
        EdgeTopBottom = '_',
        EdgeSides = '|',
        EdgeEmpty = ' ',
        Enemy = 'E',
        Player = 'P',
        Item = 'I'
    }
}