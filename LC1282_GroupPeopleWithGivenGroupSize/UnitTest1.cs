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
            var table = new Dictionary<int, List<int>>();
            var result = new List<List<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                if (!table.ContainsKey(groupSizes[i]))
                {
                    table.Add(groupSizes[i], new List<int>());
                }

                table[groupSizes[i]].Add(i);
            }


            foreach (var pair in table)
            {
                var perGroup = GetGroupingPerTableEntry(pair.Key, pair.Value);
                result.AddRange(perGroup);
            }

            return result;
        }

        private List<List<int>> GetGroupingPerTableEntry(int numPerGroup, List<int> memberIds)
        {
            var numberOfGroups = memberIds.Count / numPerGroup;

            var result = new List<int>[numberOfGroups];
            var index = 0;
            for (int i = 0; i < numberOfGroups; i++)
            {
                result[i] = new List<int>();
                while (result[i].Count != numPerGroup)
                {
                    result[i].Add(memberIds[index++]);        
                }
            }

            return new List<List<int>>(result);
        }
    }
}
