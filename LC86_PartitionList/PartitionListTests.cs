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

        [TestMethod]
        public void GivenAnotherLinkedList_PartitionList_ShouldReturnCorrectList()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 4, 2, 3, 5, 2 }).Head;

            var result = Partition(head, 3);

            Assert.IsTrue(
                result.Value == 1 && result.Next.Value == 2 && result.Next.Next.Value == 2 &&
                result.Next.Next.Next.Value == 4 && result.Next.Next.Next.Next.Value == 3 &&
                result.Next.Next.Next.Next.Next.Value == 5);
        }

        [TestMethod]
        public void GivenThirdAnotherLinkedList_PartitionList_ShouldReturnCorrectList()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 2, 1 }).Head;

            var result = Partition(head, 2);

            Assert.IsTrue(
                result.Value == 1 && result.Next.Value == 2);
        }

        [TestMethod]
        public void Given312LinkedList_PartitionList_ShouldReturnCorrectList()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 3, 1, 2 }).Head;

            var result = Partition(head, 3);

            Assert.IsTrue(
                result.Value == 1 && result.Next.Value == 2 && result.Next.Next.Value == 3);
        }

        private ListNode Partition(ListNode head, int x)
        {
            var stack = new Stack<ListNode>();
            var current = head;
            var positionFound = false;
            ListNode prev = null;
            ListNode targetSlot = null;
            while (current != null)
            {
                if (current.Value >= x)
                {
                    positionFound = true;
                }

                if (current.Value < x && !positionFound)
                {
                    targetSlot = current;
                }

                if (current.Value < x && positionFound)
                {
                    RemoveAndInsertAfterTargetSlot(ref targetSlot, ref prev, ref current, ref head);
                }

                prev = current;
                current = current.Next;
            }

            return head;
        }

        private void RemoveAndInsertAfterTargetSlot(ref ListNode targetSlot, ref ListNode prev, ref ListNode current, ref ListNode head)
        {
            prev.Next = current.Next;

            if (targetSlot == null)
            {
                current.Next = head;
                head = current;
                targetSlot = head;
            }
            else
            {
                current.Next = targetSlot.Next;
                targetSlot.Next = current;
                targetSlot = current;
            }

            current = prev;
        }
    }
}
