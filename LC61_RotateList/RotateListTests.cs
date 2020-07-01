using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC61_RotateList
{
    [TestClass]
    public class RotateListTests
    {
        [TestMethod]
        public void GivenListAndRotation_RotateList_ShouldReturnCorrectAnswer()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 2, 3, 4, 5}).Head;

            var result = RotateList(head, 2);

            Assert.IsTrue(result.Value == 4 && result.Next.Value == 5 && result.Next.Next.Value == 1 
                       && result.Next.Next.Next.Value == 2 && result.Next.Next.Next.Next.Value == 3);
        }

        [TestMethod]
        public void GivenAnotherListAndRotation_RotateList_ShouldReturnCorrectAnswer()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 0, 1, 2 }).Head;

            var result = RotateList(head, 4);

            Assert.IsTrue(result.Value == 2 && result.Next.Value == 0 && result.Next.Next.Value == 1);
        }

        private ListNode RotateList(ListNode head, int k)
        {
            if (head == null)
            {
                return null;
            }

            var stack = new Stack<ListNode>();
            var count = 0;
            var temp = head;

            while(temp != null)
            {
                stack.Push(temp);
                count++;
                temp = temp.Next;
            }

            var realRotation = count <= k ? k % count : k;

            while (realRotation-- > 0)
            {
                var last = stack.Pop();
                last.Next = head;
                head = last;
                var next = stack.Peek();
                next.Next = null;
            }

            return head;
        }
    }
}
