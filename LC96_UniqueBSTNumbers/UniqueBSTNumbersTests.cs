using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC96_UniqueBSTNumbers
{
    [TestClass]
    public class UniqueBSTNumbersTests
    {
        [TestMethod]
        public void GivenRootNumber_GetUniqueBinaryTreeCount_ShouldReturnCorrectCount()
        {
            var max = 3;

            var result = GetUniqueBinaryTreeCount(max);

            Assert.IsTrue(result == 5);

        }

        private int GetUniqueBinaryTreeCount(int max)
        {
            if (max <= 1)
            {
                return 1;
            }

            var dp = new int[max + 1];

            dp[0] = dp[1] = 1;

            for (int i = 2; i <= max; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    dp[i] += dp[j] * dp[i - j - 1];
                }
            }

            return dp[max];
        }
    }
}
