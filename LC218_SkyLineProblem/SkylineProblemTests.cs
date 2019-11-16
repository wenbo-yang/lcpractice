using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC218_SkyLineProblem
{
    [TestClass]
    public class SkylineProblemTests
    {
        [TestMethod]
        public void GivenInputDimensionsLists_FindSkyline_ShouldReturnListOfSkylines()
        {
            var input = new int[][] { new int[] { 2, 9, 10 },
                                     new int[] { 3, 7, 15 },
                                     new int[] { 5, 12, 12},
                                     new int[] { 15, 20, 10 },
                                     new int[] { 19, 24, 8 }};

            var result = GetSkyline(input);

            Assert.IsTrue(result.SequenceEqual(new List<Tuple<int, int>> {
                new Tuple<int, int>(2, 10),
                new Tuple<int, int>(3, 15),
                new Tuple<int, int>(7, 12),
                new Tuple<int, int>(12, 0),
                new Tuple<int, int>(15, 10),
                new Tuple<int, int>(20, 8),
                new Tuple<int, int>(24, 0) }));
        }


        private List<Tuple<int, int>> GetSkyline(int[][] input)
        {
            var horizontalList = new List<Tuple<int, int, int>>();

            ParseIntoHorizontalList(input, horizontalList);

            var result = GenerateSkyline(input, horizontalList);
            result.Sort();
            return result;
        }

        private List<Tuple<int, int>> GenerateSkyline(int[][] input, List<Tuple<int, int, int>> horizontalList)
        {
            var result = new List<Tuple<int, int>>();

            horizontalList.Sort();
            var hasStarted = new bool[input.Length];
            var maxHeap = new MaxHeap<Tuple<int, int, bool>>();

            for (int i = 0; i < horizontalList.Count; i++)
            {
                var coord = horizontalList[i];
                if (hasStarted[coord.Item3])
                {
                    var target = new Tuple<int, int, bool>(coord.Item2, coord.Item3, true);
                    if (maxHeap.Contains(target))
                    {
                        // remove this from heap and log start //
                        maxHeap.Remove(target);
                        result.Add(new Tuple<int, int>(input[coord.Item3][0], input[coord.Item3][2]));
                    }
                    else
                    {
                        maxHeap.Remove(new Tuple<int, int, bool>(coord.Item2, coord.Item3, false));
                    }

                    // log end 
                    if (maxHeap.Count == 0)
                    {
                        result.Add(new Tuple<int, int>(coord.Item1, 0));
                    }
                    else if(coord.Item2 > maxHeap.Peek().Item1)
                    {
                        result.Add(new Tuple<int, int>(coord.Item1, maxHeap.Peek().Item1));
                    }
                }
                else
                {
                    if (maxHeap.Count == 0 || maxHeap.Peek().Item1 < coord.Item2)
                    {
                        maxHeap.Add(new Tuple<int, int, bool>(coord.Item2, coord.Item3, true));
                    }
                    else
                    {
                        maxHeap.Add(new Tuple<int, int, bool>(coord.Item2, coord.Item3, false));
                    }

                    hasStarted[coord.Item3] = true;
                }
            }

            return result;
        }

        private void ParseIntoHorizontalList(int[][] input, List<Tuple<int, int, int>> horizontalList)
        {
            for(int i = 0; i < input.Length; i++)
            {
                var start = new Tuple<int, int, int>(input[i][0], input[i][2], i);
                var end = new Tuple<int, int, int>(input[i][1], input[i][2], i);

                horizontalList.Add(start);
                horizontalList.Add(end);
            }
        }

    }
}
