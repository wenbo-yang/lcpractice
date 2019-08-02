using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC74_SearchMatrix
{
    // binary search
    [TestClass]
    public class SearchMatrixTests
    {
        [TestMethod]
        public void GivenMatrix_Search_ShouldFindTheCorrectElement()
        {
            var mat = new int[][] { new int[] { 1, 3, 5, 7 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 50 } };
            var value = 3;
            bool found = FindValueInMatrix(mat, value);

            Assert.IsTrue(found);
        }

        [TestMethod]
        public void GivenMat_SearchRow_ShouldFindTheCorrectColumn()
        {
            var mat = new int[][] { new int[] { 1, 3, 5, 7 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 50 } };
            var value = 10;
            var col = BinarySearchRow(mat,0, mat.Length - 1, value);

            Assert.IsTrue(col == 1);
        }
        [TestMethod]
        public void GivenMat_SearchRow0_ShouldFindTheCorrectColumn()
        {
            var mat = new int[][] { new int[] { 1, 3, 5, 7 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 50 } };
            var value = 3;
            var col = BinarySearchRow(mat, 0, mat.Length - 1, value);

            Assert.IsTrue(col == 0);
        }

        private bool FindValueInMatrix(int[][] mat, int value)
        {
            var rowN= mat.Length;
            var colN = mat[0].Length;

            if (value > mat[rowN - 1][colN - 1] || value < mat[0][0])
            {
                return false;
            }

            var row = BinarySearchRow(mat, 0, rowN - 1, value);

            return BinarySearchCol(mat, row, 0, colN - 1, value);
        }

        private bool BinarySearchCol(int[][] mat, int row, int lower, int upper, int value)
        {
            if (lower >= upper)
            {
                return mat[row][lower] == value;
            }

            var mid = (upper + lower) / 2;

            return value <= mat[row][mid] ? BinarySearchCol(mat, row, lower, mid, value) : BinarySearchCol(mat, row, mid + 1, upper, value);
        }

        private int BinarySearchRow(int[][] mat, int lower, int upper, int value)
        {
            if (lower >= upper - 1)
            {
                if (value < mat[upper][0])
                {
                    return lower;
                }

                return upper;
            }

            var mid = (upper + lower) / 2;

            return value < mat[mid][0] ? BinarySearchRow(mat, 0, mid, value) : BinarySearchRow(mat, mid, upper, value);
        }
    }
}
