using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1423_MaximumPointsForKCards
{
    [TestClass]
    public class MaximumPointsForKCardsTests
    {
        [TestMethod]
        public void GivenCardArrayAndNumberOfCards_GetMaximum_CardScore_ShouldReturnMaximumCardScore()
        {
            var cardPoints = new int[] { 1, 2, 3, 4, 5, 6, 1 };
            var k = 3;
            var result = GetMaximumCardScore(cardPoints, k);
            Assert.IsTrue(result == 12);
        }

        [TestMethod]
        public void GivenCardArrayPickingAllCards_GetMaximum_CardScore_ShouldReturnMaximumCardScore()
        {
            var cardPoints = new int[] { 9, 7, 7, 9, 7, 7, 9};
            var k = 7;
            var result = GetMaximumCardScore(cardPoints, k);
            Assert.IsTrue(result == 55);
        }

        private int GetMaximumCardScore(int[] cardPoints, int k)
        {
            var min = 0;
            var sum = 0;
            var left = 0;
            var windowSize = cardPoints.Length - k;
            var windowValue = 0;
            for (int i = 0; i < cardPoints.Length; i++)
            {
                sum += cardPoints[i];

                if (i - left < windowSize)
                {
                    windowValue = sum;
                    min = sum;
                }
                else
                {
                    windowValue += cardPoints[i];
                    windowValue -= cardPoints[left++];
                    min = Math.Min(min, windowValue);
                }
            }

            return sum - min;
        }
    }
}
