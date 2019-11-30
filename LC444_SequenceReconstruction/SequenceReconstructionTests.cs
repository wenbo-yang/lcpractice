using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC444_SequenceReconstruction
{
    [TestClass]
    public class SequenceReconstructionTests
    {
        [TestMethod]
        public void GivenOriginalSequenceAndListOfEdges_CanReconstructSequence_ShouldReturnTrue()
        {
            var sequence = new int[] { 1, 2, 3 };
            var edges = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 } };

            var result = CanReconstructFromSequence(sequence, edges);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAnotherSetOriginalSequenceAndListOfEdges_CanReconstructSequence_ShouldReturnTrue()
        {
            var sequence = new int[] { 1, 2, 3 };
            var edges = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 2, 3} };

            var result = CanReconstructFromSequence(sequence, edges);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenOriginalSequenceAndMulitpleEdges_CanReconstructSequence_ShouldReturnTrue()
        {
            var sequence = new int[] { 4, 1, 5, 2, 6, 3 };
            var edges = new int[][] { new int[] { 5, 2, 6, 3 }, new int[] { 4, 1, 5, 2 } };

            var result = CanReconstructFromSequence(sequence, edges);

            Assert.IsTrue(result);
        }

        private bool CanReconstructFromSequence(int[] sequence, int[][] edges)
        {
            var childToParentTable = ConstructChildToParentTable(sequence);

            var childToParentTableFromEdges = ConstructChildToParentTableFromEdges(edges, childToParentTable);

            foreach (var pair in childToParentTable)
            {
                if (!childToParentTableFromEdges.ContainsKey(pair.Key) || childToParentTableFromEdges[pair.Key] != pair.Value)
                {
                    return false;
                }
            }

            return true;
        }

        private Dictionary<int, int> ConstructChildToParentTableFromEdges(int[][] edges, Dictionary<int, int> childToParentTable)
        {
            var childToParentTableEdges = new Dictionary<int, int>();

            foreach (var edge in edges)
            {
                for (int i = edge.Length - 1; i >= 1; i--)
                {
                    var parent = edge[i - 1];
                    var child = edge[i];
                    if (childToParentTable[child] != parent)
                    {
                        continue;
                    }
                    else
                    {
                        if (!childToParentTableEdges.ContainsKey(child))
                        {
                            childToParentTableEdges.Add(child, parent);
                        }
                    }
                }

                if (childToParentTable[edge[0]] == edge[0] && !childToParentTableEdges.ContainsKey(edge[0]))
                {
                    childToParentTableEdges.Add(edge[0], edge[0]);
                }
            }

            return childToParentTableEdges;
        }

        private Dictionary<int, int> ConstructChildToParentTable(int[] sequence)
        {
            var childToParentTable = new Dictionary<int, int>();
            for (int i = sequence.Length - 1; i >= 1; i--)
            {
                childToParentTable.Add(sequence[i], sequence[i - 1]); 
            }

            childToParentTable.Add(sequence[0], sequence[0]);
            return childToParentTable;
        }
    }
}
