using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1439_KthSmallestSumInASortedMatrix
{
    [TestClass]
    public class KthSmallestSumInASortedMatrixTests
    {
        [TestMethod]
        public void GivenMatrixAndK_FindKthSmallestSum_ShouldReturnCorrectSum()
        {
            var mat = new int[][] { new int[] { 1, 10, 10 }, new int[] { 1, 4, 5 }, new int[] { 2, 3, 6 } };
            var k = 7;
            var result = FindKthSmallestSum(mat, k);

            Assert.IsTrue(result == 9);
        }

        private int FindKthSmallestSum(int[][] mat, int k)
        {
            var initialSum = GetInitialSum(mat);
            var initalCommit = new int[mat.Length];
            var heap = InitalizeHeap(mat);
            var diff = 0;

            while (k > 1)
            {
                k--;
            }
        }

        private MinHeap<(int diff, int row, int col)> InitalizeHeap(int[][] mat)
        {
            var heap = new MinHeap<(int value, int row, int col)>();
            for (int i = 0; i < mat.Length; i++)
            {
                heap.Add((mat[i][1], i, 1));
            }

            return heap;
        }

        private int GetInitialSum(int[][] mat)
        {
            var sum = 0;

            for (int i = 0; i < mat.Length; i++)
            {
                sum += mat[i][0];
            }

            return sum;
        }
    }
}
