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
        public void GivenDictionaryAndIncorrectString_WordBreak_ShouldReturnFalse()
        {
            var set = new HashSet<string>() { "cats", "cat", "sand", "dog", "and" };
            var target = "catsandog";

            bool result = WorkBreak(target, set);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenDictionaryAndCorrectString_WordBreakSearch_ShouldReturnTrue()
        {
            var set = new HashSet<string>() { "leet", "code" };
            var target = "leetcode";

            bool result = WorkBreakSearch(target, set);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void GivenDictionaryAndIncorrectString_WordBreakSearch_ShouldReturnFalse()
        {
            var set = new HashSet<string>() { "cats", "cat", "sand", "dog", "and" };
            var target = "catsandog";

            bool result = WorkBreakSearch(target, set);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenDictionaryAndCorrectString_WordBreakDPSingle_ShouldReturnTrue()
        {
            var set = new HashSet<string>() { "leet", "code" };
            var target = "leetcode";

            bool result = WordBreakDPSingle(target, set);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenDictionaryAndIncorrectString_WordBreakDPSingle_ShouldReturnFalse()
        {
            var set = new HashSet<string>() { "cats", "cat", "sand", "dog", "and" };
            var target = "catsandog";

            bool result = WordBreakDPSingle(target, set);

            Assert.IsFalse(result);
        }

        private bool WordBreakDPSingle(string target, HashSet<string> set)
        {
            // generate dp

            var dp = new bool[target.Length];

            // initialize dp
            var startIndex = -1;
            for (int i = 1; i < target.Length; i++)
            {
                dp[i] = IsSubstringInDictionary(target, 0, i, set);
                if (dp[i] && startIndex == -1)
                {
                    startIndex = i;
                }
            }

            for (int i = startIndex; i < target.Length; i++)
            {
                for (int j = i; j < target.Length; j++)
                {
                    dp[j] = (dp[j] || dp[i - 1] && IsSubstringInDictionary(target, i, j, set));
                }
            }

            return dp[dp.Length - 1];
        }

        private bool WorkBreakSearch(string target, HashSet<string> set)
        {
            return WorkBreakSearchHelper(target, 0, set);
        }

        private bool WorkBreakSearchHelper(string target, int startIndex, HashSet<string> set)
        {
            if (startIndex >= target.Length)
            {
                return true;
            }

            for (int i = startIndex + 1; i < target.Length; i++)
            {
                if (IsSubstringInDictionary(target, startIndex, i, set))
                {
                    return WorkBreakSearchHelper(target, i + 1, set);
                }
            }

            return false;
        }

        private bool WorkBreak(string target, HashSet<string> set)
        {
            var dp = GenerateDP(target.Length);
            var columnMem = InitializeDP(dp, target, set);

            for (int i = 1; i < target.Length; i++)
            {
                for (int j = i; j < target.Length; j++)
                {
                    dp[i][j] = columnMem.Contains(i - 1) && IsSubstringInDictionary(target, i, j, set);
                    if (dp[i][j])
                    {
                        columnMem.Add(j);
                    }
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

        private HashSet<int> InitializeDP(bool[][] dp, string target, HashSet<string> set)
        {
            var columnMem = new HashSet<int>();
            for (int i = 0; i < target.Length; i++)
            {
                dp[0][i] = IsSubstringInDictionary(target, 0, i, set);

                if (dp[0][i])
                {
                    columnMem.Add(i);
                }
            }

            return columnMem;
        }

        // could use sparse matrix to reduce storageh
    }
}
