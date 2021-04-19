using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Helpers.Enums;
using GameLibrary.Helpers.Exceptions;

namespace GameLibrary.Helpers
{
    public class Controller
    {
        private World World;

        public Controller(ref World world)
        {
            this.World = world;
        }

        public void PlayerController(InputEnum controlInputEnum, ref Creature player)
        {
            switch (controlInputEnum)
            {
                case InputEnum.Up:
                    if (player.Position.X - 1 == 0)
                    {
                        throw new IllegalMoveException("You cannot leave the area");
                    }
                    else if (World.WorldPlayGround[player.Position.X - 1, player.Position.Y].Creature != null)
                    {
                        var creature = World.WorldPlayGround[player.Position.X - 1, player.Position.Y].Creature;
                        player.Hit(creature);
                        creature?.Hit(player);
                    }
                    else
                    {
                        var play = World.WorldPlayGround[player.Position.X, player.Position.Y].Creature;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = null;
                        player.Position.X -= 1;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = play;
                    }

                    break;

                case InputEnum.Down:
                    if (player.Position.X + 1 == World.MaxX - 1)
                    {
                        throw new IllegalMoveException("You cannot leave the area");
                    }
                    else if (World.WorldPlayGround[player.Position.X + 1, player.Position.Y].Creature != null)
                    {
                        var creature = World.WorldPlayGround[player.Position.X + 1, player.Position.Y].Creature;
                        player.Hit(creature);
                        creature?.Hit(player);
                    }
                    else
                    {
                        var play = World.WorldPlayGround[player.Position.X, player.Position.Y].Creature;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = null;
                        player.Position.X += 1;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = play;
                    }

                    break;

                case InputEnum.Right:
                    if (player.Position.Y + 1 == World.MaxY - 1)
                    {
                        throw new IllegalMoveException("You cannot leave the area");
                    }
                    else if (World.WorldPlayGround[player.Position.X, player.Position.Y + 1].Creature != null)
                    {
                        var creature = World.WorldPlayGround[player.Position.X, player.Position.Y + 1].Creature;
                        player.Hit(creature);
                        creature?.Hit(player);
                    }
                    else
                    {
                        var play = World.WorldPlayGround[player.Position.X, player.Position.Y].Creature;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = null;
                        player.Position.Y += 1;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = play;
                    }

                    break;

                case InputEnum.Left:
                    if (player.Position.Y - 1 == 0)
                    {
                        throw new IllegalMoveException("You cannot leave the area");
                    }
                    else if (World.WorldPlayGround[player.Position.X, player.Position.Y - 1].Creature != null)
                    {
                        var creature = World.WorldPlayGround[player.Position.X, player.Position.Y - 1].Creature;
                        player.Hit(creature);
                        creature?.Hit(player);
                    }
                    else
                    {
                        var play = World.WorldPlayGround[player.Position.X, player.Position.Y].Creature;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = null;
                        play.Position.Y -= 1;
                        World.WorldPlayGround[play.Position.X, play.Position.Y].Creature = play;
                    }
                    break;
            }
        }

        public InputEnum ConvertInput(char x)
        {
            switch (x)
            {
                case 'w': return InputEnum.Up;
                case 's': return InputEnum.Down;
                case 'a': return InputEnum.Left;
                case 'd': return InputEnum.Right;
                default: return InputEnum.L;
            }
        }
    }
}