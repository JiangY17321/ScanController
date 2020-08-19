using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FlowController
{
    public class SynQueue<T>
    {
        private readonly AutoResetEvent _ars;
        private readonly Mutex _mutex;
        private readonly List<T> _list;

        public SynQueue()
        {
            _list = new List<T>();
            _mutex = new Mutex();
            _ars = new AutoResetEvent(false);
        }

        public int Count
        {
            get
            {
                _mutex.WaitOne();
                int count = _list.Count;
                _mutex.ReleaseMutex();
                return count;
            }
        }

        public T Dequeue()
        {
            _mutex.WaitOne(-1, true);
            while (_list.Count == 0)
            {
                _mutex.ReleaseMutex();
                _ars.WaitOne(-1, true);
                _mutex.WaitOne(-1, true);
            }
            T local = _list.ElementAt(0);
            _list.RemoveAt(0);
            _mutex.ReleaseMutex();
            return local;
        }

        public List<T> DequeueAll(int timeout = -1)
        {
            _mutex.WaitOne(-1, true);
            while (_list.Count == 0)
            {
                _mutex.ReleaseMutex();
                _ars.WaitOne(timeout, true);
                if (_list.Count == 0 && timeout != -1)
                {
                    return null;
                }
                _mutex.WaitOne(-1, true);
            }
            List<T> list = new List<T>();
            list.AddRange(_list);
            _list.Clear();
            _mutex.ReleaseMutex();
            return list;
        }

        public void Enqueue(T t)
        {
            if (t == null) return;
            _mutex.WaitOne(-1, true);
            _list.Add(t);
            _ars.Set();
            _mutex.ReleaseMutex();
        }

        public T Peek()
        {
            _mutex.WaitOne(-1, true);
            while (_list.Count == 0)
            {
                _mutex.ReleaseMutex();
                _ars.WaitOne(-1, true);
                _mutex.WaitOne(-1, true);
            }
            T local = _list.ElementAt(0);
            _mutex.ReleaseMutex();
            return local;
        }

        public T Peek(int interval)
        {
            _mutex.WaitOne(-1, true);
            _ars.WaitOne(interval, true);
            T local = default(T);
            if (_list.Count > 0)
            {
                local = _list.ElementAt(0);
            }
            _mutex.ReleaseMutex();
            return local;
        }

        public List<T> PeekAll()
        {
            _mutex.WaitOne(-1, true);
            while (_list.Count == 0)
            {
                _mutex.ReleaseMutex();
                _ars.WaitOne(-1, true);
                _mutex.WaitOne(-1, true);
            }
            List<T> list = new List<T>();
            list.AddRange(_list);
            _mutex.ReleaseMutex();
            return list;
        }

        public void RemoveItem(T t)
        {
            _mutex.WaitOne(-1, true);
            _list.Remove(t);
            _mutex.ReleaseMutex();
        }
    }
}
