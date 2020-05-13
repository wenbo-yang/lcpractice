using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1400_ConstructKPalindromeStrings
{
    [TestClass]
    public class ConstructKPalindromeStringsTests
    {
        [TestMethod]
        public void GivenString_CanConstructKPalindrome_ShouldReturnCorrectAnswer()
        {
            var s = "true";
            var k = 4;

            var result = CanConstructKPalidrome(s, k);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenSAnothertring_CanConstructKPalindrome_ShouldReturnCorrectAnswer()
        {
            var s = "leetcode";
            var k = 3;

            var result = CanConstructKPalidrome(s, k);

            Assert.IsFalse(result);
        }

        private bool CanConstructKPalidrome(string s, int k)
        {
            if (k > s.Length)
            {
                return false;
            }

            var charCount = new int[26];

            foreach (var c in s)
            {
                charCount[c - 'a']++;
            }

            var oddCount = GetNumberOfOddChars(charCount);

            return oddCount <= k;  
        }

        private int GetNumberOfOddChars(int[] charCount)
        {
            var oddCount = 0;
            foreach (var count in charCount)
            {
                if (count % 2 != 0)
                {
                    oddCount++;
                }
            }

            return oddCount;
        }
    }
}
