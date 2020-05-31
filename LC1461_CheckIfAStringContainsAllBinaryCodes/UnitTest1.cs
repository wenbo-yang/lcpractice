using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1461_CheckIfAStringContainsAllBinaryCodes
{
    [TestClass]
    public class CheckToSeeIfAStringContainsAllBinaryCodesTests
    {
        [TestMethod]
        public void GivenLengthAndString_CheckToSeeIfStringContainsAllBinaryCodes_ShouldReturnCorrectAnswer()
        {
            var s = "00110110"; var k = 2;

            var result = CheckToSeeIfAStringContainsAllBinaryCodes(s, k);

            Assert.IsTrue(result);
        }

        private bool CheckToSeeIfAStringContainsAllBinaryCodes(string s, int k)
        {
            var max = GetMax(k);
            var table = new bool[max + 1];
            var mask = max >> 1;
            var current = Convert.ToInt32(s.Substring(0, k), 2);
            var right = k;
            table[current] = true;

            while (right < s.Length)
            {
                current = mask & current;
                current = current << 1;
                current += s[right] == '0' ? 0 : 1;
                table[current] = true;
                right++;
            }

            return table.All(x => x == true);
        }

        private int GetMax(int k)
        {
            var max = 0;
            while (k != 0)
            {
                max = max << 1;
                max += 1;
                k--;
            }
            return max;
        }
    }
}
