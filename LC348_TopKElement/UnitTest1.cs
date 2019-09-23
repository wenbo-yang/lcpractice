using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC348_TopKElement
{
    [TestClass]
    public class TopKFrequentElementTests
    {
        [TestMethod]
        public void GivenArray_TopKFrequentElement_ShouldReturnTopKFrequentElement()
        {
            var input = new int[] { 1, 1, 1, 2, 2, 3, 4 };

            var result = TopKFrequentElement(input, 2);

            Assert.IsTrue(result.SingleOrDefault(x => x == 1) == 1);
            Assert.IsTrue(result.SingleOrDefault(x => x == 2) == 2);
        }

        [TestMethod]
        public void GivenArrayOfOneElement_TopKFrequentElement_ShouldReturnTopKFrequentElement()
        {
            var input = new int[] { 1 };

            var result = TopKFrequentElement(input, 1);

            Assert.IsTrue(result.SingleOrDefault(x => x == 1) == 1);
        }

        private int[] TopKFrequentElement(int[] input, int topK)
        {
            var heap = new MinHeap();

            var table = new Dictionary<int, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!table.ContainsKey(input[i]))
                {
                    table.Add(input[i], 0);
                }

                table[input[i]]++;
            }

            foreach (var item in table)
            {
                if (heap.Count < topK)
                {
                    heap.Add(item.Key);
                }
                
                if (heap.Count == topK && table[heap.Peek()] < item.Value)
                {
                    heap.Pop();
                    heap.Add(item.Key);
                }
            }

            var list = new List<int>();

            while (heap.Count != 0)
            {
                list.Add(heap.Pop());
            }

            return list.ToArray();
        }
    }
}
