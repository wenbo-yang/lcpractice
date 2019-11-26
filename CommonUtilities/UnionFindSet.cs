using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities
{
    public class UnionFindSet<T>
    {
        private Dictionary<T, T> _childToParentTable = new Dictionary<T, T>();
        private Dictionary<T, int> _parentRank = new Dictionary<T, int>();
        private List<T[]> _redundantEdges = new List<T[]>();


        public UnionFindSet<T> Build(T[][] edges)
        {
            foreach (var edge in edges)
            {
                if (!_childToParentTable.ContainsKey(edge[0]) && !_childToParentTable.ContainsKey(edge[1]))
                {
                    _childToParentTable.Add(edge[0], edge[0]);
                    _childToParentTable.Add(edge[1], edge[0]);

                    _parentRank.Add(edge[0], 1);
                    _parentRank.Add(edge[1], 0);

                    continue;
                }

                if (_childToParentTable.ContainsKey(edge[0]) && _childToParentTable.ContainsKey(edge[1]))
                {
                    // join two distinct set //
                    var realParent1 = Find(edge[0]);
                    var realParent2 = Find(edge[0]);

                    if (Comparer<T>.Default.Compare(realParent1, realParent2) != 0)
                    {
                        if (_parentRank[realParent1] > _parentRank[realParent2])
                        {
                            _childToParentTable[realParent2] = realParent1;
                            _parentRank[realParent1]++;
                        }
                        else
                        {
                            _childToParentTable[realParent1] = realParent2;
                            _parentRank[realParent2]++;
                        }
                    }
                    else
                    {
                        _redundantEdges.Add(new T[] { edge[0], edge[1] });
                    }

                    continue;                    
                }

                var one = _childToParentTable.ContainsKey(edge[0]) ? edge[0] : edge[1];
                var theOther = Comparer<T>.Default.Compare(one, edge[0]) == 0? edge[1] : edge[0];

                UnionOneWithTheOther(one, theOther);
            }

            return this;
        }

        private void UnionOneWithTheOther(T one, T theOther)
        {
            var realParent = Find(one);
            _parentRank[realParent]++;
            _childToParentTable.Add(theOther, realParent);
        }

        public T Find(T child)
        {
            if (Comparer<T>.Default.Compare(_childToParentTable[child], child) != 0)
            {
                _childToParentTable[child] = Find(_childToParentTable[child]);
            }

            return _childToParentTable[child];
        }

        public List<T[]> GetRedundantEdges() => _redundantEdges;
    }

}
