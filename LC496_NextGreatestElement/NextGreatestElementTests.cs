using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC496_NextGreatestElement
{
    [TestClass]
    public class NextGreatestElementTests
    {
        [TestMethod]
        public void GivenSubarrayAndArray_FindNextGreatestElement_ShouldReturnArray()
        {
            var array = new int[] { 1, 3, 4, 2 };
            var subarray = new int[] { 4, 1, 2};

            var result = FindNextGreatestElement(subarray, array);

            Assert.IsTrue(result.SequenceEqual(new int[] { -1, 2, -1 }));
        }

        [TestMethod]
        public void GivenAnotherSubarrayAndArray_FindNextGreatestElement_ShouldReturnArray()
        {
            var array = new int[] { 1, 2, 3, 4 };
            var subarray = new int[] { 2, 4 };

            var result = FindNextGreatestElement(subarray, array);

            Assert.IsTrue(result.SequenceEqual(new int[] { 3, -1 }));
        }

        private int[] FindNextGreatestElement(int[] subarray, int[] array)
        {
            var sortedMap = new SortedDictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                sortedMap.Add(array[i], i);
            }

            var nextGreaterIndex = new Dictionary<int, int>();
            var left = 0;
            var sortedArray = sortedMap.Keys.ToArray();
            var currentMaxLeft = sortedMap.Count - 1;

            for (int i = 1; i < sortedMap.Count; i++)
            {
                while (left < sortedMap.Count - 1)
                {
                    var leftIndex = sortedMap[sortedArray[left]];

                    if (leftIndex == currentMaxLeft)
                    {
                        nextGreaterIndex.Add(sortedArray[left], -1);
                        left++;
                        currentMaxLeft--;
                        break;
                    }

                    var rightIndex = sortedMap[sortedArray[i]];
                    if (leftIndex < rightIndex)
                    {
                        nextGreaterIndex.Add(sortedArray[left], rightIndex);
                        left++;
                        break;
                    }
                }
            }

            nextGreaterIndex.Add(sortedArray.Last(), -1);

            var result = new int[subarray.Length];

            for (int i = 0; i < result.Length; i++)
            {
                var index = nextGreaterIndex[subarray[i]];
                result[i] = index == -1 ? -1 : array[index];
            }

            return result;
        }
        
    }
}
