using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC71_SimplifyPath
{
    [TestClass]
    public class SimplifyPathTests
    {
        [TestMethod]
        public void GivenPathString_SimplyPath_ShouldReturnCorrectAnswewr()
        {
            var path = "/home//foo/";
            var result = SimplifyPath(path);
            Assert.IsTrue(result == "/home/foo");
        }

        [TestMethod]
        public void GivenAnotherPathString_SimplyPath_ShouldReturnCorrectAnswewr()
        {
            var path = "/a//b////c/d//././/..";
            var result = SimplifyPath(path);
            Assert.IsTrue(result == "/a/b/c");
        }

        private string SimplifyPath(string path)
        {
            var stack = new Stack<string>();

            var index = 0;
            while (index < path.Length)
            {
                if (IsGoingBack(path, index))
                {
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }

                    index += 3;
                }
                else if (IsNoOp(path, index))
                {
                    index = GetNextPath(path, ++index);
                }
                else
                {
                    var folder = GetFolderPath(path, ++index);
                    if (!string.IsNullOrWhiteSpace(folder))
                    {
                        stack.Push(folder);
                    }

                    index += folder.Length;
                }
            }

            var sb = new StringBuilder();

            while(stack.Count != 0)
            {
                sb.Insert(0, stack.Pop()); sb.Insert(0, '/');
            }

            var result = sb.ToString();

            return string.IsNullOrWhiteSpace(result) ? "/" : result;
        }

        private int GetNextPath(string path, int index)
        {
            while (index < path.Length && path[index] != '/')
            {
                index++;
            }

            return index;
        }

        private bool IsNoOp(string path, int index)
        {
            return path[index++] == '/' && index < path.Length && (path[index] == '.' || path[index] == '/');
        }

        private bool IsGoingBack(string path, int index)
        {
            return index + 2 < path.Length && path[index++] == '/' && path[index++] == '.' && path[index++] == '.';
        }

        private string GetFolderPath(string path, int index)
        {
            var sb = new StringBuilder();
            while (index < path.Length && path[index] != '/')
            {
                sb.Append(path[index]);
                index++;
            }

            return sb.ToString();
        }
    }
}
