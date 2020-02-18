using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1312_MinimumInsertionsStepsToMakeAStringPalindrome
{
    [TestClass]
    public class MinimumInsertionsStepsToMakeAStringPalindromeTests
    {
        [TestMethod]
        public void GivenString_GetMinimumInsertion_ShouldReturnMinInsertion()
        {
            var s = "n";
            var result = GetMinimumInsertion(s);

            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void GivenAnotherString_GetMinimumInsertion_ShouldReturnMinInsertion()
        {
            var s = "mbadm";
            var result = GetMinimumInsertion(s);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void GivenLeetcodeString_GetMinimumInsertion_ShouldReturnMinInsertion()
        {
            var s = "leetcode";
            var result = GetMinimumInsertion(s);

            Assert.IsTrue(result == 5);
        }

        private int GetMinimumInsertion(string s)
        {
            var dp = new Dictionary<(int left, int right), int>();

            return GetMinimumInsertionHelper(s, 0, s.Length - 1, dp);
        }

        private int GetMinimumInsertionHelper(string s, int left, int right, Dictionary<(int left, int right), int> dp)
        {
            if (left >= right)
            {
                return 0;
            }

            if (dp.ContainsKey((left, right)))
            {
                return dp[(left, right)];
            }

            dp.Add((left, right), int.MaxValue);

            if (s[left] == s[right])
            {
                dp[(left, right)] = GetMinimumInsertionHelper(s, left + 1, right - 1, dp);
            }
            else
            {
                dp[(left, right)] = 1 + Math.Min(GetMinimumInsertionHelper(s, left + 1, right, dp), GetMinimumInsertionHelper(s, left, right - 1, dp));
            }

            return dp[(left, right)];
        }
    }
}
