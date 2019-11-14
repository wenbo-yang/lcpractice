using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC59_GenerateSpiralMatrix
{
    [TestClass]
    public class SpiralMatrixTests
    {
        [TestMethod]
        public void GivenInputSize_GenerateSpiralMatrix_ShouldGenerateSpiralMatrix()
        {
            var input = 3;

            var result = GenerateSpiralMatrix(input);

            Assert.IsTrue(result[0].SequenceEqual(new int[] { 1, 2, 3 }));
            Assert.IsTrue(result[1].SequenceEqual(new int[] { 8, 9, 4 }));
            Assert.IsTrue(result[2].SequenceEqual(new int[] { 7, 6, 5 }));
        }

        private int[][] GenerateSpiralMatrix(int input)
        {
            var total = input * input;
            var mat = GenerateBase(input);
            var current = 1;

            var direction = Direction.Start;
            var placeAt = Next(0, 0, mat, ref direction);

            do
            {
                mat[placeAt.Item1][placeAt.Item2] = current;
                placeAt = Next(placeAt.Item1, placeAt.Item2, mat, ref direction);
                current++;
            }
            while (current < total + 1);

            return mat;

        }

        private int[][] GenerateBase(int input)
        {
            var result = new int[input][];

            for (int i = 0; i < input; i++)
            {
                result[i] = new int[input];
            }
            return result;
        }

        private Tuple<int, int> Next(int row, int col, int[][] mat, ref Direction direction)
        {
            Tuple<int, int> result = null;
            switch (direction)
            {
                case Direction.Right:
                    if (CanGo(row, col + 1, mat))
                    {
                        result = new Tuple<int, int>(row, col + 1);
                    }
                    else
                    {
                        direction = Direction.Down;
                        result = new Tuple<int, int>(row + 1, col);
                    }
                    break;

                case Direction.Down:
                    if (CanGo(row + 1, col, mat))
                    {
                        result = new Tuple<int, int>(row + 1, col);
                    }
                    else
                    {
                        direction = Direction.Left;
                        result = new Tuple<int, int>(row, col - 1);
                    }
                    break;

                case Direction.Left:
                    if (CanGo(row, col - 1, mat))
                    {
                        result = new Tuple<int, int>(row, col - 1);
                    }
                    else
                    {
                        direction = Direction.Up;
                        result = new Tuple<int, int>(row - 1, col);
                    }
                    break;

                case Direction.Up:
                    if (CanGo(row - 1, col, mat))
                    {
                        result = new Tuple<int, int>(row - 1, col);
                    }
                    else
                    {
                        direction = Direction.Right;
                        result = new Tuple<int, int>(row, col + 1);
                    }
                    break;

                default:
                    direction = Direction.Right;
                    result =  new Tuple<int, int>(0, 0);
                    break;

            }

            return result;

        }

        private bool CanGo(int row, int col, int[][] mat)
        {
            return row >= 0 && col >= 0 && row < mat.Length && col < mat[0].Length && mat[row][col] == 0;
        }

       
        public enum Direction
        {
           Right = 0,
           Down,
           Left,
           Up,
           Start,
        }
    }
}
