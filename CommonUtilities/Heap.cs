using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities
{
    public abstract class Heap<T>
    {
        internal readonly List<T> _heap = new List<T>();
        
        public T Peek()
        {
            return _heap[0];
        }

        public void Add(T value)
        {
            _heap.Add(value);
            HeapUp();
        }

        public T Pop()
        {
            var retVal = _heap[0];

            Swap(0, Count - 1);
            _heap.RemoveAt(Count - 1);

            if (Count > 0)
            {
                HeapDown();
            }

            return retVal;
        }

        // assume this is o(1) search and o(logk) removal
        public void Remove(T target)
        {
            for (int i = 0; i < _heap.Count; i++)
            {
                if (Comparer<T>.Default.Compare(_heap[i], target) == 0)
                {
                    Swap(i, Count - 1);
                    _heap.RemoveAt(Count - 1);

                    if (Count > 0)
                    {
                        HeapDown();
                    }
                }
            }
        }

        public bool Contains(T target)
        {
            for (int i = 0; i < _heap.Count; i++)
            {
                if (Comparer<T>.Default.Compare(_heap[i], target) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public int Count => _heap.Count;
        internal abstract void HeapUp();
        internal abstract void HeapDown();

        internal void Swap(int i, int j)
        {
            var temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }
    }

    public class MinHeap<T> : Heap<T>
    {
        internal override void HeapUp()
        {
            var current = Count - 1;

            while (current != 0)
            {
                var parent = current % 2 == 0 ? current / 2 - 1 : current / 2;
                
                if (Comparer<T>.Default.Compare(_heap[current], _heap[parent]) >=0 )
                {
                    break;
                }

                Swap(current, parent);
                current = parent;
            }
        }

        internal override void HeapDown()
        {
            var current = 0;

            while (current < Count)
            {
                var left = current * 2 + 1;
                var right = current * 2 + 2;
                var index = current;
                if (left < Count && right < Count)
                {
                    
                    index = Comparer<T>.Default.Compare(_heap[left], _heap[right]) < 0 ? left : right;
                }
                else if (right >= Count)
                {
                    index = left;
                }

                if (index >= Count || Comparer<T>.Default.Compare(_heap[index], _heap[current]) > 0)
                {
                    break;
                }

                Swap(current, index);
                current = index;
            }
        }
    }

    public class MaxHeap<T> : Heap<T>
    {
        internal override void HeapUp()
        {
            var current = Count - 1;

            while (current != 0)
            {
                var parent = current % 2 == 0 ? current / 2 - 1 : current / 2;
                if (Comparer<T>.Default.Compare(_heap[current], _heap[parent]) <= 0)
                {
                    break;
                }

                Swap(current, parent);
                current = parent;
            }
        }

        internal override void HeapDown()
        {
            var current = 0;

            while (current < Count)
            {
                var left = current * 2 + 1;
                var right = current * 2 + 2;
                var index = current;
                if (left < Count && right < Count)
                {
                    index = Comparer<T>.Default.Compare(_heap[left], _heap[right]) > 0 ? left : right;
                }
                else if (right >= Count)
                {
                    index = left;
                }

                if (index >= Count || Comparer<T>.Default.Compare(_heap[index], _heap[current]) < 0)
                {
                    break;
                }

                Swap(current, index);
                current = index;
            }
        }

        public bool Find(Tuple<int, int> tuple)
        {
            throw new NotImplementedException();
        }
    }
}
