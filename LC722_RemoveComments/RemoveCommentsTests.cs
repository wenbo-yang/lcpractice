using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC722_RemoveComments
{
    [TestClass]
    public class RemoveCommentsTests
    {
        [TestMethod]
        // using a stack to keep track of /**/
        public void GivenListOfSourceCode_RemoveComments_ShouldRemoveComments()
        {
            var source = new string[] { "/*Test program */", "int main()", "{ ", "  // variable declaration ", "int a, b, c;", "/* This is a test", "   multiline  ", "   comment for ", "   testing */", "a = b + c;", "}" };
            var result = RemoveComments(source);

            Assert.IsTrue(result.SequenceEqual(new List<string> { "int main()", "{ ", "  ", "int a, b, c;", "a = b + c;", "}" }));
        }

        private List<string> RemoveComments(string[] source)
        {
            var completeLineRemoval = new bool[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                var startingCol = source[i].IndexOf("/*");
                var startingRow = i;
                if (startingCol != -1)
                {
                    var closing = FindCorrespondingClosingComment(i, source);

                    MarkCompleteLineRemoval(startingRow, startingCol, closing.row, closing.col, source, completeLineRemoval);

                    i = closing.row;

                    // remove post startingCol
                    var start = source[startingRow].Remove(startingCol);

                    // remove prior closingCol
                    var leftOver = source[closing.row].Substring(closing.col + 2);

                    source[closing.row] = start + leftOver;

                    if (!string.IsNullOrEmpty(source[closing.row]))
                    {
                        completeLineRemoval[closing.row] = false;
                        completeLineRemoval[startingRow] = true;
                    }
                }

                var lineCommentStart = source[i].IndexOf("//");
                if (lineCommentStart != -1)
                {
                    source[i] = source[i].Remove(lineCommentStart);
                }
            }

            var result = new List<string>();
            for (int i = 0; i < source.Length; i++)
            {
                if (!completeLineRemoval[i])
                {
                    result.Add(source[i]);
                }
            }

            return result;
        }

        private void MarkCompleteLineRemoval(int startingRow, int startingCol, int closingRow, int closingCol, string[] source, bool[] completeLineRemoval)
        {
            if (startingCol == 0)
            {
                completeLineRemoval[startingRow] = true;
            }

            if (closingCol == source[closingRow].Length - 2)
            {
                completeLineRemoval[closingRow] = true;
            }

            for (int i = startingRow + 1; i < closingRow; i++)
            {
                completeLineRemoval[i] = true;
            }
        }

        private (int row, int col) FindCorrespondingClosingComment(int startingRow, string[] source)
        {
            var stack = new Stack<(int row, int col)>();
            for (int i = startingRow; i < source.Length; i++)
            {
                for (int j = 0; j < source[i].Length - 1; j++)
                {
                    if (source[i][j] == '/' && source[i][j + 1] == '*')
                    {
                        stack.Push((i, j));
                    }

                    if (source[i][j] == '*' && source[i][j + 1] == '/' && (j > 0 && source[i][j - 1] != '/'))
                    {
                        stack.Pop();

                        if (stack.Count == 0)
                        {
                            return (i, j);
                        }
                    }
                }
            }

            return (-1, -1);
        }

    }
}
