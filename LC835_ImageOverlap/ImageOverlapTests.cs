using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC835_ImageOverlap
{
    [TestClass]
    public class ImageOverlapTests
    {
        [TestMethod]
        public void GivenTwoImages_FindMaxMatchingValue_ShouldReturnCorrectMapping()
        {
            var inputA = new int[][] {  new int[] { 1, 1, 0},
                                        new int[] { 0, 1, 0},
                                        new int[] { 0, 1, 0}};

            var inputB = new int[][] {  new int[] { 0, 0, 1},
                                        new int[] { 0, 1, 1},
                                        new int[] { 0, 0, 1}};


            var result = MaxOverlappingByTranslation(inputA, inputB);

            Assert.IsTrue(result == 3);
        }

        private int MaxOverlappingByTranslation(int[][] inputA, int[][] inputB)
        {
            var aCoorSet = GetBinaryCoordinates(inputA);
            var bCoorSet = GetBinaryCoordinates(inputB);
            var numRow = inputA.Length;
            var numCol = inputA[0].Length;

            var boundingOffSet = new Tuple<int, int, int , int>((numRow - 1) * -1, (numCol - 1) * -1, (numRow - 1), (numCol -1));
            
            var result = int.MinValue;

            for (int i = boundingOffSet.Item1; i < boundingOffSet.Item3; i++)
            {
                for (int j = boundingOffSet.Item2; j < boundingOffSet.Item4; j++)
                {
                    var aWithOffset = GenerateOffAListWithOffset(aCoorSet, i, j, numRow, numCol);
                    result = Math.Max(result, FindOverlapping(aWithOffset, bCoorSet));
                }
            }

            return result;
        }

        private HashSet<Tuple<int, int>> GenerateOffAListWithOffset(HashSet<Tuple<int, int>> sourceSet , int offsetRow, int offsetCol, int numRow, int numCol)
        {
            var setWithOffSet = new HashSet<Tuple<int, int>>();
            foreach (var coor in sourceSet)
            {
                var targetRow = coor.Item1 + offsetRow;
                var targetCol = coor.Item2 + offsetCol;

                if (targetRow >= 0 && targetCol >= 0 && targetRow < numRow && targetCol < numCol)
                {
                    setWithOffSet.Add(new Tuple<int, int>(targetRow, targetCol));
                }
            }

            return setWithOffSet;
        }

        private int FindOverlapping(HashSet<Tuple<int, int>> aWithOffset, HashSet<Tuple<int, int>> bCoorSet)
        {
            var matchingCount = 0;
            var smaller = aWithOffset.Count < bCoorSet.Count ? aWithOffset : bCoorSet;
            var bigger = aWithOffset.Count >= bCoorSet.Count ? aWithOffset : bCoorSet;

            foreach (var coor in smaller)
            {
                if (bigger.Contains(coor))
                {
                    matchingCount++;
                }
            }
            return matchingCount;
        }

        private HashSet<Tuple<int, int>> GetBinaryCoordinates(int[][] input)
        {
            var result = new HashSet<Tuple<int, int>>();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    if (input[i][j] == 0)
                    {
                        result.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            return result;
        }
    }
}
