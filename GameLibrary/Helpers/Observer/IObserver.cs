using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;

namespace GameLibrary.Helpers.Observer
{
    public interface IObserver
    {
        public void Notify(Creature creature);
    }
}