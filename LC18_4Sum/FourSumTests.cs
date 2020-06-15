using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC18_4Sum
{
    [TestClass]
    public class FourSumTests
    {
        [TestMethod]
        public void GivenArray_FourSum_ShouldReturnAllPossibleCombinations()
        {
            var nums = new int[] { 1, 0, -1, 0, -2, 2 };
            var target = 0;
            var result = FourSum(nums, target);

            Assert.IsTrue(result.Count == 3);
        }

        private List<List<int>> FourSum(int[] nums, int target)
        {
            var result = new List<List<int>>();

            var twoSums = TwoSum(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var sum = nums[i] + nums[j];

                    var other = target - sum;

                    if (twoSums.ContainsKey(other))
                    {
                        var values = twoSums[other];

                        foreach(var value in values)
                        {
                            if (!Overlapping(value.a, value.b, i, j))
                            {
                                result.Add(new List<int> { value.a, value.b, i, j });
                            }
                        }
                    }
                }
            }

            return result;
        }

        private bool Overlapping(int a, int b, int i, int j)
        {
            return a == i || a == j || b == i || b == j;
        }

        private Dictionary<int, HashSet<(int a, int b)>> TwoSum(int[] nums)
        {
            var twoSums = new Dictionary<int, HashSet<(int a, int b)>>();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var sum = nums[i] + nums[j];

                    if (!twoSums.ContainsKey(sum))
                    {
                        twoSums.Add(sum, new HashSet<(int a, int b)>());
                    }

                    twoSums[sum].Add((i, j));
                }
            }

            return twoSums;
        }
    }
}
