using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC480_SlidingWindowMedian
{
    [TestClass]
    public class SlidingWindowMediaTests
    {
        // this is the same as running median
        [TestMethod]
        public void GivenArrayAndWindow_SlidingWindowMedian_ShouldReturnResultArray()
        {
            var input = new double[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            var window = 3;

            var medians = SlidingWindowMedian(input, window);

            Assert.IsTrue(medians.SequenceEqual(new List<double> { 1, -1, -1, 3, 5, 6 }));
        }

        private List<double> SlidingWindowMedian(double[] input, int window)
        {
            if (window < 2 || window > input.Length)
            {
                throw new ArgumentException();
            }

            var result = new List<double>();

            var maxHeap = new MaxHeap<double>();
            var minHeap = new MinHeap<double>();

            maxHeap.Add(Math.Min(input[0], input[1]));
            minHeap.Add(Math.Max(input[0], input[1]));
            var currentMedian = (maxHeap.Peek() + minHeap.Peek()) / 2;
            var index = 2;
            while (index < window)
            {
                currentMedian = FindMedian(maxHeap, minHeap, currentMedian, input, index, window);
                index++;
            }
            result.Add(currentMedian);
            for (int i = index; i < input.Length; i++)
            {
                currentMedian = FindMedian(maxHeap, minHeap, currentMedian, input, i, window);
                result.Add(currentMedian);
            }

            return result;
        }

        private double FindMedian(MaxHeap<double> maxHeap, MinHeap<double> minHeap, double currentMedian, double[] input, int index, int window)
        {
            var runningMedian = currentMedian;
            if (minHeap.Count + maxHeap.Count == window)
            {
                var toRemove = input[index - window];
                if (minHeap.Contains(toRemove))
                {
                    minHeap.Remove(toRemove);

                }
                else
                {
                    maxHeap.Remove(toRemove);
                }

                runningMedian = RebalanceAndCalculateMedian(minHeap, maxHeap);
            }

            var target = input[index];
            if (target >= runningMedian)
            {
                minHeap.Add(target);
            }
            else
            {
                maxHeap.Add(target);
            }


            return RebalanceAndCalculateMedian(minHeap, maxHeap);
        }

        private double RebalanceAndCalculateMedian(MinHeap<double> minHeap, MaxHeap<double> maxHeap)
        {
            if (minHeap.Count == maxHeap.Count - 2)
            {
                minHeap.Add(maxHeap.Pop());
            }
            else if (maxHeap.Count == minHeap.Count - 2)
            {
                maxHeap.Add(minHeap.Pop());
            }

            if (minHeap.Count == maxHeap.Count)
            {
                return (maxHeap.Peek() + minHeap.Peek()) / 2;
            }

            return maxHeap.Count > minHeap.Count ? maxHeap.Peek() : minHeap.Peek();
        }
    }
}
