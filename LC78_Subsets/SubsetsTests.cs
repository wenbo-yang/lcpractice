using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC78_Subsets
{
    [TestClass]

    // 90 with repeating number is here as well
    public class SubsetsTests
    {
        [TestMethod]
        public void GivenArray_FindAllSubsets_ShouldReturnAllSubsets()
        {
            var nums = new int[] { 1, 2, 3 };

            List<List<int>> results = FindAllSubsets(nums);

            Assert.IsTrue(results.Count == 8);
        }

        [TestMethod]
        public void GivenArrayWithRepeatingChar_FindAllSubsets_ShouldReturnAllSubsets()
        {
            var nums = new int[] { 1, 2, 2 };

            List<List<int>> results = FindAllSubsets(nums);

            Assert.IsTrue(results.Count == 6);
        }

        private List<List<int>> FindAllSubsets(int[] nums)
        {
            var results = new List<List<int>>();
            results.Add(new List<int>()); // add the empty set //

            Dfs(nums, 0, new List<int>(), results);
            return results;
        }

        void Dfs(int[] nums, int index, List<int> current, List<List<int>> results)
        {
            if (current.Count == nums.Length)
            {
                return;
            }

            for (int i = index; i < nums.Length; i++)
            {
                if (i > index && nums[i] == nums[i - 1])
                {
                    continue;
                }

                current.Add(nums[i]);
                results.Add(new List<int>(current.ToArray()));
                Dfs(nums, i+1, current, results);
                current.Remove(nums[i]);
            }
        }
    }
}
