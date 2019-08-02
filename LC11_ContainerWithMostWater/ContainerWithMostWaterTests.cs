using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC11_ContainerWithMostWater
{
    [TestClass]
    // two pointers finding the short comings
    public class ContainerWithMostWaterTests
    {
        [TestMethod]
        // not much to test
        public void GivenArray_MaxWater_ShouldReturnMaxWaterSize()
        {
            var array = new int[] { 0, 8, 7, 0 };

            var maxWater = ContainerBoundWithTheMostWater(array);

            Assert.IsTrue(maxWater == 7);
        }

        private int ContainerBoundWithTheMostWater(int[] height)
        {
            var left = 0;
            var right = height.Length - 1;

            var currentMaxSize = 0;

            do
            {
                var tempSize = (right - left) * Math.Min(height[left], height[right]);

                if (tempSize > currentMaxSize)
                {
                    currentMaxSize = tempSize;
                }

                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }

            }
            while (left != right);
          
            return currentMaxSize;
        }
    }
}
