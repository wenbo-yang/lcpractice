using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1320_MinimumDistanceToTypeAWordUsingTwoFingers
{
    [TestClass]
    public class MinimumDistanceToTypeAWordUsingTwoFingers
    {
        [TestMethod]
        public void GivenChar_GetCoordinate_ShouldReturnCoordinates()
        {
            var result = GetCoordinate('Z');

            Assert.IsTrue(result.row == 4 && result.col == 1);
        }

        [TestMethod]
        public void GivenString_GetMinimumDistance_ShouldReturnMinimumDistanceSum()
        {
            var word = "CAKE";

            var result = GetMinimumDistance(word);

            Assert.IsTrue(result == 3);
        }

        private int GetMinimumDistance(string word)
        {
            if (word.Length < 3)
            {
                return 0;
            }

            var dp = new Queue<(int firstKChars, int firstIndex, int secondIndex, int distance)>();

            dp.Enqueue((2, 0, 1, 0));
            dp.Enqueue((2, 1, -1, GetDistance(word[0], word[1])));

            for (int i = 3; i <= word.Length; i++)
            {
                var count = dp.Count;
                while (count > 0)
                {
                    var top = dp.Dequeue();

                    dp.Enqueue((i, i - 1, top.secondIndex, top.distance + GetDistance(word[top.firstIndex], word[i - 1])));
                    dp.Enqueue((i, top.firstIndex, i - 1, top.secondIndex == -1 ? top.distance : top.distance + GetDistance(word[top.secondIndex], word[i - 1])));
                    count--;
                }
            }

            var currentMin = int.MaxValue;
            while (dp.Count != 0)
            {
                var top = dp.Dequeue();

                currentMin = Math.Min(top.distance, currentMin);
            }

            return currentMin;
        }

        private (int row, int col) GetCoordinate(char c)
        {
            return ((c - 'A') / 6, (c - 'A') % 6);
        }

        private int GetDistance(char s, char d)
        {
            var source = GetCoordinate(s);
            var destination = GetCoordinate(d);
            return Math.Abs(source.row - destination.row) + Math.Abs(source.col - destination.col);
        }
    }
}
