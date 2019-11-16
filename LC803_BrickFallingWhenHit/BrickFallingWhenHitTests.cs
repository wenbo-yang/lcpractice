using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC803_BrickFallingWhenHit
{
    [TestClass]
    public class BrickFallingWhenHitTests
    {
        [TestMethod]
        public void GivenGridAndOneSetOfCoordinates_CountFallingBricks_ShouldReturnTotalNumberOfBricks()
        {
            var grid = new int[][] { new int[] { 1, 0, 0, 0},
                                     new int[] { 1, 1, 1, 0}};

            var targetCoords = new Tuple<int, int>[] { new Tuple<int, int>(1, 0) };

            var result = CountFallingBricks(grid, targetCoords);

            Assert.IsTrue(result.SequenceEqual(new int[] { 2 }));
        }

        [TestMethod]
        public void GivenGridAndTwoCoordinates_CountFallingBricks_ShouldReturnTotalNumberOfBricks()
        {
            var grid = new int[][] { new int[] { 1, 0, 0, 0},
                                     new int[] { 1, 1, 0, 0}};

            var targetCoords = new Tuple<int, int>[] { new Tuple<int, int>(1, 1), new Tuple<int, int>(1, 0) };

            var result = CountFallingBricks(grid, targetCoords);

            Assert.IsTrue(result.SequenceEqual(new int[] {0, 0}));
        }

        private int[] CountFallingBricks(int[][] grid, Tuple<int, int>[] targetCoords)
        {
            var result = new int[targetCoords.Length];

            for (int i = 0; i < targetCoords.Length; i++)
            {
                var row = targetCoords[i].Item1; var col = targetCoords[i].Item2;
                grid[row][col] = 0;
                var neighbors = GetNeighbors(grid, row, col);
                foreach (var neighbor in neighbors)
                {
                    var visited = new HashSet<Tuple<int, int>>();
                    CountFallingBricksDFSHelper(grid, visited, neighbor.Item1, neighbor.Item2, ref result[i]);
                }
            }

            return result;
        }

        private bool CountFallingBricksDFSHelper(int[][] grid, HashSet<Tuple<int, int>> visited, int currRow, int currCol, ref int result)
        {
            if (currRow == 0)
            {
                return true;
            }

            visited.Add(new Tuple<int, int>(currRow, currCol));

            var neighbors = GetNeighbors(grid, currRow, currCol);
            foreach (var neighbor in neighbors)
            {
                if(!visited.Contains(neighbor) && CountFallingBricksDFSHelper(grid, visited, neighbor.Item1, neighbor.Item2, ref result))
                {
                    return true;
                }
            }

            result++;
            return false;
        }

        private List<Tuple<int, int>> GetNeighbors(int[][] grid, int currRow, int currCol)
        {
            var result = new List<Tuple<int, int>>();

            if (CanMoveTo(currRow - 1, currCol, grid))
            {
                result.Add(new Tuple<int, int>(currRow - 1, currCol));
            }

            if (CanMoveTo(currRow + 1, currCol, grid))
            {
                result.Add(new Tuple<int, int>(currRow + 1, currCol));
            }

            if (CanMoveTo(currRow, currCol - 1, grid))
            {
                result.Add(new Tuple<int, int>(currRow, currCol - 1));
            }

            if (CanMoveTo(currRow, currCol + 1, grid))
            {
                result.Add(new Tuple<int, int>(currRow, currCol + 1));
            }

            return result;
        }

        private bool CanMoveTo(int row, int col, int[][] grid)
        {
            return row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length && grid[row][col] == 1;
        }
    }
}
