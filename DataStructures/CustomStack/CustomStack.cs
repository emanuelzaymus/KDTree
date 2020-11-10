using System;
using System.Collections.Generic;

namespace DataStructures.CustomStack
{
    class CustomStack<T>
    {
        public int Count => _linkedList.Count;

        private readonly LinkedList<T> _linkedList = new LinkedList<T>();

        public void Push(T item)
        {
            _linkedList.AddLast(item);
        }

        public T Pop()
        {
            if (Count > 0)
            {
                T item = _linkedList.Last.Value;
                _linkedList.RemoveLast();
                return item;
            }
            throw new InvalidOperationException();
        }

    }
}
