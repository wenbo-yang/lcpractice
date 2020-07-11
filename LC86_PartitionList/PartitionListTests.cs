using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC86_PartitionList
{
    [TestClass]
    public class PartitionListTests
    {
        [TestMethod]
        public void GivenLinkedList_PartitionList_ShouldReturnCorrectList()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 4, 3, 2, 5, 2}).Head;

            var result = Partition(head, 3);

            Assert.IsTrue(
                result.Value == 1 && result.Next.Value == 2 && result.Next.Next.Value == 2 &&
                result.Next.Next.Next.Value == 4 && result.Next.Next.Next.Next.Value == 3 &&
                result.Next.Next.Next.Next.Next.Value == 5);
        }

        private ListNode Partition(ListNode head, int x)
        {
            var stack = new Stack<ListNode>();
            var current = head;
            var positionFound = false;
            ListNode prev = null;
            while (current != null)
            {
                if (current.Value == x)
                {
                    positionFound = true;
                }

                if (current.Value < x && !positionFound)
                {
                    stack.Push(current);
                }

                if (current.Value < x && positionFound)
                {
                    RemoveAndInsert(prev, current, head, stack);
                }

                prev = current;
                current = current.Next;
            }

            return head;
        }

        private void RemoveAndInsert(ListNode prev, ListNode current, ListNode head, Stack<ListNode> stack)
        {
            prev.Next = current.Next;

            if (stack.Count == 0)
            {
                current.Next = head;
                stack.Push(head);
            }
            else
            {
                current.Next = stack.Peek().Next;
                stack.Peek().Next = current.Next;

                stack.Push(current);
            }
        }
    }
}
