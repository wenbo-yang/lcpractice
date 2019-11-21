using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC198_HouseRobber
{
    [TestClass]
    public class HouseRobberTests
    {
        [TestMethod]
        public void GivenInputArray_FindNonConsecutiveMax_ShouldReturnCorrectResult()
        {
            var input = new int[] { 2, 7, 9, 3, 1};
            int result = FindNonConsecutiveMax(input);

            Assert.IsTrue(result == 12);
        }

        private int FindNonConsecutiveMax(int[] input)
        {
            // validate
            var prevl1 = 0;
            var prev = input[0];
            var current = input[0];

            for (int i = 1; i < input.Length; i++)
            {
                current = Math.Max(prevl1 + input[i], prev);
                prevl1 = prev;
                prev = current;
            }

            return current;
        }

        
    }
}
