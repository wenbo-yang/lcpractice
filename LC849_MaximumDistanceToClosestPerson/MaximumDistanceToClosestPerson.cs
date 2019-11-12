using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC849_MaximumDistanceToClosestPerson
{
    [TestClass]
    public class MaximumDistanceToClosestPerson
    {
        [TestMethod]
        public void GivenArray_GetMaximumDistance_ShouldReturnMaximumDistance()
        {
            var input = new int[] { 1, 0, 0, 0, 1, 0, 1 };

            var result = GetMaximumDistance(input);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void GivenArrayWithLargeEndingZeros_GetMaximumDistance_ShouldReturnMaximumDistance()
        {
            var input = new int[] { 1, 0, 0, 1, 0, 0, 0 };

            var result = GetMaximumDistance(input);

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void GivenArrayWithLargeStartingZeros_GetMaximumDistance_ShouldReturnMaximumDistance()
        {
            var input = new int[] { 0, 0, 0, 0, 1, 0, 0, 1 };

            var result = GetMaximumDistance(input);

            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void GivenArray_GetMaximumDistanceNoExtraMemory_ShouldReturnMaximumDistance()
        {
            var input = new int[] { 1, 0, 0, 0, 1, 0, 1 };

            var result = GetMaximumDistanceNoExtraMemory(input);

            Assert.IsTrue(result == 2);
        }


        [TestMethod]
        public void GivenArrayWithLargeStartingZeros_GetMaximumDistanceNoExtraMemory_ShouldReturnMaximumDistance()
        {
            var input = new int[] { 0, 0, 0, 0, 1, 0, 0, 1 };

            var result = GetMaximumDistanceNoExtraMemory(input);

            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void GivenArrayWithLargeEndingZeros_GetMaximumDistanceNoExtraMemory_ShouldReturnMaximumDistance()
        {
            var input = new int[] { 1, 0, 0, 1, 0, 0, 0 };

            var result = GetMaximumDistanceNoExtraMemory(input);

            Assert.IsTrue(result == 3);
        }

        private int GetMaximumDistanceNoExtraMemory(int[] input)
        {
            var currentMax = 0;
            var right = 0;
            var left = 0;

            while (right < input.Length)
            {
                if (input[right] == 1 && left == 0 && input[left] == 0)
                {
                    currentMax = right - left;
                    left = right;
                }
                else if (input[right] == 1)
                {
                    currentMax = Math.Max((right - left) / 2, currentMax);
                    left = right;
                    right++;
                }
                else if (right == input.Length - 1)
                {
                    currentMax = Math.Max(right - left, currentMax);
                }

                right++; 
            }

            return currentMax;
        }

        private int GetMaximumDistance(int[] input)
        {
            var currentMax = 0;

            var occupied = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 1)
                {
                    occupied.Add(i);
                } 
            }

            currentMax = TryPlaceAtStartOrEnd(occupied, input.Length);

            currentMax = Math.Max(TryPlaceInBetween(occupied), currentMax);

            return currentMax;
        }

        private int TryPlaceInBetween(List<int> occupied)
        {
            var currentMax = 0;

            for (int i = 1; i < occupied.Count; i++)
            {
                currentMax = Math.Max((occupied[i] - occupied[i - 1]) / 2, currentMax);            
            }

            return currentMax; 
        }

        private int TryPlaceAtStartOrEnd(List<int> occupied, int inputLength)
        {
            var currentMax = 0;
            currentMax = (inputLength - 1) - occupied[occupied.Count - 1];

            currentMax = Math.Max(occupied[0], currentMax);
            return currentMax;
        }
    }
}
