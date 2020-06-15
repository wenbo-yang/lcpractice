using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC36_ValidSudoku
{
    [TestClass]
    public class ValidSudokuTests
    {
        [TestMethod]
        public void GivenBoard_IsValid_ShouldReturnCorrectAnswer()
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

            var result = IsValid(board);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenAnotherBoard_IsValid_ShouldReturnCorrectAnswer()
        {
            var board = new char[][] {
                        new char[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
                        new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                        new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                        new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                        new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                        new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                        new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                        new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                        new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }};

            var result = IsValid(board);

            Assert.IsFalse(result);
        }

        private bool IsValid(char[][] board)
        {
            var row = GenerateMatrix();
            var col = GenerateMatrix();
            var cell = GenerateMatrix();
            
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

        private bool[][] GenerateMatrix()
        {
            var value = new bool[9][];
            for (int i = 0; i < value.Length; i++)
            {
                value[i] = new bool[9];
            }

            return value;
        }
    }
}
