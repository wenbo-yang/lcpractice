using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1347_MinimumNumberOfStepsToMakeTwoStringsAnagram
{
    [TestClass]
    public class MinimumNumberOfStepsToMakeTwoStringsAnagramTests
    {
        [TestMethod]
        public void GivenTwoString_GetMinNumbers_ShouldReturnMinimumNumberOfSteps()
        {
            var s = "bab"; var t = "aba";

            var result = GetMinNumbers(s, t);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void GivenAnotherSetOfTwoString_GetMinNumbers_ShouldReturnMinimumNumberOfSteps()
        {
            var s = "leetcode"; var t = "practice";

            var result = GetMinNumbers(s, t);

            Assert.IsTrue(result == 5);
        }

        private int GetMinNumbers(string s, string t)
        {
            var sCharCount = new int[26];
            var tCharCount = new int[26];
            
            for (int i = 0; i < s.Length; i++)
            {
                sCharCount[s[i] - 'a']++;
                tCharCount[t[i] - 'a']++;
            }

            var sum = 0;
            for (int i = 0; i < 26; i++)
            {
                sum += Math.Abs(sCharCount[i] - tCharCount[i]);
            }

            return sum / 2;
        }
    }
}
