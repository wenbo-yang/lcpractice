using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1297_MaximumNumberOfOccurencesOfASubstring
{
    [TestClass]
    public class MaximumNumberOfOccurencesOfASubstringTests
    {
        [TestMethod]
        public void GivenStringMinMaxWindowSizeAndMaxUniqueLetters_GetMaxFrequency_ShouldReturnMaxFrequencyOfASubstring()
        {
            var s = "aababcaab"; var maxLetters = 2; var minSize = 3; var maxSize = 4;

            var result = GetMaxFrequency(s, maxLetters, minSize, maxSize);

            Assert.IsTrue(result == 2);
        }

        private int GetMaxFrequency(string s, int maxLetters, int minSize, int maxSize)
        {
            var substringCount = new Dictionary<string, int>();
            var window = new Queue<char>();
            var left = 0;
            var right = 0;
            var charCount = new int[26];

            while (right < s.Length)
            {
                var count = GetUniqueCharCount(charCount);

                if (count >= minSize)
                {
                    AddToDictionary(substringCount, window);
                    right++;
                    charCount[s[right]]++;
                    window.Enqueue(s[right]);

                }
                else if (count > maxLetters || window.Count > maxSize)
                {
                    left++;
                    charCount[s[left]]--;
                    window.Dequeue();
                }
            }

            return substringCount.Values.Max();
        }

        private void AddToDictionary(Dictionary<string, int> substringCount, Queue<char> window)
        {
            var substring = new string(window.ToArray());

            if (!substringCount.ContainsKey(substring))
            {
                substringCount.Add(substring, 0);
            }

            substringCount[substring]++;
        }

        private int GetUniqueCharCount(int[] charCount)
        {
            var count = 0;

            for(int i = 0; i < charCount.Length; i++) 
            {
                if (charCount[i] > 0) count++;
            }

            return count;
        }
    }
}
