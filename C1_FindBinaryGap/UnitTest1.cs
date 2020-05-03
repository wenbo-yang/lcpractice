using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C1_FindBinaryGap
{
    [TestClass]
    public class FindBinaryGapTests
    {
        [TestMethod]
        public void GivenInteger_FindBinaryGap_ShouldReturnBinaryGap()
        {
            var n = -1;
            var text = Convert.ToString(n, 2);
            n = n >> 5;
            text = Convert.ToString(n, 2);

            n = 1041;

            var gap = FindMaxBinaryGap(n);

            Assert.IsTrue(gap == 5);
             
        }

        private int FindMaxBinaryGap(int n)
        {
            var startIndex = -1;
            var maxGap = 0;
            var mask = 1;
            for (int i = 0; i < 32; i++)
            {
                if ((mask & n) == mask)
                {
                    maxGap = Math.Max(maxGap, startIndex == -1 ? 0 : i - startIndex - 1);
                    startIndex = i;
                }

                mask = mask << 1;
            }

            return maxGap;
        }
    }
}
