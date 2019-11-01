using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC532_ContinuousSubarraySum
{
    [TestClass]
    public class ContinuousSubarraySumTests
    {
        [TestMethod]
        public void GivenValidArray_DoesSubArrayExist_ShouldReturnTrue()
        {
            var array = new int[] { 23, 2, 4, 6, 7 };
            var k = 6;

            var result = DoesSubArrayExist(array, k);

            Assert.IsTrue(result);
        }

        private bool DoesSubArrayExist(int[] array, int k)
        {
            // param validation // 

            var sumArray = new int[array.Length + 1];

            sumArray[0] = 0;

            for (int i = 1; i < array.Length; i++)
            {
                sumArray[i] = sumArray[i - 1] + array[i - 1];
            }

            for (int i = 0; i < sumArray.Length; i++)
            {
                for (int j = i + 2; j < sumArray.Length; j++)
                {
                    var sum = sumArray[j] - sumArray[i];

                    if (sum % k == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
