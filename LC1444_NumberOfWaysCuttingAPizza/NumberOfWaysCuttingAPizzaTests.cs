using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1444_NumberOfWaysCuttingAPizza
{
    [TestClass]
    public class NumberOfWaysCuttingAPizzaTests
    {
        [TestMethod]
        public void GivenPizzaContainingApples_NumberOfWays_ShouldReturnCorrectNumberOfWays()
        {
            var pizza = new string[] { "A..", "AAA", "..." };
            var k = 3;
            var result = NumberOfWays(pizza, k);

            Assert.IsTrue(result == 4);
        }

        private int NumberOfWays(string[] pizza, int k)
        {
            throw new NotImplementedException();
        }

        private object InitializeDP(string[] pizza, int k)
        {
            throw new NotImplementedException();
        }
    }
}
