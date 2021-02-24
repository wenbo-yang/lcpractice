using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace h1_EvaluateExpression
{
    [TestClass]
    public class EvaluateExpressionTests
    {
        [TestMethod]
        public void GivenExpression_EvaluateExpression_ShouldReturnCorrectAnswer()
        {
            var s = "!(&(&(t,t), |(t,f)))";

            var result = EvaluateExpression(s);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenNotExpression_EvaluateExpression_ShouldReturnFalse()
        {
            var s = "!(t)";

            var result = EvaluateExpression(s);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenSimpleExpression_EvaluateExpression_ShouldReturnFalse()
        {
            var s = "t";

            var result = EvaluateExpression(s);

            Assert.IsTrue(result);
        }

        private bool EvaluateExpression(string s)
        {
            var list = ConstructListFromString(s);

            var stack = new Stack<LinkedListNode<char>>();

            var head = list.First;

            while (head != null)
            {
                if (head.Value == '(')
                {
                    stack.Push(head);
                }
                else if (head.Value == ')')
                {
                    var start = stack.Pop();
                    var end = head;

                    head = ReplaceLinkedListWithEvaluatedResult(start, end, list);
                }

                head = head.Next;
            }

            return list.First.Value == 't' ? true : false;
        }

        private LinkedListNode<char> ReplaceLinkedListWithEvaluatedResult(LinkedListNode<char> start, LinkedListNode<char> end, LinkedList<char> list)
        {
            var op = start.Previous;

            var prev = op.Previous;

            var result = EvaluateBasicListExpression(op, end);
            while (end != prev)
            {
                var tempEnd = end.Previous;
                list.Remove(end);
                end = tempEnd;
            }

            if (list.Count == 0)
            {
                list.AddFirst(result);
                return list.First;
            }
            
            list.AddAfter(prev, result);

            return prev.Next;
        }

        private LinkedList<char> ConstructListFromString(string s)
        {
            var list = new LinkedList<char>();

            foreach (var c in s)
            {
                list.AddLast(c);
            }

            return list;
        }

        private char EvaluateBasicListExpression(LinkedListNode<char> head, LinkedListNode<char> tail)
        {
            if (head.Value == '!')
            {
                return head.Next.Next.Value == 't' ? 'f' : 't';
            }

            var left = head.Next.Next.Value == 't' ? true : false;
            var right = tail.Previous.Value == 't' ? true : false;

            if (head.Value == '&')
            {
                return left && right ? 't' : 'f';
            }

            return left || right ? 't' : 'f';
        }
    }
}
