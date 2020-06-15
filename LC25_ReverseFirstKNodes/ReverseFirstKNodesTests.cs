using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC25_ReverseFirstKNodes
{
    [TestClass]
    public class ReverseFirstKNodesTests
    {
        [TestMethod]
        public void GivenLinkedList_ReverseFirstKNodes_ShouldReturnCorrectAnswer()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 2, 3, 4, 5 }).Head;

            var result = ReverseFirstKNodes(head, 2);

            Assert.IsTrue(result.Value == 2);
        }

        [TestMethod]
        public void GivenAnotherLinkedList_ReverseFirstKNodes_ShouldReturnCorrectAnswer()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 2, 3, 4 }).Head;

            var result = ReverseFirstKNodes(head, 2);

            Assert.IsTrue(result.Value == 2);
        }

        private ListNode ReverseFirstKNodes(ListNode head, int k)
        {
            if (head == null)
            {
                return null;
            }

            var prev = head;
            var current = head.Next;
            var count = 0;
            while (++count < k)
            {
                RemoveAndAddToHead(ref head, ref prev, ref current);
            }

            while (CanReverse(current, k))
            {
                var currentHead = prev;
                prev = current;
                current = current.Next;
                count = 0;
                while (++count < k)
                {
                    RemoveAndInsertAfterPosition(currentHead, ref prev, ref current);
                }
            }

            return head;
        }

        private void RemoveAndInsertAfterPosition(ListNode currentHead, ref ListNode prev, ref ListNode current)
        {
            var next = current.Next;
            prev.Next = next;

            current.Next = currentHead.Next;
            currentHead.Next = current;

            current = next;
        }

        private bool CanReverse(ListNode current, int k)
        {
            while (k-- > 0 && current != null)
            {
                current = current.Next;
            }

            return k < 0;
        }

        private void RemoveAndAddToHead(ref ListNode head, ref ListNode prev, ref ListNode current)
        {
            prev.Next = current.Next;
            current.Next = head;
            head = current;

            current = prev.Next;
        }
    }
}
