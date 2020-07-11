using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC85_MaximalRectangle
{
    [TestClass]
    public class MaximalRectangleTests
    {
        [TestMethod]
        public void GivenMatrix_MaximalRectangle_ShouldReturnCorrectAnswer()
        {
            var matrix = new char[][] {
                new char[] { '1', '0', '1', '0', '0'},
                new char[] { '1', '0', '1', '1', '1'},
                new char[] { '1', '1', '1', '1', '1'},
                new char[] { '1', '0', '0', '1', '0'}};

            var result = MaximalRectangle(matrix);

            Assert.IsTrue(result == 6);
        }

        private int MaximalRectangle(char[][] matrix)
        {
            var dp = GenerateDP(matrix);

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    dp[i][j] = matrix[i][j] == '1' ? (j == 0 ? 1 : dp[i][j - 1] + 1) : 0;
                }
            }

            var result = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; ++j)
                {
                    int len = int.MaxValue;
                    for (int k = i; k < matrix.Length; k++)
                    {
                        len = Math.Min(len, dp[k][j]);
                        if (len == 0)
                        {
                            break;
                        }
                        result = Math.Max(len * (k - i + 1), result);
                    }
                }
            }

            return result;
        }

        private int[][] GenerateDP(char[][] matrix)
        {
            var dp = new int[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                dp[i] = new int[matrix[0].Length];
            }

            return dp;
        }
    }
}
