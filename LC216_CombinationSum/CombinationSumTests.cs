using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC216_CombinationSum
{
    [TestClass]
    public class CombinationSumTests
    {
        [TestMethod]
        public void GivenArraySizeAndTargetSum_CombinationSum_ShouldReturnListOfAnswers()
        {
            List<List<int>> result = CombinationSum(3, 7);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].SequenceEqual(new List<int>() { 1, 2, 4}));
        }

        private List<List<int>> CombinationSum(int size, int target)
        {
            var result = new List<List<int>>();

            for (int i = 1; i < target / 2 - 1; i++)
            {
                var currentList = new List<int>() { i };
                CombinationSumHelper(currentList, i, size, target, result);
            }

            return result;
        }

        private void CombinationSumHelper(List<int> currentList, int currentSum, int size, int target, List<List<int>> result)
        {
            if (currentList.Count == size)
            {
                if (currentSum == target)
                {
                    result.Add(new List<int>(currentList));
                }

                return;
            }

            for (int i = currentList[currentList.Count - 1] + 1; i <= target / 2 + 1; i++)
            {
                currentList.Add(i);
                CombinationSumHelper(currentList, currentSum + i, size, target, result);
                currentList.RemoveAt(currentList.Count - 1);
            }
        }
    }
}
