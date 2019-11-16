using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC818_RaceCar
{
    [TestClass]
    public class RaceCarTests
    {
        [TestMethod]
        public void GivenPosition_GetMinSteps_ShouldReturnCorrectMinStep()
        {
            var target = 6;

            var result = GetMinSteps(target);

            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void GivenPositionWithGoingToNegative_GetMinSteps_ShouldReturnCorrectMinStep()
        {
            var target = 6;

            var result = GetMinSteps(target);

            Assert.IsTrue(result == 5);
        }

        private int GetMinSteps(int target)
        {
            var position = GeneratePosition(target);

            return GetMinStepsHelper(target, position);
        }

        private int GetMinStepsHelper(int target, Dictionary<int, PositionInfo> position)
        {
            if (position.ContainsKey(target))
            {
                return position[target].Steps;
            }

            var upper = 0; var lower = 0;
            GetUpperAndLowerBound(target, position, ref upper, ref lower);

            var case1 = position[upper].Steps + 1 + GetMinStepsHelper(upper - target, position);
            var case2 = int.MaxValue;

            for (int i = 0; i < position[lower].Steps; i++)
            {
                var distance = StepsToDistance(i) + (target - lower);
                case2 = Math.Min(position[lower].Steps + 2 + i + GetMinStepsHelper(distance, position), case2);
            }

            return Math.Min(case1, case2);
        }

        private int StepsToDistance(int steps)
        {
            var currentPosition = 0;
            var currentSpeed = 1;
            for (int i = 0; i < steps; i++)
            {
                currentPosition += currentSpeed;
                currentSpeed = currentSpeed * 2;
            }

            return currentPosition;
        }

        private void GetUpperAndLowerBound(int target, Dictionary<int, PositionInfo> position, ref int upper, ref int lower)
        {
            var last = 0;
            var current = 0;
            foreach (var key in position.Keys)
            {
                last = current;
                current = key;

                if (current >= target)
                {
                    upper = current;
                    lower = last;
                    break;
                }
            }
        }

        private Dictionary<int, PositionInfo> GeneratePosition(int target)
        {
            var currentPosition = 0;
            var currentSpeed = 1;
            var result = new Dictionary<int, PositionInfo>() { { 0, new PositionInfo { Steps = 0, Direction = true, Speed = 1} } };
            var steps = 0;
            while (currentPosition <= target)
            {
                var lastPosition = currentPosition;

                currentPosition = lastPosition + currentSpeed;
                currentSpeed = currentSpeed * 2;
                steps++;
                result.Add(currentPosition, new PositionInfo { Steps = steps, Direction = true, Speed = currentSpeed});
            }

            return result;
        }


        private class PositionInfo
        {
            public int Steps { get; set; }
            public int Speed { get; set; }
            public bool Direction { get; set; }
        }
    }
}
