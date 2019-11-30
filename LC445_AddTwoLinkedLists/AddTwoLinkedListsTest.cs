using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC445_AddTwoLinkedLists
{
    [TestClass]
    public class AddTwoLinkedListsTest
    {
        [TestMethod]
        public void GivenTwoLinkedLists_AddingLinkedList_ShouldReturnTwoLinkedLists()
        {
            var list1 = new LinkedListBuilder().ConstructFromArray(new int[] { 7, 2, 4, 3 }).Head;
            var list2 = new LinkedListBuilder().ConstructFromArray(new int[] { 5, 6, 4 }).Head;

            var result = AddingLinkedListStack(list1, list2);
            Assert.IsTrue(result.Value == 7 && result.Next.Value == 8 && result.Next.Next.Value == 0 && result.Next.Next.Next.Value == 7);
        }

        private ListNode AddingLinkedListStack(ListNode list1, ListNode list2)
        {
            var list1Stack = new Stack<int>();
            var list2Stack = new Stack<int>();

            while (list1 != null)
            {
                list1Stack.Push(list1.Value);
                list1 = list1.Next;
            }

            while (list2 != null)
            {
                list2Stack.Push(list2.Value);
                list2 = list2.Next;
            }

            var carry = 0;

            var resultStack = new Stack<int>();

            ListNode listNodeHead = null;
            while (list1Stack.Count != 0 || list2Stack.Count != 0)
            {
                var result = 0;
                if (list1Stack.Count != 0)
                {
                    result += list1Stack.Pop();
                }

                if (list2Stack.Count != 0)
                {
                    result += list2Stack.Pop();
                }
                result += carry;
                carry = result >= 10 ? 1 : 0;

                listNodeHead = new ListNode { Value = result >= 10 ? result - 10 : result, Next = listNodeHead };       
            }

            return listNodeHead;
        }
    }
}
