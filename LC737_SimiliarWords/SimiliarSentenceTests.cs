using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC737_SimiliarWords
{
    [TestClass]
    // leetcode 734 is here as well
    public class SimiliarSentenceTests
    {
        [TestMethod]
        public void GivenTwoSimiliarSentencesAndSimilarDictionary_IsSimiliar_ShouldReturnTrue()
        {
            var sentence1 = new string[] { "fine", "acting", "skills" };
            var sentence2 = new string[] { "wonderful", "drama", "talent" };

            var pairs = new string[][] { new string[] { "fine", "great" }, new string[] { "good", "great"}, new string[] { "good", "wonderful" }, new string[] { "acting", "drama" }, new string[] { "skills", "talent" } };

            var result = IsSimiliar(sentence1, sentence2, pairs);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoSimiliarSentencesAndSimilarDictionary_IsSimiliarSinglePair_ShouldReturnTrue()
        {
            var sentence1 = new string[] { "fine", "acting", "skills" };
            var sentence2 = new string[] { "great", "drama", "talent" };

            var pairs = new string[][] { new string[] { "fine", "great" }, new string[] { "acting", "drama" }, new string[] { "skills", "talent" } };

            var result = IsSimiliarSinglePair(sentence1, sentence2, pairs);

            Assert.IsTrue(result);
        }

        private bool IsSimiliarSinglePair(string[] sentence1, string[] sentence2, string[][] pairs)
        {
            if (sentence1.Length != sentence2.Length)
            {
                return false;
            }

            var pairsSet = ParsePairsIntoSet(pairs);

            for (int i = 0; i < sentence1.Length; i++)
            {
                if (sentence1[i] == sentence2[i])
                {
                    continue;
                }

                if (!pairsSet.Contains(new Tuple<string, string>(sentence1[i], sentence2[i])))
                {
                    return false;
                }
            }

            return true;
        }

        private HashSet<Tuple<string, string>> ParsePairsIntoSet(string[][] pairs)
        {
            var result = new HashSet<Tuple<string, string>>();
            foreach (var pair in pairs)
            {
                result.Add(new Tuple<string, string>(pair[0], pair[1]));
                result.Add(new Tuple<string, string>(pair[1], pair[0]));
            }

            return result;
        }

        private bool IsSimiliar(string[] sentence1, string[] sentence2, string[][] pairs)
        {
            if (sentence1.Length != sentence2.Length)
            {
                return false;
            }

            var set = new UnionFindSet().Build(pairs);

            for (int i = 0; i < sentence1.Length; i++)
            {
                if (sentence1[i] != sentence2[i])
                {
                    var realMeaning1 = set.Find(sentence1[i]);
                    var realMeaning2 = set.Find(sentence2[i]);

                    if (realMeaning1 != realMeaning2)
                    {
                        return false;
                    }
                }
            }

            return true;   
        }

        public class UnionFindSet
        {
            private Dictionary<string, string> _childToParentTable = new Dictionary<string, string>();

            public UnionFindSet Build(string[][] edges)
            {
                foreach (var edge in edges)
                {
                    if (!_childToParentTable.ContainsKey(edge[0]) && !_childToParentTable.ContainsKey(edge[1]))
                    {
                        _childToParentTable.Add(edge[0], edge[0]);
                        _childToParentTable.Add(edge[1], edge[0]);
                    }

                    if (_childToParentTable.ContainsKey(edge[0]) && _childToParentTable.ContainsKey(edge[1]))
                    {
                        var realParent0 = Find(edge[0]);
                        var realParent1 = Find(edge[1]);

                        if (realParent0 != realParent1)
                        {
                            // join distinct sets
                            _childToParentTable[realParent0] = realParent1;
                        }

                        continue;
                    }

                    var one = _childToParentTable.ContainsKey(edge[0]) ? edge[0] : edge[1];
                    var theOther = one == edge[0] ? edge[1] : edge[0];

                    UnionOneWithTheOthet(one, theOther);
                }

                return this;
            }

            private void UnionOneWithTheOthet(string one, string theOther)
            {
                var realParent = Find(one);
                _childToParentTable.Add(theOther, realParent);
            }

            public string Find(string child)
            {
                if (_childToParentTable[child] != child)
                {
                    _childToParentTable[child] = Find(_childToParentTable[child]);
                    return _childToParentTable[child];
                }

                return child;
            }
        }
    }
}
