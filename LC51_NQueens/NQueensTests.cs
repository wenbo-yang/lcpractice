using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC51_NQueens
{

    // both 51 and 52
    // DFS or BFS with back track
    [TestClass]
    public class NQueensTests
    {
        [TestMethod]
        public void Given4X4Board_PlaceQueens_ShouldHave2Solutions()
        {
            var input = 4;

            var output = PlaceQueens(input);

            Assert.IsTrue(output.Count == 2);
        }

        private List<List<string>> PlaceQueens(int input)
        {
            var board = new Board();
            board.Initialize(input);

            var results = new List<List<string>>();
            Dfs(ref board, 0, input, results);

            return results;
        }

        private void Dfs(ref Board board, int number, int size, List<List<string>> results)
        {
            if (number == size)
            {
                results.Add(board.GetBoard());
                return;
            }

            for (int i = board.LastPlaced_x; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (!board.CheckOccupied(i, j))
                    {
                        board.PlaceQueenAt(i, j);
                        Dfs(ref board, number + 1, size, results);
                        board.RemoveAt(i, j);
                    }
                }
            }
        }

        public class Board
        {
            private int _size;
            private bool[][] _board;
            private bool[] _row;
            private bool[] _col;
            private bool[] _diag1;
            private bool[] _diag2;
            public int LastPlaced_x { get; set; }
            public int LastPlaced_y { get; set; }

            public Board()
            {
            }

            public void Initialize(int size)
            {
                _size = size;
                _board = InitializeBoard(size);
                _row = new bool[size];
                _col = new bool[size];
                _diag1 = new bool[size * 2 - 1];
                _diag2 = new bool[size * 2 - 1];
            }

            public void PlaceQueenAt(int x, int y)
            {
                _board[x][y] = true;
                _row[x] = true;
                _col[y] = true;
                _diag1[x + y] = true;
                _diag2[x + _size - y - 1] = true;

                LastPlaced_x = x;
                LastPlaced_y = y;
            }

            public void RemoveAt(int x, int y)
            {
                _board[x][y] = false;
                _row[x] = false;
                _col[y] = false;
                _diag1[x + y] = false;
                _diag2[x + _size - y - 1] = false;
            }

            public bool CheckOccupied(int x, int y)
            {
                return _row[x] || _col[y] || _diag1[x + y] || _diag2[x + _size - y - 1];
            }

            public List<string> GetBoard()
            {
                return ConvertBoolBoardToString();
            }

            private bool[][] InitializeBoard(int input)
            {
                var result = new bool[input][];

                for (int i = 0; i < input; i++)
                {
                    result[i] = new bool[input];
                }

                return result;
            }

            private List<string> ConvertBoolBoardToString()
            {
                var result = new List<string>();

                foreach (var row in _board)
                {
                    var rowString = "";
                    foreach (var col in row)
                    {
                        rowString = rowString + (col ? "Q" : ".");
                    }

                    result.Add(rowString);
                }

                return result;
            }
        }

        

        
    }
}
