using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC136_SingleNumber
{
    [TestClass]
    // 137 is the same
    public class SingleNumberTests
    {
        [TestMethod]
        public void GivenArray_FindSingleNumber_ShouldReturnSingleNumber()
        {
            var input = new int[] { 2, 2, 1 };

            int result = FindSingleNumber(input);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void GivenArrayOf3RepeatingNumbers_FindSingleNumber_ShouldReturnSingleNumber()
        {
            var input = new int[] { 2, 2, 2, 3 };

            int result = FindSingleNumberII(input);

            Assert.IsTrue(result == 3);
        }

        private int FindSingleNumberII(int[] input)
        {
            int one = 0, two = 0;

            for (int i = 0; i < input.Length; i++)
            {
                one = (one ^ input[i]) & ~two;
                two = (two ^ input[i]) & ~one;
            }

            return one;
        }

        private int FindSingleNumber(int[] input)
        {
            var result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                result ^= input[i];
            }

            return result;
        }
    }
}
