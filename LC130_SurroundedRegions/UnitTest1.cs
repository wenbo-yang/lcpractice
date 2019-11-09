using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC130_SurroundedRegions
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given2DMatrix_FlipSurroundedRegion_ShouldReturnUpdatedMatrix()
        {
            var input = new char[][] { new char[] { 'x', 'x', 'x', 'x'},
                                       new char[] { 'x', 'o', 'o', 'x'},
                                       new char[] { 'x', 'x', 'o', 'x'},
                                       new char[] { 'x', 'o', 'x', 'x'} };

            var result = FlipSurroundedRegion(input);

            Assert.IsTrue(result[0].SequenceEqual(new char[] { 'x', 'x', 'x', 'x' }));
            Assert.IsTrue(result[1].SequenceEqual(new char[] { 'x', 'x', 'x', 'x' }));
            Assert.IsTrue(result[2].SequenceEqual(new char[] { 'x', 'x', 'x', 'x' }));
            Assert.IsTrue(result[3].SequenceEqual(new char[] { 'x', 'o', 'x', 'x' }));
        }

        private char[][] FlipSurroundedRegion(char[][] input)
        {
            var row = input.Length;
            var col = input[0].Length;

            var visited = GenerateVisited(row, col);

            var start = new Tuple<int, int>(1, 1);

            while (start.Item1 > -1 && start.Item2 > -1)
            {
                if (!FindStartO(input, visited, ref start))
                {
                    break;
                }

                var backTrace = new List<Tuple<int, int>>();
                var result = MapRegion(input, start.Item1, start.Item2, visited, backTrace);

                if (result)
                {
                    foreach (var coor in backTrace)
                    {
                        input[coor.Item1][coor.Item2] = 'x';
                    }
                }

                backTrace.Clear();
            }

            return input;
        }

        private bool MapRegion(char[][] input, int row, int col, bool[][] visited, List<Tuple<int, int>> backTrace)
        {
            if (input[row][col] == 'o' && (row == 0 || col == 0 || row == input.Length - 1 || col == input[0].Length - 1))
            {
                return false;
            }

            if (input[row][col] == 'x' || visited[row][col])
            {
                return true;
            }
            
            visited[row][col] = true;
            backTrace.Add(new Tuple<int, int>(row, col));

            var result = MapRegion(input, row - 1, col, visited, backTrace);
            result &= MapRegion(input, row + 1, col, visited, backTrace);
            result &= MapRegion(input, row, col - 1, visited, backTrace);
            result &= MapRegion(input, row, col + 1, visited, backTrace);

            return result;
        }

        private bool[][] GenerateVisited(int row, int col)
        {
            var visited = new bool[row][];
            for (int i = 0; i < col; i++)
            {
                visited[i] = new bool[col];
            }

            return visited;
        }

        private bool FindStartO(char[][] input, bool[][] visited, ref Tuple<int, int> start)
        {
            for (int i = start.Item1; i < input.Length - 1; i++)
            {
                for (int j = start.Item2; j < input[0].Length -1 ; j++)
                {
                    if (input[i][j] == 'o' && !visited[i][j])
                    {
                        start= new Tuple<int, int>(i, j);
                        return true;
                    }
                }
            }

            start = new Tuple<int, int>(-1, -1);
            return false;
        }

    }
}
