using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC215_KthLargestInAnArray
{
    [TestClass]
    public class KthLargestElementInAnArrayTests
    {
        [TestMethod]
        public void GivenUnsortedArray_FindKthLargest_ShouldReturnKthLargest()
        {
            var input = new int[] { 3, 2, 1, 5, 6, 4 };
            var k = 2;

            var result = FindKthLargest(input, k);

            Assert.IsTrue(result == 5);
        }

        public int FindKthLargest(int[] input, int k)
        {
            var heap = new MinHeap<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (heap.Count < k)
                {
                    heap.Add(input[i]);
                }
                else if(input[i] >= heap.Peek())
                {
                    heap.Pop();
                    heap.Add(input[i]);
                }
            }

            return heap.Peek();
        }
    }
}
