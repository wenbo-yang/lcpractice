using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC361_BombGuy
{
    [TestClass]
    public class BombGuyTests
    {
        // given a grid with chars 'W' and 'E' find coordinate where you can kill max 'E'
        // generate two dynamic function and back fill row and col
        
        [TestMethod]
        public void GivenMatrix_FindBestPlace_ShouldReturnMaxNumberOfEnemyKilled()
        {
            var grid = new char[][] { new char[] { '0', 'E', '0', '0' },
                                      new char[] { 'E', '0', 'E', 'E' },
                                      new char[] { '0', 'E', 'W', '0' },
                                      new char[] { '0', 'E', '0', '0' },
                                      new char[] { '0', 'E', '0', '0' }};

            var result = FindBestPlace(grid);

            Assert.IsTrue(result == 7);
        }

        private int FindBestPlace(char[][] grid)
        {
            // param validation

            var row = grid.Length;
            var col = grid[0].Length;

            var rowEnemyNum = InitializeDF(row, col);
            var colEnemyNum = InitializeDF(row, col);

            GenerateDF(rowEnemyNum, colEnemyNum, grid, row, col);

            return GetMaxPoints(rowEnemyNum, colEnemyNum, row, col);
        }

        private int GetMaxPoints(int[][] rowEnemyNum, int[][] colEnemyNum, int row, int col)
        {
            int max = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    max = Math.Max(rowEnemyNum[i][j] + colEnemyNum[i][j], max);
                }
            }

            return max;
        }

        private void GenerateDF(int[][] rowEnemyNum, int[][] colEnemyNum, char[][] grid, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    var gridValue = grid[i][j];

                    if (gridValue == 'W')
                    {
                        rowEnemyNum[i][j] = 0;
                        colEnemyNum[i][j] = 0;

                        if (i != 0) BackFillCol(colEnemyNum, grid, i - 1, j);
                        BackFillRow(rowEnemyNum, grid, i, j - 1);
                    }
                    else if (gridValue == '0')
                    {
                        rowEnemyNum[i][j] = j == 0 ? 0 : rowEnemyNum[i][j - 1];
                        colEnemyNum[i][j] = i == 0 ? 0 : colEnemyNum[i - 1][j];
                    }
                    else if (gridValue == 'E')
                    {
                        rowEnemyNum[i][j] = j == 0 ? 1 : rowEnemyNum[i][j - 1] + 1 ;
                        colEnemyNum[i][j] = i == 0 ? 1 : colEnemyNum[i - 1][j] + 1;
                    }
                }
            }

            for (int k = 0; k < row; k++)
            {
                BackFillRow(rowEnemyNum, grid, k, col - 1);
            }

            for (int k = 0; k < col; k++)
            {
                BackFillCol(colEnemyNum, grid, row - 1, k);
            }
        }

        private void BackFillRow(int[][] rowEnemyNum, char[][] grid, int row, int col)
        {
            for (int i = col; i >= 0; i--)
            {
                if (grid[row][i] == 'W')
                {
                    break;
                }

                rowEnemyNum[row][i] = rowEnemyNum[row][col];
            }
        }

        private void BackFillCol(int[][] colEnemyNum, char[][] grid, int row, int col)
        {
            for (int i = row; i >= 0; i--)
            {
                if (grid[i][col] == 'W')
                {
                    break;
                }

                colEnemyNum[i][col] = colEnemyNum[row][col];
            }
        }

        private int[][] InitializeDF(int row, int col)
        {
            var result = new int[row][];
            for (int i = 0; i < row ; i++)
            {
                result[i] = new int[col];
            }

            return result;
        }
    }
}
