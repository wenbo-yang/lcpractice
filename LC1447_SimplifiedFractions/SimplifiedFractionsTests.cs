using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1447_SimplifiedFractions
{
    [TestClass]
    public class SimplifiedFractionsTests
    {
        [TestMethod]
        public void GivenN_SimplifiedFractions_ShouldReturnCorrectAnswer()
        {
            var n = 2;
            var result = SimplifiedFractions(n);

            Assert.IsTrue(result.SequenceEqual(new List<string> { "1/2" }));
        }

        [TestMethod]
        public void Given9_SimplifiedFractions_ShouldReturnCorrectAnswer()
        {
            var n = 9;
            var result = SimplifiedFractions(n);

            Assert.IsTrue(result.SequenceEqual(new List<string> { "1/2", "1/3", "1/4", "1/5", "1/6", "1/7", "1/8", "1/9", "2/3", "2/5", "2/7", "2/9", "3/4", "3/5", "3/7", "3/8", "4/5", "4/7", "4/9", "5/6", "5/7", "5/8", "5/9", "6/7", "7/8", "7/9", "8/9" }));
        }

        private List<string> SimplifiedFractions(int n)
        {
            var result = new List<string>();
            var primeSet = new HashSet<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            for (int i = 1; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    if (!CanReduce(i, j, primeSet))
                    {
                        result.Add($"{i.ToString()}/{j.ToString()}");
                    }
                }
            }

            return result;
        }

        private bool CanReduce(int i, int j, HashSet<int> primeSet)
        {
            if (i == 1)
            {
                return false;
            }

            if (primeSet.Contains(i) || primeSet.Contains(j))
            {
                return j % i == 0;
            }

            var set = GetPrimeFactors(i, primeSet);
            
            foreach(var factor in set)
            {
                if (j % factor == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private List<int> GetPrimeFactors(int num, HashSet<int> primeSet)
        {
            var result = new List<int>();
            foreach (var factor in primeSet)
            {
                if (factor > num)
                {
                    break;
                }

                if (num % factor == 0)
                {
                    result.Add(factor);
                    num /= factor;
                }
                
            }

            return result;
        }
    }
}
