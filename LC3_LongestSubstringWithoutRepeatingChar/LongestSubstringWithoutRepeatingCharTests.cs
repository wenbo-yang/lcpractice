using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC3_LongestSubstringWithoutRepeatingCharTests
{
    [TestClass]
    public class LongestSubstringWithoutRepeatingCharTests
    {
        [TestMethod]
        public void GivenAnArrayOfCharsIfTheLastOneRepeats_SlidingWindow_ShouldResetToLeftEnd()
        {
            var input = "abb";

            var result = LongestSubstringWithOutRepeatingChars(input);

            Assert.IsTrue(result == "ab");
        }

        [TestMethod]
        public void GivenAnArrayOfCharsIfTheFirstOneRepeats_SlidingWindow_ShouldResetToRepeatingCharIndex()
        {
            var input = "aab";

            var result = LongestSubstringWithOutRepeatingChars(input);

            Assert.IsTrue(result == "ab");
        }

        [TestMethod]
        public void GivenAnArrayOfCharsIfTheFirstOneIsFoundInDictionary_SlidingWindowLeft_ShouldResetToLeftPlusOne()
        {
            var input = "awab";

            var result = LongestSubstringWithOutRepeatingChars(input);

            Assert.IsTrue(result == "wab");
        }

        private string LongestSubstringWithOutRepeatingChars(string input)
        {
            int leftIndex = 0;
            int rightIndex = 0;

            int longestIndexLeft = 0;
            int longestIndexRight = 0;
            var table = new Dictionary<char, int>();

            while (rightIndex < input.Length)
            {
                if (!table.ContainsKey(input[rightIndex]))
                {
                    table.Add(input[rightIndex], rightIndex);
                }
                else 
                {
                    leftIndex = ResetLeftIndex(input, table, rightIndex);
                }

                rightIndex++;

                if (rightIndex - leftIndex > longestIndexRight - longestIndexLeft)
                {
                    longestIndexLeft = leftIndex;
                    longestIndexRight = rightIndex;
                }
            }

            return input.Substring(longestIndexLeft, longestIndexRight - longestIndexLeft);
        }

        private int ResetLeftIndex(string input, Dictionary<char, int> table, int rightIndex)
        {
            var leftIndex = -1;

            if (table[input[rightIndex]] == rightIndex - 1)
            {
                leftIndex = rightIndex;
            }
            else
            {
                leftIndex = table[input[rightIndex]] + 1;
            }

            return leftIndex;
        }
    }
}
