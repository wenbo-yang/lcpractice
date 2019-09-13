using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC322_CoinChange
{
    [TestClass]
    // greedy
    public class CoinChangeTests
    {
        [TestMethod]
        public void GivenInputListOfCoins_MinCoinChange_ShouldReturnCorrectAnswer()
        {
            var input = new int[] { 1, 2, 5 };
            var target = 11;

            var result = MinCoinChange(input, target);

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void GivenInputListOfCoinsAndInvalidTarget_MinCoinChange_ShouldReturnNegative1()
        {
            var input = new int[] { 2 };
            var target = 3;

            var result = MinCoinChange(input, target);

            Assert.IsTrue(result == -1);
        }

        private int MinCoinChange(int[] input, int target)
        {
            Array.Sort(input);

            var result = 0;
            var currentIndex = input.Length - 1;
            var remainder = 0;
            var tempTarget = target;

            do
            {
                if (currentIndex == -1)
                {
                    return -1;
                }

                result += tempTarget / input[currentIndex];
                remainder = tempTarget % input[currentIndex];
                tempTarget = remainder;
                currentIndex--;
            }
            while (remainder != 0);

            return result;
        }
    }
}
