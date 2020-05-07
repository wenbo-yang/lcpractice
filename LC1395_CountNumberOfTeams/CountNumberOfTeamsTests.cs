using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1395_CountNumberOfTeams
{
    [TestClass]
    public class CountNumberOfTeamsTests
    {
        [TestMethod]
        public void GivenArray_CountNumberOfTeams_ShouldReturnCorrectNumberOfTeams()
        {
            var rating = new int[] { 2, 5, 3, 4, 1 };

            var result = CountNumberOfTeams(rating);

            Assert.IsTrue(result == 3);
        }

        private int CountNumberOfTeams(int[] rating)
        {
            var sum = 0;

            for (int i = 1; i < rating.Length - 1; i++)
            {
                var target = rating[i];
                var count = FindBiggerAndSmaller(target, i, rating);

                sum += count.biggerLeft * count.smallerRight;
                sum += count.smallerLeft * count.biggerRight;
            }

            return sum;
        }

        private (int biggerLeft, int smallerLeft, int biggerRight, int smallerRight) FindBiggerAndSmaller(int target, int targetIndex, int[] rating)
        {
            var biggerLeft = 0;
            var biggerRight = 0;
            var smallerLeft = 0;
            var smallerRight = 0;

            for (int i = 0; i < targetIndex; i++)
            {
                if (rating[i] < target)
                {
                    smallerLeft++;
                }
                else
                {
                    biggerLeft++;
                }
            }

            for (int i = targetIndex + 1; i < rating.Length; i++)
            {
                if (target < rating[i])
                {
                    biggerRight++;
                }
                else
                {
                    smallerRight++;
                }
            }

            return (biggerLeft, smallerLeft, biggerRight, smallerRight);
        }
    }
}
