using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1383_MaximumPerformanceOfATeam
{
    [TestClass]
    public class MaximumPerformanceOfATeamTests
    {
        [TestMethod]
        public void GivenTeamWithSpeedAndEfficiency_FindMaximumWithK_ShouldReturnCorrectAnswer()
        {
            var speed = new int[] { 5, 1, 5 };
            var efficiency = new int[] { 3, 30, 5 };
            var n = 3; var k = 1;
            var result = FindMaximumWithK(n, speed, efficiency, k);

            Assert.IsTrue(result == 30);
        }

        [TestMethod]
        public void GivenAnotherTeamWithSpeedAndEfficiency_FindMaximumWithK_ShouldReturnCorrectAnswer()
        {
            var speed = new int[] { 2, 10, 3, 1, 5, 8 };
            var efficiency = new int[] { 5, 4, 3, 9, 7, 2 };
            var n = 6; var k = 3;
            var result = FindMaximumWithK(n, speed, efficiency, k);

            Assert.IsTrue(result == 68);
        }

        private int FindMaximumWithK(int n, int[] speed, int[] efficiency, int k)
        {
            var engineers = new List<(int speed, int efficiency)>();

            for (int i = 0; i < n; i++)
            {
                engineers.Add((speed[i], efficiency[i]));
            }

            var sortedEngineers = engineers.OrderByDescending(x => x.efficiency);
            var minHeap = new MinHeap<int>();
            var speedSum = 0;
            var total = 0;
            foreach (var engineer in sortedEngineers)
            {
                if (minHeap.Count == k)
                {
                    speedSum -= minHeap.Pop();
                }

                minHeap.Add(engineer.speed);
                speedSum += engineer.speed;

                total = Math.Max(total, speedSum * engineer.efficiency); 
            }

            return total;
        }
    }
}
