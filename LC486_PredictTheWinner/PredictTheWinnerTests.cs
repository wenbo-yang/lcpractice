using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC486_PredictTheWinner
{
    [TestClass]
    public class PredictTheWinnerTests
    {
        [TestMethod]
        public void GivenScoresAndPlayer1CanWin_PredictWinner_ShouldReturnTrue()
        {
            var scores = new int[] { 1, 233, 5, 7 };
            var result = PredictWinner(scores);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenScoresAndPlayer1CannotWin_PredictWinner_ShouldReturnTrue()
        {
            var scores = new int[] { 1, 5, 2 };
            var result = PredictWinner(scores);

            Assert.IsFalse(result);
        }

        private bool PredictWinner(int[] scores)
        {
            var subSum = new Dictionary<(int left, int right, bool), int>();

            var max = GetMax(scores, 0, scores.Length - 1, subSum, true);

            return max > scores.Sum() / 2;
        }

        private int GetMax(int[] scores, int left, int right, Dictionary<(int left, int right, bool isPlayer1), int> subSum, bool isPlayer1)
        {
            if (subSum.ContainsKey((left, right, isPlayer1)))
            {
                return subSum[(left, right, isPlayer1)];
            }

            if (left == right - 1)
            {
                var value = isPlayer1 ? Math.Max(scores[left], scores[right]) : Math.Min(scores[left], scores[right]);
                subSum.Add((left, right, isPlayer1), value);

                return value;
            }

            var sum = 0;

            if (isPlayer1)
            {
                var leftSum = scores[left] + GetMax(scores, left + 1, right, subSum, !isPlayer1);
                var rightSum = scores[right] + GetMax(scores, left, right - 1, subSum, !isPlayer1);
                sum = Math.Max(leftSum, rightSum);
            }
            else
            {
                var leftSum = GetMax(scores, left + 1, right, subSum, !isPlayer1);
                var rightSum = GetMax(scores, left, right - 1, subSum, !isPlayer1);

                sum = Math.Min(leftSum, rightSum);
            }
                
            subSum.Add((left, right, isPlayer1), sum);

            return sum;

        }
    }
}
