using System;
using System.Collections.Generic;

namespace Blatomic.Threading
{
    public class ThreadSafeList<T> : ThreadSafeBase
    {
        private readonly List<T> list = new List<T>();

        public void LockedAction(Action<List<T>> action)
        {
            lock (_lock)
                action(list);
        }

        public TResult LockedFunction<TResult>(Func<List<T>, TResult> func)
        {
            lock (_lock)
                return func(list);
        }

        public void Add(T item)
        {
            lock (_lock)
                list.Add(item);
        }

        public void Remove(T item)
        {
            lock (_lock)
                list.Remove(item);
        }

        public IEnumerable<T> GetItems()
        {
            lock (_lock)
                foreach (var item in list)
                    yield return item;
        }

        public void Clear()
        {
            lock (_lock)
                list.Clear();
        }

        public int Count
        {
            get
            {
                lock (_lock)
                    return list.Count;
            }
        }

        public T Find(Predicate<T> match)
        {
            lock (_lock)
                return list.Find(match);
        }

        public List<T> FindAll(Predicate<T> match)
        {
            lock (_lock)
                return list.FindAll(match);
        }

        public bool Contains(T item)
        {
            lock (_lock)
                return list.Contains(item);
        }

        public int IndexOf(T item)
        {
            lock (_lock)
                return list.IndexOf(item);
        }

        public T IndexOf(int index)
        {
            lock (_lock)
                return list[index];
        }

        public void ForEach(Action<T> action)
        {
            lock (_lock)
                list.ForEach(action);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            lock (_lock)
                list.AddRange(collection);
        }
    }
}