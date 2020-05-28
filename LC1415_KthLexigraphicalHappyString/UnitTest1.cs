using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1415_KthLexigraphicalHappyString
{
    [TestClass]
    public class KthLexigraphicalHappyStringTests
    {
        [TestMethod]
        public void GivenNAndK_FindKthString_ShouldReturnCorrectString()
        {
            var n = 3; var k = 9;
            var result = FindKThString(n, k);

            Assert.IsTrue(result == "cab");
        }

        private string FindKThString(int n, int k)
        {
            var list = GenerateInitialList(n);

            while (--k != 0)
            {
                IncrementList(list);
            }

            return new string(list.ToArray());
        }

        private void IncrementList(List<char> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                var target = TryIncrement(list, i);
                if (target != ' ')
                {
                    list[i] = target;
                    ResetSubsequent(list, i + 1);
                    break;
                }
            }
        }

        private char TryIncrement(List<char> list, int i)
        {
            if (list[i] == 'c')
            {
                return ' ';
            }

            if (i > 0)
            {
                if (list[i - 1] == 'a' && list[i] == 'b')
                {
                    return 'c';
                }
                else if (list[i - 1] == 'b' && list[i] == 'a')
                {
                    return 'c';
                }
                else if (list[i - 1] == 'c' && list[i] == 'a')
                {
                    return 'b';
                }
            }
            else
            {
                return (char)(list[i] + 1);
            }

            return ' ';
        }

        private void ResetSubsequent(List<char> list, int startIndex)
        {
            for (int i = startIndex; i < list.Count; i++)
            {
                list[i] = (list[i - 1] != 'a') ? 'a' : 'b';
            }
        }

        private List<char> GenerateInitialList(int n)
        {
            var list = new List<char>();
            list.Add('a');
            for (int i = 1; i < n; i++)
            {
                list.Add(list[i - 1] == 'a' ? 'b' : 'a');
            }

            return list;
        }
    }
}
