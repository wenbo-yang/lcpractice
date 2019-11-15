using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC149_LinkedListCycle
{
    [TestClass]
    public class LinkedListCycleTests
    {
        [TestMethod]
        public void GivenLinkedListWithNoCycle_HasCycle_ShouldReturnFalse()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 2, 3, 4, 5 }).Head;

            var result = HasCycle(head);

            Assert.IsFalse(result);
        }

        private bool HasCycle(ListNode head)
        {
            var fast = head;
            var slow = head;

            while (fast != null && slow != null)
            {
                fast = fast.Next != null && fast.Next.Next != null ? fast.Next.Next : null;

                slow = slow.Next != null ? slow.Next : null;

                if(fast == slow)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
