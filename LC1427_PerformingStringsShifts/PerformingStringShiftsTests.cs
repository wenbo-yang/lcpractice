using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1427_PerformingStringsShifts
{
    [TestClass]
    public class PerformingStringShiftsTests
    {
        [TestMethod]
        public void GivenShifts_ShiftString_ShouldReturnCorrectString()
        {
            var shift = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 } };
            var s = "abc";
            var result = ShiftString(s, shift);

            Assert.IsTrue(result == "cab");
        }

        [TestMethod]
        public void GivenAnotherSetOfShifts_ShiftString_ShouldReturnCorrectString()
        {
            var shift = new int[][] { new int[] { 1, 1 }, new int[] { 1, 1 }, new int[] { 0, 2}, new int[] {1, 3} };
            var s = "abcdefg";
            var result = ShiftString(s, shift);

            Assert.IsTrue(result == "efgabcd");
        }

        private string ShiftString(string s, int[][] shifts)
        {
            var shiftVector = 0;
           
            foreach (var shift in shifts)
            {
                if (shift[0] == 0)
                {
                    shiftVector += shift[1];
                }
                else
                {
                    shiftVector -= shift[1];
                }
            }

            var direction = shiftVector < 0 ? -1 : 1;
            var value = direction < 0 ? s.Length - direction * shiftVector % s.Length : shiftVector % s.Length;

            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                sb.Append(s[(i + value) % s.Length]);
            }

            return sb.ToString();
        }
    }
}
