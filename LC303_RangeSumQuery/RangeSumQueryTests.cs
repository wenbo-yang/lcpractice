using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC303_RangeSumQuery
{

    // 304 is also here
    [TestClass]
    public class RangeSumQueryTests
    {
        [TestMethod]
        public void GivenRangeAndQuery_RangeSum_ShouldCalculateTheSum()
        {
            var input = new int[] { -2, 0, 3, -5, 2, -1};

            var rangeSumQuery = new RangeSumQuery(input).Build();

            Assert.IsTrue(rangeSumQuery.RangeQuery(0, 2) == 1);
            Assert.IsTrue(rangeSumQuery.RangeQuery(2, 5) == -1);
            Assert.IsTrue(rangeSumQuery.RangeQuery(0, 5) == -3);
        }

        [TestMethod]
        public void GivenRangeAndQueryIn2D_RangeSum_ShouldCalculateTheSum()
        {
            var input = new int[][] {   new int[] { 3, 0, 1, 4, 2},
                                        new int[] { 5, 6, 3, 2, 1},
                                        new int[] { 1, 2, 0, 1, 5},
                                        new int[] { 4, 1, 0, 1, 7},
                                        new int[] { 1, 0, 3, 0, 5},};

            var rangeSumQuery = new RangeSumQuery2D(input).Build();

            Assert.IsTrue(rangeSumQuery.RangeQuery(2, 1, 4, 3) == 8);
            Assert.IsTrue(rangeSumQuery.RangeQuery(1, 1, 2, 2) == 11);
            Assert.IsTrue(rangeSumQuery.RangeQuery(1, 2, 2, 4) == 12);
        }


        public class RangeSumQuery
        {
            private int[] _input;
            private int[] _sum;
            public RangeSumQuery(int[] input)
            {
                _input = input;
            }

            public RangeSumQuery Build()
            {
                _sum = new int[_input.Length];

                _sum[0] = _input[0];
                for (int i = 1; i < _input.Length; i++)
                {
                    _sum[i] = _sum[i - 1] + _input[i];
                }

                return this;
            }

            public int RangeQuery(int startIndex, int endIndex)
            {
                // param validation
                // throw exception on invalid args

                if (startIndex == 0)
                {
                    return _sum[endIndex];
                }

                return _sum[endIndex] - _sum[startIndex - 1];
            }
        }
    }

    public class RangeSumQuery2D
    {
        private int[][] _input;
        private int[][] _sum;

        public RangeSumQuery2D(int[][] input)
        {
            _input = input;
        }

        public RangeSumQuery2D Build()
        {
            _sum = InitializeSum(_input);

            var row = _input.Length;
            var col = _input[0].Length;
            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    _sum[i][j] = _sum[i - 1][j] + _sum[i][j - 1] - _sum[i - 1][j - 1] + _input[i][j];
                }
            }

            return this;
        }

        private int[][] InitializeSum(int[][] input)
        {
            var sum = new int[input.Length][];
            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = new int[input[0].Length];
            }

            sum[0][0] = input[0][0];

            for (int r = 1; r < input.Length; r++)
            {
                sum[r][0] = sum[r - 1][0] + input[r][0];
            }

            for (int c = 1; c < input[0].Length; c++)
            {
                sum[0][c] = sum[0][c - 1] + input[0][c];
            }

            return sum;
        }

        public int RangeQuery(int startRow, int startCol, int endRow, int endCol)
        {
            // param validation
            return GetRangeQuery(endRow, endCol) - GetRangeQuery(startRow - 1, endCol) - GetRangeQuery(endRow, startCol - 1) + GetRangeQuery(startRow - 1, startCol - 1); 
        }

        private int GetRangeQuery(int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return 0;
            }

            return _sum[row][col];
        }
    }
}
