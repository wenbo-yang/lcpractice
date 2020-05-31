using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1453_CircleOfRadiusRContainingMostPoints
{
    [TestClass]
    public class CircleOfRadiusRContainingMostPointsTests
    {
        [TestMethod]
        public void GivenRadiusAndListOfPoints_GetCircleWithMostPoints_ShouldReturnCorrectNumber()
        {
            var points = new int[][] { new int[] { -3, 0 }, new int[] { 3, 0 }, new int[] { 2, 6 }, new int[] { 5, 4 }, new int[] { 0, 9 }, new int[] { 7, 8 } };
            var r = 5;
            var result = GetCircleOfRadiusRWithMostPoints(points, r);

            Assert.IsTrue(result == 5);
        }

        private int GetCircleOfRadiusRWithMostPoints(int[][] points, int r)
        {
            //var rSqr = 4 * r * r;
            //var distance = new Dictionary<int, HashSet<int>>();
            //for (int i = 0; i < points.Length; i++)
            //{
            //    distance.Add(i, new HashSet<int>());

            //    for (int j = 0; j < points.Length; j++)
            //    {
            //        if ((points[i][0] - points[j][0]) * (points[i][0] - points[j][0]) + (points[i][1] - points[j][1]) * (points[i][1] - points[j][1]) <= rSqr)
            //        {
            //            distance[i].Add(j);
            //        }
            //    }
            //}

            //return -1;

            throw new NotImplementedException();
        }
    }
}
