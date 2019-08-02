using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC70_ClimbingStairs
{
    [TestClass]
    public class ClimbingStairsTests
    {
        [TestMethod]
        public void GivenInputNumber_FindWays_ShouldReturnCorrectResult()
        {
            var input = 2;

            int output = FindWays(input);

            Assert.IsTrue(output == 2);
        }

        [TestMethod]
        public void GivenInputNumber3_FindWays_ShouldReturnCorrectResult()
        {
            var input = 3;

            int output = FindWays(input);

            Assert.IsTrue(output == 3);
        }

        [TestMethod]
        public void GivenInputNumber4_FindWays_ShouldReturnCorrectResult()
        {
            var input = 4;

            int output = FindWays(input);

            Assert.IsTrue(output == 5);
        }

        private int FindWays(int input)
        {
            int prev = 1;
            int prevl1 = 0;
            int current = 0;
            for (int i = 1; i <= input; i++)
            {
                current = prev + prevl1;
                prevl1 = prev;
                prev = current;
            }

            return current;
        }
    }
}
