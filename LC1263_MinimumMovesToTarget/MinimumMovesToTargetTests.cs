using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1263_MinimumMovesToTarget
{
    [TestClass]
    public class MinimumMovesToTargetTests
    {
        [TestMethod]
        public void GivenGridWithTargetAndBox_GetMinimumPushes_ShouldReturnMinimumPushes()
        {
            var grid = new char[][] { new char[] { '#', '#', '#', '#', '#', '#' },
                                      new char[] { '#', 'T', '#', '#', '#', '#' },
                                      new char[] { '#', '.', '.', 'B', '.', '#' },
                                      new char[] { '#', '.', '#', '#', '.', '#' },
                                      new char[] { '#', '.', '.', '.', 'S', '#' },
                                      new char[] { '#', '#', '#', '#', '#', '#' }};

            var result = GetMinPushes(grid);

            Assert.IsTrue(result == 3);
        }

        private int GetMinPushes(char[][] grid)
        {
            var visited = GenerateVisited(grid);
            (int row, int col) target = (-1, -1);
            (int row, int col) start = (-1, -1);
            (int row, int col) person = (-1, -1);

            GetTargetStartAndPerson(grid, ref target, ref start, ref person);

            var queue = new Queue<(int row, int col, int parentRow, int parentCol, int length)>();
            
            queue.Enqueue((target.row, target.col, target.row, target.col, 0));

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                visited[top.row][top.col] = true;
                if (top.row == start.row && top.col == start.col)
                {
                    return top.length;
                }
                
                var neighbors = GetNeighbors(top.row, top.col, grid, visited);

                foreach (var neighbor in neighbors)
                {
                    var row = neighbor.row - (top.row - neighbor.row);
                    var col = neighbor.col - (top.col - neighbor.col);

                    if (CanGetTo(row, col, neighbor.row, neighbor.col, person.row, person.col, grid))
                    {
                        queue.Enqueue((neighbor.row, neighbor.col, top.row, top.col, top.length + 1));
                    }
                }
            }

            return -1;
        }

        private void GetTargetStartAndPerson(char[][] grid, ref (int row, int col) target, ref (int row, int col) start, ref (int row, int col) person)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 'T') target = (i, j);
                    if (grid[i][j] == 'B') start = (i, j);
                    if (grid[i][j] == 'S') person = (i, j);
                }
            }
        }

        private bool[][] GenerateVisited(char[][] grid)
        {
            var visited = new bool[grid.Length][];

            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = new bool[grid[0].Length]; 
            }

            return visited;
        }

        private List<(int row, int col)> GetNeighbors(int row, int col, char[][] grid, bool[][] visited)
        {
            var result = new List<(int row, int col)>();

            if (CanMoveTo(row - 1, col, grid, visited))
            {
                result.Add((row - 1, col));
            }
            if (CanMoveTo(row + 1, col, grid, visited))
            {
                result.Add((row + 1, col));
            }
            if (CanMoveTo(row, col - 1, grid, visited))
            {
                result.Add((row, col - 1));
            }
            if (CanMoveTo(row, col + 1, grid, visited))
            {
                result.Add((row, col + 1));
            }

            return result;
        }

        private bool CanMoveTo(int row, int col, char[][] grid, bool[][] visited)
        {
            return row >= 0 && col >= 0 && row < grid.Length && col < grid.Length && grid[row][col] != '#' && !visited[row][col];
        }

        private bool CanPushTo(int targetRow, int targetCol, int currentRow, int currentCol, char[][] grid)
        {
            var row = currentRow - (targetRow - currentRow);
            var col = currentCol - (targetCol - currentCol);

            return row >= 0 && col >= 0 && row < grid.Length && col < grid.Length && (grid[row][col] == 'T' || grid[row][col] == '.');
        }

        private bool CanGetTo(int startRow, int startCol, int boxRow, int boxCol, int endRow, int endCol, char[][] grid)
        {
            var visited = GenerateVisited(grid);

            var queue = new Queue<(int row, int col)>();

            queue.Enqueue((startRow, startCol));
            visited[boxRow][boxCol] = true;

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                if (top.row == endRow && top.col == endCol)
                {
                    return true;
                }

                visited[top.row][top.col] = true;
                var neighbors = GetNeighbors(top.row, top.col, grid, visited);

                foreach (var neighbor in neighbors)
                {
                    queue.Enqueue(neighbor);
                }
            }

            return false;
        }
    }
}
