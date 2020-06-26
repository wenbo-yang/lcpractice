using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC48_RotateImages
{
    [TestClass]
    public class RotateImagesTests
    {
        [TestMethod]
        public void GivenMatrix_Rotate_ShouldRotateImages()
        {
            var matrix = new int[][] {
                         new int[] { 1, 2, 3},
                         new int[] { 4, 5, 6},
                         new int[] { 7, 8, 9}};

            Rotate(matrix);

            Assert.IsTrue(matrix[0].SequenceEqual(new int[] { 7, 4, 1}) && matrix[1].SequenceEqual(new int[] { 8, 5, 2}) && matrix[2].SequenceEqual(new int[] { 9, 6, 3}));
        }

        [TestMethod]
        public void GivenMatrix_RotateInplace_ShouldRotateImages()
        {
            var matrix = new int[][] {
                         new int[] { 1, 2, 3},
                         new int[] { 4, 5, 6},
                         new int[] { 7, 8, 9}};

            RotateInplace(matrix);

            Assert.IsTrue(matrix[0].SequenceEqual(new int[] { 7, 4, 1 }) && matrix[1].SequenceEqual(new int[] { 8, 5, 2 }) && matrix[2].SequenceEqual(new int[] { 9, 6, 3 }));
        }

        private void RotateInplace(int[][] matrix)
        {
            throw new NotImplementedException();
        }

        private int[][] Rotate(int[][] matrix)
        {
            var rotated = GeneratedMatrix(matrix);
            var col = matrix[0].Length - 1;
            for (int i = 0; i < rotated.Length; i++)
            {
                for (int j = 0; j < rotated[0].Length; j++)
                {
                    rotated[i][j] = matrix[col - j][i];
                }
            }

            for (int i = 0; i < rotated.Length; i++)
            {
                for (int j = 0; j < rotated[0].Length; j++)
                {
                    matrix[i][j] = rotated[i][j];
                }
            }

            return rotated;
        }

        private int[][] GeneratedMatrix(int[][] matrix)
        {
            var rotated = new int[matrix.Length][];

            for (int i = 0; i < rotated.Length; i++)
            {
                rotated[i] = new int[matrix[0].Length];
            }

            return rotated;
        }
    }
}
