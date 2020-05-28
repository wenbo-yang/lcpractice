using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1414_FindMinimumNumberOfFibonacciTargetSumK
{
    [TestClass]
    public class FindMinimumNumberOfFibonacciTargetSumKTests
    {
        [TestMethod]
        public void GivenTargetSumK_FindMinNumberOfFibWithTargetSumK_ShouldReturnMinimum()
        {
            var k = 19;
            var result = FindMinNumberOfFibWithTargetSumK(k);

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void GivenAnotherTargetSumK_FindMinNumberOfFibWithTargetSumK_ShouldReturnMinimum()
        {
            var k = 9083494;
            var result = FindMinNumberOfFibWithTargetSumK(k);

            Assert.IsTrue(result == 10);
        }

        [TestMethod]
        public void GivenThirdTargetSumK_FindMinNumberOfFibWithTargetSumK_ShouldReturnMinimum()
        {
            var k = 991244035;
            var result = FindMinNumberOfFibWithTargetSumK(k);

            Assert.IsTrue(result == 14);
        }

        private int FindMinNumberOfFibWithTargetSumK(int k)
        {
            var max = 1000000000;
            var fibSet = GenerateFibonacciSet(max);
            var fibList = fibSet.AsEnumerable().ToList();
            var result = 0;

            while (!fibSet.Contains(k))
            {
                var index = FindLastIndexSmallerThanK(fibList, k);

                k = k - fibList[index];
                result++;
            }

            return result + 1;
        }

        private int FindLastIndexSmallerThanK(List<int> fibList, int k)
        {
            for (int i = 0; i < fibList.Count; i++)
            {
                if (k < fibList[i])
                {
                    return i - 1;
                }
            }

            return -1;
        }

        private HashSet<int> GenerateFibonacciSet(int max)
        {
            var result = new HashSet<int>();

            var current = 1;
            var prev = 1;
            result.Add(current);
            while (current <= max)
            {
                var temp = current;
                current = current + prev;
                prev = temp;
                result.Add(current);
            }

            return result;
        }
    }
}
