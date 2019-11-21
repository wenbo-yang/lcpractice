using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC353_SnakeGame
{
    [TestClass]
    public class SnakeGameTests
    {
        [TestMethod]
        public void GivenGridAndFoodCoordinateAndMoves_Move_ShouldUpdateBoard()
        {
        }

        public class Snake
        {
            private int[][] _grid;
            private LinkedList<Tuple<int, int>> _snake = new LinkedList<Tuple<int, int>>();

            public Snake(int[][] grid)
            {
                _grid = grid;
            }

            public void Build()
            {
                _snake.AddLast(new Tuple<int, int>(0, 0));
                _grid[0][0] = 1;
            }

            public bool Move(char direction)
            {
                var result = false;
                var head = _snake.First;
                var row = head.Value.Item1;
                var col = head.Value.Item2;
                switch (direction)
                {
                    case 'U':
                        if (CanMoveTo(row - 1, col))
                        {
                            MoveTo(row - 1, col);
                            result = true;
                        }
                        break;
                    case 'D':
                        if (CanMoveTo(row + 1, col))
                        {
                            MoveTo(row + 1, col);
                            result = true;
                        }
                        break;

                    case 'L':
                        if (CanMoveTo(row, col - 1))
                        {
                            MoveTo(row, col - 1);
                            result = true;
                        }
                        break;
                    case 'R':
                        if (CanMoveTo(row, col + 1))
                        {
                            MoveTo(row, col + 1);
                            result = true;
                        }
     
                        break;
                    default:
                        throw new ArgumentException();
                }

                return result;
            }

            private void MoveTo(int row, int col)
            {
                if (_grid[row][col] == -1)
                {
                    GrowSnake(row, col);
                }

                MoveSnake(row, col);
            }

            private void GrowSnake(int row, int col)
            {
                _snake.AddFirst(new Tuple<int, int>(row, col));
                _grid[row][col] = 1;
            }

            private void MoveSnake(int row, int col)
            {
                _snake.AddFirst(new Tuple<int, int>(row, col));
                var last =  _snake.Last;
                _snake.RemoveLast();
                _grid[row][col] = 1;
                _grid[last.Value.Item1][last.Value.Item2] = 0;
            }

            private bool CanMoveTo(int row,  int col)
            {
                return IsInBoundary(row, col) && _grid[row][col] != 1; 
            }

            public bool GiveFood(int row, int col)
            {
                if (CanGiveFood(row, col))
                {
                    _grid[row][col] = -1;
                    return true;
                }

                return false;
            }

            private bool CanGiveFood(int row, int col)
            {
                return IsInBoundary(row, col) && _grid[row][col] == 0;
            }
            

            private bool IsInBoundary(int row, int col)
            {
                return row >= 0 && col >= 0 && row < _grid.Length && col < _grid[0].Length;
            }


            public int Score { get; private set; }

        }

    }
}
