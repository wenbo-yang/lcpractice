using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC88_MergeSortedArray
{
    [TestClass]
    public class MergeSortedArrayTests
    {
        [TestMethod]
        // merge from back to front;
        public void GivenTwoSortedArray_Merge_ShouldDoInPlaceMerge()
        {
            var a1 = new int[] { 1, 2, 3, 0, 0, 0 };
            var a2 = new int[] { 2, 5, 6 };

            int[] output = Merge(a1, 3, a2);

            Assert.IsTrue(output.SequenceEqual(new int[] { 1, 2, 2, 3, 5, 6 }));
        }

        private int[] Merge(int[] a1, int actualLength, int[] a2)
        {
            // param validation

            var l1 = a1.Length > a2.Length ? actualLength : a1.Length;
            var l2 = a2.Length > a1.Length ? actualLength : a2.Length;

            var longest = a1.Length > a2.Length ? a1.Length : a2.Length;
            var output = a1.Length > a2.Length ? a1 : a2;

            int i = l1 - 1;
            int j = l2 - 1;
            int index = longest - 1;
            while (i >= 0 && j >= 0)
            {
                output[index] = a1[i] >= a2[j] ? a1[i--] : a2[j--];
                index--;
            }

            return output;
        }
    }
}
