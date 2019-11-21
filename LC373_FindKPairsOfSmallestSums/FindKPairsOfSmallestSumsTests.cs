using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC373_FindKPairsOfSmallestSums
{
    [TestClass]
    public class FindKPairsOfSmallestSumsTests
    {
        [TestMethod]
        public void GivenTwoSortedArrays_FindKPairsOfSmallestSums_ShouldReturnCorrectResult()
        {
            var array1 = new int[] { 1, 7, 11 };
            var array2 = new int[] { 2, 4, 6 };

            var k = 3;

            var result = FindKPairsOfSmallestSums(array1, array2, k);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result.Contains(new Tuple<int, int>(1, 2)));
            Assert.IsTrue(result.Contains(new Tuple<int, int>(1, 4)));
            Assert.IsTrue(result.Contains(new Tuple<int, int>(1, 6)));
        }
        private List<Tuple<int, int>> FindKPairsOfSmallestSums(int[] array1, int[] array2, int k)
        {
            var heap = new MaxHeap<Tuple<int, int, int>>(); // sum, a1, a2;

            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    var sum = array1[i] + array2[j];
                    if (heap.Count < k)
                    {
                        heap.Add(new Tuple<int, int, int>(sum, array1[i], array2[j]));
                    }
                    else
                    {
                        var top = heap.Peek();

                        if (top.Item1 > sum)
                        {
                            heap.Pop();
                            heap.Add(new Tuple<int, int, int>(sum, array1[i], array2[j]));
                        }
                        else 
                        {
                            break;
                        }
                    }
                }
            }

            var result = new List<Tuple<int, int>>();
            while (heap.Count != 0)
            {
                var top = heap.Pop();
                result.Add(new Tuple<int, int>(top.Item2, top.Item3));
            }

            return result;
        }
    }
}


