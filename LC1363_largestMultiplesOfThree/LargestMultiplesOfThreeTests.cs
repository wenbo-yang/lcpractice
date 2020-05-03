using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1363_largestMultiplesOfThree
{
    [TestClass]
    public class LargestMultiplesOfThreeTests
    {
        [TestMethod]
        public void GivenSimpleArray_GetLargestMultiplesOfThree_ShouldReturnCorrectAnswer()
        {
            var array = new int[] { 8, 9, 1 };

            var result = GetLargestMultiplesOfThree(array);

            Assert.IsTrue(result == "981");
        }

        [TestMethod]
        public void GivenArray_GetLargestMultiplesOfThree_ShouldReturnCorrectAnswer()
        {
            var array = new int[] { 8, 6, 7, 1, 0 };

            var result = GetLargestMultiplesOfThree(array);

            Assert.IsTrue(result == "8760");
        }

        [TestMethod]
        public void GivenAnotherArray_GetLargestMultiplesOfThree_ShouldReturnCorrectAnswer()
        {
            var array = new int[] { 5, 8 };

            var result = GetLargestMultiplesOfThree(array);

            Assert.IsTrue(result == "");
        }

        [TestMethod]
        public void GivenThirdArray_GetLargestMultiplesOfThree_ShouldReturnCorrectAnswer()
        {
            var array = new int[] { 0, 0 };

            var result = GetLargestMultiplesOfThree(array);

            Assert.IsTrue(result == "0");
        }

        private string GetLargestMultiplesOfThree(int[] array)
        {
            if (array == null)
            {
                return "";
            }

            // get count 
            var numCount = GenerateNumCount(array);
            var sum = GetSum(numCount);
            var remainder = sum % 3;

            if (remainder != 0)
            {
                RemoveOneOrTwoDigits(numCount, remainder);
            }

            return ConvertNumCountToString(numCount);
        }

        private string ConvertNumCountToString(int[] numCount)
        {
            var sb = new StringBuilder();
            for (int i = 9; i >= 0; i--)
            {
                for (int j = 0; j < numCount[i]; j++)
                {
                    sb.Append(i.ToString());
                }
            }

            var result = sb.ToString();

            return result.StartsWith("0") ? "0" : result;
        }

        private void RemoveOneOrTwoDigits(int[] numCount, int remainder)
        {
            if (!TryRemoveOneDigit(numCount, remainder))
            {
                RemoveTwoDigits(numCount, remainder);
            }
        }

        private void RemoveTwoDigits(int[] numCount, int remainder)
        {
            for (int i = 1; i < numCount.Length; i++)
            {
                for (int j = i; j < numCount.Length; j++)
                {
                    if ((i + j) % 3 == remainder)
                    {
                        if (i == j)
                        {
                            if (numCount[i] >= 2)
                            {
                                numCount[i] -= 2;
                                return;
                            }
                        }
                        else
                        {
                            if (numCount[i] > 0 && numCount[j] > 0)
                            {
                                numCount[i]--;
                                numCount[j]--;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private bool TryRemoveOneDigit(int[] numCount, int remainder)
        {
            for (int i = 0; i < numCount.Length; i++)
            {
                if (i % 3 == remainder && numCount[i] > 0)
                {
                    numCount[i]--;
                    return true;
                }
            }

            return false;
        }

        private int GetSum(int[] numCount)
        {
            var sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += numCount[i] * i;
            }

            return sum;
        }

        private int[] GenerateNumCount(int[] array)
        {
            var numCount = new int[10];

            foreach (var item in array)
            {
                numCount[item]++;
            }

            return numCount;
        }
    }
}
