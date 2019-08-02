using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC76_MinimumWindowSubstring
{
    [TestClass]
    public class MinimumWindowSubstringTests
    {
        [TestMethod]
        public void GivenStringAndSubstring_FindWindow_ShouldReturnCorrectWindow()
        {
            var input = "ADOBECIDEBANC";
            var substring = "ABC";

            string result = FindWindow(input, substring);

            Assert.IsTrue(result == "BANC");
        }

        private string FindWindow(string input, string substring)
        {
            var table = GenerateTable(substring);

            var right = -1;
            var left = 0;

            while(true)
            {
                var tempRight = FindNextCharIndex(input, table, right + 1);

                if (tempRight == -1)
                {
                    break;
                }

                right = tempRight;
                table[input[right]]--;

                while (CanMoveLeft(input, table, left, right))
                {
                    table[input[left]]++;
                    left = FindNextCharIndex(input, table, left + 1);
                }
            }

            if (table.Any(item => item.Value > 0))
            {
                return "";
            }
            
            return input.Substring(left, right - left + 1);
        }

        private int FindNextCharIndex(string input, Dictionary<char, int> table, int startIndex)
        {
            for (int i = startIndex; i < input.Length; i++)
            {
                if (table.ContainsKey(input[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool CanMoveLeft(string input, Dictionary<char, int> table, int left, int right)
        {
            return left < right && table[input[left]] < 0;
        }

        private Dictionary<char, int> GenerateTable(string substring)
        {
            var table = new Dictionary<char, int>();

            for (int i = 0; i < substring.Length; i++)
            {
                if (!table.ContainsKey(substring[i]))
                {
                    table.Add(substring[i], 0);
                }

                table[substring[i]]++;
            }

            return table;
        }
    }
}
