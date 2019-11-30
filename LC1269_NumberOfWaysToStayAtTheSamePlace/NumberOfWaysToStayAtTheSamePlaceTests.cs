using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1269_NumberOfWaysToStayAtTheSamePlace
{
    [TestClass]
    public class NumberOfWaysToStayAtTheSamePlaceTests
    {
        [TestMethod]
        public void GivenArrayLengthAndSteps_GetNumberOfWays_ShouldReturnCorrectNumberOfWays()
        {
            var steps = 3; var arrLen = 2;

            var result = GetNumberOfWays(steps, arrLen);

            Assert.IsTrue(result == 4);
        }

        private int GetNumberOfWays(int steps, int arrLen)
        {
            var dp = GenerateDP(steps, arrLen);

            var result = 0;

            for (int i = 0; i < arrLen; i++)
            {
                if (CanTravelToPositionAndBack(i, steps))
                {
                    result += GetNumberOfWaysToTravelToPositionAndBack(i, steps, dp);
                }               
            }

            return 0;
        }

        private int GetNumberOfWaysToTravelToPositionAndBack(int position, int steps, int[][] dp)
        {
            return GetNumberOfWaysToTravelToPositionWithNSteps(position, position, dp) * GetNumberOfWaysToTravelToPositionWithNSteps(position, steps - position, dp);
        }

        private int GetNumberOfWaysToTravelToPositionWithNSteps(int position, int steps, int[][] dp)
        {
            throw new NotImplementedException();
        }

        private int[][] GenerateDP(int steps, int arrLen)
        {
            var dp = new int[steps][];

            for (int i = 0; i < steps; i++)
            {
                dp[i] = new int[arrLen];
            }

            return dp;
        }

        private bool CanTravelToPositionAndBack(int steps, int position)
        {
            if (steps == 0 && position == 0)
            {
                return true;
            }

            return steps > position * 2;
        }
    }
}
