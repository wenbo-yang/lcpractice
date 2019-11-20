using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC787_CheapestFlightWithKStopsToDestination
{
    [TestClass]
    public class CheapestFlightWithKStopsToDestinationTests
    {
        [TestMethod]
        public void GivenNodeAndCost_FindCheapestFlightWithKStops_ShouldReturnCost()
        {
            var input = new int[][] { new int[] { 0, 1, 100 }, new int[] { 1, 2, 100 }, new int[] { 0, 2, 500 } };
            var k = 1;
            var target = 2;

            var result = FindCheapestFlightWithKStops(input, k, target);

            Assert.IsTrue(result == 200);
        }

        private int FindCheapestFlightWithKStops(int[][] input, int k, int target)
        {
            // param validation

            var graph = BuildGraph(input);
            var cost = BuildCost(input);

            var result = FindCheapestFlightBFS(graph, cost, k, target);
            
            return result == int.MaxValue ? -1 : result;
        }

        private int FindCheapestFlightBFS(Dictionary<int, HashSet<int>> graph, Dictionary<Tuple<int, int>, int> cost, int k, int target)
        {
            var result = int.MaxValue;

            var visited = new HashSet<int>();

            var queue = new Queue<Tuple<int, int, int>>();
            queue.Enqueue(new Tuple<int, int, int>(0, 0, 0));

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                visited.Add(current.Item1);

                if (current.Item1 == target || current.Item2 > k)
                {
                    result = Math.Min(result, current.Item3);
                }
                else
                {
                    var children = graph[current.Item1];
                    foreach (var child in children)
                    {
                        queue.Enqueue(new Tuple<int, int, int>(child, current.Item2 + 1, current.Item3 + cost[new Tuple<int, int>(current.Item1, child)]));
                    }
                }
            }

            return result;
        }

        private Dictionary<int, HashSet<int>> BuildGraph(int[][] input)
        {
            var graph = new Dictionary<int, HashSet<int>>();

            foreach (var edge in input)
            {
                if (!graph.ContainsKey(edge[0]))
                {
                    graph.Add(edge[0], new HashSet<int>());
                }

                graph[edge[0]].Add(edge[1]);
            }

            return graph;
        }

        private Dictionary<Tuple<int, int>, int> BuildCost(int[][] input)
        {
            var costMapping = new Dictionary<Tuple<int, int>, int>();
            foreach (var cost in input)
            {
                costMapping.Add(new Tuple<int, int>(cost[0], cost[1]), cost[2]);
            }

            return costMapping;
        }
    }
}
