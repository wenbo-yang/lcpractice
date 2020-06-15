using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC24_SwapNodesInPairs
{
    [TestClass]
    public class SwapNodesInPairsTests
    {
        [TestMethod]
        public void GivenLinkedList_SwapNodesInPairs_ShouldReturnCorrectAnswer()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 2, 3, 4 }).Head;

            var result = SwapNodesInPairs(head);

            Assert.IsTrue(result.Value == 2);
        }

        private ListNode SwapNodesInPairs(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var prev = head;
            var current = head.Next;
            head = current;
            prev.Next = current.Next;
            current.Next = prev;
            current = prev.Next;

            while (current != null)
            {
                var next = current.Next;

                if (next == null)
                {
                    break;
                }

                prev.Next = next;
                current.Next = next.Next;
                next.Next = current;
                prev = current;
                current = current.Next;
            }
            return head;
        }
    }
}
