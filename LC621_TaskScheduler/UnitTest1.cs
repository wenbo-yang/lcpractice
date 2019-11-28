using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC621_TaskScheduler
{
    [TestClass]
    public class TaskSchedulerTests
    {
        [TestMethod]
        public void GivenTaskArrayAndInterval_TaskScheduler_OutPutTasks()
        {
            var tasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'B' };
            var interval = 2;

            var result = TaskScheduler(tasks, interval);

            Assert.IsTrue(result == 8);
        }

        private int TaskScheduler(char[] tasks, int interval)
        {
            var frequency = new int[26];
            foreach (var c in tasks)
            {
                frequency[c - 'A']++;
            }

            var startingIndex = 0; ;
            var result = int.MinValue;
            for (int i = 0; i < 26; i++)
            {
                var max = frequency.Max();
                if (max == 0)
                {
                    break;
                }
                var temp = (max - 1) * (interval + 1) + 1;
                result = Math.Max(temp + startingIndex++, result);
                frequency[Array.IndexOf(frequency, max)] = 0;
            }

            return result;
        }
    }
}
