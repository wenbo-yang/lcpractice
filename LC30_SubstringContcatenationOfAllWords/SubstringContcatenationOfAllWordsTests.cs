using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC30_SubstringContcatenationOfAllWords
{
    [TestClass]
    public class SubstringContcatenationOfAllWordsTests
    {
        [TestMethod]
        public void GivenListOfStringsOfSameLength_Find_ShouldReturnIndices()
        {
            var target = "barfoothefoobarman";
            var words = new string[] { "foo", "bar" };

            var results = FindIndices(target, words);

            Assert.IsTrue(results.Count == 2);
            Assert.IsNotNull(results.Single(index => index == 0));
            Assert.IsNotNull(results.Single(index => index == 9));
        }

        private List<int> FindIndices(string target, string[] words)
        {
            var windowLength = words[0].Length;
            var numWords = words.Length;
            
            var validIndices = new List<int>();
            foreach (var word in words)
            {

                var index = 0; 
                do
                {
                    index = target.IndexOf(word, index);
                    
                    if (index != -1)
                    {
                        var valid = IsWindowMatching(target, words, windowLength, index);
                        if (valid)
                        {
                            validIndices.Add(index);
                        }

                        index = index + word.Length;
                    }

                } while (index != -1);
            }

            return validIndices;
        }

        private HashSet<string> InitializeHashSet(string[] words)
        {
            var hashSet = new HashSet<string>();
            foreach (var word in words)
            {
                hashSet.Add(word);
            }

            return hashSet;
        }

        private bool IsWindowMatching(string target, string[] words, int windowLength, int startIndex)
        {
            bool result = true;
            int index = startIndex;

            var hashSet = InitializeHashSet(words);
            
            while (index + windowLength < target.Length && hashSet.Count > 0)
            {
                var substring = target.Substring(index, windowLength);

                if (hashSet.Contains(substring))
                {
                    index += windowLength;
                    hashSet.Remove(substring);
                }
                else
                {
                    result = false;
                    break;
                }

            }

            return result && hashSet.Count == 0;
        }
    }
}
