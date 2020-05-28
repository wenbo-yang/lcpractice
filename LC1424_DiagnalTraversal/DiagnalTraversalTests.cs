using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1424_DiagnalTraversal
{
    [TestClass]
    public class DiagnalTraversalTests
    {
        [TestMethod]
        public void GivenListOfSameLength_DiagnalTraversal_ShouldReturnCorrectTraversalOrder()
        {
            var nums = new List<List<int>> { new List<int> { 1, 2, 3 }, new List<int> { 4, 5, 6 }, new List<int> { 7, 8, 9 } };

            var result = DiagnalTraversal(nums);

            Assert.IsTrue(result.SequenceEqual(new int[] { 1, 4, 2, 7, 5, 3, 8, 6, 9 }));
        }

        [TestMethod]
        public void GivenAnotherListOfVariousLength_DiagnalTraversal_ShouldReturnCorrectTraversalOrder()
        {
            var nums = new List<List<int>> { new List<int> { 1, 2, 3 }, new List<int> { 4 }, new List<int> { 5, 6, 7 }, new List<int> { 8}, new List<int> { 9, 10, 11} };

            var result = DiagnalTraversal(nums);

            Assert.IsTrue(result.SequenceEqual(new int[] { 1,4,2,5,3,8,6,9,7,10,11 }));
        }

        private int[] DiagnalTraversal(List<List<int>> nums)
        {
            var table = new List<Stack<int>>();
            var maxColumn = 0;
             
            for (int i = 0; i < nums.Count; i++)
            {
                maxColumn = Math.Max(maxColumn, nums[i].Count);
                for (int j = 0; j < nums[i].Count; j++)
                {
                    while (table.Count <= i + j)
                    {
                        table.Add(new Stack<int>());
                    }
                    table[i + j].Push(nums[i][j]);
                }
            }

            var result = new List<int>();
            for (int i = 0; i < table.Count; i++)
            {
                result.AddRange(table[i].ToArray());
            }

            return result.ToArray();
        }
    }
}
