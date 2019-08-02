using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongestPalidromicSubstring
{
    [TestClass]
    public class LongestPalidromicSubstringTest
    {
        [TestMethod]
        public void GivenStringWithAllUniqueChars_PalidromicSubstring_ShouldReturnFirstChar()
        {
            var input = "abcd";

            var output = LongestPalidromicSubstringDP(input);

            Assert.IsTrue(output == "a");
        }

        [TestMethod]
        public void GivenPalidromeHead_PalidromicSubstring_ShouldReturnPalidromeHead()
        {
            var input = "aacd";

            var output = LongestPalidromicSubstringDP(input);

            Assert.IsTrue(output == "aa");
        }

        [TestMethod]
        public void GivenTwoPalidrome_PalidromicSubstring_ShouldReturnTheLongest()
        {

            var input = "cabbad";

            var output = LongestPalidromicSubstringDP(input);

            Assert.IsTrue(output == "abba");
        }

        private string LongestPalidromicSubstringDP(string input)
        {
            var dp = InitializeDP(input.Length);

            var substringLength = 1;
            var startIndex = 0;
            var endIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    // normal case
                    if (dp[i][j - 1] && i - 1 >= 0 && input[i - 1] == input[j])
                    {
                        dp[i - 1][j] = true;

                        if (j - (i - 1) + 1 > substringLength)
                        {
                            substringLength = j - (i - 1) + 1;
                            startIndex = i - 1;
                            endIndex = j;
                        }
                    }

                    // even case
                    if (j == i + 1 && input[i] == input[j])
                    {
                        dp[i][j] = true;
                        if (j - i + 1 > substringLength)
                        {
                            substringLength = j - i + 1;
                            startIndex = i;
                            endIndex = j;
                        }
                    }
                }
            }

            return input.Substring(startIndex, endIndex - startIndex + 1);
        }

        private bool[][] InitializeDP(int length)
        {
            bool[][] mat = new bool[length][];

            for (int i = 0; i < length; i++)
            {
                mat[i] = new bool[length];
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    mat[i][j] = i == j;
                }
            }

            return mat;
        }

        private string LongestPalidromicSubstringManacher(string input)
        {
            throw new NotImplementedException();
        }
    }
}
