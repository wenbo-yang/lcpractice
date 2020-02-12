using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1296_DivideArrayIntoSetsOfKConsecutiveNumbers
{
    [TestClass]
    public class DivideArrayIntoSetsOfKConsecutiveNumbersTests
    {
        [TestMethod]
        public void GivenValidArrayAndSize_IsPossibleToDivide_ShouldReturnTrue()
        {
            var nums = new int[] { 1, 2, 3, 3, 4, 4, 5, 6 };
            var k = 4;

            var result = IsPossibleToDivide(nums, k);

            Assert.IsTrue(result);
        }

        private bool IsPossibleToDivide(int[] nums, int k)
        {
            if(nums == null && nums.Length % k != 0)
            {
                return false;    
            }

            var sortedMap = new SortedDictionary<int, int>();

            foreach (var num in nums)
            {
                if (!sortedMap.ContainsKey(num))
                {
                    sortedMap.Add(num, 0);
                }

                sortedMap[num]++;
            }

            while (sortedMap.Count != 0)
            {
                var first = sortedMap.First().Key;
                if (!CanPartition(first, k, sortedMap))
                {
                    break;
                }
            }

            return sortedMap.Count == 0;
        }

        private bool CanPartition(int first, int k, SortedDictionary<int, int> sortedMap)
        {
            for (int key = first; key < first + k; key++)
            {
                if (!sortedMap.ContainsKey(key))
                {
                    return false;
                }

                sortedMap[key]--;

                if (sortedMap[key] == 0)
                {
                    sortedMap.Remove(key);
                }
            }

            return true;
        }
    }
}
