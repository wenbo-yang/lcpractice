using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC20_ValidParentheses
{
    [TestClass]
    public class ValidParenthesesTests
    {
        [TestMethod]
        public void GivenValidParentheses_Validate_ShouldReturnTrue()
        {
            var input = "{[]}[]{}<>()";

            var result = ValidateParentheses(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenInvalidParentheses_Validate_ShouldReturnFalse()
        {
            var input = "{[]}[]{}<()";

            var result = ValidateParentheses(input);

            Assert.IsFalse(result);
        }

        // use a stack, last in first out // 

        private bool ValidateParentheses(string input)
        {
            var stack = new Stack<char>();

            foreach (var character in input)
            {
                if (IsClosing(character) && stack.Count == 0)
                {
                    break;
                }
                else if (IsClosing(character) && stack.Count > 0)
                {
                    var left = stack.Peek();

                    if (!IsMatching(left, character))
                    {
                        break;
                    }
                    
                    stack.Pop();
                }
                else if (IsOpening(character))
                {
                    stack.Push(character);
                }
            }

            return stack.Count == 0;        
        }

        //private Dictionary<char, char> _matching;  // use this to scale
        //private HashSet<char> _closing;
        private bool IsOpening(char left)
        {
            var retVal = false;

            if (left == '(')
            {
                retVal = true;
            }
            else if (left == '{')
            {
                retVal = true;
            }
            else if (left == '[')
            {
                retVal = true;
            }
            else if (left == '<')
            {
                retVal = true;
            }

            return retVal;
        }

        private bool IsClosing(char right)
        {
            var retVal = false;

            if (right == ')')
            {
                retVal = true;
            }
            else if (right == '}')
            {
                retVal = true;
            }
            else if (right == ']')
            {
                retVal = true;
            }
            else if (right == '>')
            {
                retVal = true;
            }

            return retVal;
        }

        private bool IsMatching(char left, char right)
        {
            var retVal = false;

            if (left == '(' && right == ')')
            {
                retVal = true;
            }
            else if (left == '{' && right == '}')
            {
                retVal = true;
            }
            else if (left == '[' && right == ']')
            {
                retVal = true;
            }
            else if (left == '<' && right == '>')
            {
                retVal = true;
            }

            return retVal;
        }

    }
}
