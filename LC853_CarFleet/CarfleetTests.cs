using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC853_CarFleet
{
    [TestClass]
    public class CarFleetTest
    {
        [TestMethod]
        public void GivenCarFleet_GetNumberOfFleet_ShouldReturnCorrectFleet()
        {
            var position = new int[] { 10, 8, 0, 5, 3 };
            var speed = new int[] { 2, 4, 1, 1, 3 };

            var result = GetNumberOfFleet(position, speed);

            Assert.IsTrue(result == 3);
        }

        private int GetNumberOfFleet(int[] position, int[] speed)
        {
            if (position.Length == 0)
            {
                return 0;
            }

            var sortedPositionSpeedPair = SortByPosition(position, speed);
            var result = 1;

            for (int i = 1; i < sortedPositionSpeedPair.Count; i++)
            {
                if (sortedPositionSpeedPair[i].Item2 > sortedPositionSpeedPair[i - 1].Item2)
                {
                    sortedPositionSpeedPair[i] = new Tuple<int, int>(sortedPositionSpeedPair[i].Item1, sortedPositionSpeedPair[i - 1].Item2);
                }
                else
                {
                    result++;
                }
            }

            return result;
        }

        private List<Tuple<int, int>> SortByPosition(int[] position, int[] speed)
        {
            var sorted = new List<Tuple<int, int>>();
            for (int i = 0; i < position.Length; i++)
            {
                sorted.Add(new Tuple<int, int>(position[i], speed[i]));
            }

            sorted.Sort();
            sorted.Reverse();
            return sorted;
        }
    }
}
