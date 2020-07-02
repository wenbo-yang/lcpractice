using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC82_RemoveDuplicatesFromSortedList
{
    [TestClass]
    public class RemoveDuplicatesFromSortedListTests
    {
        [TestMethod]
        public void GivenSortedLinkedList_RemoveDuplicates_ShouldReturnCorrect()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 2, 3, 3, 4, 4, 5 }).Head;

            var result = RemoveDuplicates(head);

            Assert.IsTrue(result.Value == 1 && result.Next.Value == 2 && result.Next.Next.Value == 5);
        }

        [TestMethod]
        public void GivenAnotherSortedLinkedList_RemoveDuplicates_ShouldReturnCorrect()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 1, 1, 2, 3, 3 }).Head;

            var result = RemoveDuplicates(head);

            Assert.IsTrue(result.Value == 2 && result.Next == null);
        }

        private ListNode RemoveDuplicates(ListNode head)
        {
            var stack = new Stack<ListNode>();

            var shouldRemoveLast = false;

            var temp = head;

            while (temp != null)
            {
                if (stack.Count != 0 && temp.Value == stack.Peek().Value)
                {
                    shouldRemoveLast = true;
                    stack.Peek().Next = temp.Next;
                }
                else if (stack.Count != 0 && temp.Value != stack.Peek().Value)
                {
                    if (shouldRemoveLast)
                    {
                        stack.Pop();

                        if (stack.Count == 0)
                        {
                            head = temp;
                        }
                        else
                        {
                            stack.Peek().Next = temp;
                        }

                        shouldRemoveLast = false;
                    }

                    stack.Push(temp);
                }
                else
                {
                    stack.Push(temp);
                }

                temp = temp.Next;
            }

            if (shouldRemoveLast && stack.Count != 0)
            {
                stack.Pop();

                if (stack.Count == 0)
                {
                    head = null;
                }
                else
                {
                    stack.Peek().Next = null;
                } 
            }

            return head;
        }
    }
}
