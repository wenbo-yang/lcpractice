using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC657_RobotToOrigin
{
    [TestClass]
    public class RobotToOriginTests
    {
        [TestMethod]
        public void GivenRightMoves_CanMoveToOrigin_ShouldReturnTrue()
        {
            var moves = "UD";
            var result = CanMoveToOrigin(moves);

            Assert.IsTrue(result);               
        }

        private bool CanMoveToOrigin(string moves)
        {
            var x = 0; var y = 0;

            foreach (var c in moves)
            {
                if (c == 'U')
                {
                    y++;
                }
                else if(c == 'D')
                {
                    y--;
                }
                else if (c == 'L')
                {
                    x--;
                }
                else if (c == 'R')
                {
                    x++;
                }
            }

            return x == 0 && y == 0;
        }
    }
}
