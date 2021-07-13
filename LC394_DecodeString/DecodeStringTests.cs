using System;
using System.Collections.Generic;
using System.Text;
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

            var list = ConvertStringToLinkedList(input);

            DecodeStringHelper(list.First, list.Last);

            return ConvertLinkedListToString(list);
        }

        private LinkedListNode<char> DecodeStringHelper(LinkedListNode<char> first, LinkedListNode<char> last)
        {
            
            while (first != last)
            {
                while(isChar(first.Value))
                {
                    first = first.Next;
                }

                if (isNumber(first.Value))
                {
                    var tempNumber = first;
                    var num = 0;
                    while (isNumber(tempNumber.Value))
                    {
                        num *= 10;
                        num = tempNumber.Value - '0';

                        tempNumber = tempNumber.Next;
                    }

                    var bracket = tempNumber;
                    var stack = new Stack<LinkedListNode<char>>();
                    do
                    {
                        if (isOpenBracket(bracket.Value))
                        {
                            stack.Push(bracket);
                        }

                        if (isCloseBracket(bracket.Value))
                        {
                            var openBracketNode = stack.Pop();
                            DecodeStringHelper(openBracketNode.Next, bracket.Previous);
                        }

                        bracket = bracket.Next;
                    }
                    while (stack.Count != 0);

                    RepeatNTimes(num, first, bracket.Previous);
                }
            }

            return last;
        }

        private void RepeatNTimes(int num, LinkedListNode<char> first, LinkedListNode<char> previous)
        {
            throw new NotImplementedException();
        }

        private bool isCloseBracket(char value)
        {
            return value == ']';
        }

        private bool isOpenBracket(char value)
        {
            return value == '[';
        }

        private bool isNumber(char value)
        {
            return value >= '0' && value <= '9';

        }

        private bool isChar(char value)
        {
            return value >= 'a' && value <= 'z';
        }

        private LinkedList<char> ConvertStringToLinkedList(string input)
        {
            var result = new LinkedList<char>();

            for (int i = 0; i < input.Length; i++)
            {
                result.AddLast(input[i]);
            }

            result.AddLast(' ');
            return result;
        }

        private string ConvertLinkedListToString(LinkedList<char> list)
        {
            var sb = new StringBuilder();

            var head = list.First;

            while (head != null)
            {
                sb.Append(head.Value);
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

    }
}
