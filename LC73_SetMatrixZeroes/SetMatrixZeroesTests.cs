using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC73_SetMatrixZeroes
{
    [TestClass]
    public class SetMatrixZeroesTests
    {
        [TestMethod]
        public void GivenMatrix_SetMatrixZeroes_ShouldReturnCorrectMatrix()
        {
            var matrix = new int[][] {
                new int[] { 1, 1, 1},
                new int[] { 1, 0, 1},
                new int[] { 1, 1, 1}
            };

            SetMatrixZeroes(matrix);

            Assert.IsTrue(matrix[0].SequenceEqual(new int[] { 1, 0, 1 }) && matrix[1].SequenceEqual(new int[] { 0, 0, 0 }) && matrix[2].SequenceEqual(new int[] { 1, 0, 1 }));
        }

        private void SetMatrixZeroes(int[][] matrix)
        {
            var col0 = false;
            var row0 = false;

            (row0, col0) = ShouldSetFirstRowAndFirstColToZeroes(matrix);

            UseFirstRowAndColToRecord(matrix);

            SetRowColToZeroes(matrix);

            SetFirstRowColToZeroes(matrix, row0, col0); 
        }

        private void SetFirstRowColToZeroes(int[][] matrix, bool row0, bool col0)
        {
            if (row0)
            {
                for (int i = 0; i < matrix[0].Length; i++)
                {
                    matrix[0][i] = 0;
                }
            }

            if (col0)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }

        private void SetRowColToZeroes(int[][] matrix)
        {
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }

        private void UseFirstRowAndColToRecord(int[][] matrix)
        {
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }
        }

        private (bool row0, bool col0) ShouldSetFirstRowAndFirstColToZeroes(int[][] matrix)
        {
            var row0 = false;
            var col0 = false;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    col0 = true;
                    break;
                }
            }

            for (int i = 0; i < matrix[0].Length; i++)
            {
                if (matrix[0][i] == 0)
                {
                    row0 = true;
                    break;
                }
            }

            return (row0, col0);
        }
    }
}
