using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC4_MediaOfTwoSortedArrays
{
    [TestClass, Ignore]
    public class MedianOfTwoSortedArraysTests
    {
        [TestMethod]
        public void GivenTwoSortedArrays_FindMedian_ShouldPartitionArrayOneAndTwoSuchThatLeftIsSmallerThanAllRight()
        {
            var array1 = new int[] { 1, 2 };
            var array2 = new int[] { 2, 3, 4 };

            var retValue = FindMedianOfTwoSortedArraysBinarySearch(array1, array2);

            Assert.IsTrue(retValue == 2.0);
        }

        [TestMethod]
        public void GivenTwoSortedArrays_FindMedian_ShouldPartitionArrayUsingBinarySearch()
        {
            var array1 = new int[] { 1, 5 };
            var array2 = new int[] { 2, 3, 4 };

            var retValue = FindMedianOfTwoSortedArraysBinarySearch(array1, array2);

            Assert.IsTrue(retValue == 3.0);
        }

        [TestMethod]
        public void GivenTwoSortedArrays_FindMedian_ShouldDealWithArrayOfOneElement()
        {
            var array1 = new int[] { 2 };
            var array2 = new int[] { 1, 3 };

            var retValue = FindMedianOfTwoSortedArraysBinarySearch(array1, array2);

            Assert.IsTrue(retValue == 2.0);
        }

        [TestMethod]
        public void GivenTwoNonIntersectingArrays_FindMedian_ShouldFindCorrectMedian()
        {
            var array1 = new int[] { 1, 2 };
            var array2 = new int[] { 3, 4 };

            var retValue = FindMedianOfTwoSortedArraysBinarySearch(array1, array2);

            Assert.IsTrue(retValue == 2.5);
        }

        // not working yet
        private double FindMedianOfTwoSortedArraysBinarySearch(int[] input1, int[] input2)
        {
            var l1 = input1.Length;
            var l2 = input2.Length;

            var p1 = l1 / 2;
            var p2 = l2 / 2;

            return 0;
        }

        private bool ResetP1AndP2(ref int p1, ref int p2)
        {
            var tempP1 = p1 / 2;
            p2 = p1 - tempP1 > 1 ? p2 + p1 - tempP1 : p2;
            p1 = tempP1;

            return true;
        }

        private double GetMediaByPivotIndices(int p1, int p2, int[] array1, int[] array2)
        {
            return 0;
        }
    }
}
