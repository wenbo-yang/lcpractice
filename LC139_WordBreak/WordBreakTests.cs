using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC139_WordBreak
{
    // 139 is dp // 140 is dfs
    [TestClass]
    public class WordBreakTests
    {
        [TestMethod]
        public void GivenDictionaryAndCorrectString_WordBreak_ShouldReturnTrue()
        {
            var set = new HashSet<string>() { "leet", "code" };
            var target = "leetcode";

            bool result = WorkBreak(target, set);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenDictionaryAndInCorrectString_WordBreak_ShouldReturnTrue()
        {
            var set = new HashSet<string>() { "cats", "cat", "sand", "dog", "and" };
            var target = "catsanddog";

            bool result = WorkBreak(target, set);

            Assert.IsFalse(result);
        }


        private bool WorkBreak(string target, HashSet<string> set)
        {
            var dp = GenerateDP(target.Length);
            InitializeDP(dp, target, set);

            for (int i = 1; i < target.Length; i++)
            {
                for (int j = i; j < target.Length; j++)
                {
                    var l = j - i + 1;
                    dp[i][j] = (j - l >= 0 && i - l >=0 && dp[i - l][j - l]) && IsSubstringInDictionary(target, i, j, set);
                }
            }

            var result = false;
            for (int i = 0; i < target.Length; i++)
            {
                result |= dp[i][target.Length - 1];
            }

            return result;
        }

        private bool IsSubstringInDictionary(string target, int startIndex, int endIndex, HashSet<string> set)
        {
            return set.Contains(target.Substring(startIndex, endIndex - startIndex + 1));
        }

        private bool[][] GenerateDP(int size)
        {
            var result = new bool[size][];
            for (int i = 0; i < size; i++)
            {
                result[i] = new bool[size];
            }

            return result;
        }

        private void InitializeDP(bool[][] dp, string target, HashSet<string> set)
        {
            for (int i = 0; i < target.Length; i++)
            {
                dp[0][i] = IsSubstringInDictionary(target, 0, i, set);
            }
        }

        // could use sparse matrix to reduce storageh
    }
}
