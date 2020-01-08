using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1275_TicTacToeGame
{
    [TestClass]
    public class TicTacToeGameTests
    {
        [TestMethod]
        public void GivenBoardAndMoves_GetWinner_ShouldReturnWinner()
        {
            var moves = new (int row, int col)[] { (0, 0),(2, 0),(1, 1),(2, 1),(2, 2)};
            var winner = GetWinner(moves);

            Assert.IsTrue(winner == "A");
        }

        private string GetWinner((int row, int col)[] moves)
        {
            var placeA = true;

            var A = new TicTacToeWinner();
            var B = new TicTacToeWinner();

            for (int i = 0; i < moves.Length; i++)
            {
                if (placeA)
                {
                    A.PlaceAt(moves[i]);
                }
                else
                {
                    B.PlaceAt(moves[i]);
                }

                placeA = !placeA;

                if (A.CanWin()) return "A";
                if (A.CanWin()) return "B";
            }

            return moves.Length == 9 ? "Draw" : "Pending";
        }

        public class TicTacToeWinner
        {
            private int[] _countCol = new int[3];
            private int[] _countRow = new int[3];
            private int _countDiag1;
            private int _countDiag2;


            public void PlaceAt((int row, int col) coord)
            {
                _countRow[coord.row]++;
                _countCol[coord.col]++;
                _countDiag1 += coord.row == coord.col ? 1 : 0;
                _countDiag2 += coord.row + coord.col == 2 ? 1 : 0;
            }

            public bool CanWin()
            {
                return _countRow.Max() == 3 || _countCol.Max() == 3 || _countDiag1 == 3 || _countDiag2 == 3; 
            }
        }
    }
}
