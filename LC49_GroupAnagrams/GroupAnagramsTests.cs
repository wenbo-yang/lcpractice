using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC49_GroupAnagrams
{
    [TestClass]
    public class GroupAnagramsTests
    {
        [TestMethod]
        public void GivenListOfWords_Group_ShouldReturnCorrectResults()
        {
            var input = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            List<List<string>> results = Group(input);

            Assert.IsTrue(results.Count == 3);
        }

        private List<List<string>> Group(string[] input)
        {
            var table = new Dictionary<string, List<string>>();

            foreach (var item in input)
            {
                var list = new List<char>(item.ToCharArray());
                list.Sort();
                var sortedString = new string(list.ToArray());
                if (!table.ContainsKey(sortedString))
                {
                    table.Add(sortedString, new List<string>());
                }

                table[sortedString].Add(item);
            }

            var array = new List<string>[table.Count];

            table.Values.CopyTo(array, 0);

            return new List<List<string>>(array);
        }
    }
}
