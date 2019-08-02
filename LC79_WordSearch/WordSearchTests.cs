using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC79_WordSearch
{
    [TestClass]
    public class WordSearchTests
    {
        [TestMethod]
        public void GivenMatAndWord_Find_ShouldFindWord()
        {
            var board = new char[][] { new char[] { 'A', 'B', 'C', 'E' },
                                       new char[] { 'S', 'F', 'C', 'S' },
                                       new char[] { 'A', 'D', 'E', 'E' } };
            var word = "ABCCED";

            bool result = FindWord(board, word);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenMatAndInvalidWord_Find_ShouldNotFindWord()
        {
            var board = new char[][] { new char[] { 'A', 'B', 'C', 'E' },
                                       new char[] { 'S', 'F', 'C', 'S' },
                                       new char[] { 'A', 'D', 'E', 'E' } };
            var word = "ABCB";

            bool result = FindWord(board, word);

            Assert.IsFalse(result);
        }

        private bool FindWord(char[][] board, string word)
        {

            List<Tuple<int, int>> startList = FindCharInBoard(board, word[0]);

            var result = false;

            foreach (var coor in startList)
            {
                result = Dfs(board, word, 0, coor, new HashSet<Tuple<int, int>>());

                if (result)
                {
                    break;
                }
            }

            return result;
        }

        private bool Dfs(char[][] board, string word, int index, Tuple<int, int> coor, HashSet<Tuple<int, int>> visited)
        {
            if (board[coor.Item1][coor.Item2] != word[index])
            {
                return false;
            }

            if (index == word.Length - 1)
            {
                return true;
            }

            visited.Add(coor);
            var r = board.Length;
            var c = board[0].Length;
            List<Tuple<int, int>> neighbors = GetNeighbors(coor, r, c);

            var result = false;
            foreach (var neighbor in neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    result = Dfs(board, word, index + 1, neighbor, visited);
                    if (result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        private List<Tuple<int, int>> GetNeighbors(Tuple<int, int> coor, int r, int c)
        {
            var neighbors = new List<Tuple<int, int>>();

            if (coor.Item1 != 0)
            {
                neighbors.Add(new Tuple<int, int>(coor.Item1 - 1, coor.Item2));
            }
            if (coor.Item1 != r - 1)
            {
                neighbors.Add(new Tuple<int, int>(coor.Item1 + 1, coor.Item2));
            }
            if (coor.Item2 != 0)
            {
                neighbors.Add(new Tuple<int, int>(coor.Item1, coor.Item2 - 1));
            }
            if (coor.Item2 != c - 1)
            {
                neighbors.Add(new Tuple<int, int>(coor.Item1, coor.Item2 + 1));
            }

            return neighbors;
        }

        private List<Tuple<int, int>> FindCharInBoard(char[][] board, char v)
        {
            var r = board.Length;
            var c = board[0].Length;

            var result = new List<Tuple<int, int>>();
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if(board[i][j] == v)
                    {
                        result.Add(new Tuple<int, int>(i, j));
                    }
                }
            }


            return result;
        }
    }
}
