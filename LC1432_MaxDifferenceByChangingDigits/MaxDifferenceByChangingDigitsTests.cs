using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1432_MaxDifferenceByChangingDigits
{
    [TestClass]
    public class MaxDifferenceByChangingDigitsTests
    {
        [TestMethod]
        public void GivenNumber_GetMaxDifference_ShouldReturnMaxDifference()
        {
            var number = 555;

            var result = GetMaxDifference(number);

            Assert.IsTrue(result == 888);
        }

        [TestMethod]
        public void GivenAnotherNumber_GetMaxDifference_ShouldReturnMaxDifference()
        {
            var number = 505;

            var result = GetMaxDifference(number);

            Assert.IsTrue(result == 808);
        }

        [TestMethod]
        public void GivenNonRepeatingNumber_GetMaxDifference_ShouldReturnMaxDifference()
        {
            var number = 123456;

            var result = GetMaxDifference(number);

            Assert.IsTrue(result == 820000);
        }

        [TestMethod]
        public void GivenNumberStartingWithNineZero_GetMaxDifference_ShouldReturnMaxDifference()
        {
            var number = 9089733;

            var result = GetMaxDifference(number);

            Assert.IsTrue(result == 8908000);
        }

        private int GetMaxDifference(int number)
        {
            var list = ConvertNumberIntoDigitList(number);

            var minTarget = -1;
            var shouldUseZero = false;
            var maxTarget = -1;
            var min = 0;
            var max = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (minTarget == -1)
                {
                    if (list[i] != 1 && list[i] != 0)
                    {
                        minTarget = list[i];
                        shouldUseZero = i > 0;
                    }
                }

                min *= 10;
                min += list[i] == minTarget ? (shouldUseZero ? 0 : 1) : list[i];

                if (maxTarget == -1)
                {
                    if (list[i] != 9)
                    {
                        maxTarget = list[i];
                    }
                }

                max *= 10;
                max += list[i] == maxTarget ? 9 : list[i];
            }

            return max - min;
        }

        private List<int> ConvertNumberIntoDigitList(int number)
        {
            var max = 100000000;
            var digitList = new List<int>();
            while (max != 0)
            {
                var result = number / max;

                if (result != 0)
                {
                    number -= result * max;
                    digitList.Add(result);
                }

                if (result == 0 && digitList.Count != 0)
                {
                    digitList.Add(result);
                }

                max /= 10;
            }
            return digitList;
        }
    }
}
