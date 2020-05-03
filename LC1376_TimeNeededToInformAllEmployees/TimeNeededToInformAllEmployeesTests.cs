using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1376_TimeNeededToInformAllEmployees
{
    [TestClass]
    public class TimeNeededToInformAllEmployeesTests
    {
        [TestMethod]
        public void GivenManagerArrayAndTimeArray_GetTimeToInformAll_ShouldReturnCorrectTime()
        {
            var n = 6; var headID = 2;
            var manager = new int[] { 2, 2, -1, 2, 2, 2 };
            var informTime = new int[] { 0, 0, 1, 0, 0, 0 };

            var result = GetTimeToInformAll(n, headID, manager, informTime);

            Assert.IsTrue(result == 1);
        }

        private int GetTimeToInformAll(int n, int headID, int[] manager, int[] informTime)
        {
            var table = ConstructSubordinateIndexTable(manager, headID);

            var queue = new Queue<(int id, int timeToInform)>();

            queue.Enqueue((headID, 0));
            var result = 0;
            while (queue.Count != 0)
            {
                var top = queue.Dequeue();

                result = Math.Max(result, top.timeToInform);

                if (table.ContainsKey(top.id))
                {
                    foreach (var subordinate in table[top.id])
                    {
                        queue.Enqueue((subordinate, top.timeToInform + informTime[top.id]));
                    }
                }
            }

            return result;
        }

        private Dictionary<int, List<int>> ConstructSubordinateIndexTable(int[] manager, int headID)
        {
            var table = new Dictionary<int, List<int>>();

            for(int i = 0; i < manager.Length; i++)
            {
                if (manager[i] == -1)
                {
                    continue;
                }

                if (!table.ContainsKey(manager[i]))
                {
                    table.Add(manager[i], new List<int>());
                }

                table[manager[i]].Add(i);
            }

            return table;
        }
    }
}
