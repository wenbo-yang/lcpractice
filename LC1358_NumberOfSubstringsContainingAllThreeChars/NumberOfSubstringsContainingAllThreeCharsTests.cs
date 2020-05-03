using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1358_NumberOfSubstringsContainingAllThreeChars
{
    [TestClass]
    public class NumberOfSubstringsContainingAllThreeCharsTests
    {
        [TestMethod]
        public void GivenString_GetNumberOfSubstringsContainingAllThreeChars_SouldReturnCorrectNumber()
        {
            var s = "abcabc";

            var result = GetNumberOfSubstringsContainingAllThreeChars(s);

            Assert.IsTrue(result == 10);
        }

        [TestMethod]
        public void GivenAnotherString_GetNumberOfSubstringsContainingAllThreeChars_SouldReturnCorrectNumber()
        {
            var s = "aaacb";

            var result = GetNumberOfSubstringsContainingAllThreeChars(s);

            Assert.IsTrue(result == 3);
        }

        private int GetNumberOfSubstringsContainingAllThreeChars(string s)
        {
            var result = 0;
            var counts = new int[3];
            var left = 0; var right = 0;

            while (right < s.Length)
            {
                counts[s[right] - 'a']++;

                while(AreAllCharsPresent(counts))
                {
                    result += CalculateAllSubstrings(s, right);
                    
                    ShrinkWindow(s, left, counts);
                    left++;
                }

                right++;
            }

            return result;
        }

        private bool AreAllCharsPresent(int[] counts)
        {
            return counts[0] > 0 && counts[1] > 0 && counts[2] > 0;
        }

        private void ShrinkWindow(string s, int left, int[] counts)
        {
            counts[s[left] - 'a']--;
        }

        private int CalculateAllSubstrings(string s, int right)
        {
            return s.Length - right;
        }
    }
}
