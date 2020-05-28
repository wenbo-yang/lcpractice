using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1416_RestoreArray
{
    [TestClass]
    public class RestoreArrayTests
    {
        [TestMethod]
        public void GivenStringAndMax_GetNumberOfPossibleArrays_ShouldReturnCorrectNumber()
        {
            var s = "1000"; var k = 10000;
            var result = GetNumberOfPossibleArrays(s, k);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void GivenString1000AndMax10_GetNumberOfPossibleArrays_ShouldReturnCorrectNumber()
        {
            var s = "1000"; var k = 10;
            var result = GetNumberOfPossibleArrays(s, k);

            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void GivenString1317AndMax2000_GetNumberOfPossibleArrays_ShouldReturnCorrectNumber()
        {
            var s = "1317"; var k = 2000;
            var result = GetNumberOfPossibleArrays(s, k);

            Assert.IsTrue(result == 8);
        }

        private int GetNumberOfPossibleArrays(string s, int k)
        {
            var multi = 1;
            var currentNumberOfDigits = 0;
            var maxNumOfDigits = GetMaxNumOfDigits(k);
            var dp = new int[s.Length];
            
            var currentValue = 0;
         
            for (int i = s.Length - 1; i >= 0; i--)
            {
                var currentDigit = s[i] - '0';
                if (currentDigit > k || currentDigit == 0)
                {
                    if (currentNumberOfDigits < maxNumOfDigits)
                    {
                        currentNumberOfDigits++;
                        multi *= 10;
                    }
                    dp[i] = 0;
                }
                else
                {
                    currentValue = multi * currentDigit + currentValue;
                    if (currentValue <= k)
                    {
                        dp[i] = 1;
                        currentNumberOfDigits++;
                        multi *= 10; 
                    }
                    else
                    {
                        currentValue /= 10;
                        multi /= 10;
                    }

                    for (int j = 1; j < currentNumberOfDigits; j++)
                    {
                        dp[i] += dp[i + j];
                    }
                }
            }

            return dp[0];
        }

        private int GetMaxNumOfDigits(int k)
        {
            var result = 0;
            while (k != 0)
            {
                k /= 10;
                result++;
            }

            return result;
        }
    }
}
