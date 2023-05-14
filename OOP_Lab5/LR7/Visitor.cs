using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2.LR7
{
    class Visitor : IObserver
    {
        private string name;

        public Visitor(string name)
        {
            this.name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine("Посетитель" + name + "сел за компьютер: " + message);
        }
    }
}
