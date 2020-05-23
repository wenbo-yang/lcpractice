using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC973_KClosestPointToOrigin
{
    [TestClass]
    public class KClosestPointToOriginTests
    {
        [TestMethod]
        public void GivenListOfPoints_GetKClosestPoints_ShouldReturnCorrectPoints()
        {
            var points = new int[][] { new int[] {3, 3}, new int[] {5, -1}, new int[] {-2, 4}};
            var k = 2;

            var result = GetKClosesPoints(points, k);

            Assert.IsTrue(result.Length == 2);
            Assert.IsTrue(result[0].SequenceEqual(new int[] { 3, 3 }) || result[1].SequenceEqual(new int[] { 3, 3 }));
            Assert.IsTrue(result[0].SequenceEqual(new int[] { -2, 4 }) || result[1].SequenceEqual(new int[] { -2, 4 }));
        }

        [TestMethod]
        public void GivenAnotherListOfPoints_GetKClosestPoints_ShouldReturnCorrectPoints()
        {
            var points = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } };
            var k = 2;

            var result = GetKClosesPoints(points, k);

            Assert.IsTrue(result.Length == 2);
            Assert.IsTrue(result[0].SequenceEqual(new int[] { 1, 0 }) || result[1].SequenceEqual(new int[] { 1, 0 }));
            Assert.IsTrue(result[0].SequenceEqual(new int[] { 0, 1 }) || result[1].SequenceEqual(new int[] { 0, 1 }));
        }

        [TestMethod]
        public void GivenThirdListOfPoints_GetKClosestPoints_ShouldReturnCorrectPoints()
        {
            var points = new int[][] { new int[] { 2, 2 }, new int[] { 2, 2 }, new int[] { 2, 2}, new int[] { 1, 1 } };
            var k = 2;

            var result = GetKClosesPoints(points, k);

            Assert.IsTrue(result.Length == 2);
            Assert.IsTrue(result[0].SequenceEqual(new int[] { 1, 1 }) || result[0].SequenceEqual(new int[] { 2, 2 }));
        }

        private int[][] GetKClosesPoints(int[][] points, int k)
        {
            var maxHeap = new MaxHeap<(int value, int x, int y)>();
            foreach (var point in points)
            {
                var distanceSqr = point[0] * point[0] + point[1] * point[1];

                if (maxHeap.Count == k)
                {
                    if (distanceSqr < maxHeap.Peek().value)
                    {
                        maxHeap.Pop();
                    }
                    else
                    {
                        continue;
                    }

                }

                maxHeap.Add((distanceSqr, point[0], point[1]));
            }

            var result = new List<int[]>();
            while (maxHeap.Count != 0)
            {
                var point = maxHeap.Pop();
                result.Add(new int[] { point.x, point.y});
            }

            return result.ToArray();
        }

        private int[][] GetKClosesPointsSortedDictionary(int[][] points, int k)
        {
            var maxHeap = new SortedDictionary<int, List<int[]>>();
            var count = 0;
            foreach (var point in points)
            { 
                var distanceSqr = point[0] * point[0] + point[1] * point[1];
                
                if (count == k)
                {
                    if (distanceSqr < maxHeap.Last().Key)
                    {
                        maxHeap.Last().Value.RemoveAt(maxHeap.Last().Value.Count - 1);
                        if (maxHeap.Last().Value.Count == 0)
                        {
                            maxHeap.Remove(maxHeap.Last().Key);
                        }
                        count--;
                    }
                    else
                    {
                        continue;
                    }

                }

                if (!maxHeap.ContainsKey(distanceSqr))
                {
                    maxHeap.Add(distanceSqr, new List<int[]>());
                }

                maxHeap[distanceSqr].Add(point);
                count++;
            }

            var result = new List<int[]>();
            while (maxHeap.Count != 0)
            {
                while (maxHeap.Last().Value.Count != 0)
                {
                    result.Add(maxHeap.Last().Value.Last());
                    maxHeap.Last().Value.RemoveAt(maxHeap.Last().Value.Count - 1);
                }

                maxHeap.Remove(maxHeap.Last().Key);
            }

            return result.ToArray();
        }
    }
}
