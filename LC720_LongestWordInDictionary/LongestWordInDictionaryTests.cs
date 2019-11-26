using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC720_LongestWordInDictionary
{
    [TestClass]
    public class LongestWordInDictionaryTests
    {
        [TestMethod]
        public void GivenDictionaryList_GetLongestWord_ShouldReturnLongestWord()
        {
            var dictionary = new List<string> { "w", "wo", "wor", "worl", "world" };

            var result = GetLongestWord(dictionary);

            Assert.IsTrue(result == "world");
        }

        [TestMethod]
        public void GivenAnotherDictionaryList_GetLongestWord_ShouldReturnLongestWord()
        {
            var dictionary = new List<string> { "a", "banana", "app", "appl", "ap", "apply", "apple" };

            var result = GetLongestWord(dictionary);

            Assert.IsTrue(result == "apple");
        }

        private string GetLongestWord(List<string> dictionary)
        {
            var set = new HashSet<string>();

            foreach (var word in dictionary)
            {
                set.Add(word);
            }

            var queue = new Queue<string>();
            queue.Enqueue("");

            var currentMax = "";
            do
            {
                var top = queue.Dequeue();

                if (top.Length > currentMax.Length)
                {
                    currentMax = top;
                }

                for (int i = 0; i < 26; i++)
                {
                    var target = $"{top}{((char)(i + 'a')).ToString()}";
                    if (set.Contains(target))
                    {
                        queue.Enqueue(target);
                    }
                }
            }
            while (queue.Count != 0);

            return currentMax;
        }
    }
}
