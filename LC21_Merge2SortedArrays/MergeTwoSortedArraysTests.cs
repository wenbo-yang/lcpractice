using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC21_Merge2SortedArrays
{
    // See the MergeKSortedArrays using heap
    // Merge two arrays are doing simple comparisons. 
    // this is to practice in place merge
    [TestClass]
    public class MergeTwoSortedArraysTests
    {
        [TestMethod]
        public void GivenTwoSortedArrays_Merge_ShouldMergeTwoArrays()
        {
            var list1 = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 2, 3 }).Head;
            var list2 = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 1, 2 }).Head;

            ListNode list3 = MergeTwoSortedArrays(list1, list2);

            var result = LinkedListBuilder.GetList(list3);
            Assert.IsTrue(result.Count == 6);
            Assert.IsTrue(result[0] == 1);
            Assert.IsTrue(result[1] == 1);
            Assert.IsTrue(result[2] == 1);
            Assert.IsTrue(result[3] == 2);
            Assert.IsTrue(result[4] == 2);
            Assert.IsTrue(result[5] == 3);
        }

        private ListNode MergeTwoSortedArrays(ListNode list1, ListNode list2)
        {
            var tempHead1 = list1.Value >= list2.Value ? list1 : list2;
            var tempHead2 = list1.Value < list2.Value ? list1 : list2;

            // initialize prev head so it doesn't have to be in loop
            var tempNode2 = tempHead2.Next;
            tempHead2.Next = tempHead1;
            var prevHead1 = tempHead2;
            tempHead2 = tempNode2;

            var result = prevHead1;

            // merge 2 into 1;
            while (tempHead1 != null)
            {
                if (tempHead2 == null)
                {
                    break;
                }

                if (tempHead1.Value >= tempHead2.Value)
                {
                    tempNode2 = tempHead2.Next;
                    tempHead2.Next = tempHead1;
                    prevHead1.Next = tempHead2;
                    prevHead1 = tempHead2;
                    tempHead2 = tempNode2;
                    continue;
                }

                prevHead1 = tempHead1;
                tempHead1 = tempHead1.Next;
            }

            return result;
        }
    }
}
