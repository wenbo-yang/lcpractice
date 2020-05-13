using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddTwoNumbers
{
    [TestClass]
    public class AddTwoNumbersTests
    {
        [TestMethod]
        public void GivenTwoNonEmptyLSFLinkedLists_AddTwoNumbers_Should_ReturnTargetLinkedLists()
        {
            var listNode1 = new LinkedListBuilder().ConstructFromArray(new int[] { 2, 4, 3 }).Head;
            var listNode2 = new LinkedListBuilder().ConstructFromArray(new int[] { 5, 6, 4 }).Head;

            ListNode result = AddTwoNumbers(listNode1, listNode2);

            Assert.IsTrue(result.Value == 7);
            result = result.Next;
            Assert.IsTrue(result.Value == 0);
            result = result.Next;
            Assert.IsTrue(result.Value == 8);
        }

        [TestMethod]
        public void GivenTwoNonEmptyLSFLinkedListsOfUnevenLength_AddTwoNumbers_Should_ReturnTargetLinkedLists()
        {
            var listNode1 = new LinkedListBuilder().ConstructFromArray(new int[] { 2, 4, 3 }).Head;
            var listNode2 = new LinkedListBuilder().ConstructFromArray(new int[] { 5, 6 }).Head;

            ListNode result = AddTwoNumbers(listNode1, listNode2);

            Assert.IsTrue(result.Value == 7);
            result = result.Next;
            Assert.IsTrue(result.Value == 0);
            result = result.Next;
            Assert.IsTrue(result.Value == 4);
        }

        private ListNode AddTwoNumbers(ListNode listNode1, ListNode listNode2)
        {
            var carry = 0;

            var list = new List<int>(); // either have this or use a stack to recursively maintain head
            while (true)
            {
                if (listNode1 == null && listNode2 == null)
                {
                    break;
                }

                var value1 = GetValueForListNode(ref listNode1);
                var value2 = GetValueForListNode(ref listNode2);

                var temp = value1 + value2 + carry;
                carry = temp >= 10 ? 1 : 0;

                list.Add(temp >= 10 ? temp - 10 : temp);
            }

            return new LinkedListBuilder().ConstructFromArray(list.ToArray()).Head;
        }

        private int GetValueForListNode(ref ListNode listNode)
        {
            var retVal = listNode == null ? 0 : listNode.Value;

            if (listNode != null)
            {
                listNode = listNode.Next;
            }
            
            return retVal;
        }
    }
}