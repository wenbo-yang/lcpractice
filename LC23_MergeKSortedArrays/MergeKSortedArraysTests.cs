using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeKSortedArrays
{
    [TestClass]
    public class MergeKSortedArraysTests
    {

        // binary merge linkedlist or use heap
        [TestMethod]
        public void GivenKSortedArray_MergeArray_ShouldOutputMergedArray()
        {
            var input = new int[][] { new int[] { 2, 4, 4 }, new int[] { 2, 2, 2, 3 }, new int[] { 1, 1 } };

            var result = MergeKSortedArrays(input);

            Assert.IsTrue(result.SequenceEqual(new int[] { 1, 1, 2, 2, 2, 2, 3, 4, 4 }));
        }

        private List<int> MergeKSortedArrays(int[][] input)
        {
            var result = new List<int>();
            var minHeap = InitializeHeap(input);

            while (minHeap.Count != 0)
            {
                var top = minHeap.Pop();
                result.Add(top.Item1);
                
                if (top.Item3 != input[top.Item2].Length - 1)
                {
                    minHeap.Add(new Tuple<int, int, int>(input[top.Item2][top.Item3 + 1], top.Item2, top.Item3 + 1));
                }
            }

            return result;
        }

        private MinHeap<Tuple<int, int, int>> InitializeHeap(int[][] input)
        {
            var minHeap = new MinHeap<Tuple<int, int, int>>(); // value, row, col

            for (int i = 0; i < input.Length; i++)
            {
                minHeap.Add(new Tuple<int, int, int>(input[i][0], i, 0));
            }

            return minHeap;
        }
    }
}
