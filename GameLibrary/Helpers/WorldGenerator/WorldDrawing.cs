using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Concrete.Creatures;
using GameLibrary.Enums;
using GameLibrary.Helpers.Structs;

namespace GameLibrary.Helpers.WorldGenerator
{
    public class WorldDrawing
    {
        private World _world;
        private List<Creature> arr = new List<Creature>();

        public WorldDrawing(World world)
        {
            _world = world;
        }

        protected virtual void DrawEverything(ref Creature player)
        {
            DrawEdges(ref _world.WorldPlayGround);
            DrawGround(ref _world.WorldPlayGround);
            DrawItemsOnTheGround(ref _world.WorldPlayGround);
            DrawCreature(ref _world.WorldPlayGround, ref player);
        }

        protected virtual void DrawEdges(ref Tile[,] playGround)
        {
            for (int i = 0; i < playGround.GetLength(0); i++)
            {
                for (int j = 0; j < playGround.GetLength(1); j++)
                {
                    if (i == 0) playGround[i, j].Ground = GroundTileEnum.EdgeTopBottom;
                    if (i == playGround.GetLength(0) - 1) playGround[i, j].Ground = GroundTileEnum.EdgeTopBottom;
                    if (j == 0) playGround[i, j].Ground = GroundTileEnum.EdgeSides;
                    if (j == playGround.GetLength(1) - 1) playGround[i, j].Ground = GroundTileEnum.EdgeSides;
                    if (i == 0 && j == 0) playGround[i, j].Ground = GroundTileEnum.EdgeEmpty;
                    if (i == 0 && j == playGround.GetLength(1) - 1) playGround[i, j].Ground = GroundTileEnum.EdgeEmpty;
                }
            }
        }

        protected void DrawGround(ref Tile[,] playGround)
        {
            for (int i = 1; i < playGround.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < playGround.GetLength(1) - 1; j++)
                {
                    playGround[i, j].Ground = GroundTileEnum.EmptyGround;
                }
            }
        }

        protected virtual void DrawItemsOnTheGround(ref Tile[,] playGround)
        {
            for (int x = 0; x < playGround.GetLength(0); x++)
            {
                for (int y = 0; y < playGround.GetLength(1); y++)
                {
                    if (playGround[x, y].Object != null) playGround[x, y].Ground = GroundTileEnum.Item;
                }
            }
        }

        protected virtual void DrawCreature(ref Tile[,] playground, ref Creature player)
        {
            for (int x = 0; x < playground.GetLength(0); x++)
            {
                for (int y = 0; y < playground.GetLength(1); y++)
                {
                    if (playground[x, y].Creature is not null &&
                        playground[x, y].Creature is EnemyCreature)
                    {
                        playground[x, y].Ground = GroundTileEnum.Enemy;
                    }

                    if (playground[x, y].Creature is not null &&
                        playground[x, y].Creature is PlayerCreature)
                    {
                        arr.Add(playground[x, y].Creature);
                    }
                }
            }
            //this is the only way to draw a player??
            playground[player.Position.X, player.Position.Y].Ground = GroundTileEnum.Player;
        }

        public virtual string DrawWorld(ref Tile[,] world, ref Creature player)
        {
            Console.SetCursorPosition(0, 0);
            DrawEverything(ref player);
            StringBuilder worldString = new StringBuilder();
            for (int x = 0; x < world.GetLength(0); x++)
            {
                for (int y = 0; y < world.GetLength(1); y++)
                {
                    worldString = y == world.GetLength(1) - 1
                        ? worldString.Append((char)world[x, y].Ground + "\n")
                        : worldString.Append((char)world[x, y].Ground);
                }
            }

            return worldString.ToString();
        }
    }
}