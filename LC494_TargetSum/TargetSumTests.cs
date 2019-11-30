using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC494_TargetSum
{
    [TestClass]
    public class TargetSumTests
    {
        [TestMethod]
        public void GivenArrayAndTargetSum_FindNumOfTargetSumWays_ShouldGiveCorrectNumber()
        {
            var array = new int[] {1,1,1,1,1 };
            var targetSum = 3;

            var result = FindNumberOfTargetSumWays(array, targetSum);
            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void GivenAnotherArrayAndTargetSum_FindNumOfTargetSumWaysDFS_ShouldGiveCorrectNumber()
        {
            var array = new int[] { 1, 2, 3, 4 };
            var targetSum = 8;

            var result = FindNumberOfTargetSumWaysDFSWrong(array, targetSum);
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void GivenAnotherArrayAndTargetSum_FindNumOfTargetSumWays_ShouldGiveCorrectNumber()
        {
            var array = new int[] { 1, 2, 3, 4 };
            var targetSum = 8;

            var result = FindNumberOfTargetSumWays(array, targetSum);
            Assert.IsTrue(result == 1);
        }

        private int FindNumberOfTargetSumWaysDFSWrong(int[] array, int targetSum)
        {
            var max = array.Sum();

            var dp = new Dictionary<int, int> { { max, 1 } };

            var currentSum = max;
            var currentUsed = new bool[array.Length];

            FindNumberOfTargetSumWaysDFSHelper(currentSum, max, currentUsed, array, dp);

            return dp.ContainsKey(targetSum) ? dp[targetSum] : 0;
        }

        private void FindNumberOfTargetSumWaysDFSHelper(int currentSum, int parent, bool[] currentUsed, int[] array, Dictionary<int, int> dp)
        {
            if (currentSum < 0)
            {
                return;
            }

            if (!dp.ContainsKey(currentSum))
            {
                dp.Add(currentSum, 0);
            }

            if (currentSum != parent)
            {
                dp[currentSum] += dp[parent];
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (currentUsed[i])
                {
                    continue;
                }

                var target = currentSum - 2 * array[i];
                currentUsed[i] = true;
                FindNumberOfTargetSumWaysDFSHelper(target, currentSum, currentUsed, array, dp);
                currentUsed[i] = false;
            }

        }

        private int FindNumberOfTargetSumWays(int[] array, int targetSum)
        {
            var max = array.Sum();

            if (targetSum < 0)
            {
                targetSum = -1 * targetSum;
            }

            var dp = new Dictionary<int, int> { { max, 1 } };

            for (int i = 0; i < array.Length; i++)
            {
                var updatedDP = new Dictionary<int, int>();
                foreach (var pair in dp)
                {
                    updatedDP.Add(pair.Key - 2 * array[i], pair.Value);
                }

                foreach (var item in updatedDP)
                {
                    if (!dp.ContainsKey(item.Key))
                    {
                        dp.Add(item.Key, 0);
                    }
                    dp[item.Key] += item.Value;
                }
                
            }
            
            return dp[targetSum];
        }

        private HashSet<int> GenerateOriginalSet(int[] array)
        {
            var hashSet = new HashSet<int>();
            for (int i = 0; i < array.Length; i++)
            {
                hashSet.Add(i);
            }

            return hashSet;
        }

        private Dictionary<int, int> GenerateDP(int min, int max)
        {
            var dp = new Dictionary<int, int>();

            for (int i = min; i <= max; i++)
            {
                dp.Add(i, 0);
            }

            dp[min] = 1;
            dp[max] = 1;

            return dp;
        }
    }
}
