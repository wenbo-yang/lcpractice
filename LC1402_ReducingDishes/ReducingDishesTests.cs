using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1402_ReducingDishes
{
    [TestClass]
    public class ReducingDishesTests
    {
        [TestMethod]
        public void GivenDishes_GetMaximumScore_ShouldReturnMaximum()
        {
            var dishes = new int[] { -1, -8, 0, 5, -9 };
            var result = GetMaximumScore(dishes);

            Assert.IsTrue(result == 14);
        }

        [TestMethod]
        public void GivenDishes_GetMaximumScoreDescending_ShouldReturnMaximum()
        {
            var dishes = new int[] { -1, -8, 0, 5, -9 };
            var result = GetMaximumScoreDescending(dishes);

            Assert.IsTrue(result == 14);
        }

        private int GetMaximumScoreDescending(int[] dishes)
        {
            Array.Sort(dishes);

            if (dishes[dishes.Length - 1] < 0)
            {
                return 0;
            }

            var currentScore = 0;
            var sum = 0;
            var maxScore = 0;

            for (int i = dishes.Length - 1; i >= 0; i--)
            {
                sum += dishes[i];
                currentScore += sum;

                if (currentScore < maxScore)
                {
                    break;
                }
                else
                {
                    maxScore = currentScore;
                }
            }

            return maxScore;
        }

        private int GetMaximumScore(int[] dishes)
        {
            Array.Sort(dishes);

            if (dishes[dishes.Length - 1] < 0)
            {
                return 0;
            }
            var sum = dishes.Sum();
               
            var currentScore = GetInitialScore(dishes);
            if (dishes[0] >= 0)
            {
                return currentScore;
            }

            var maxScore = currentScore;

            for (int i = 0; i < dishes.Length; i++)
            {
                currentScore -= sum;
                sum -= dishes[i];
                maxScore = Math.Max(currentScore, maxScore);
            }

            return maxScore < 0 ? 0 : maxScore;
        }

        private int GetInitialScore(int[] dishes)
        {
            var initial = 0;
            for (int i = 0; i < dishes.Length; i++)
            {
                initial += (i + 1) * dishes[i];
            }

            return initial;
        }
    }
}
