using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC767_ReorganizeString
{
    [TestClass]
    public class ReorganizeStringTests
    {
        [TestMethod]
        public void GivenValidString_Rearrange_ShouldReturnCorrectAnswer()
        {
            var input = "aab";

            var result = Rearrange(input);

            Assert.IsTrue(result == "aba");
        }

        private string Rearrange(string input)
        {
            var length = input.Length;
            var maxCharCount = (length + 1) / 2;

            var pairList = GetCharCountPairs(input);

            if (pairList.First().Value > maxCharCount)
            {
                return "";
            }

            return RearrangeHelper(pairList, length);
        }

        private string RearrangeHelper(List<KeyValuePair<char, int>> pairList, int length)
        {
            var result = new char[length];
            var avaibleSlotPointer = 0;

            foreach (var pair in pairList)
            {
                if (!(result[avaibleSlotPointer] == 0))
                {
                    avaibleSlotPointer = FindFirstEmptySlot(result, avaibleSlotPointer);
                }

                var count = pair.Value;
                var current = avaibleSlotPointer;
                while (count != 0)
                {
                    result[current] = pair.Key;
                    current += 2;
                    count--;
                }
            }

            return new string(result);
        }

        private int FindFirstEmptySlot(char[] result, int avaibleSlotPointer)
        {
            for (int i = avaibleSlotPointer; i < result.Length; i++)
            {
                if (result[i] == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private List<KeyValuePair<char, int>> GetCharCountPairs(string input)
        {
            var table = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!table.ContainsKey(input[i]))
                {
                    table.Add(input[i], 0);
                }

                table[input[i]]++;
            }

            var result = new List<KeyValuePair<char, int>>();

            foreach (var pairs in table)
            {
                result.Add(pairs);
            }

            result.OrderByDescending(x => x.Value);

            return result;
        }
    }
}
