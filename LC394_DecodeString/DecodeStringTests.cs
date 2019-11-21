using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC394_DecodeString
{
    [TestClass]
    public class DecodeStringTests
    {
        [TestMethod]
        public void GivenStringExpression_DecodeString_ShouldReturnCorrectString()
        {
            var input = "3[a]2[bc]";

            var result = DecodeString(input);

            Assert.IsTrue(result == "aaabcbc");
        }

        private string DecodeString(string input)
        {
            var result = new List<char>();

            DecodeStringHelper(input, 0, input.Length - 1, result);

            return new string(result.ToArray());    
        }

        private void DecodeStringHelper(string input, int start, int end, List<char> result)
        {
            for (int i = start; i <= end; i++)
            {
                if (input[i] >= 'a' && input[i] <= 'z')
                {
                    result.Add(input[i]);
                }
                else if (input[i] >= '0' && input[i] <= '9')
                {
                    var openBracketIndex = input.IndexOf('[', i);
                    var closeBracketIndex = input.IndexOf(']', openBracketIndex);
                    var numberString = input.Substring(i, openBracketIndex - i);
                    var shouldRepeatNTimes = Convert.ToInt32(numberString);
                    var tempResult = new List<char>();
                    DecodeStringHelper(input, openBracketIndex + 1, closeBracketIndex - 1, tempResult);
                    result.AddRange(RepeatNTimes(tempResult, shouldRepeatNTimes));
                    i = closeBracketIndex;
                }
            }
        }

        private List<char> RepeatNTimes(List<char> chars, int n)        {
            var result = new List<char>();

            for (int i = 0; i < n; i++)
            {
                foreach (var c in chars)
                {
                    result.Add(c);
                }
            }

            return result;
        }
    }
}
