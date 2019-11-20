using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC334_IncreasingTriplet
{
    [TestClass]
    // greedy
    public class IncreasingTripletTests
    {
        [TestMethod]
        public void GivenValidArray_HasIncreasingTriplet_ShouldReturnTrue()
        {
            var input = new int[] { 8, 3, 2, 4, 5 };

            var result = HasIncreasingTriplet(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenInvalidArray_HasIncreasingTriplet_ShouldReturnTrue()
        {
            var input = new int[] { 5, 2, 3, 2, 1 };

            var result = HasIncreasingTriplet(input);

            Assert.IsFalse(result);
        }


        private bool HasIncreasingTriplet(int[] input)
        {
            var min1 = int.MaxValue; var min2 = int.MaxValue;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] <= min1)
                {
                    min1 = input[i];
                }
                else if (input[i] > min1 && input[i] <= min2)
                {
                    min2 = input[i];
                }
                else if (input[i] > min2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
