using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC29_DivideTwoIntegers
{
    [TestClass]
    public class DivideTwoIntegersTests
    {
        [TestMethod]
        public void GivneTwoIntegers_Divide_ShouldReturnCorrectAnswer()
        {
            var dividend = 10; var divisor = 3;
            var result = Divide(dividend, divisor);

            Assert.IsTrue(result == 3);
        }

        private int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1) return int.MaxValue;
            long m = Math.Abs(dividend), n = Math.Abs(divisor), res = 0;
            int sign = ((dividend < 0) ^ (divisor < 0)) ? -1 : 1;
            if (n == 1) return sign == 1 ? (int)m : -(int)m;
            while (m >= n)
            {
                long t = n, p = 1;
                while (m >= (t << 1))
                {
                    t <<= 1;
                    p <<= 1;
                }
                res += p;
                m -= t;
            }
            return sign == 1 ? (int)res : -(int)res;
        }
    }
}
