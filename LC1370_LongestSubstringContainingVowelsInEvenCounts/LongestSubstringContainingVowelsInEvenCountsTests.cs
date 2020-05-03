using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1370_LongestSubstringContainingVowelsInEvenCounts
{
    [TestClass]
    public class LongestSubstringContainingVowelsInEvenCountsTests
    {
        [TestMethod]
        public void GivenString_FindTheLongestSubstring_ShouldReturnLengthOfLongestSubString()
        {
            var s = "eleetminicoworoep";

            var result = FindTheLongestSubstring(s);

            Assert.IsTrue(result == 13);
        }

        [TestMethod]
        public void GivenAnotherString_FindTheLongestSubstring_ShouldReturnLengthOfLongestSubString()
        {
            var s = "leetcodeisgreat";

            var result = FindTheLongestSubstring(s);

            Assert.IsTrue(result == 5);
        }

        private int FindTheLongestSubstring(string s)
        {
            var vowels = "aeiou";
            var idx = new int[s.Length];
            for (int i = 0; i < idx.Length; i++)
            {
                idx[i] = int.MaxValue;
            }

            idx[0] = -1;
            int state = 0;
            int ans = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                for (int j = 0; j < 5; ++j)
                    if (s[i] == vowels[j]) state ^= 1 << j;
                if (idx[state] == int.MaxValue) idx[state] = i;
                ans = Math.Max(ans, i - idx[state]);
            }
            return ans;
        }
    }
}
