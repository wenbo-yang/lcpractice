using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1300_OptimalSumOfAMutatedArray
{
    [TestClass]
    public class OptimalSumOfAMutatedArrayTests
    {
        [TestMethod]
        public void GivenTargetSumAndArray_FindBestValue_ShouldReturnBestValue()
        {
            var array = new int[] { 4, 9, 3};  var target = 10;

            var result = FindBestValue(array, target);

            Assert.IsTrue(result == 3);
        }
        
        [TestMethod]
        public void GivenTargetSumAndAnotherArray_FindBestValue_ShouldReturnBestValue()
        {
            var array = new int[] { 2, 3, 5 }; var target = 10;

            var result = FindBestValue(array, target);

            Assert.IsTrue(result == 5);
        }

        private int FindBestValue(int[] array, int target)
        {
            (int value, int diff) currentValueDiff = (int.MinValue, int.MaxValue);

            Array.Sort(array);

            if (array[0] >= target / array.Length)
            {
                return Convert.ToInt32(Convert.ToDouble(target) / Convert.ToDouble(array.Length));
            }

            var prefixSum = new int[array.Length];

            prefixSum[0] = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                prefixSum[i] = array[i] + prefixSum[i - 1]; 
            }

            for (int i = 0; i < array.Length; i++)
            {
                var currentSum = prefixSum[i] + (array.Length - 1 - i) * array[i];

                var currentDiff = Math.Abs(currentSum - target);

                if (currentDiff < currentValueDiff.diff)
                {
                    currentValueDiff.value = array[i];
                    currentValueDiff.diff = currentDiff;
                }
            }

            return currentValueDiff.value;
        }
    }
}
