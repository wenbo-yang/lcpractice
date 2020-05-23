using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC772_BasicCalculator
{
    [TestClass]
    public class BasicCalculatorTests
    {
        [TestMethod]
        public void GivenBasicExpressionString_Calculate_ShouldReturnCorrectResult()
        {
            var input = "1 + 1";

            var result = Calculate(input);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void GivenAnotherBasicExpressionString_Calculate_ShouldReturnCorrectResult()
        {
            var input = "2*(1+1)";

            var result = Calculate(input);

            Assert.IsTrue(result == 4);
        }

        private int Calculate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("exception");
            }

            return CalculateHelper(input.Replace(" ", ""));
        }

        private int CalculateHelper(string input)
        {
            var list = ConvertInputIntoLinkedList(input);

            CalculateAllValuesInBracket(list);

            return EvaluateExpressionNoBracketInTheMiddle(list, list.First, list.Last);
        }

        private void CalculateAllValuesInBracket(LinkedList<(char symbol, int number)> list)
        {
            var stack = new Stack<LinkedListNode<(char symbol, int number)>>();

            var head = list.First;

            while (head != null)
            {
                if (head.Value.symbol == '(')
                {
                    stack.Push(head);
                }
                else if (head.Value.symbol == ')')
                {
                    var open = stack.Pop();
                    var close = head;

                    var result = EvaluateExpressionNoBracketInTheMiddle(list, open, close);

                    head = ReplaceExpressionWithValue(list, open, close, result);
                }

                head = head.Next;
            }

        }

        private int EvaluateExpressionNoBracketInTheMiddle(LinkedList<(char symbol, int number)> list, LinkedListNode<(char symbol, int number)> first, LinkedListNode<(char symbol, int number)> last)
        {
            if (first == last)
            {
                return first.Value.number;
            }

            if (first.Next.Next == last)
            {
                return EvaluateBasicExpression(first, last);
            }

            if (first.Value.symbol == '(')
            {
                first = first.Next;
                last = last.Previous;
            }

            list.AddBefore(first, ('s', -1));
            list.AddAfter(last, ('e', -1));

            var start = first.Previous;
            var end = last.Next;

            var head = first;
            while (head != end)
            {
                if (head.Value.symbol == '*' || head.Value.symbol == '/')
                {
                    var result = EvaluateBasicExpression(head.Previous, head.Next);
                    head = ReplaceExpressionWithValue(list, head.Previous, head.Next, result);
                }

                head = head.Next;
            }

            head = start.Next;

            while (head != end)
            {
                if (head.Value.symbol == '+' || head.Value.symbol == '/')
                {
                    var result = EvaluateBasicExpression(head.Previous, head.Next);
                    head = ReplaceExpressionWithValue(list, head.Previous, head.Next, result);
                }

                head = head.Next;
            }

            head = start.Next;

            list.Remove(start); list.Remove(end);

            return head.Value.number;
        }

        private LinkedListNode<(char symbol, int number)> ReplaceExpressionWithValue(LinkedList<(char symbol, int number)> list, LinkedListNode<(char symbol, int number)> open, LinkedListNode<(char symbol, int number)> close, int result)
        {
            list.AddAfter(close, (' ', result));
            var newHead = open.Previous;
            while (close != newHead)
            {
                var prev = close.Previous;
                list.Remove(close);
                close = prev;
            }

            return newHead.Next;
        }

        private int EvaluateBasicExpression(LinkedListNode<(char symbol, int number)> first, LinkedListNode<(char symbol, int number)> last)
        {
            if (first.Value.symbol == '(')
            {
                return first.Next.Value.number;
            }

            var left = first.Value.number;
            var right = last.Value.number;
            var operation = first.Next.Value.symbol;
            switch (operation)
            {
                case '+':
                    return left + right;

                case '-':
                    return left - right;

                case '*':
                    return left * right;

                case '/':
                    return left / right;

                default:
                    throw new Exception();
            }
        }

        private LinkedList<(char symbol, int number)> ConvertInputIntoLinkedList(string s)
        {
            var linkedList = new LinkedList<(char symbol, int number)>();

            for (int i = 0; i < s.Length; )
            {
                if (IsOperatorOrBracket(s[i]))
                {
                    linkedList.AddLast((s[i], -1));
                    i++;
                }
                else
                {
                    var number = 0;
                    while (!IsOperatorOrBracket(s[i]))
                    {
                        number *= 10;
                        number += s[i] - '0';
                        i++;
                    }

                    linkedList.AddLast((' ', number));
                }
            }

            return linkedList;
        }

        private bool IsOperatorOrBracket(char c)
        {
            var value = c - '0';
            return !(value >= 0 && value <= 9);
        }
    }
}
