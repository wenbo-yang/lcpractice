using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC419_BattleShipsInBoard
{
    [TestClass]
    public class BattleShipsInBoardTests
    {
        [TestMethod]
        public void GivenBattleShipsInBoard_GetNumberOfBatteShips_ShouldReturnNumber()
        {
            var board = new char[][] { new char[] { 'X', '.', '.', 'X' },
                                       new char[] { '.', '.', '.', 'X' },
                                       new char[] { '.', '.', '.', 'X' }};

            var result = GetNumberOfBattleShips(board);

            Assert.IsTrue(result == 2);
        }

        private int GetNumberOfBattleShips(char[][] board)
        {
            var result = 0;

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if(board[i][j] == 'X')
                    {
                        result++;
                        var row = i; var col = j;
                        var direction = GetDirection(i, j, board);
                        do
                        {
                            board[row][col] = '.';

                            row += direction.row;
                            col += direction.col;
                        }
                        while (CanGo(row, col, board));
                    }

                }
            }

            return result;
        }

        private (int row, int col) GetDirection(int row, int col, char[][] board)
        {
            if (CanGo(row - 1, col, board))
            {
                return (-1, 0);
            }
            if (CanGo(row + 1, col, board))
            {
                return (1, 0);
            }
            if (CanGo(row, col - 1, board))
            {
                return (0, -1);
            }
            if (CanGo(row , col + 1, board))
            {
                return (0, 1);
            }

            return (0, 0);
        }

        private bool CanGo(int row, int col, char[][] board)
        {
            return row >= 0 && col >= 0 && row < board.Length && col < board[0].Length && board[row][col] == 'X';
        }
    }
}
