using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.CustomQueue
{
    class CustomQueue<T> : IEnumerable<T>
    {
        public int Count => _linkedList.Count;

        private readonly LinkedList<T> _linkedList = new LinkedList<T>();

        public void Enqueue(T item)
        {
            _linkedList.AddLast(item);
        }

        public T Dequeue()
        {
            if (Count > 0)
            {
                T item = _linkedList.First.Value;
                _linkedList.RemoveFirst();
                return item;
            }
            throw new InvalidOperationException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _linkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
