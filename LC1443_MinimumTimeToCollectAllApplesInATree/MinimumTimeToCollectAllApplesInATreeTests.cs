using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1443_MinimumTimeToCollectAllApplesInATree
{
    [TestClass]
    public class MinimumTimeToCollectAllApplesInATreeTests
    {
        [TestMethod]
        public void GivenEdgesAndNodeList_GetMinimumTime_ShouldReturnMinimumTime()
        {
            var edges = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 4 }, new int[] { 1, 5 }, new int[] { 2, 3 }, new int[] { 2, 6 } };
            var hasApple = new List<bool> { false, false, true, false, true, true, false }; var n = 7;

            var result = GetMinTime(n, edges, hasApple);

            Assert.IsTrue(result == 8);
        }

        private int GetMinTime(int n, int[][] edges, List<bool> hasApple)
        {
            var tree = ConstructTree(edges, n);

            var visited = new bool[hasApple.Count];

            return GetMinTimeHelper(tree, visited, 0, hasApple);
        }

        private int GetMinTimeHelper(Dictionary<int, List<int>> tree, bool[] visited, int currentNode, List<bool> hasApple)
        {
            if (visited[currentNode])
            {
                return 0;
            }
            visited[currentNode] = true;
            int ans = 0;
            foreach(var child in tree[currentNode]) 
            {
                ans += GetMinTimeHelper(tree, visited, child, hasApple);
            }
            if ((ans > 0 || hasApple[currentNode]) && currentNode != 0)
            {
                return ans + 2;
            }
            return ans;
        }

        private Dictionary<int, List<int>> ConstructTree(int[][] edges, int n)
        {
            var tree = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                tree.Add(i, new List<int>());
            }

            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]);
            }

            return tree;
        }
    }
}
