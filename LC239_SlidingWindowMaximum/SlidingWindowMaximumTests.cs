using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC239_SlidingWindowMaximum
{
    [TestClass]
    public class SlidingWindowMaximumTests
    {
        [TestMethod]
        public void GivenIncreasingSequence_MonotonicQueue_ShouldHaveOnlyOne()
        {
            var input = new int[] { 1, 2, 3, 4, 5 };

            var queue = new MonotonicQueue();
            foreach (var item in input)
            {
                queue.Push(item);
            }

            Assert.IsTrue(queue.Peek() == 5);
            Assert.IsTrue(queue.Count == 1);
        }

        [TestMethod]
        public void GivenDecreasingSequence_MonotonicQueue_ShouldHaveFiveElements()
        {
            var input = new int[] { 5, 4, 3, 2, 1 };

            var queue = new MonotonicQueue();
            foreach (var item in input)
            {
                queue.Push(item);
            }

            Assert.IsTrue(queue.Peek() == 5);
            Assert.IsTrue(queue.Count == 5);
        }


        [TestMethod]
        public void GivenDecreasingSequenceAndWindowEqualToArray_FindSlidingWindowMaximum_ShouldReturnOneResult()
        {
            var array = new int[] { 3, 2, 1};

            List<int> result = FindMaximum(array, 3);

            Assert.IsTrue(result.SequenceEqual(new List<int>() { 3 }));
        }

        [TestMethod]
        public void GivenIncreasingSequenceAndWindowEqualToArray_FindSlidingWindowMaximum_ShouldReturnOneResult()
        {
            var array = new int[] { 1, 2, 3 };

            List<int> result = FindMaximum(array, 3);

            Assert.IsTrue(result.SequenceEqual(new List<int>() { 3 }));
        }

        [TestMethod]
        public void GivenDecreasingSequenceAndWindowSmallerThanArray_FindSlidingWindowMaximum_ShouldReturnCorrectResults()
        {
            var array = new int[] { 3, 2, 1, 0 };

            List<int> result = FindMaximum(array, 3);

            Assert.IsTrue(result.SequenceEqual(new List<int>() { 3, 2 }));
        }

        [TestMethod]
        public void GivenIncreasingSequenceAndWindowSmallerThanArray_FindSlidingWindowMaximum_ShouldReturnCorrectResults()
        {
            var array = new int[] { 1, 2, 3, 4 };

            List<int> result = FindMaximum(array, 3);

            Assert.IsTrue(result.SequenceEqual(new List<int>() { 3, 4 }));
        }

        [TestMethod]
        public void GivenArrayAndWindowSize_FindMaximum_ShouldReturnListOfMaximums()
        {
            var array = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };

            List<int> result = FindMaximum(array, 3);

            Assert.IsTrue(result.SequenceEqual(new List<int>() { 3, 3, 5, 5, 6, 7 }));
        }

        private List<int> FindMaximum(int[] array, int size)
        {
            var result = new List<int>();
            var l = 0;
            var r = 0;
            var queue = new MonotonicQueue();

            var currentWindowMaximum = int.MinValue;

            while (r < size)
            {
                if (array[r] > currentWindowMaximum)
                {
                    currentWindowMaximum = array[r];
                }

                queue.Push(array[r]);
                r++;
            }

            result.Add(currentWindowMaximum);

            while (r < array.Length)
            {
                if (array[l] == queue.Peek() && queue.Count > 1)
                {
                    queue.Pop();
                }

                queue.Push(array[r]);
                result.Add(queue.Peek());

                l++;
                r++;
            }


            return result;
        }
    }
}
