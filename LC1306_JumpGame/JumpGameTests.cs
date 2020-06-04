using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1306_JumpGame
{
    [TestClass]
    public class JumpGameTests
    {
        [TestMethod]
        public void GivenArray_CanReach_ShouldReturnCurrectAnswer()
        {
            var arr = new int[] { 4, 2, 3, 0, 3, 1, 2}; var start = 5;
            var result = CanReach(arr, start);

            Assert.IsTrue(result);
        }

        private bool CanReach(int[] arr, int start)
        {
            var visited = new bool[arr.Length];
            var queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                if (arr[top] == 0)
                {
                    return true;
                }

                visited[top] = true;

                var right = top + arr[top];
                var left = top - arr[top];

                if (right < arr.Length && !visited[right]) queue.Enqueue(right);
                if (left >= 0 && !visited[left]) queue.Enqueue(left);
            }

            return false;
        }
    }
}
