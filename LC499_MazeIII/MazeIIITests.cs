using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC499_MazeIII
{
    [TestClass]
    public class MazeIIITests
    {
        [TestMethod]
        public void GivenMazeStartCannotReachEndCoor_GetShortestPath_ShouldReturnNothing()
        {
            var grid = new int[][] { new int[] { 0, 0, 0, 0, 0},
                                     new int[] { 1, 1, 0, 0, 1},
                                     new int[] { 0, 0, 0, 0, 0},
                                     new int[] { 0, 1, 0, 0, 1},
                                     new int[] { 0, 1, 0, 0, 0}};


            var pathList = GetShortestPath(grid, 4, 3, 3, 0);

            Assert.IsTrue(pathList.Count == 0);
        }

        [TestMethod]
        public void GivenMazeStartCanReachEndCoor_GetShortestPath_ShouldReturnNothing()
        {
            var grid = new int[][] { new int[] { 0, 0, 0, 0, 0},
                                     new int[] { 1, 1, 0, 0, 1},
                                     new int[] { 0, 0, 0, 0, 0},
                                     new int[] { 0, 1, 0, 0, 1},
                                     new int[] { 0, 1, 0, 0, 0}};


            var pathList = GetShortestPath(grid, 4, 3, 0, 1);

            Assert.IsTrue(pathList.Count == 2);
            Assert.IsTrue(pathList.Contains("lul") && pathList.Contains("ul"));
        }

        private List<string> GetShortestPath(int[][] grid, int startRow, int startCol, int endRow, int endCol)
        {
            var visited = new Dictionary<(int row, int col), int>();
            var result = new List<string>();

            GetShortestPathHelper(grid, (startRow, startCol, 0), new List<char>(), endRow, endCol, visited, result);

            return result;
        }

        private void GetShortestPathHelper(int[][] grid, (int row, int col, int distance) current, List<char> lineage, int endRow, int endCol, Dictionary<(int row, int col), int> visited, List<string> result)
        {
            if (!visited.ContainsKey((current.row, current.col)))
            {
                visited.Add((current.row, current.col), current.distance);
            }

            if (current.distance > visited[(current.row, current.col)])
            {
                return;
            }

            if (current.distance < visited[(current.row, current.col)])
            {
                visited[(current.row, current.col)] = current.distance;

                if (current.row == endRow && current.col == endCol)
                {
                    result.Clear();
                }
            }
            
            if (current.row == endRow && current.col == endCol)
            {
                result.Add(new string(lineage.ToArray()));
                return;
            }

            if (visited[(current.row, current.col)] < current.distance)
            {
                return;
            }

            var destination = GoUp(current, endRow, endCol, grid);
            if (destination.row != current.row)
            {
                lineage.Add('u');
                GetShortestPathHelper(grid, destination, lineage, endRow, endCol, visited, result);
                lineage.RemoveAt(lineage.Count - 1);
            }

            destination = GoDown(current, endRow, endCol, grid);
            if (destination.row != current.row)
            {
                lineage.Add('d');
                GetShortestPathHelper(grid, destination, lineage, endRow, endCol, visited, result);
                lineage.RemoveAt(lineage.Count - 1);
            }

            destination = GoLeft(current, endRow, endCol, grid);
            if (destination.col != current.col)
            {
                lineage.Add('l');
                GetShortestPathHelper(grid, destination, lineage, endRow, endCol, visited, result);
                lineage.RemoveAt(lineage.Count - 1);
            }

            destination = GoRight(current, endRow, endCol, grid);
            if (destination.col != current.col)
            {
                lineage.Add('r');
                GetShortestPathHelper(grid, destination, lineage, endRow, endCol, visited, result);
                lineage.RemoveAt(lineage.Count - 1);
            }
        }

        private (int row, int col, int distance) GoRight((int row, int col, int distance) current, int endRow, int endCol, int[][] grid)
        {
            var destination = current;
            while (CanGo(destination.row, destination.col + 1, grid))
            {
                destination.col++; destination.distance++;
                if (destination.row == endRow && destination.col == endCol)
                {
                    break;
                }
            }

            return destination;
        }

        private (int row, int col, int distance) GoLeft((int row, int col, int distance) current, int endRow, int endCol, int[][] grid)
        {
            var destination = current;
            while (CanGo(destination.row, destination.col - 1, grid))
            {
                destination.col--; destination.distance++;
                if (destination.row == endRow && destination.col == endCol)
                {
                    break;
                }
            }

            return destination;
        }

        private (int row, int col, int distance) GoDown((int row, int col, int distance) current, int endRow, int endCol, int[][] grid)
        {
            var destination = current;
            while (CanGo(destination.row + 1, destination.col, grid))
            {
                destination.row++; destination.distance++;
                if (destination.row == endRow && destination.col == endCol)
                {
                    break;
                }
            }

            return destination;
        }

        private (int row, int col, int distance) GoUp((int row, int col, int distance) current, int endRow, int endCol, int[][] grid)
        {
            var destination = current;
            while (CanGo(destination.row - 1, destination.col, grid))
            {
                destination.row--; destination.distance++;
                if (destination.row == endRow && destination.col == endCol)
                {
                    break;
                }
            }

            return destination;
        }

        private bool CanGo(int row, int col, int[][] grid)
        {
            return row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length && grid[row][col] != 1;
        }
    }
}
