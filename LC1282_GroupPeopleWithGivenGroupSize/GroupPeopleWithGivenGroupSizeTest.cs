using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1282_GroupPeopleWithGivenGroupSize
{
    [TestClass]
    public class GroupPeopleWithGivenGroupSizeTest
    {
        [TestMethod]
        public void GivenBelongToGroupsTableOfOnlyOneGroup_GroupPeople_ShouldReturnCorrectGrouping()
        {
            var groupSizes = new int[] { 1, 1, 1, 1, 1, 1, 1 };

            var result = GroupPeople(groupSizes);

            Assert.IsTrue(result.Count == 7);
        }

        [TestMethod]
        public void GivenAnotherSetOfGroupSizes_GroupPeople_ShouldReturnCorrectGrouping()
        {
            var groupSizes = new int[] { 3, 3, 3, 3, 3, 1, 3 };

            var result = GroupPeople(groupSizes);

            Assert.IsTrue(result.Count == 3);
        }

        private List<List<int>> GroupPeople(int[] groupSizes)
        {
            var table = new Dictionary<int, List<List<int>>>();
            var result = new List<List<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                if (!table.ContainsKey(groupSizes[i]))
                {
                    table.Add(groupSizes[i], new List<List<int>>());
                    table[groupSizes[i]].Add(new List<int>());
                }

                var last = table[groupSizes[i]].Count - 1;
                var size = table[groupSizes[i]][last].Count;

                if (size == groupSizes[i])
                {
                    last++;
                    table[groupSizes[i]].Add(new List<int>());
                }

                table[groupSizes[i]][last].Add(i);
            }

            foreach (var pair in table)
            {
                result.AddRange(pair.Value);
            }

            return result;
        }
    }
}
