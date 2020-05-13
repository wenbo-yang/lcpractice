using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1401_OverlappingCircleAndRectangle
{
    [TestClass]
    public class OverlappingCircleAndRectangleTests
    {
        [TestMethod]
        public void GivenCircleAndRectangle_FindOverlapping_ShouldReturnCorrectAnswer()
        {
            var radius = 1; var x_center = 0; var y_center = 0 ; var x1 = -1; var y1 = 0; var x2 = 0; var y2 = 1;

            var result = CheckOverlap(radius, x_center, y_center, x1, y1, x2, y2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenAnotherSetCircleAndRectangle_FindOverlapping_ShouldReturnCorrectAnswer()
        {
            var radius = 1; var x_center = 1; var y_center = 1; var x1 = -3; var y1 = -3; var x2 = 3; var y2 = 3;

            var result = CheckOverlap(radius, x_center, y_center, x1, y1, x2, y2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNonOverlappingCircleAndRectangle_FindOverlapping_ShouldReturnCorrectAnswer()
        {
            var radius = 1; var x_center = 0; var y_center = 3; var x1 = 7; var y1 = 3; var x2 = 10; var y2 = 6;

            var result = CheckOverlap(radius, x_center, y_center, x1, y1, x2, y2);

            Assert.IsFalse(result);
        }

        private bool CheckOverlap(int radius, int x_center, int y_center, int x1, int y1, int x2, int y2)
        {
            return CheckOverappingSides(radius, x_center, y_center, x1, y1, x2, y2) ||
                CheckSquareContainsCircle(radius, x_center, y_center, x1, y1, x2, y2) ||
                CheckCircleContainsSquare(radius, x_center, y_center, x1, y1, x2, y2);
        }

        private bool CheckSquareContainsCircle(int r, int x_center, int y_center, int x1, int y1, int x2, int y2)
        {
            var x1_trans = x1 - x_center;
            var x2_trans = x2 - x_center;
            var y1_trans = y1 - y_center;
            var y2_trans = y2 - y_center;
            var minus_r = -1 * r;

            var temp = x2_trans;
            if (x1_trans > x2_trans)
            {
                x2_trans = x1_trans;
                x1_trans = temp;
            }

            temp = y2_trans;
            if (y1_trans > y2_trans)
            {
                y2_trans = y1_trans;
                y1_trans = temp;
            }

            return y2_trans > r && y1_trans < minus_r && x2_trans > r && x1_trans < minus_r;
        }

        private bool CheckCircleContainsSquare(int r, int x_center, int y_center, int x1, int y1, int x2, int y2)
        {
            var x1_trans = x1 - x_center;
            var x2_trans = x2 - x_center;
            var y1_trans = y1 - y_center;
            var y2_trans = y2 - y_center;
            var minus_r = -1 * r;

            return !(y1_trans > r || y2_trans > r || y1_trans < minus_r || x1_trans > r || x2_trans > r || x1 < minus_r || x2_trans < minus_r);
        }

        private bool CheckOverappingSides(int r, int x_center, int y_center, int x1, int y1, int x2, int y2)
        {
            var rSqr = r * r;
            var minus_r = -1 * r;
            var xSqr = x_center * x_center;
            var ySqr = y_center * y_center;
            var x1TSqr = (x1 - x_center) * (x1 - x_center);
            var x2TSqr = (x2 - x_center) * (x2 - x_center);
            var y1TSqr = (y1 - y_center) * (y1 - y_center);
            var y2TSqr = (y2 - y_center) * (y2 - y_center);
            var x1_trans = x1 - x_center;
            var x2_trans = x2 - x_center;
            var y1_trans = y1 - y_center;
            var y2_trans = y2 - y_center;

            var temp = x2_trans;
            if (x1_trans > x2_trans)
            {
                x2_trans = x1_trans;
                x1_trans = temp;
            }

            temp = y2_trans;
            if (y1_trans > y2_trans)
            {
                y2_trans = y1_trans;
                y1_trans = temp;
            }

            var y_intersect = rSqr - x1TSqr;
            if (y_intersect >= 0 && IsInRange(Math.Sqrt(y_intersect), y1_trans, y2_trans) || IsInRange(-1 * Math.Sqrt(y_intersect), y1_trans, y2_trans))
            {
                return true;
            }

            y_intersect = rSqr - x2TSqr;
            if (y_intersect >= 0 && IsInRange(Math.Sqrt(y_intersect), y1_trans, y2_trans) || IsInRange(-1 * Math.Sqrt(y_intersect), y1_trans, y2_trans))
            {
                return true;
            }

            var x_intersect = rSqr - y1TSqr;
            if (x_intersect >= 0 && IsInRange(Math.Sqrt(x_intersect), x1_trans, x2_trans) || IsInRange(-1 * Math.Sqrt(x_intersect), x1_trans, x2_trans))
            {
                return true;
            }

            x_intersect = rSqr - y2TSqr;
            if (x_intersect >= 0 && IsInRange(Math.Sqrt(x_intersect), x1_trans, x2_trans) || IsInRange(-1 * Math.Sqrt(x_intersect), x1_trans, x2_trans))
            {
                return true;
            }

            return false;
        }

        private bool IsInRange(double value, int lower, int upper)
        {
            return lower <= value && value <= upper; 
        }
    }
}
