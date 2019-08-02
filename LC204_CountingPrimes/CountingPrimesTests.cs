using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC204_CountingPrimes
{
    [TestClass]
    public class CountingPrimesTests
    {
        [TestMethod]
        public void GivenRangeN_CountingPrimes_ShouldReturnCorrectNumber()
        {
            var result = CountingPrimes(10);
            Assert.IsTrue(result == 4);
        }

        private int CountingPrimes(int n)
        {
            var result = 0;
            var flags = new bool[n];

            for (int i = 2; i < n; i++)
            {
                if (!flags[i])
                {
                    result++;
                }

                for (int j = 2; i * j < n; j++)
                {
                    flags[i * j] = true;
                }
            }

            return result;
        }
    }
}
