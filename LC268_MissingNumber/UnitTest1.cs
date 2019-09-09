using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC268_MissingNumber
{
    [TestClass]
    public class MissingNumberTests
    {
        [TestMethod]
        // be careful of overflow
        public void GivenArrayAndMissingNumber_FindMissingNumber_ShouldReturnMissingNumber()
        {
            var input = new int[] { 0, 1, 2, 3, 4, 6, 7 };
            int missing = FindMissingNumber(input);

            Assert.IsTrue(missing == 5);
        }

        private int FindMissingNumber(int[] input)
        {
            var max = input.Max();
            var sum = input.Sum();

            var supposedSum = (max + 1) * input.Length / 2;

            return supposedSum - sum;
        }
    }
}
