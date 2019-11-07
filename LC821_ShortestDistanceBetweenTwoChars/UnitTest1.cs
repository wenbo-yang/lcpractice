using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC821_ShortestDistanceBetweenTwoChars
{
    [TestClass]
    public class ShortestDistanceBetweenTwoCharsTests
    {
        [TestMethod]
        public void GivenArray_FindShortestDistance_ShouldReturnTheShortestDistance()
        {
            var input = new char[] { 'X', 'O', 'O', 'X', 'O', 'Y' };

            var result = FindShortestDistance(input);

            Assert.IsTrue(result == 2);
        }

        private int FindShortestDistance(char[] input)
        {
            // param validation
            var result = -1;

            var lastX = -1;
            var lastY = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'X')
                {
                    if (lastY != -1)
                    {
                        result = result == -1 ? Math.Abs(i - lastY) : Math.Min(result, Math.Abs(i - lastY));
                    }

                    lastX = i;
                }
                else if (input[i] == 'Y')
                {
                    if (lastX != -1)
                    {
                        result = result == -1 ? Math.Abs(i - lastX) : Math.Min(result, Math.Abs(i - lastX));
                    }

                    lastY = i;
                }
            }

            return result;
        }

        private int FindShortestDistance2D(char[][] input)
        {
            // param validation
            var result = -1;

            var distX = GenerateXMatrix(input.Length, input[0].Length);
            var queue = GetAllX(input);

            while (queue.Count != 0)
            {
                var item = queue.Dequeue();
                distX[item.Item1][item.Item2] = item.Item3;
                var neighbors = GetNeighbors(item, input, distX);
                foreach (var neighbor in neighbors)
                {
                    queue.Enqueue(new Tuple<int, int, int>(neighbor.Item1, neighbor.Item2, item.Item3 + 1));
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[i][j] == 'Y')
                    {
                        result = result == -1 ? distX[i][j] : Math.Min(result, distX[i][j]);
                    }
                }
            }

            return result;
        }

        private List<Tuple<int, int>> GetNeighbors(Tuple<int, int, int> item, char[][] input, int[][] xMat)
        {
            var result = new List<Tuple<int, int>>();
            var row = item.Item1;
            var col = item.Item2;

            if (CanMove(row - 1, col, xMat))
            {
                result.Add(new Tuple<int, int>(row - 1, col));
            }

            if (CanMove(row + 1, col, xMat))
            {
                result.Add(new Tuple<int, int>(row + 1, col));
            }

            if (CanMove(row, col - 1, xMat))
            {
                result.Add(new Tuple<int, int>(row, col - 1));
            }

            if (CanMove(row, col + 1, xMat))
            {
                result.Add(new Tuple<int, int>(row, col + 1));
            }

            return result;
        }

        private bool CanMove(int row, int col, int[][] xMat)
        {
            return row >= 0 && col >= 0 && row < xMat.Length && col < xMat[0].Length && xMat[row][col] == -1;
        }

        private Queue<Tuple<int, int, int>> GetAllX(char[][] input)
        {
            var current = 0;
            var result = new Queue<Tuple<int, int, int>>();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[i][j] == 'X')
                    {
                        result.Enqueue(new Tuple<int, int, int>(i, j, current));
                    }
                }
            }

            return result;
        }

        private int[][] GenerateXMatrix(int row, int col)
        {
            var result = new int[row][];

            for (int i = 0; i < row; i++)
            {
                result[i] = new int[col];
                for (int j = 0; j < col; j++)
                {
                    result[i][j] = -1;
                }
            }


            return result;
        }
    }
}
