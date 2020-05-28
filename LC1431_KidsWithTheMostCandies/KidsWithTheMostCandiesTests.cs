using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1431_KidsWithTheMostCandies
{
    [TestClass]
    public class KidsWithTheMostCandiesTests
    {
        [TestMethod]
        public void GivenArrayAndExtraCandies_KidsWithGreatestNumberOfCandies_ShouldReturnCorrectArray()
        {
            var candies = new int[] { 2, 3, 5, 1, 3 };
            var extraCandies = 3;

            var result = KidsWithTheMostCandies(candies, extraCandies);

            Assert.IsTrue(result.SequenceEqual(new List<bool> { true, true, true, false, true }));
        }

        private List<bool> KidsWithTheMostCandies(int[] candies, int extraCandies)
        {
            var result = new List<bool>();

            var max = candies.Max();

            foreach (var candyNumber in candies)
            {
                result.Add(candyNumber + extraCandies >= max);
            }

            return result;
        }
    }
}
