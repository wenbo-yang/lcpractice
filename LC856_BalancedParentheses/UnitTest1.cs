using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC856_BalancedParentheses
{
    [TestClass]
    public class BalancedParenthesesScoreTests
    {
        [TestMethod]
        public void GivenString_GetScoreOfParentheses_ShouldReturnCorrectScore()
        {
            var s = "(()(()))";
            var score = GetScoreOfParenthese(s);

            Assert.IsTrue(score == 6);
        }

        private int GetScoreOfParenthese(string s)
        {
            var openClosePair = new SortedDictionary<int, int>();
            var stack = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    openClosePair.Add(stack.Pop(), i);
                }
            }

            return GetScoreHelper(s, 0, openClosePair) + GetScoreHelper(s, openClosePair[0] + 1, openClosePair);
        }

        private int GetScoreHelper(string s, int startIndex, SortedDictionary<int, int> openClosePair)
        {
            if (startIndex == s.Length)
            {
                return 0;
            }


        }
    }
}
