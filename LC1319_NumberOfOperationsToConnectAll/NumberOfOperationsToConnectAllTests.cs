using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1319_NumberOfOperationsToConnectAll
{
    [TestClass]
    public class NumberOfOperationsToConnectAllTests
    {
        [TestMethod]
        // idea union find
        public void GivenNodeNumberAndEdgeList_GetNumberOfOperationsToConnectAll_ShouldReturnCorrectAnswer()
        {
            var connections = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2}, new int[] { 1, 2} };
            var n = 4;

            var result = GetNumberOfOperationsToConnectAll(n, connections);

            Assert.IsTrue(result == 1);
        }

        private int GetNumberOfOperationsToConnectAll(int n, int[][] connections)
        {
            var unionFindSet = new UnionFindSet(n, connections).Build();

            var danglingVertices = 0;

            for (int i = 0; i < unionFindSet.ParentTable.Length; i++)
            {
                if (unionFindSet.ParentTable[i] == i || unionFindSet.ParentTable[i] == -1)
                {
                    danglingVertices++;
                }
            }

            return unionFindSet.RedundantConnections >= danglingVertices - 1 ? danglingVertices - 1 : -1;
        }

        public class UnionFindSet
        {
            private readonly int _n;
            private readonly int[][] _edges;

            public int RedundantConnections { get; private set; } = 0;
            public int[] ParentTable { get; private set; }

            public UnionFindSet(int n, int[][] edges)
            {
                _n = n;
                _edges = edges;
            }

            public UnionFindSet Build()
            {
                ParentTable = new int[_n];

                for (int i = 0; i < ParentTable.Length; i++)
                {
                    ParentTable[i] = -1;
                }

                foreach (var edge in _edges)
                {
                    Union(edge);
                }

                return this;
            }

            private void Union(int[] edge)
            {
                if (ParentTable[edge[0]] == -1 && ParentTable[edge[1]] == -1) // both are uninitialized
                {
                    ParentTable[edge[0]] = edge[0];
                    ParentTable[edge[1]] = edge[0];
                }
                else if (ParentTable[edge[0]] != -1 && ParentTable[edge[1]] != -1) // both are connected do find
                {
                    var realParent1 = Find(ParentTable[edge[0]]);
                    var realParent2 = Find(ParentTable[edge[1]]);

                    if (realParent1 == realParent2) // don't do anything
                    {
                        RedundantConnections++;
                    }
                }
                else if (ParentTable[edge[0]] == -1 || ParentTable[edge[1]] == -1)
                {
                    var one = ParentTable[edge[0]] == -1 ? edge[0] : edge[1];
                    var theOther = one == edge[0] ? edge[1] : edge[0];

                    var realParentOther = Find(theOther);
                    ParentTable[one] = realParentOther;
                }
            }

            private int Find(int node)
            {
                while (ParentTable[node] != node)
                {
                    ParentTable[node] = Find(ParentTable[node]);
                }

                return node;
            }
        }
    }
}
