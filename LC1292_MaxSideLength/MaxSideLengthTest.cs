using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1292_MaxSideLength
{
    [TestClass]
    public class MaxSideLengthTest
    {
        [TestMethod]
        public void GivenGrid_GetMaxSideLengthWithThreshold_ShouldReturnValidLength()
        {
            var grid = new int[][] { new int[] { 1, 1, 3, 2, 4, 3, 2 },
                                     new int[] { 1, 1, 3, 2, 4, 3, 2 },
                                     new int[] { 1, 1, 3, 2, 4, 3, 2 }};
            var threshold = 4;
            var result = GetMaxSideLengthWithThreshold(grid, threshold);

            Assert.IsTrue(result == 2);
        }

        private int GetMaxSideLengthWithThreshold(int[][] grid, int threshold)
        {
            throw new NotImplementedException();
        }
    }
}
