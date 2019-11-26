using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC684_RedundantConnection
{
    [TestClass]
    public class RedundantConnectionTests
    {
        [TestMethod]
        public void GivenEdgesWithRedundantConnection_FindRedundantConnection_ShouldReturnRedundantConnection()
        {
            var edges = new int[][] { new int[] { 1, 2 }, new int[]{ 2, 3 }, new int[]{3, 4}, new int[] { 1, 4 }, new int[]{ 1, 5} };

            var result = FindRedundantConnection(edges);

            Assert.IsTrue(result.SequenceEqual(new int[] {1, 4}));
        }

        private int[] FindRedundantConnection(int[][] edges)
        {
            var edgesList = new List<Tuple<int, int>>();
            for (int i = 0; i < edges.Length; i++)
            {
                edgesList.Add(new Tuple<int, int>(edges[i][0], edges[i][1]));
            }

            edgesList.Sort();

            var parentTable = new Dictionary<int, int>();

            var current = new int[2];
            foreach (var edge in edgesList)
            {
                // union
                if (!parentTable.ContainsKey(edge.Item1))
                {
                    parentTable.Add(edge.Item1, edge.Item1);
                }

                if (!parentTable.ContainsKey(edge.Item2))
                {
                    parentTable.Add(edge.Item2, parentTable[edge.Item1]);
                }
                else
                {   // find
                    current[0] = parentTable[edge.Item2]; current[1] = edge.Item2;
                }
            }

            return current;
        }
    }
}
