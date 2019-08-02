using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC174_DungeonGame
{
    [TestClass]
    public class DungeonGameTests
    {
        [TestMethod]
        public void GivenDungeon_FindMinimumHealth_ShouldGivenCorrectAnswer()
        {
            var dungeon = new int[][] { new int[] { -2, -3, 3 }, new int[] { -5, -10, 1 }, new int[] { 10, 30, -5 } };

            int result = FindMinimumHealth(dungeon);

            Assert.IsTrue(result == 7);
        }

        private int FindMinimumHealth(int[][] dungeon)
        {
            var dp = GenerateDP(dungeon);
            InitializeDP(dp, dungeon);
            var row = dungeon.Length;
            var col = dungeon[0].Length;

            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    var minDP = dp[i - 1][j].Item1 < dp [i][j - 1].Item1 ? dp[i - 1][j] : dp[i][j - 1];

                    var tempCurrentHealth = minDP.Item2 + dungeon[i][j];
                    var minHealth = tempCurrentHealth < 0 ? minDP.Item1 - tempCurrentHealth : minDP.Item1;
                    var currentHealth = tempCurrentHealth < 0 ? 0 : tempCurrentHealth;

                    dp[i][j] = new Tuple<int, int>(minHealth, currentHealth);
                }
            }

            return dp[row - 1][col - 1].Item1 + 1;
        }

        private void InitializeDP(Tuple<int, int>[][] dp, int[][] dungeon)
        {
            var row = dungeon.Length;
            var col = dungeon[0].Length;

            var minHealth = dungeon[0][0] > 0 ? 0 : 0 - dungeon[0][0];
            var currentHealth = dungeon[0][0] < 0 ? 0: dungeon[0][0];
            dp[0][0] = new Tuple<int, int>(minHealth, currentHealth);

            for (int i = 1; i < col; i++)
            {
                var tempCurrentHealth = dp[0][i - 1].Item2 + dungeon[0][i];
                minHealth = tempCurrentHealth < 0 ? dp[0][i - 1].Item1 - tempCurrentHealth : dp[0][i - 1].Item1;
                currentHealth = tempCurrentHealth < 0 ? 0 : tempCurrentHealth;

                dp[0][i] = new Tuple<int, int>(minHealth, currentHealth);
            }

            for (int i = 1; i < row; i++)
            {
                var tempCurrentHealth = dp[i - 1][0].Item2 + dungeon[i][0];
                minHealth = tempCurrentHealth < 0 ? dp[i - 1][0].Item1 - tempCurrentHealth : dp[i - 1][0].Item1;
                currentHealth = tempCurrentHealth < 0 ? 0 : tempCurrentHealth;

                dp[i][0] = new Tuple<int, int>(minHealth, currentHealth);
            }
        }

        private Tuple<int, int>[][] GenerateDP(int[][] dungeon)
        {
            var row = dungeon.Length;
            var col = dungeon[0].Length;

            var result = new Tuple<int, int>[row][];

            for (int i = 0; i < row; i++)
            {
                result[i] = new Tuple<int, int>[col];
            }

            return result;
        }
    }
}
