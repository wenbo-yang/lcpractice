using System.Collections.Generic;

namespace CommonUtilities
{

    public abstract class MonotonicQueue
    {
        protected LinkedList<int> _list = new LinkedList<int>();

        public abstract void Push(int value);
        
        public int Pop()
        {
            var value = _list.First.Value;
            _list.RemoveFirst();
            return value;
        }

        public int Peek()
        {
            return _list.First.Value;
        }

        public int Last()
        {
            return _list.Last.Value;
        }

        public int Count => _list.Count;

        public void Clear()
        {
            _list = null;
            _list = new LinkedList<int>();
        }
    }


    public class MonotonicIncreasingQueue : MonotonicQueue
    {
        public override void Push(int value)
        {
            if (Count > 0 && Peek() < value)
            {
                Clear();
            }

            _list.AddLast(value);    
        }
    }

    public class MonotonicDecreasingQueue : MonotonicQueue
    {
        public override void Push(int value)
        {
            if (Count > 0 && Peek() > value)
            {
                Clear();
            }

            _list.AddLast(value);
        }
    }
}
