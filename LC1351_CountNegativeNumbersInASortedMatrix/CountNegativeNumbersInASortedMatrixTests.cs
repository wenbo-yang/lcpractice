using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1351_CountNegativeNumbersInASortedMatrix
{
    [TestClass]
    public class CountNegativeNumbersInASortedMatrixTests
    {
        [TestMethod]
        public void GivenSortedMatrix_CountNegativeNumbers_ShouldReturnNumberOfNegativeNumbers()
        {
            var mat = new int[][] { new int[] { 4, 3, 2, -1 },
                                    new int[] { 3, 2, -1, -1 },
                                    new int[] { 1, 1, -1, -2 },
                                    new int[] { -1, -1, -2, -3}};

            var result = CountNegativeNumbers(mat);

            Assert.IsTrue(result == 8);
        }

        private int CountNegativeNumbers(int[][] mat)
        {
            var count = 0;
            var m = mat.Length;
            var n = mat[0].Length;
            int r = m - 1;
            int c = 0;
            while (r >= 0 && c < n)
            {
                if (mat[r][c] < 0)
                {
                    count += n - c;
                    --r;
                }
                else
                {
                    ++c;
                }
            }
            return count;
        }
    }
}
