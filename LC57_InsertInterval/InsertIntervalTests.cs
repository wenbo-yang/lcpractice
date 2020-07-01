using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC57_InsertInterval
{
    [TestClass]
    public class InsertIntervalTests
    {
        [TestMethod]
        public void GivenListOfIntervalsAndInsertedInterval_Insert_ShouldReturnCorrectAnswer()
        {
            var intervals = new int[][] { new int[] { 1, 3 }, new int[] { 6, 9 } };
            var newInterval = new int[] { 2, 5 };

            var result = InsertInterval(intervals, newInterval);

            Assert.IsTrue(result[0].SequenceEqual(new int[] { 1, 5 }) && result[1].SequenceEqual(new int[] { 6, 9 }));
        }

        [TestMethod]
        public void GivenAnotherListOfIntervalsAndInsertedInterval_Insert_ShouldReturnCorrectAnswer()
        {
            var intervals = new int[][] { new int[] { 1, 2 }, new int[] { 3, 5 }, new int[] { 6, 7}, new int[] {8, 10 },  new int[] { 12, 16} };
            var newInterval = new int[] { 4, 8 };

            var result = InsertInterval(intervals, newInterval);

            Assert.IsTrue(result[0].SequenceEqual(new int[] { 1, 2 }) && result[1].SequenceEqual(new int[] { 3, 10 }) && result[2].SequenceEqual(new int[] { 12, 16 }));
        }

        private int[][] InsertInterval(int[][] intervals, int[] newInterval)
        {
            if (intervals == null || intervals.Length == 0)
            {
                return new int[][] { newInterval };
            }

            var result = new List<int[]>();

            if (intervals[0][0] > newInterval[1])
            {
                result.Add(newInterval); result.AddRange(intervals);
                return result.ToArray();
            }

            if (intervals[intervals.Length - 1][1] < newInterval[0])
            {
                result.AddRange(intervals); result.Add(newInterval);
                return result.ToArray();
            }

            var consumed = false;

            for (int i = 0; i < intervals.Length; i++)
            {
                if (!consumed)
                {
                    if (CanMerge(newInterval, intervals[i]))
                    {
                        result.Add(new int[] { Math.Min(newInterval[0], intervals[i][0]), Math.Max(newInterval[1], intervals[i][1]) });
                        consumed = true;
                    }
                    else if (CanAdd(newInterval, result, intervals[i]))
                    {
                        result.Add(newInterval);
                        result.Add(intervals[i]);
                        consumed = true;
                    }
                    else
                    {
                        result.Add(intervals[i]);
                    }
                }
                else
                {
                    if (intervals[i][0] <= result[result.Count - 1][1])
                    {
                        result[result.Count - 1][1] = Math.Max(result[result.Count - 1][1], intervals[i][1]);
                    }
                    else
                    {
                        result.Add(intervals[i]);
                    }
                }
            }

            return result.ToArray();
        }

        private bool CanAdd(int[] newInterval, List<int[]> result, int[] interval)
        {
            return interval[0] > newInterval[1] && (result.Count != 0 && result.Last()[1] < newInterval[0]);
        }

        private bool CanMerge(int[] newInterval, int[] interval)
        {
            return (newInterval[0] <= interval[1] && newInterval[1] >= interval[0]) || (newInterval[0] <= interval[1] && newInterval[1] >= interval[0]);
        }
    }
}
