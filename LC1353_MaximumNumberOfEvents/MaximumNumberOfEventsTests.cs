using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1353_MaximumNumberOfEvents
{
    [TestClass]
    public class MaximumNumberOfEventsTests
    {
        [TestMethod]
        public void GivenAnotherArrayOfStartsAndEnds_GetMaximumNumberOfEvents_ShouldReturnMaximumNumber()
        {
            var eventDates = new int[][] { new int[] { 1, 4 }, new int[] { 4, 4 }, new int[] { 2, 2 }, new int[] { 3, 4 }, new int[] { 1, 1 } };

            var result = GetMaximumNumberOfEventsAttended(eventDates);

            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void GivenArrayOfStartsAndEnds_GetMaximumNumberOfEvents_ShouldReturnMaximumNumber()
        {
            var eventDates = new int[][] { new int[] { 1, 2 }, new int[] { 1, 2 }, new int[] { 3, 3 }, new int[] { 1, 5 }, new int[] { 1, 5 } };

            var result = GetMaximumNumberOfEventsAttended(eventDates);

            Assert.IsTrue(result == 5);
        }

        private int GetMaximumNumberOfEventsAttended(int[][] events)
        {
            var sorted = events.OrderBy(x => x[1]);
            var max = sorted.Max(x => x[1]);

            var result = 0;
            var visited = new bool[max + 1];

            foreach (var e in sorted)
            {
                for (int i = e[0]; i <= e[1]; i++)
                {
                    if (visited[i])
                    {
                        continue;
                    }
                    visited[i] = true;
                    result++;
                    break;
                }
            }

            return result;
        }
    }
}
