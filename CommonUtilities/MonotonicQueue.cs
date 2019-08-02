using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities
{
    public class MonotonicQueue
    {
        private LinkedList<int> list = new LinkedList<int>();

        public void Push(int value)
        {
            if (Count > 0 && Peek() < value)
            {
                Clear();
            }

            list.AddLast(value);
        }

        public int Pop()
        {
            var value = list.First.Value;
            list.RemoveFirst();
            return value;
        }

        public int Peek()
        {
            return list.First.Value;
        }

        public int Count => list.Count;

        public void Clear()
        {
            list = null;
            list = new LinkedList<int>();
        }
    }
}
