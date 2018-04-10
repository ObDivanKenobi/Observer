using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class ObservableList<T> : IObservable, IList<T>
    {
        static int instancesQuantity = 0;

        List<IObserver> _observers;
        List<T> _innerList;

        public ObservableList()
        {
            _observers = new List<IObserver>();
            _innerList = new List<T>();
            ++instancesQuantity;
        }

        #region IList intact
        public int Count => ((IList<T>)_innerList).Count;

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((IList<T>)_innerList).CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly => ((IList<T>)_innerList).IsReadOnly;

        public IEnumerator<T> GetEnumerator()
        {
            return ((IList<T>)_innerList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<T>)_innerList).GetEnumerator();
        }

        public bool Contains(T item)
        {
            return ((IList<T>)_innerList).Contains(item);
        }

        public int IndexOf(T item)
        {
            return ((IList<T>)_innerList).IndexOf(item);
        }
        #endregion

        #region IList modified
        public void Insert(int index, T item)
        {
            ((IList<T>)_innerList).Insert(index, item);
            NotifyAll($"{item.ToString()} was inserted into {GetType()}-{instancesQuantity}");
        }

        public void RemoveAt(int index)
        {
            ((IList<T>)_innerList).RemoveAt(index);
            NotifyAll($"From {GetType()}-{instancesQuantity} was removed {index}th entry");
        }

        public void Add(T item)
        {
            ((IList<T>)_innerList).Add(item);
            NotifyAll($"{item.ToString()} was added into {GetType()}-{instancesQuantity}");
        }

        public void Clear()
        {
            ((IList<T>)_innerList).Clear();
            NotifyAll($"{GetType()}-{instancesQuantity} was cleared");
        }

        public bool Remove(T item)
        {
            if (((IList<T>)_innerList).Remove(item))
            {
                NotifyAll($"{item.ToString()} was removed from {GetType()}-{instancesQuantity}");
                return true;
            }

            return false;
        }

        public T this[int index]
        {
            get => ((IList<T>)_innerList)[index];
            set
            {
                ((IList<T>)_innerList)[index] = value;
                NotifyAll($"{index}th entry of {GetType()}-{instancesQuantity} was changed to {value}");
            }
        }
        #endregion

        #region IObservable
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }
        #endregion

        private void NotifyAll(string message)
        {
            foreach (IObserver observer in _observers)
                observer.Update(message);
        }


    }
}
