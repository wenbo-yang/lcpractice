using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CombinationOfAPhoneNumber
{

    // DFS not much to say
    [TestClass]
    public class CombinationOfAPhoneNumberTests
    {
        [TestMethod]
        public void GivenInputOf23_Combination_ShouldReturn9Results()
        {
            var input = "23";

            var result = CombinationOfPhoneNumbers(input);

            Assert.IsTrue(result.Count == 9);
            Assert.IsTrue(result[0] == "ad");
            Assert.IsTrue(result[1] == "ae");
            Assert.IsTrue(result[2] == "af");
            Assert.IsTrue(result[3] == "bd");
            Assert.IsTrue(result[4] == "be");
            Assert.IsTrue(result[5] == "bf");
            Assert.IsTrue(result[6] == "cd");
            Assert.IsTrue(result[7] == "ce");
            Assert.IsTrue(result[8] == "cf");
        }

        private List<string> CombinationOfPhoneNumbers(string input)
        {
            var table = ConstructMappingTable();
            var results = new List<string>();

            Dfs(results, table, "", input, 0);

            return results;
        }

        private void Dfs(List<string> results, Dictionary<char, List<char>> table, string tempResult, string inputString, int currentDepth)
        {
            if (currentDepth == inputString.Length)
            {
                var result = tempResult;
                results.Add(result);
                return;
            }

            var mapping = table[inputString[currentDepth]];

            foreach (var item in mapping)
            {
                Dfs(results, table, tempResult + item, inputString, currentDepth + 1);
            }
        }

        private Dictionary<char, List<char>> ConstructMappingTable()
        {
            var table = new Dictionary<char, List<char>>();
            table.Add('2', new List<char> { 'a', 'b', 'c' });
            table.Add('3', new List<char> { 'd', 'e', 'f' });
            table.Add('4', new List<char> { 'g', 'h', 'i' });
            table.Add('5', new List<char> { 'j', 'k', 'l' });
            table.Add('6', new List<char> { 'm', 'n', 'o' });
            table.Add('7', new List<char> { 'p', 'q', 'r', 's' });
            table.Add('8', new List<char> { 't', 'u', 'v' });
            table.Add('9', new List<char> { 'w', 'x', 'y', 'z' });

            return table;
        }
    }
}
