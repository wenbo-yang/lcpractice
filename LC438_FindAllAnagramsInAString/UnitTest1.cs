using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC438_FindAllAnagramsInAString
{
    [TestClass]
    public class FindAllAnagramsInStringTests
    {
        [TestMethod]
        public void GivenStringAndTarget_FindAllAnagrams_ShouldFindAllAnagrams()
        {
            var source = "cbaebabacd";
            var target = "abc";

            var result = FindAllAnagrams(source, target);
            Assert.IsTrue(result.SequenceEqual(new List<int> { 0, 6 }));
        }

        private List<int> FindAllAnagrams(string source, string target)
        {
            var left = 0; var right = 0;

            var targetTable = GenerateTargetTable(target);
            var sourceTable = new Dictionary<char, int>();
            var result = new List<int>();
            while (right < source.Length)
            {
                if (right - left < source.Length)
                {
                    AddToTable(sourceTable, source[right]);
                }

                if (right - left == target.Length - 1)
                {
                    if (IsMatching(sourceTable, targetTable))
                    {
                        result.Add(left);
                    }

                    DecrementAndCleanSourceTable(sourceTable, source[left]);

                    left++;
                }

                right++;
            }

            return result;
        }

        private void DecrementAndCleanSourceTable(Dictionary<char, int> sourceTable, char c)
        {
            sourceTable[c]--;
            if (sourceTable[c] == 0)
            {
                sourceTable.Remove(c);
            }
        }

        private bool IsMatching(Dictionary<char, int> sourceTable, Dictionary<char, int> targetTable)
        {
            foreach (var pair in sourceTable)
            {
                var c = pair.Key;
                if (!targetTable.ContainsKey(c))
                {
                    return false;
                }

                if (targetTable[c] != sourceTable[c])
                {
                    return false;
                }
            }

            return true;
        }

        private void AddToTable(Dictionary<char, int> table, char c)
        {
            if (!table.ContainsKey(c))
            {
                table.Add(c, 0);
            }
            table[c]++;
        }

        private Dictionary<char, int> GenerateTargetTable(string target)
        {
            var targetTable = new Dictionary<char, int>();
            foreach (var c in target)
            {
                AddToTable(targetTable, c);
            }

            return targetTable;
        }
    }
}
