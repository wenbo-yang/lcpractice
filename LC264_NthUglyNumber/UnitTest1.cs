using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC264_NthUglyNumber
{
    [TestClass]
    public class NthUglyNumberTests
    {
        [TestMethod]
        public void GivenInputN_GetNthUglyNumber_ShouldReturnCorrectResult()
        {
            var n = 10;

            int result = GetNthUglyNumber(n);

            Assert.IsTrue(result == 12);
        }

        private int GetNthUglyNumber(int n)
        {
            var list = new List<int>() { 1 };

            var i2 = 0;
            var i3 = 0;
            var i5 = 0;

            for (int i = 1; i < n; i++)
            {
                var next2 = list[i2] * 2;
                var next3 = list[i3] * 3;
                var next5 = list[i5] * 5;

                var next = Math.Min(next2, Math.Min(next3, next5));

                if (next == next2) i2++;
                if (next == next3) i3++;
                if (next == next5) i5++;

                list.Add(next);
            }

            return list[list.Count - 1];
        }
    }
}
