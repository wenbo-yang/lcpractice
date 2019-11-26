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

            var table = ParseIntoParentDictionary(pairs);

            for (int i = 0; i < sentence1.Length; i++)
            {
                var word1 = sentence1[i];
                var word2 = sentence2[i];

                if (word1 == word2)
                {
                    continue;
                }

                if (table.ContainsKey(word1) && table.ContainsKey(word2))
                {
                    if (table[word1] != table[word2])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private Dictionary<string, string> ParseIntoParentDictionary(string[][] pairs)
        {
            var result = new Dictionary<string, string>();
            foreach (var pair in pairs)
            {
                if (!result.ContainsKey(pair[0]))
                {
                    result.Add(pair[0], pair[0]);
                }

                if (!result.ContainsKey(pair[1]))
                {
                    result.Add(pair[1], result[pair[0]]);
                }
            }

            return result;
        }
    }
}
