using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1057_CampusBikes
{
    [TestClass]
    public class CampusBikesTests
    {
        [TestMethod]
        public void GivenListOfCoordinates_MatchPersonToBikeHeapList_ShouldReturnListOfCorrectPairs()
        {
            var workers = new List<Tuple<int, int>> { new Tuple<int, int>(0, 0), new Tuple<int, int>(2, 1) };
            var bikes = new List<Tuple<int, int>> { new Tuple<int, int>(1, 2), new Tuple<int, int>(3, 3) };

            var result = MatchPersonToBikeHeapList(workers, bikes);

            Assert.IsTrue(result.SequenceEqual(new int[] { 0, 1}));
        }

        [TestMethod]
        public void GivenAnotherListOfCoordinates_MatchPersonToBikeHeapList_ShouldReturnListOfCorrectPairs()
        {
            var workers = new List<Tuple<int, int>> { new Tuple<int, int>(0, 0), new Tuple<int, int>(1, 1), new Tuple<int, int>(2, 0) };
            var bikes = new List<Tuple<int, int>> { new Tuple<int, int>(1, 0), new Tuple<int, int>(2, 2), new Tuple<int, int>(2, 1) };

            var result = MatchPersonToBikeHeapList(workers, bikes);

            Assert.IsTrue(result.SequenceEqual(new int[] { 0, 2, 1 }));
        }

        [TestMethod]
        public void GivenListOfCoordinates_MatchPersonToBikeOneHeap_ShouldReturnListOfCorrectPairs()
        {
            var workers = new List<Tuple<int, int>> { new Tuple<int, int>(0, 0), new Tuple<int, int>(2, 1) };
            var bikes = new List<Tuple<int, int>> { new Tuple<int, int>(1, 2), new Tuple<int, int>(3, 3) };

            var result = MatchPersonToBikeOneHeap(workers, bikes);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 1, 0 }));
        }

        private int[] MatchPersonToBikeOneHeap(List<Tuple<int, int>> workers, List<Tuple<int, int>> bikes)
        {
            var heap = new MinHeap<Tuple<int, int, int>>();
            var result = new int[workers.Count];
            for (int i = 0; i < workers.Count; i++)
            {
                result[i] = -1;
                for (int j = 0; j < bikes.Count; j++)
                {
                    var distance = Math.Abs(workers[i].Item1 - bikes[j].Item1) + Math.Abs(workers[i].Item2 - bikes[j].Item2);

                    heap.Add(new Tuple<int, int, int>(distance, i, j));
                }
            }

            var bikeAssigned = new HashSet<int>();

            while (heap.Count != 0)
            {
                var top = heap.Pop();

                if (result[top.Item2] == -1 && !bikeAssigned.Contains(top.Item3))
                {
                    result[top.Item2] = top.Item3;
                    bikeAssigned.Add(top.Item3);
                }
            }

            return result;
        }

        private int[] MatchPersonToBikeHeapList(List<Tuple<int, int>> workers, List<Tuple<int, int>> bikes)
        {
            var heapList = new List<MinHeap<Tuple<int, int>>>();
            var result = new int[workers.Count];
            for (int i = 0; i < workers.Count; i++)
            {
                heapList.Add(new MinHeap<Tuple<int, int>>());
                result[i] = -1;
                for (int j = 0; j < bikes.Count; j++)
                {
                    var distance = Math.Abs(workers[i].Item1 - bikes[j].Item1) + Math.Abs(workers[i].Item2 - bikes[j].Item2);

                    heapList[i].Add(new Tuple<int, int>(distance, j));
                }
            }

            var carAssigned = new HashSet<int>();

            for(int i = 0; i < result.Length; i++)
            {
                while (heapList[i].Count != 0)
                {
                    var top = heapList[i].Pop();

                    if (!carAssigned.Contains(top.Item2))
                    {
                        result[i] = top.Item2;
                        carAssigned.Add(top.Item2);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
