using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC6_ZigZagConversion
{
    [TestClass]
    public class ZigZagConversionTests
    {
        [TestMethod]
        public void GivenStringAndRows_ZigZagConversion_ShouldReturnCorrectString()
        {
            var s = "PAYPALISHIRING";
            var rows = 3;

            var result = ZigZagConversion(s, rows);

            Assert.IsTrue(result == "PAHNAPLSIIGYIR");
        }

        private string ZigZagConversion(string s, int rows)
        {
            var list = new List<char>[rows];
            var row = -1;
            var rowOffSet = 1;
            for (int i = 0; i < s.Length; i++)
            {
                row += rowOffSet;
                if (list[row] == null)
                {
                    list[row] = new List<char>();
                }

                list[row].Add(s[i]);

                if (rows == 1)
                {
                    row = -1;
                    continue;
                }

                if (row == rows - 1)
                {
                    rowOffSet = -1;
                }

                if (row == 0)
                {
                    rowOffSet = 1;
                }
            }

            var sb = new StringBuilder();

            foreach(var rowChars in list)
            {
                if (rowChars == null)
                {
                    break;
                }
                sb.Append(rowChars.ToArray());
            }

            return sb.ToString();
        }
    }
}
