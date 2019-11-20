using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC785_IsGraphBipartite
{
    [TestClass]
    public class IsGraphBipartiteTests
    {
        [TestMethod]
        public void GivenBipartiteGraph_IsGraphBipartite_ShouldReturnTrue()
        {
            var nodes = new int[][] { new int[] { 1, 3 }, new int[] { 0, 2 }, new int[] { 1, 3 }, new int[] { 0, 2 } };
            var result = IsGraphBipartite(nodes);

            Assert.IsTrue(result);
        }

        private bool IsGraphBipartite(int[][] nodes)
        {
            var color = new Color[nodes.Length];

            for (int i = 0; i < nodes.Length; i++)
            {
                if (color[i] != 0)
                {
                    continue;
                }

                color[i] = Color.ColorA;

                var queue = new Queue<int>();
                queue.Enqueue(i);

                while (queue.Count != 0)
                {
                    var current = queue.Dequeue();

                    foreach (var child in nodes[current])
                    {
                        if (color[child] == color[current])
                        {
                            return false;
                        }

                        if (color[child] == Color.Uncolored) // put it into another color
                        {
                            color[child] = color[current] == Color.ColorA ? Color.ColorB : Color.ColorA;
                        }
                    }
                }
            }

            return true;
        }

        private enum Color
        {
            Uncolored = 0,
            ColorA,
            ColorB
        }
    }
}
