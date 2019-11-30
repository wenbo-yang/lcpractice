using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC312_BurstingBalloons
{
    [TestClass]
    public class BurstingBalloonsTests
    {
        [TestMethod]
        public void GivenArrayOfScores_GetMaxScore_ShouldReturnMaxScore()
        {
            var points = new List<int> { 3, 1, 5, 8 };

            var result = GetMaxScore(points);

            Assert.IsTrue(result == 167);
        }

        private int GetMaxScore(List<int> points)
        {
            points.Insert(0, 1);
            points.Add(1);

            var dp = GenerateDP(points);

            return GetMaxScoreHelper(dp, points, 1, points.Count - 2);
        }

        private int GetMaxScoreHelper(int[][] dp, List<int> points, int start, int end)
        {
            if (start > end)
            {
                return 0;
            }

            if (dp[start][end] > 0)
            {
                return dp[start][end];
            }

            var result = 0;

            for (int i = start; i <= end; i++)
            {
                var score = points[i] * points[start - 1] * points[end + 1];
                result = Math.Max(result, GetMaxScoreHelper(dp, points, start, i - 1) + score + GetMaxScoreHelper(dp, points, i + 1, end));
            }

            dp[start][end] = result;

            return result;
        }

        private int[][] GenerateDP(List<int> points)
        {
            var dp = new int[points.Count][];
            for (int i = 0; i < points.Count; i++)
            {
                dp[i] = new int[points.Count];
            }

            return dp;
        }
    }
}
