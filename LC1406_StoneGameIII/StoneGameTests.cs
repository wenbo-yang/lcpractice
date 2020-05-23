using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1406_StoneGameIII
{
    [TestClass]
    public class StoneGameTests
    {
        [TestMethod]
        public void GivenValuesArray_GetWinner_ShouldReturnCorrectWinner()
        {
            var stoneValue = new int[] { 1, 2, 3, 7 };

            var result = GetWinner(stoneValue);

            Assert.IsTrue(result == "Bob");
        }

        [TestMethod]
        public void GivenAnotherValuesArray_GetWinner_ShouldReturnCorrectWinner()
        {
            var stoneValue = new int[] { 1, 2, 3, -9 };

            var result = GetWinner(stoneValue);

            Assert.IsTrue(result == "Alice");
        }

        private string GetWinner(int[] stoneValue)
        {
            var postSum = new int[stoneValue.Length + 5];
            postSum[stoneValue.Length - 1] = stoneValue[stoneValue.Length - 1];
            var sum = stoneValue[stoneValue.Length - 1];

            for (int i = stoneValue.Length - 2; i >= 0; i--)
            {
                sum += stoneValue[i];
                var one = stoneValue[i];
                var two = one + stoneValue[i + 1];
                var three = two + (i + 2 == stoneValue.Length ? 0 : stoneValue[i + 2]);
                postSum[i] = Math.Max(one + GetMin(i + 2, postSum),
                             Math.Max(two + GetMin(i + 3, postSum),
                                    three + GetMin(i + 4, postSum)));
            }

            if (postSum[0] == sum / 2 && sum%2 ==0)
            {
                return "Tie";
            }

            return postSum[0] > sum / 2 ? "Alice" : "Bob";
        }

        private int GetMin(int startIndex, int[] postSum)
        {
            return Math.Min(postSum[startIndex], Math.Min(postSum[startIndex + 1], postSum[startIndex + 2]));
        }
    }
}
