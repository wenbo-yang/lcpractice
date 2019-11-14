using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC115_DistinctSubsequences
{
    [TestClass]
    // DP
    public class DistinctSubsequencesTests
    {        
        [TestMethod]
        public void GivenSourceAndTargetString_GetUniqueSubsequenceCount_ShouldReturnCorrectNumber()
        {
            var source = "rabbbit";
            var target = "rabbit";

            var result = GetUniqueSequenceCount(source, target);

            Assert.IsTrue(result == 3);
        }

        private int GetUniqueSequenceCount(string source, string target)
        {
            // remember to pad source such that s[0] == t[0]

            var dp = GenerateDP(source, target);
            InitializeDP(dp);

            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = i; j < dp[0].Length; j++)
                {
                    if (source[j - 1] == target[i - 1])
                    {
                        dp[i][j] = dp[i - 1][j - 1] + dp[i][j - 1];
                    }
                    else
                    {
                        dp[i][j] = dp[i][j - 1];
                    }
                }
            }

            return dp[target.Length][source.Length];
        }

        private void InitializeDP(int[][] dp)
        {
            for (int i = 0; i < dp[0].Length; i++)
            {
                dp[0][i] = 1;
            }
        }

        private int[][] GenerateDP(string source, string target)
        {
            var dp = new int[target.Length + 1][];
            for (int i = 0; i < target.Length + 1; i++)
            {
                dp[i] = new int[source.Length + 1];
            }

            return dp;
        }
    }
}
