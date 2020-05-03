using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1345_MinJumps
{
    [TestClass]
    public class MinJumpsTests
    {
        [TestMethod]
        public void GivenArray_GetMinJumps_ShouldReturnMinJumpSteps()
        {
            var array = new int[] { 100, -23, -23, 404, 100, 23, 23, 23, 3, 404 };

            var result = GetMinJumps(array);

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void GivenAnotherArray_GetMinJumps_ShouldReturnMinJumpSteps()
        {
            var array = new int[] {68, -94, -44, -18, -1, 18, -87, 29, -6, -87, -27, 37, -57, 7, 18, 68, -59, 29, 7, 53, -27, -59, 18, -1, 18, -18, -59, -1, -18, -84, -20, 7, 7, -87, -18, -84, -20, -27 };

            var result = GetMinJumps(array);

            Assert.IsTrue(result == 5);
        }

        private int GetMinJumps(int[] array)
        {
            if (array.Length == 1)
            {
                return 0;
            }

            var valueIndexTable = new Dictionary<int, List<int>>();
            
            for (int i = 1; i < array.Length; i++)
            {
                if (!valueIndexTable.ContainsKey(array[i]))
                {
                    valueIndexTable.Add(array[i], new List<int>());
                }

                valueIndexTable[array[i]].Add(i);
            }

            var queue = new Queue<(int value, int index, int steps)>();
            queue.Enqueue((array[0], 0, 0));
            var result = int.MaxValue;
            var visited = new bool[array.Length];
            visited[0] = true;

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                if (top.index == array.Length - 1)
                {
                    result = top.steps;
                    break;
                }

                EnqueueNeighbors(top, array, queue, visited);
                EnqueueSameValues(top, array, queue, valueIndexTable, visited);
            }

            return result;
        }

        private void EnqueueSameValues((int value, int index, int steps) top, int[] array, Queue<(int value, int index, int steps)> queue, Dictionary<int, List<int>> valueIndexTable, bool[] visited)
        {
            if (valueIndexTable.ContainsKey(array[top.index]))
            {
                foreach (var index in valueIndexTable[array[top.index]])
                {
                    queue.Enqueue((array[index], index, top.steps + 1));
                    visited[index] = true;
                }
                
                valueIndexTable.Remove(array[top.index]);
            }
        }

        private void EnqueueNeighbors((int value, int index, int steps) top, int[] array, Queue<(int value, int index, int steps)> queue, bool[] visited)
        {
            if (array[top.index] != array[top.index + 1] && !visited[top.index + 1])
            {
                queue.Enqueue((array[top.index + 1], top.index + 1, top.steps + 1));
                visited[top.index + 1] = true;
            }

            if (top.index != 0 && array[top.index] != array[top.index - 1] && !visited[top.index - 1])
            {
                queue.Enqueue((array[top.index - 1], top.index - 1, top.steps + 1));
                visited[top.index - 1] = true;
            }
        }
    }
}
