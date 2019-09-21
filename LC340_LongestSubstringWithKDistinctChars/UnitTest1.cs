using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC340_LongestSubstringWithKDistinctChars
{
    [TestClass]
    public class LongestSubsctringWithKDistinctChars
    {
        [TestMethod]
        public void GivenString_FindSubstringWithKChar_ShouldReturnLengthOfSubstring()
        {
            var input = "eceba";
            var k = 2;

            var result = FindSubstringWithKDistinctChars(input, k);

            Assert.IsTrue(result == 3);
        }

        private int FindSubstringWithKDistinctChars(string input, int k)
        {
            // param validation
            var currentMax = 0;

            var table = new Dictionary<char, int>();

            var left = 0;
            var right = 0;
            while (right < input.Length)
            {
                if (!table.ContainsKey(input[right]))
                {
                    table.Add(input[right], 0);
                }

                table[input[right]]++;
                
                while (table.Count > k)
                {
                    table[input[left]]--;
                    if (table[input[left]] == 0)
                    {
                        table.Remove(input[left]);
                    }
                    left++;
                }

                if (right - left + 1 > currentMax)
                {
                    currentMax = right - left + 1;
                }

                right++;
            }

            return currentMax;
        }
    }
}
