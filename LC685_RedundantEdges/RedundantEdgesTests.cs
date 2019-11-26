using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC685_RedundantEdges
{
    [TestClass]
    public class RedundantEdgesTests
    {
        [TestMethod]
        public void GivenEdgesWithRedundantConnection_FindRedundantConnection_ShouldReturnCorrectEdges()
        {
            var edges = new int[][] { new int[] {1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 1 }, new int[] { 1, 5 }};
            var result = FindRedundantConnection(edges);

            Assert.IsTrue(result[0] == 4 && result[1] == 1);
        }

        [TestMethod]
        public void GivenAnotherSetOfEdgesWithRedundantConnection_FindRedundantConnection_ShouldReturnCorrectEdges()
        {
            var edges = new int[][] { new int[] { 1, 4 }, new int[] { 4, 3 }, new int[] { 4, 5 }, new int[] { 3, 6 }, new int[] { 5, 2 }, new int[] { 2, 4}, new int[] { 6, 1} };
            var result = FindRedundantConnection(edges);

            Assert.IsTrue(result[0] == 6 && result[1] == 1);
        }

        private int[] FindRedundantConnection(int[][] edges)
        {
            var set = new UnionFindSetDirectional<int>().Build(edges);

            var result = set.GetRedundantEdges();

            return result.Last();
        }

        public class UnionFindSetDirectional<T>
        {
            private Dictionary<T, T> _childToParentTable = new Dictionary<T, T>();
            private List<T[]> _circularConnection = new List<T[]>();

            public UnionFindSetDirectional<T> Build(T[][] edges)
            {
                foreach (var edge in edges)
                {
                    if (!_childToParentTable.ContainsKey(edge[0]) && !_childToParentTable.ContainsKey(edge[1]))
                    {
                        _childToParentTable.Add(edge[0], edge[0]);
                        _childToParentTable.Add(edge[1], edge[0]);
                       
                        continue;
                    }

                    if (_childToParentTable.ContainsKey(edge[0]) && _childToParentTable.ContainsKey(edge[1]))
                    {
                        var realParent0 = Find(edge[0]);
                        var realParent1 = Find(edge[0]);

                        if (Comparer<T>.Default.Compare(realParent0, realParent1) != 0)
                        {
                            _childToParentTable[edge[1]] = realParent0;
                        }
                        else
                        {
                            _circularConnection.Add(new T[] { edge[0], edge[1] });
                        }

                        continue;
                    }

                    if (_childToParentTable.ContainsKey(edge[0]) && !_childToParentTable.ContainsKey(edge[1]))
                    {
                        var realParent0 = Find(edge[0]);
                        _childToParentTable.Add(edge[1], realParent0);
                    }                    
                }

                return this;
            }

            public T Find(T child)
            {
                if (Comparer<T>.Default.Compare(_childToParentTable[child], child) != 0)
                {
                    _childToParentTable[child] = Find(_childToParentTable[child]);
                }

                return _childToParentTable[child];
            }

            public List<T[]> GetRedundantEdges() => _circularConnection;
        }
    }
}
