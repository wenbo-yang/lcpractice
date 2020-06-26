using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC37_SudokuSolver
{
    [TestClass]
    public class SudokuSolverTests
    {
        [TestMethod]
        public void GivenSudoku_SolveSudoku_ShouldReturnCorrectAnswer()
        {
            var board = new char[][] {
                        new char[] { '5','3','.','.','7','.','.','.','.' },
                        new char[] { '6','.','.','1','9','5','.','.','.' },
                        new char[] { '.','9','8','.','.','.','.','6','.' },
                        new char[] { '8','.','.','.','6','.','.','.','3' },
                        new char[] { '4','.','.','8','.','3','.','.','1' },
                        new char[] { '7','.','.','.','2','.','.','.','6' },
                        new char[] { '.','6','.','.','.','.','2','8','.' },
                        new char[] { '.','.','.','4','1','9','.','.','5' },
                        new char[] { '.','.','.','.','8','.','.','7','9' }};

            SolveSudoku(board);

            foreach (var row in board)
            {
                Assert.IsTrue(row.Contains('1') && row.Contains('2') && row.Contains('3') && row.Contains('4') && row.Contains('5') && row.Contains('6') && row.Contains('7') && row.Contains('8') && row.Contains('9'));
            }
        }

        private void SolveSudoku(char[][] board)
        {
            var rowValid = GenerateMatrix();
            var colValid = GenerateMatrix();
            var cellValid = GenerateMatrix();

            if (IsValid(rowValid, colValid, cellValid, board))
            {
                throw new Exception("Initial board is invalid");
            }

            TrySolve(rowValid, colValid, cellValid, 0, 0, board);
        }

        private bool TrySolve(bool[][] rowValid, bool[][] colValid, bool[][] cellValid, int row, int col, char[][] board)
        {
            for (int i = row; i < board.Length; i++)
            {
                for (int j = col; j < board.Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        var cell = GetCellId(i, j);

                        for (int k = 0; k < 9; k++)
                        {
                            if (cellValid[cell][k] || rowValid[i][k] || colValid[j][k])
                            {
                                continue;
                            }
                            else
                            {
                                var nextRow = j == board.Length - 1 ? i + 1 : i;
                                var nextCol = j == board.Length - 1 ? 0 : j + 1;
                                board[i][j] = (char)(k + 1 + '0');

                                cellValid[cell][k] = true;
                                rowValid[i][k] = true;
                                colValid[j][k] = true;
                                if (!TrySolve(rowValid, colValid, cellValid, nextRow, nextCol, board))
                                {
                                    cellValid[cell][k] = false;
                                    rowValid[i][k] = false;
                                    colValid[j][k] = false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        private bool[][] GenerateMatrix()
        {
            var value = new bool[9][];
            for (int i = 0; i < value.Length; i++)
            {
                value[i] = new bool[9];
            }

            return value;
        }

        private bool IsValid(bool[][] row, bool[][] col, bool[][] cell, char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j] != '.')
                    {
                        var value = board[i][j] - '1';

                        var cellId = GetCellId(i, j);

                        if (cell[cellId][value] || row[i][value] || col[j][value])
                        {
                            return false;
                        }
                        else
                        {
                            cell[cellId][value] = true;
                            row[i][value] = true;
                            col[j][value] = true;
                        }
                    }
                }
            }

            return true;
        }

        private int GetCellId(int row, int col)
        {
            if (row < 3 && col < 3)
            {
                return 0;
            }

            if (row < 3 && col < 6)
            {
                return 1;
            }

            if (row < 3 && col < 9)
            {
                return 2;
            }

            if (row < 6 && col < 3)
            {
                return 3;
            }

            if (row < 6 && col < 6)
            {
                return 4;
            }

            if (row < 6 && col < 9)
            {
                return 5;
            }

            if (row < 9 && col < 3)
            {
                return 6;
            }

            if (row < 9 && col < 6)
            {
                return 7;
            }

            if (row < 9 && col < 9)
            {
                return 8;
            }

            return -1;
        }
    }
}
