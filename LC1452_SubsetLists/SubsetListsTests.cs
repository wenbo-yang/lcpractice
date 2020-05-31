using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1452_SubsetLists
{
    [TestClass]
    public class SubsetListsTests
    {
        [TestMethod]
        public void GivenLists_NonSubsetLists_ShouldReturnCorrectLists()
        {
            var lists = new List<List<string>> { new List<string> { "leetcode", "google", "facebook" }, new List<string> { "google", "microsoft" }, new List<string> { "google", "facebook" }, new List<string> { "google" }, new List<string> { "amazon" } };
            var result = NonSubsetLists(lists);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 0, 1, 4 }));
        }

        private List<int> NonSubsetLists(List<List<string>> favoriteCompanies)
        {
            var lists = favoriteCompanies;
            var array = InitializeArray(lists);

            var result = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                var j = i + 1;
                while(j < array.Length)
                {
                    if (array[i].set.Intersect(array[j].set).Count() == array[i].set.Count)
                    {
                        break;
                    }
                    j++;
                }

                if (j == array.Length)
                {
                    result.Add(array[i].index);
                }
            }
            result.Sort();
            return result;
        }

        private (int index, HashSet<int> set)[] InitializeArray(List<List<string>> lists)
        {
            var index = 0;
            var table = new Dictionary<string, int>();

            for (int i = 0; i < lists.Count(); i++)
            {
                foreach (var item in lists[i])
                {
                    if (!table.ContainsKey(item))
                    {
                        table.Add(item, index++);
                    }
                }
            }

            var array = new (int index, HashSet<int> set)[lists.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (i, new HashSet<int>());
                for (int j = 0; j < lists[i].Count; j++)
                {
                    array[i].set.Add(table[lists[i][j]]);
                }
            }

            array = array.OrderBy(x => x.set.Count).ToArray();
            return array;
        }
    }
}
