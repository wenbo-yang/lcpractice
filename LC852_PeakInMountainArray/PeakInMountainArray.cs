using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC852_PeakInMountainArray
{
    [TestClass]
    public class PeakInMountainArray
    {
        [TestMethod]
        public void GivenArray_FindPeak_ShouldReturnPeakIndex()
        {
            var array = new int[] { 0, 1, 2, 5, 3 };

            var result = FindPeak(array);

            Assert.IsTrue(result == 3);
        }

        private int FindPeak(int[] array)
        {
            if (array[0] > array[1])
            {
                return 0;
            }

            if (array[array.Length - 1] > array[array.Length - 2])
            {
                return array.Length - 1;
            }

            var start = 1;
            var end = array.Length - 2;

            while (start <= end)
            {
                var pivot = (start + end) / 2;

                if (array[pivot] > array[pivot - 1] && array[pivot] > array[pivot + 1])
                {
                    return pivot;
                }
                else
                {
                    start = pivot + 1;
                }
            }

            return start;
        }
    }
}
