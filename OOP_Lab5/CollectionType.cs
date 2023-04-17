using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2
{
    public class CollectionType<T> : IEnumerable
    {

        private List<T> _list;

        public int Count { get { return _list.Count;} } 

        public CollectionType()
        {
            _list = new List<T>();
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Remove(T name)
        {
            _list.Remove(name);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public T this[int index] 
        {
            get => _list[index];
            set => _list[index] = value;
        }

        public void Sort(List<T> list)
        {
            _list.Clear();
            foreach (var l in list)
            {
                _list.Add(l);
            }
        }

        public List<T> GetList()
        {
            return _list;
        }


        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
