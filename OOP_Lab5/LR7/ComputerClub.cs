using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2.LR7
{
    class ComputerClub : IObservable
    {
        private List<IObserver> observers = new List<IObserver>();

        public void AddVisitor(string name)
        {
            NotifyObservers("Новый посетитель " + name + " в компьютерном клубе");
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(message);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}
