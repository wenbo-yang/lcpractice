using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1291_SequentialDigits
{
    [TestClass]
    public class SequentialDigitsTests
    {
        [TestMethod]
        public void GivenRange_GetSequentialDigits_ShouldReturnList()
        {
            var low = 100; var high = 300;

            var result = GetSequentialDigits(low, high);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 123, 234 }));
        }

        [TestMethod]
        public void GivenInvalidRange_GetSequentialDigits_ShouldReturnList()
        {
            var low = 100; var high = 120;

            var result = GetSequentialDigits(low, high);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void GivenRangeWithMultipleSegments_GetSequentialDigits_ShouldReturnList()
        {
            var low = 100; var high = 3000;

            var result = GetSequentialDigits(low, high);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 123, 234, 345, 456, 567, 678, 789, 1234, 2345}));
        }

        private List<int> GetSequentialDigits(int low, int high)
        {
            var result = new List<int>();

            var numberOfDigitsLow = GetNumberOfDigits(low);
            var numberOfDigitsHigh = GetNumberOfDigits(high);
            var initial = low;
            for (int i = numberOfDigitsLow; i <= numberOfDigitsHigh; i++)
            {
                var adjustedBase = AdjustInitial(i, initial);
                var upperBound = GetMaxForNumberOfDigits(i);
                var max = Math.Min(high, upperBound);
                var offSet = GetOffSetForNumberOfDigits(i);

                while (adjustedBase <= max)
                {
                    result.Add(adjustedBase);
                    adjustedBase += offSet;
                }
            }

            return result;
        }

        private int AdjustInitial(int numberOfDigits, int initial)
        {
            var mostSignificantDigit = GetMostSignificantDigit(initial);
            var adjustedInitial = mostSignificantDigit;
            var lastDigit = adjustedInitial;
            for (int i = 1; i < numberOfDigits; i++)
            {
                adjustedInitial = adjustedInitial * 10 + (++lastDigit); 
            }

            return adjustedInitial;
        }

        private int GetMostSignificantDigit(int initial)
        {
            var result = initial;
            while (result >= 10)
            {
                result = result / 10;
            }

            return result;
        }

        private int GetMaxForNumberOfDigits(int numberOfDigits)
        {
            var max = 10 - numberOfDigits;
            var lastDigit = max;
            for (int i = 1; i < numberOfDigits; i++)
            {
                max = max * 10 + (++lastDigit); 
            }

            return max;
        }

        private int GetOffSetForNumberOfDigits(int numberOfDigits)
        {
            var max = Convert.ToInt32(Math.Pow(10, numberOfDigits));
            var offSet = 1;
            while (offSet * 10 + 1 < max)
            {
                offSet = offSet * 10 + 1;
            }

            return offSet;
        }

        private int GetNumberOfDigits(int number)
        {
            var result = 1;

            while (number >= 10)
            {
                number = number / 10;
                result++;
            }

            return result;
        }
    }
}
