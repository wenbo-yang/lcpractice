using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1377_FrogPositionProbabilityAfterTSeconds
{
    [TestClass]
    public class FrogPositionProbabilityAfterTSecondsTests
    {
        [TestMethod]
        public void GivenGraphEdgesTimeAndTargetPosition_GetProbability_ShouldReturnCorrectProbability()
        {
            var n = 7; var time = 2; var target = 4;
            var edges = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 7 }, new int[] { 2, 4 }, new int[] { 2, 6 }, new int[] { 3, 5 } };

            var result = GetProbability(n, edges, time, target);

            Assert.IsTrue(result == 1.0d/6);
        }

        [TestMethod]
        public void GivenGraphEdgesTimeAndAnotherTargetPosition_GetProbability_ShouldReturnCorrectProbability()
        {
            var n = 7; var time = 1; var target = 7;
            var edges = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 7 }, new int[] { 2, 4 }, new int[] { 2, 6 }, new int[] { 3, 5 } };

            var result = GetProbability(n, edges, time, target);

            Assert.IsTrue(result == 1.0d / 3);
        }

        [TestMethod]
        public void GivenGraphEdgesAotherTimeAndAnotherTargetPosition_GetProbability_ShouldReturnCorrectProbability()
        {
            var n = 7; var time = 2; var target = 7;
            var edges = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 7 }, new int[] { 2, 4 }, new int[] { 2, 6 }, new int[] { 3, 5 } };

            var result = GetProbability(n, edges, time, target);

            Assert.IsTrue(result == 1.0d / 3);
        }

        private double GetProbability(int n, int[][] edges, int time, int target)
        {
            var table = ConstructTableFromEdges(n, edges);

            var queue = new Queue<(int node, int time, double probability)>();
            var visited = new bool[n + 1]; visited[0] = true; 
            queue.Enqueue((1, 0, 1));

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();

                if (top.node == target && top.time <= time && table[top.node].Count == 0)
                {
                    return top.probability;
                }

                if (top.time > time)
                {
                    break;
                }

                var children = table[top.node];
                foreach (var child in children)
                {
                    queue.Enqueue((child, top.time + 1, top.probability / children.Count));
                }
            }

            return 0.0d;
        }

        private Dictionary<int, List<int>> ConstructTableFromEdges(int n, int[][] edges)
        {
            var table = new Dictionary<int, List<int>>();
            for (int i = 1; i <= n; i++)
            {
                table.Add(i, new List<int>());
            }

            foreach (var edge in edges)
            {
                table[edge[0]].Add(edge[1]);
            }

            return table;
        }
    }
}
