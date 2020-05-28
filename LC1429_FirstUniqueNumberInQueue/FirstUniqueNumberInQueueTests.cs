using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1429_FirstUniqueNumberInQueue
{
    [TestClass]
    public class FirstUniqueNumberInQueueTests
    {
        [TestMethod]
        public void GivenArray_GetFirstUnique_ShouldReturnCorrectAnswer()
        {
            FirstUnique firstUnique = new FirstUnique(new int[] { 2, 3, 5 });
            Assert.IsTrue(firstUnique.ShowFirstUnique() == 2); // return 2
            firstUnique.Add(5);            // the queue is now [2,3,5,5]
            Assert.IsTrue(firstUnique.ShowFirstUnique() == 2); // return 2
            firstUnique.Add(2);            // the queue is now [2,3,5,5,2]
            Assert.IsTrue(firstUnique.ShowFirstUnique() == 3); // return 3
            firstUnique.Add(3);            // the queue is now [2,3,5,5,2,3]
            Assert.IsTrue(firstUnique.ShowFirstUnique() == -1); // return -1
        }
    }

    public class FirstUnique
    {
        private LinkedList<int> _uniqueQueue = new LinkedList<int>();
        private Dictionary<int, LinkedListNode<int>> _uniqueTable = new Dictionary<int, LinkedListNode<int>>();
        private HashSet<int> _nonUniqueSet = new HashSet<int>();

        public FirstUnique(int[] array)
        {
            Initialize(array);
        }

        private void Initialize(int[] array)
        {
            foreach (var item in array)
            {
                AddToQueue(item);
            }
        }

        private void AddToQueue(int number)
        {
            if (!_nonUniqueSet.Contains(number))
            {
                if (!_uniqueTable.ContainsKey(number))
                {
                    _uniqueQueue.AddLast(number);
                    _uniqueTable.Add(number, _uniqueQueue.Last);
                }
                else
                {
                    _uniqueQueue.Remove(_uniqueTable[number]);
                    _uniqueTable.Remove(number);
                    _nonUniqueSet.Add(number);
                }
            }
        }

        public void Add(int number)
        {
            AddToQueue(number);
        }

        public int ShowFirstUnique()
        {
            return _uniqueQueue.Count == 0 ? -1 : _uniqueQueue.First.Value;
        }
    }
}
