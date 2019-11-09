using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC240_SearchA2DMatrix
{
    [TestClass]
    // FB find the left most 1 is here as well
    public class Search2DMatrixTest
    {
        [TestMethod]
        public void GivenValidNumberAndMatrix_SearchMatrix_ShouldReturnTrue()
        {
            var mat = new int[][] { new int [] { 1, 4, 7, 11, 15 },
                                    new int [] { 2, 5, 8, 12, 19 },
                                    new int [] { 3, 6, 9, 16, 22 },
                                    new int [] { 10, 13, 14, 17, 24 },
                                    new int [] { 18, 21, 23, 26, 30 }};

            var value = 5;
            var result = FindElementInMatrix(mat, value);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void GivenABinaryMatrix_FindLeftMostOne_ShouldReturnCorrectCoordinate()
        {
            var mat = new int[][] { new int [] { 0, 0, 0, 1 },
                                    new int [] { 0, 0, 1, 1 },
                                    new int [] { 0, 1, 1, 1 },
                                    new int [] { 0, 0, 0, 0 }};

            var coor = FindLeftMostOne(mat);

            Assert.IsTrue(coor.Item1 == 2);
            Assert.IsTrue(coor.Item2 == 1);
        }

        private Tuple<int, int> FindLeftMostOne(int[][] mat)
        {
            var targetRow = FindRow(mat);
            if (targetRow == -1)
            {
                return new Tuple<int, int>(-1, -1);
            }

            var targetCol = FindCol(mat, targetRow);
 
            return new Tuple<int, int>(targetRow, targetCol);
        }

        private int FindCol(int[][] mat, int targetRow)
        {
            if (mat[targetRow][0] == 1)
            {
                return 0;
            }

            var start = 1;
            var end = mat[0].Length - 1;

            while (start <= end)
            {
                var pivot = (start + end) / 2;

                if (mat[targetRow][pivot] == 1 && mat[targetRow][pivot - 1] == 0)
                {
                    return pivot;
                }
                else if (mat[targetRow][pivot] == 0)
                {
                    start = pivot;
                }
                else
                {
                    end = pivot - 1;
                }
            }

            return end;
        }

        private int FindRow(int[][] mat)
        {
            var col = mat[0].Length - 1;
            var row = mat.Length - 1;
            if (mat[0][col] == 0)
            {
                return -1;
            }

            if (mat[row][col] == 1)
            {
                return row;
            }

            var start = 0;
            var end = col - 1;

            while (start <= end)
            {
                var pivot = (start + end) / 2;

                if (mat[pivot][col] == 1 && mat[pivot + 1][col] == 0)
                {
                    return pivot;
                }
                else if (mat[pivot][col] == 0)
                {
                    end = pivot;
                }
                else
                {
                    start = pivot + 1;
                }    
            }

            return start;
        }

        [TestMethod]
        public void Test()
        {
            var mat = new int[][] { new int [] { 1, 4, 7, 11, 15 },
                                    new int [] { 2, 5, 8, 12, 19 },
                                    new int [] { 3, 6, 9, 16, 22 },
                                    new int [] { 10, 13, 14, 17, 24 },
                                    new int [] { 18, 21, 23, 26, 30 }};

            var value = 5;

            var row = FindPotentialRow(mat, 5);
            var col = FindPotentialCol(mat, 5, row);

        }

        private bool FindElementInMatrix(int[][] mat, int value)
        {
            var row = mat.Length; var col = mat[0].Length;
            if (mat[0][0] > value || mat[row - 1][col - 1] < value)
            {
                return false;
            }

            var targetRow = FindPotentialRow(mat, value);
            var targetCol = FindPotentialCol(mat, value, targetRow);

            var found = FindActualValue(mat, value, targetRow, targetCol);

            return found;
        }

        private bool FindActualValue(int[][] mat, int value, int targetRow, int targetCol)
        {
            var start = 0;
            var end = targetRow;
            while (start <= end)
            {
                var pivot = (start + end) / 2;

                if (mat[pivot][targetCol] == value)
                {
                    return true; ;
                }
                if (mat[pivot][targetCol] > value)
                {
                    end = pivot - 1;
                }
                else if (mat[pivot][targetCol] < value)
                {
                    start = pivot + 1;
                }
            }

            return false;
        }

        // find col in row that is >= value and col - 1 < 
        private int FindPotentialCol(int[][] mat, int value, int targetRow) 
        {
            if (mat[targetRow][0] == value)
            {
                return 0;
            }

            var start = 1;
            var end = mat[0].Length - 1;

            while (start <= end)
            {
                var pivot = (start + end) / 2;

                if (mat[targetRow][pivot] >= value)
                {
                    if (mat[targetRow][pivot - 1] >= value)
                    {
                        end = pivot - 1;
                    }
                    else
                    {
                        return pivot;
                    }
                }
                else
                {
                    start = pivot;
                }
            }

            return end;

        }

        private int FindPotentialRow(int[][] mat, int value)
        {
            var start = 0;
            var end = mat.Length - 1;

            if (mat[end][0] <= value)
            {
                return end;
            }

            end--;

            while (start <= end)
            {
                var pivot = (start + end) / 2;
                if (mat[pivot][0] <= value)
                {
                    if (mat[pivot + 1][0] > value)
                    {
                        return pivot;
                    }

                    start = pivot + 1;
                }
                else
                {
                    end = pivot;
                }
            }

            return start;
        }
    }
}
