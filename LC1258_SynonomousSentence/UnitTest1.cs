using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1258_SynonymousSentence
{
    [TestClass]
    public class SynonymousSentenceTests
    {
        [TestMethod]
        public void GivenPairList_GenerateSynomymousSentence_ShouldReturnAllSynomymousSentences()
        {
            var wordList = new string[][] { new string[] { "happy", "joy" }, new string[] { "sad", "sorrow" }, new string[] { "joy", "cheerful" } };

            var result = GenerateSynomymousSentence(wordList);

            Assert.IsTrue(result.Count == 6);
        }

        private List<string> GenerateSynomymousSentence(string[][] wordList)
        {
            throw new NotImplementedException();
        }

        public class UnionFindSet
        {
            private Dictionary<string, string> _childTable;
            private Dictionary<string, int> _rank;

            public void Build(string[][] edges)
            {
                foreach (var edge in edges)
                {
                    Union(edge);
                }
            }

            public void Union(string[] vertices)
            {
                if (!_childTable.ContainsKey(vertices[0]) && !_childTable.ContainsKey(vertices[1]))
                {
                    _childTable.Add(vertices[0], vertices[0]);
                    _childTable.Add(vertices[1], vertices[0]);
                    _rank.Add(vertices[0], 2);
                }
                else if (_childTable.ContainsKey(vertices[0]) && _childTable.ContainsKey(vertices[1]))
                {
                    var realParentOne = Find(vertices[0]);
                    var realParentOther = Find(vertices[1]);

                    var one = _rank[realParentOne] > _rank[realParentOther] ? realParentOther : realParentOne;
                    var other = realParentOne == one ? realParentOther : realParentOne;

                    UnionOneWithTheOther(one, other);
                }
                else
                {
                    var one = _childTable.ContainsKey(vertices[0]) ? vertices[1] : vertices[0];
                    var other = _childTable.ContainsKey(vertices[0]) ? vertices[0] : vertices[1];

                    UnionOneWithTheOther(one, other);
                }
            }

            private void UnionOneWithTheOther(string one, string other)
            {
                _rank[one]++;
                _childTable[other] = one;
            }

            public string Find(string child)
            {
                if (_childTable[child] == child)
                {
                    return child;
                }

                _childTable[child] = Find(_childTable[child]);

                return _childTable[child]; 
            }
        }


    }
}
