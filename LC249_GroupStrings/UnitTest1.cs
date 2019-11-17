using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC249_GroupStrings
{
    [TestClass]
    public class GroupStringsTests
    {
        [TestMethod]
        public void GivenListOfStrings_GroupShiftedStrings_ShouldGroupShiftedStrings()
        {
            var input = new string[] { "abc", "bcd", "acef", "xyz", "az", "ba", "a", "z" };

            var result = GroupShiftedStrings(input);

            Assert.IsTrue(result[0].SequenceEqual(new List<string> { "abc", "bcd", "xyz" }));
            Assert.IsTrue(result[1].SequenceEqual(new List<string> { "acef" }));
            Assert.IsTrue(result[2].SequenceEqual(new List<string> { "az", "ba" }));
            Assert.IsTrue(result[3].SequenceEqual(new List<string> { "a", "z" }));
        }

        private List<List<string>> GroupShiftedStrings(string[] input)
        {
            var result = new List<List<string>>();

            var originalList = ParseIntoSet(input);

            do
            {
                result.Add(new List<string>());
                var current = originalList.First();
                var tempSet = GenerateAccordingToOriginalTarget(current);

                foreach (var item in tempSet)
                {
                    if (originalList.Contains(item))
                    {
                        result[result.Count - 1].Add(item);
                        originalList.Remove(item);
                    }
                }
            }
            while (originalList.Count != 0);

            return result;
        }

        private string[] GenerateAccordingToOriginalTarget(string current)
        {
            var result = new string[26];
            result[0] = current;

            for (int i = 1; i < 26; i++)
            {
                var tempChar = new char[current.Length];
                for (int j = 0; j < current.Length; j++)
                {
                    var c = result[i - 1][j] + 1;
                    c = c > 'z' ? c - 26 : c;
                    tempChar[j] = (char)c;
                }

                result[i] = new string(tempChar);
            }

            return result;
        }

        private HashSet<string> ParseIntoSet(string[] input)
        {
            var originalList = new HashSet<string>();
            foreach (var word in input)
            {
                originalList.Add(word);
            }
            return originalList;
        }
    }
}
