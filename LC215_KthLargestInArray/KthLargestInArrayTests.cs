using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC215_KthLargestInArray
{
    [TestClass]
    public class KthLargestInArrayTests
    {
        [TestMethod]
        public void GivenArray_Add_ShouldConstructMinHeap()
        {
            var minHeap = new MinHeap();
            var array = new int[] { 2, 3, 3, 1, -1, -2 };

            foreach (var item in array)
            {
                minHeap.Add(item);
            }

            var result = minHeap.Peek();

            Assert.IsTrue(result == -2);
        }

        [TestMethod]
        public void GivenMinHeap_Pop_ReturnInSortedOrder()
        {
            var minHeap = new MinHeap();
            var array = new int[] { 2, 3, 3, 1, -1, - 2};

            foreach (var item in array)
            {
                minHeap.Add(item);
            }

            var sortedList = new List<int>();

            while (minHeap.Count > 0)
            {
                sortedList.Add(minHeap.Pop());
            }

            Assert.IsTrue(sortedList.SequenceEqual(new List<int>() { -2, -1, 1, 2, 3, 3 }));
        }


        [TestMethod]
        public void GivenArray_Add_ShouldConstructMaxHeap()
        {
            var maxHeap = new MaxHeap();
            var array = new int[] { 2, 3, 3, 1, -1 };

            foreach (var item in array)
            {
                maxHeap.Add(item);
            }

            var result = maxHeap.Peek();

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void GivenMaxHeap_Pop_ReturnInSortedOrder()
        {
            var maxHeap = new MaxHeap();
            var array = new int[] { 2, 3, 3, 1, -1 };

            foreach (var item in array)
            {
                maxHeap.Add(item);
            }

            var sortedList = new List<int>();

            while (maxHeap.Count > 0)
            {
                sortedList.Add(maxHeap.Pop());
            }

            Assert.IsTrue(sortedList.SequenceEqual(new List<int>() { 3, 3, 2, 1, -1 }));
        }

        [TestMethod]
        public void GivenArray_FindKthLargest_ShouldReturnCorrectResult()
        {
            var array = new int[] { 3, 2, 1, 5, 6, 4 };
            var k = 2;

            var result = FindKthLargest(array, k);

            Assert.IsTrue(result == 5);
        }

        private int FindKthLargest(int[] array, int k)
        {
            // param validation
            var minHeap = new MinHeap();

            foreach (var item in array)
            {
                if (minHeap.Count < k)
                {
                    minHeap.Add(item);
                }
                else
                {
                    if (item > minHeap.Peek())
                    {
                        minHeap.Add(item);
                        minHeap.Pop();
                    }
                }
            }

            return minHeap.Peek();
        }
    }
}
