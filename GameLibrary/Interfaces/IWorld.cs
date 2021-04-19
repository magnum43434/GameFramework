using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;
using GameLibrary.Helpers.Observer;

namespace GameLibrary.Interfaces
{
    public interface IWorld : IObserver
    {
        int MaxX { get; set; }
        int MaxY { get; set; }
        DeathObserver DeathObserver { get; set; }

        void Notify(Creature creature);
    }
}