using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC44_WildCharMatching
{
    [TestClass]
    public class WildCharMatchingTests
    {
        [TestMethod]
        public void GivenStringWithString_IsMatching_ShouldReturnTrue()
        {
            var input = "abcd";
            var regex = "**abcd";

            bool result = IsMatching(input, regex);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenStringSequenceAndRegexWithStar_IsMatching_ShouldReturnTrue()
        {
            var input = "aaac";
            var regex = "a*c";

            bool result = IsMatching(input, regex);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenStringSequenceAndRegexWithQuestionMark_IsMatching_ShouldReturnTrue()
        {
            var input = "aaac";
            var regex = "aaa?";

            bool result = IsMatching(input, regex);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void GivenStringAndSequenceWithWildChars_IsMatching_ShouldReturnTrue()
        {
            var input = "aaac";
            var regex = "a*?";

            bool result = IsMatching(input, regex);

            Assert.IsTrue(result);
        }

        private bool IsMatching(string input, string regex)
        {
            regex = regex.TrimStart(new char[] { '*' });

            if (string.IsNullOrWhiteSpace(regex))
            {
                return string.IsNullOrWhiteSpace(input.Trim(new char[] { input[0] }));
            }

            var dp = InitializeDp(input, regex);

            for (int i = 0; i < regex.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    if (regex[i] == '*')
                    {
                        dp[i][j] = dp[i - 1][j];
                    }
                    else 
                    {   
                        // this is even worse than the if statement, code is not readable
                        dp[i][j] = (regex[i] == '?' || input[j] == regex[i]) && (i == 0 || dp[i - 1][j - 1]);

                        //if (i == 0)
                        //{
                        //    dp[i][j] = (regex[i] == '?' || input[j] == regex[i]);
                        //}
                        //else
                        //{
                        //    dp[i][j] = (regex[i] == '?' || input[j] == regex[i]) && dp[i - 1][j - 1];
                        //}
                    }
                }
            }

            return dp[regex.Length - 1][input.Length - 1];
        }



        private bool[][] InitializeDp(string input, string regex)
        {
            var result = new bool[regex.Length][];

            for (int i = 0; i < regex.Length; i++)
            {
                result[i] = new bool[input.Length];
            }
            return result;
        }
    }
}
