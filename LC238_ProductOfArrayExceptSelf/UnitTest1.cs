using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC238_ProductOfArrayExceptSelf
{
    [TestClass]
    public class ProductOfArrayExceptSelfTests
    {
        [TestMethod]
        public void GivenArray_FindProductArrayExceptSelf_ShouldReturnCorrectArray()
        {
            var array = new int[] { 2, 3, 4, 5 };

            var result = FindProductArrayExceptSelf(array);

            Assert.IsTrue(result.SequenceEqual(new int[] { 60, 40, 30, 24 }));
        }

        private int[] FindProductArrayExceptSelf(int[] array)
        {
            var left = new int[array.Length];
            var right = new int[array.Length];

            left[0] = 1;
            for (int i = 1; i < left.Length; i++)
            {
                left[i] = left[i - 1] * array[i - 1];
            }

            right[right.Length - 1] = 1;
            for (int i = right.Length - 2; i >= 0; i--)
            {
                right[i] = right[i + 1] * array[i + 1];
            }

            var result = new int[array.Length];
            result[0] = right[0];
            result[array.Length - 1] = left[array.Length - 1];

            for (int i = 1; i < result.Length - 1; i++)
            {
                result[i] = left[i] * right[i]; 
            }

            return result;
        }
    }
}
