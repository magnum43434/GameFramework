using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Abstracts;

namespace GameLibrary.Helpers.Observer
{
    public class DeathObserver : IObservable
    {
        private static List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        private static void NotifyObservers(Creature creature)
        {
            foreach (var observer in _observers)
            {
                observer.Notify(creature);
            }
        }

        public static void OnDeath(Creature creature)
        {
            NotifyObservers(creature);
        }
    }
}