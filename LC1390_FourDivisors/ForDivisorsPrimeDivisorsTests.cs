using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1390_FourDivisors
{
    [TestClass]
    public class ForDivisorsPrimeDivisorsTests
    {
        [TestMethod]
        public void GivenArrayOfIntegers_GetSumOfFourDivisors_ShouldReturnSum()
        {
            var array = new int[] { 25, 21, 4, 7 };
            var result = GetSumOfNumberWithFourDivisors(array);

            Assert.IsTrue(result == 32);
        }

        [TestMethod]
        public void GivenAnotherArrayOfIntegers_GetSumOfFourDivisors_ShouldReturnSum()
        {
            var array = new int[] { 25, 6, 4, 7 };
            var result = GetSumOfNumberWithFourDivisors(array);

            Assert.IsTrue(result == 12);
        }

        [TestMethod]
        public void GivenThirdArrayOfIntegers_GetSumOfFourDivisors_ShouldReturnSum()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var result = GetSumOfNumberWithFourDivisors(array);

            Assert.IsTrue(result == 45);
        }

        [TestMethod]
        public void GivenInteger_GetPrimeFactors_ShouldReturnPrimeFactors()
        {
            var result = GetPrimeFactors(25, new SortedSet<int>() { 2 });

           Assert.IsTrue(result.Count == 1);
        }

        private int GetSumOfNumberWithFourDivisors(int[] array)
        {
            var primeTable = new SortedSet<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

            var sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 1)
                {
                    continue;
                }

                var factors = GetPrimeFactors(array[i], primeTable);

                if (factors.Count == 0)
                {
                    primeTable.Add(array[i]);
                }

                if (factors.Count == 1 && (array[i] == factors.First()*factors.First()*factors.First()))
                {
                    sum += array[i] + 1 + factors.First() + factors.First() * factors.First();
                }

                if (factors.Count == 2 && (factors.First() * factors.Last() == array[i]))
                {
                    sum += array[i] + 1 + factors.First() + factors.Last();
                }
            }

            return sum;
        }

        private HashSet<int> GetPrimeFactors(int number, SortedSet<int> primeTable)
        {
            if (primeTable.Contains(number))
            {
                return new HashSet<int>();
            }

            var factors = new HashSet<int>();
            var sqrtOfN = Math.Sqrt(number);

            foreach (var item in primeTable)
            {
                if (item > sqrtOfN)
                {
                    break;
                }

                while (number % item == 0)
                {
                    factors.Add(item);
                    number = number / item;
                }
            }

            for (int div = 2; div <= number; div++)
            {
                while (number % div == 0)
                {
                    factors.Add(div);
                    primeTable.Add(div);
                    number = number / div;
                }
            }

            return factors;
        }
    }
}

