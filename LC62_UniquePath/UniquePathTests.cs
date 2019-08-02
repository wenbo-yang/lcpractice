using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC62_UniquePath
{
    [TestClass]
    // both 62 and 63 is here
    public class UniquePathTests
    {
        [TestMethod]
        public void Given3X2WithNoBlocker_FindUniquePath_ShouldGiveCorrentNumber()
        {
            var mat = new int[][] { new int[2], new int[2], new int[2] };
            int path = FindUniquePaths(mat);
            Assert.IsTrue(path == 3);
        }

        [TestMethod]
        public void Given7X3WithNoBlocker_FindUniquePath_ShouldGiveCorrentNumber()
        {
            var mat = new int[][] { new int[3], new int[3], new int[3], new int[3], new int[3], new int[3], new int[3] };
            int path = FindUniquePaths(mat);
            Assert.IsTrue(path == 28);
        }

        [TestMethod]
        public void Given3X3With1Blocker_FindUniquePath_ShouldGiveCorrentNumber()
        {
            var mat = new int[][] { new int[3], new int[3] { 0,1,0}, new int[3] };
            int path = FindUniquePaths(mat);
            Assert.IsTrue(path == 2);
        }


        private int FindUniquePaths(int[][] mat)
        {
            var dp = GenerateDP(mat.Length, mat[0].Length);
            InitializDP(dp, mat);

            for (int i = 1; i < mat.Length; i++)
            {
                for (int j = 1; j < mat[0].Length; j++)
                {
                    dp[i][j] = mat[i][j] == 1 ? 0 : dp[i - 1][j] + dp[i][j - 1];
                }
            }

            return dp[mat.Length - 1][mat[0].Length - 1];
        }

        private void InitializDP(int[][] dp, int[][] mat)
        {
            dp[0][0] = 1;
                 
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i][0] = mat[i][0] == 1 ? 0 : dp[i - 1][0];
            }

            for (int j = 1; j < dp[0].Length; j++)
            {
                dp[0][j] = mat[0][j] == 1 ? 0 : dp[0][j - 1];
            }
        }

        private int[][] GenerateDP(int row, int col)
        {
            var dp = new int[row][];

            for (int i = 0; i < row; i++)
            {
                dp[i] = new int[col];
            }

            dp[0][0] = 0;

            return dp;
        }

        private bool CanMoveRight(int x, int y, int[][] mat)
        {
            return true;
        }
    }
}
