using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeKSortedArrays
{
    [TestClass]
    public class MergeKSortedArraysTests
    {
        // binary merge linkedlist or use heap
        [TestMethod]
        public void GivenKSortedArray_MergeArray_ShouldOutputMergedArray()
        {
            var input = new int[][] { new int[] { 2, 4, 4 }, new int[] { 2, 2, 2, 3 }, new int[] { 1, 1 } };

            var result = MergeKSortedArrays(input);

            Assert.IsTrue(result.SequenceEqual(new int[] { 1, 1, 2, 2, 2, 2, 3, 4, 4 }));
        }

        [TestMethod]
        public void GivenKSortedArray_MergeArraySortedDict_ShouldOutputMergedArray()
        {
            var input = new int[][] { new int[] { 2, 4, 4 }, new int[] { 2, 2, 2, 3 }, new int[] { 1, 1 } };

            var result = MergeKSortedArraysSortedDict(input);

            Assert.IsTrue(result.SequenceEqual(new int[] { 1, 1, 2, 2, 2, 2, 3, 4, 4 }));
        }

        [TestMethod]
        public void GivenKSortedArray_MergeArraySortedListWithSortedMap_ShouldOutputMergedArray()
        {
            var list = new ListNode[]
            {
                new ListNode(2, new ListNode(4, new ListNode(4, null))),
                new ListNode(2, new ListNode(2, new ListNode(2, new ListNode(3, null)))),
                new ListNode(1, new ListNode(1, null)),
            };

            var result = MergeKListNodesSortedDictionary(list);
            Assert.IsTrue(result.val == 1);
            result = result.next;
            Assert.IsTrue(result.val == 1);
            result = result.next;
            Assert.IsTrue(result.val == 2);
            result = result.next;
            Assert.IsTrue(result.val == 2);
            result = result.next;
            Assert.IsTrue(result.val == 2);
            result = result.next;
            Assert.IsTrue(result.val == 2);
            result = result.next;
            Assert.IsTrue(result.val == 3);
            result = result.next;
            Assert.IsTrue(result.val == 4);
            result = result.next;
            Assert.IsTrue(result.val == 4);
        }

        [TestMethod]
        public void GivenKSortedArray_MergeArraySortedListNoExtraMemory_ShouldOutputMergedArray()
        {
            var list = new ListNode[]
            {
                new ListNode(2, new ListNode(2, new ListNode(2, new ListNode(3, null)))),
                new ListNode(2, new ListNode(4, new ListNode(4, null))),
                new ListNode(1, new ListNode(1, null)),
            };

            var result = MergeKListNodesNoExtraMemory(list);
            Assert.IsTrue(result.val == 1);
            result = result.next;
            Assert.IsTrue(result.val == 1);
            result = result.next;
            Assert.IsTrue(result.val == 2);
            result = result.next;
            Assert.IsTrue(result.val == 2);
            result = result.next;
            Assert.IsTrue(result.val == 2);
            result = result.next;
            Assert.IsTrue(result.val == 2);
            result = result.next;
            Assert.IsTrue(result.val == 3);
            result = result.next;
            Assert.IsTrue(result.val == 4);
            result = result.next;
            Assert.IsTrue(result.val == 4);
        }

        private ListNode MergeKListNodesNoExtraMemory(ListNode[] list)
        {
            if (list.Length == 1)
            {
                return list[0];
            }

            var listOfListNode = new List<ListNode>();
            for (int i = 0; i < list.Length; i++)
            {
                listOfListNode.Add(list[i]);
            }

            list = null;

            while (listOfListNode.Count > 1)
            {
                for (int i = 0; i < listOfListNode.Count; i = i + 2)
                {
                    listOfListNode[i] = MergeTwoLists(listOfListNode[i], listOfListNode[i + 1]);
                    listOfListNode.RemoveAt(i + 1);
                }

            }

            return listOfListNode[0];
        }

        private ListNode MergeTwoLists(ListNode listNode1, ListNode listNode2)
        {
            var head = listNode1.val < listNode2.val ? listNode1 : listNode2;

            if (listNode1.val < listNode2.val)
            {
                listNode1 = listNode1.next;
            }
            else
            {
                listNode2 = listNode2.next;
            }

            var tail = head;

            while (listNode1 != null || listNode2 != null)
            {
                if (listNode1 == null)
                {
                    tail.next = listNode2;
                    break;
                }

                if (listNode2 == null)
                {
                    tail.next = listNode1;
                    break;
                }

                tail.next = listNode1.val < listNode2.val ? listNode1 : listNode2;
                tail = tail.next;

                if (listNode1.val < listNode2.val)
                {
                    listNode1 = listNode1.next;
                }
                else
                {
                    listNode2 = listNode2.next;
                }
            }

            return head;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        private ListNode MergeKListNodesSortedDictionary(ListNode[] list)
        {
            var sortedMap = new SortedDictionary<int, List<int>>();

            for (int i = 0; i < list.Length; i++)
            {
                AddToSortedMapListNode(sortedMap, list, i);
            }

            ListNode tail = null;
            ListNode head = null;

            while (sortedMap.Count != 0)
            {
                if (head == null)
                {
                    head = new ListNode(sortedMap.First().Key);
                    tail = head;
                }
                else
                {
                    tail.next = new ListNode(sortedMap.First().Key);
                    tail = tail.next;
                }

                var first = sortedMap.First();
                var poppedIndex = first.Value[first.Value.Count - 1];
                sortedMap[first.Key].RemoveAt(first.Value.Count - 1);

                list[poppedIndex] = list[poppedIndex].next;
                AddToSortedMapListNode(sortedMap, list, poppedIndex);

                if (sortedMap[first.Key].Count == 0)
                {
                    sortedMap.Remove(first.Key);
                }
            }

            return head;
        }

        private void AddToSortedMapListNode(SortedDictionary<int, List<int>> sortedMap, ListNode[] list, int i)
        {
            if (list[i] == null)
            {
                return;
            }

            if (!sortedMap.ContainsKey(list[i].val))
            {
                sortedMap.Add(list[i].val, new List<int>());
            }

            sortedMap[list[i].val].Add(i);
        }

        private List<int> MergeKSortedArraysSortedDict(int[][] input)
        {
            var sortedMap = new SortedDictionary<int, List<(int row, int col)>>();

            for (int i = 0; i < input.Length; i++)
            {
                AddToDictionary(sortedMap, input[i][0], i, 0);
            }

            var result = new List<int>();
            
            while (sortedMap.Count != 0)
            {
                result.Add(sortedMap.First().Key);

                RemoveFromAndAddNextToMap(input, sortedMap, sortedMap.First().Key);
            }

            return result;
        }

        private void RemoveFromAndAddNextToMap(int[][] input, SortedDictionary<int, List<(int row, int col)>> sortedMap, int key)
        {
            var rowCol = sortedMap[key][sortedMap[key].Count - 1];
            sortedMap[key].RemoveAt(sortedMap[key].Count - 1);

            if (rowCol.col < input[rowCol.row].Length - 1)
            {
                AddToDictionary(sortedMap, input[rowCol.row][rowCol.col + 1], rowCol.row, rowCol.col + 1);
            }

            if (sortedMap[key].Count == 0)
            {
                sortedMap.Remove(key);
            }
        }

        private void AddToDictionary(SortedDictionary<int, List<(int row, int col)>> sortedMap, int key, int row, int col)
        {
            if (!sortedMap.ContainsKey(key))
            {
                sortedMap.Add(key, new List<(int row, int col)>());   
            }

            sortedMap[key].Add((row, col));
        }

        private List<int> MergeKSortedArrays(int[][] input)
        {
            var result = new List<int>();
            var minHeap = InitializeHeap(input);

            while (minHeap.Count != 0)
            {
                var top = minHeap.Pop();
                result.Add(top.Item1);
                
                if (top.Item3 != input[top.Item2].Length - 1)
                {
                    minHeap.Add(new Tuple<int, int, int>(input[top.Item2][top.Item3 + 1], top.Item2, top.Item3 + 1));
                }
            }

            return result;
        }

        private MinHeap<Tuple<int, int, int>> InitializeHeap(int[][] input)
        {
            var minHeap = new MinHeap<Tuple<int, int, int>>(); // value, row, col

            for (int i = 0; i < input.Length; i++)
            {
                minHeap.Add(new Tuple<int, int, int>(input[i][0], i, 0));
            }

            return minHeap;
        }
    }
}
