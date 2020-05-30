using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1446_ConsecutiveChars
{
    [TestClass]
    public class ConsecutiveCharsTests
    {
        [TestMethod]
        public void GivenString_NumberOfConsecutiveChars_ShouldReturnCorrectAnswer()
        {
            var s = "leetcode";
            var result = NumberOfConsecutiveChars(s);

            Assert.IsTrue(result == 2);
        }

        private int NumberOfConsecutiveChars(string s)
        {
            var max = 0;
            var left = 0;
            var right = 1;

            while (right < s.Length)
            {
                if (s[right] == s[left])
                {
                    max = Math.Max(right - left + 1, max);
                }
                else
                {
                    left = right;
                }
                right++;
            }

            return max;
        }
    }
}
