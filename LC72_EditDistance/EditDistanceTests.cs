using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC72_EditDistance
{
    [TestClass]
    public class EditDistanceTests
    {
        [TestMethod]
        public void GivenTwoWords_GetMinEditDistance_ShouldReturnCorrectAnswer()
        {
            var s1 = "horse";
            var s2 = "ros";

            var result = GetMinEditDistance(s1, s2);

            Assert.IsTrue(result == 3);
        }

        private int GetMinEditDistance(string s1, string s2)
        {
            var dp = GenerateDP(s1, s2);
            InitializeDP(dp);

            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[0].Length; j++)
                {
                    dp[i][j] = Math.Min(dp[i - 1][j] + 1, dp[i][j - 1] + 1);
                    var shouldInsertOrReplace = s1[i - 1] == s2[j - 1] ? 0 : 1;

                    dp[i][j] = Math.Min(dp[i - 1][j - 1] + shouldInsertOrReplace, dp[i][j]);
                }
            }

            return dp[s1.Length][s2.Length];

        }

        private void InitializeDP(int[][] dp)
        {
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i][0] = i;
            }

            for (int i = 0; i < dp[0].Length; i++)
            {
                dp[0][i] = i;
            }

        }

        private int[][] GenerateDP(string s1, string s2)
        {
            var result = new int[s1.Length + 1][];
            for (int i = 0; i < s1.Length + 1; i++)
            {
                result[i] = new int[s2.Length + 1];
            }

            return result;
        }
    }
}
