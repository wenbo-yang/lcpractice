using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC87_ScrambleString
{
    [TestClass]
    public class ScrambleStringTests
    {
        [TestMethod]
        public void GivenStringAndScrambledString_IsScramble_ShouldReturnCorrectAnswer()
        {
            var s1 = "great"; var s2 = "rgtae";

            var result = IsScrambledString(s1, s2);

            Assert.IsTrue(result);
        }

        private bool IsScrambledString(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            if (s1 == s2)
            {
                return true;
            }

            if (!AreCharFrequenciesTheSame(s1, s2))
            {
                return false;
            }

            for (int i = 1; i < s1.Length; i++)
            {
                if ((IsScrambledString(s1.Substring(0, i), s2.Substring(0, i)) && IsScrambledString(s1.Substring(i), s2.Substring(i))) ||
                   (IsScrambledString(s1.Substring(0, i), s2.Substring(s1.Length - i, i)) && IsScrambledString(s1.Substring(i), s2.Substring(0, s1.Length - i))))
                {
                    return true;
                }
            }

            return false;
        }

        private bool AreCharFrequenciesTheSame(string s1, string s2)
        {
            var freq = new int[26];

            for (int i = 0; i < s1.Length; i++)
            {
                freq[s1[i] - 'a']++;
                freq[s2[i] - 'a']--;
            }

            return !freq.Any(x => x != 0);
        }
    }
}
