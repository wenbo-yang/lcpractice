using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC83_RemoveDuplicatesFromSortedList
{
    [TestClass]
    public class RemoveDuplicatesFromSortedListTests
    {
        [TestMethod]
        public void GivenSortedLinkedList_RemoveDuplicates_ShouldReturnCorrectList()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 1, 1, 2, 3 }).Head;
            var result = RemoveDuplicates(head);

            Assert.IsTrue(result.Value == 1 && result.Next.Value == 2 && result.Next.Next.Value == 3);
        }

        [TestMethod]
        public void GivenAnotherSortedLinkedList_RemoveDuplicates_ShouldReturnCorrectList()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 1, 1, 2, 2 }).Head;
            var result = RemoveDuplicates(head);

            Assert.IsTrue(result.Value == 1 && result.Next.Value == 2 && result.Next.Next == null);
        }

        [TestMethod]
        public void GivenAllSameSortedLinkedList_RemoveDuplicates_ShouldReturnCorrectList()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 1, 1 }).Head;
            var result = RemoveDuplicates(head);

            Assert.IsTrue(result.Value == 1 && result.Next == null);
        }

        private ListNode RemoveDuplicates(ListNode head)
        {
            var temp = head;

            while (temp != null && temp.Next != null)
            {
                if (temp.Next.Value == temp.Value)
                {
                    temp.Next = temp.Next.Next;
                }
                else
                {
                    temp = temp.Next;
                }
            }

            return head;
        }
    }
}
