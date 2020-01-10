using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1295_FindEvenNumberOfDigits
{
    [TestClass]
    public class FindEvenNumberOfDigitsTests
    {
        [TestMethod]
        public void GivenArray_FindNumberWithEvenDigits_ShouldReturnCorrecNumber()
        {
            var array = new int[] { 12, 345, 2, 6, 7896 };

            var result = FindEvenNumberOfDigits(array);

            Assert.IsTrue(result == 2);
        }

        private int FindEvenNumberOfDigits(int[] array)
        {
            var result = 0;

            var bounds = GenerateBoundary();

            foreach (int item in array)
            {
                foreach (var bound in bounds)
                {
                    if (item >= bound.lower && item < bound.upper)
                    {
                        result++;
                        break;
                    }
                }
            }

            return result;
        }

        private List<(int lower, int upper)> GenerateBoundary()
        {
            var lower = 10;
            var upper = 100;
            var maxLower = 1000000000;
            var result = new List<(int lower, int upper)>();

            result.Add((lower, upper));

            while (upper != int.MaxValue)
            {
                lower = lower * 100;
                
                if (lower == maxLower)
                {
                    upper = int.MaxValue;
                }
                else
                {
                    upper = upper * 100;
                }

                result.Add((lower, upper));
            }

            return result;
        }
    }
}
