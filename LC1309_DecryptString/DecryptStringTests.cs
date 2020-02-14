using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1309_DecryptString
{
    [TestClass]
    public class DecryptStringTests
    {
        [TestMethod]
        public void GivenString_DecryptString_ShouldReturnCorrectString()
        {
            var input = "110#11#12";

            var result = DecryptString(input);

            Assert.IsTrue(result == "ajkab");
        }

        private string DecryptString(string input)
        {
            var right = input.Length - 1;
            var stack = new Stack<char>();
            while (right >= 0)
            {
                char decryptedChar;
                if (input[right] == '#')
                {
                    right = right - 2;
                    var substring = input.Substring(right, 2);
                    decryptedChar = DecryptHelper(substring);
                }
                else
                {
                    decryptedChar = DecryptHelper(input[right].ToString());    
                }

                stack.Push(decryptedChar);
                right--;
            }

            return new string(stack.ToArray());
        }

        private char DecryptHelper(string substring)
        {
            return (char)('a' + Convert.ToInt32(substring) - 1);
        }
    }
}
