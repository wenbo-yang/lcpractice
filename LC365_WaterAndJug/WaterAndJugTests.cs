using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC365_WaterAndJug
{
    [TestClass]
    public class WaterAndJugTests
    {
        [TestMethod]
        public void GivenValidWaterAndJug_CanMeasure_ShouldReturnTrue()
        {
            var jug1 = 3;
            var jug2 = 5;

            var water = 4;

            var result = CanMeasure(jug1, jug2, water);

            Assert.IsTrue(result);
        }

        private bool CanMeasure(int jug1, int jug2, int water)
        {
            if (jug1 + jug2 < water)
            {
                return false;
            }

            return water % FindSolution(jug1, jug2) == 0;
        }

        private int FindSolution(int jug1, int jug2)
        {
            return jug2 == 0 ? jug1 : FindSolution(jug2, jug1 % jug2);
        }
    }
}
