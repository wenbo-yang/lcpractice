using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC77_Combinations
{
    [TestClass]
    public class CombinationsTests
    {
        [TestMethod]
        public void GivenListArray_FindCombinations_ShouldGenerateLists()
        {
            var n = 4;
            var k = 2;

            List<List<int>> result = FindCombinations(n, k);

            Assert.IsTrue(result.Count == 6);
        }

        private List<List<int>> FindCombinations(int n, int k)
        {
            var results = new List<List<int>>();
            Dfs(n, k, new List<int>(), results);

            return results;
        }

        private void Dfs(int n, int k, List<int> current, List<List<int>> results)
        {
            if (current.Count == k)
            {
                results.Add(new List<int>(current.ToArray()));
                return;
            }

            var last = current.Count == 0 ? 0 : current[current.Count - 1];

            for (int i = last + 1; i <= n; i++)
            {
                current.Add(i);
                Dfs(n, k, current, results);
                current.Remove(i);
            }
        }
    }
}
