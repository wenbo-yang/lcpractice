using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1392_LongestPrefixSuffix
{
    [TestClass]
    public class LongestPrefixSuffixTests
    {
        [TestMethod]
        public void GivenString_FindLongestPrefixSuffix_ShouldReturnCorrectSubstring()
        {
            var s = "ababab";

            var result = FindLongestPrefixSuffix(s);

            Assert.IsTrue(result == "abab");
        }

        [TestMethod]
        public void GivenStringOfSingleChar_FindLongestPrefixSuffix_ShouldReturnCorrectSubstring()
        {
            var s = "a";

            var result = FindLongestPrefixSuffix(s);

            Assert.IsTrue(result == "");
        }

        [TestMethod]
        public void GivenStringNoPrefixAndSuffix_FindLongestPrefixSuffix_ShouldReturnCorrectSubstring()
        {
            var s = "leetcode";

            var result = FindLongestPrefixSuffix(s);

            Assert.IsTrue(result == "");
        }

        private string FindLongestPrefixSuffix(string s)
        {
            if (s.Length == 1)
            {
                return "";
            }

            var prefixCount = new int[s.Length][];
            prefixCount[0] = new int[26];
            prefixCount[0][s[0] - 'a']++;

            for (int i = 1; i < s.Length; i++)
            {
                prefixCount[i] = GetPrefixSum(prefixCount[i - 1], s[i]);
            }

            var result = "";
            var length = s.Length - 1;

            var left = 0;
            var right = s.Length - 1;
            while (left < s.Length - 1)
            {
                if (!(s[left] == s[right] && s[left] == s[0]))
                {
                    break;
                }
                left++;
                right--;
            }

            result = s.Substring(0, left);

            length = s.Length - 1;
            while (length > left)
            {
                if (IsPrefixSuffixCountEqual(prefixCount, length) && VerifyPrefixSuffixOfLength(s, length))
                {
                    result = s.Substring(0, length);

                    break;
                }
                length--;
            }

            return result;
        }

        private bool VerifyPrefixSuffixOfLength(string s, int length)
        {
            var prefixLeft = 0;
            var prefixRight = length - 1;
            var suffixLeft = s.Length - length;
            var suffixRight = s.Length - 1;

            while (prefixLeft < prefixRight)
            {
                if (s[prefixLeft] != s[suffixLeft] || s[prefixRight] != s[suffixRight])
                {
                    return false;
                }

                prefixLeft++;
                prefixRight--;
                suffixLeft++;
                suffixRight--;
            }

            return true;
        }

        private bool IsPrefixSuffixCountEqual(int[][] prefixCount, int length)
        {
            var prefix = prefixCount[length - 1];
            var from = prefixCount[prefixCount.Length - 1 - length];
            var total = prefixCount[prefixCount.Length - 1];

            var suffix = new int[26];
            for (int i = 0; i < 26; i++)
            {
                suffix[i] = total[i] - from[i];
            }

            return prefix.SequenceEqual(suffix); 
        }

        private int[] GetPrefixSum(int[] prefix, char c)
        {
            var result = new int[26];
            Array.Copy(prefix, result, prefix.Length);
            result[c - 'a']++;
            return result;
        }
    }
}
