using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1391_CheckToSeeIfThereIsAValidPath
{
    [TestClass]
    public class CheckToSeeIfThereIsAValidPathTests
    {
        [TestMethod]
        public void GivenGridAndRoadMap_HasValidPath_ShouldReturnCorrectAnswer()
        {
            var grid = new int[][] { new int[] { 2, 4, 3 }, new int[] { 6, 5, 2 } };
            var result = HasValidPath(grid);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenAnotherGridAndRoadMap_HasValidPath_ShouldReturnCorrectAnswer()
        {
            var grid = new int[][] { new int[] { 4, 1 }, new int[] { 6, 1 } };
            var result = HasValidPath(grid);

            Assert.IsTrue(result);
        }

        private bool HasValidPath(int[][] grid)
        {
            var visited = new HashSet<(int r, int c)>() { (0, 0) };

            (int r, int c) current = (0, 0);

            if (grid[current.r][current.c] == 4)
            {
                if (TryGoRight(ref current, grid, visited) && HasValidPathHelper(ref current, grid, visited))
                {
                    return true;
                }
                else
                {
                    visited = new HashSet<(int r, int c)>() { (0, 0) };
                    current = (0, 0);
                    return TryGoDown(ref current, grid, visited) && HasValidPathHelper(ref current, grid, visited);
                }
            }
            
            
            return HasValidPathHelper(ref current, grid, visited);
        }

        private bool HasValidPathHelper(ref (int r, int c) current, int[][] grid, HashSet<(int r, int c)> visited)
        {
            while (!(current.r == grid.Length - 1 && current.c == grid[0].Length - 1))
            {
                if (!TryMoveTo(ref current, grid, visited))
                {
                    return false;
                }
            }

            return true;
        }

        private bool TryMoveTo(ref (int r, int c) current, int[][] grid, HashSet<(int r, int c)> visited)
        {
            var currentValue = grid[current.r][current.c];

            switch (currentValue)
            {
                case 1:
                    if (TryGoLeft(ref current, grid, visited))
                    {
                        
                        return true;
                    }

                    if (TryGoRight(ref current, grid, visited))
                    {
                        return true;
                    }
                    
                    break;
                case 2:
                    if (TryGoUp(ref current, grid, visited))
                    {
                        return true;
                    }

                    if (TryGoDown(ref current, grid, visited))
                    {
                        return true;
                    }

                    break;

                case 3:
                    if (TryGoLeft(ref current, grid, visited))
                    {
                        return true;
                    }

                    if (TryGoDown(ref current, grid, visited))
                    {
                        return true;
                    }

                    break;

                case 4:
                    if (TryGoRight(ref current, grid, visited))
                    {
                        return true;
                    }

                    if (TryGoDown(ref current, grid, visited))
                    {
                        return true;
                    }
                    break;

                case 5:
                    if (TryGoLeft(ref current, grid, visited))
                    {
                        return true;
                    }

                    if (TryGoUp(ref current, grid, visited))
                    {
                        return true;
                    }
                    break;
                case 6:
                    if (TryGoRight(ref current, grid, visited))
                    {
                        return true;
                    }

                    if (TryGoUp(ref current, grid, visited))
                    {
                        return true;
                    }

                    break;
                default:
                    throw new Exception("invalid value");
            }

            return false;
        }

        private bool TryGoDown(ref (int r, int c) current, int[][] grid, HashSet<(int r, int c)> visited)
        {
            if (IsNeighbor(current.r + 1, current.c, grid, visited))
            {
                var neighborValue = grid[current.r + 1][current.c];
                if (neighborValue == 2 || neighborValue == 5 || neighborValue == 6)
                {
                    current = (current.r + 1, current.c);
                    visited.Add(current);
                    return true;

                }
            }

            return false;
        }

        private bool TryGoUp(ref (int r, int c) current, int[][] grid, HashSet<(int r, int c)> visited)
        {
            if (IsNeighbor(current.r - 1, current.c, grid, visited))
            {
                var neighborValue = grid[current.r - 1][current.c];
                if (neighborValue == 2 || neighborValue == 3 || neighborValue == 4)
                {
                    current = (current.r - 1, current.c);
                    visited.Add(current);
                    return true;

                }
            }

            return false;
        }

        private bool TryGoRight(ref (int r, int c) current, int[][] grid, HashSet<(int r, int c)> visited)
        {
            if (IsNeighbor(current.r, current.c + 1, grid, visited))
            {
                var neighborValue = grid[current.r][current.c + 1];
                if (neighborValue == 1 || neighborValue == 3 || neighborValue == 5)
                {
                    current = (current.r, current.c + 1);
                    visited.Add(current);
                    return true;

                }
            }

            return false;
        }

        private bool TryGoLeft(ref (int r, int c) current, int[][] grid, HashSet<(int r, int c)> visited)
        {
            if (IsNeighbor(current.r, current.c - 1, grid, visited))
            {
                var neighborValue = grid[current.r][current.c - 1];
                if (neighborValue == 1 || neighborValue == 4 || neighborValue == 6)
                {
                    current = (current.r, current.c - 1);
                    visited.Add(current);
                    return true;

                }
            }

            return false;
        }

        private bool IsNeighbor(int r, int c, int[][] grid, HashSet<(int r, int c)> visited)
        {
            return r >= 0 && c >= 0 && r < grid.Length && c < grid[0].Length && !visited.Contains((r, c));
        }
    }
}
