using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC804_UniqueMorseCodeWords
{
    [TestClass]
    public class UniqueMorseCodeWords
    {
        [TestMethod]
        public void GivenMorseCodeListAndSetOfWords_GetUniqueMorseCode_ShouldReturnCorrectNumber()
        {
            var morseArray = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            var wordList = new string[] { "gin", "zen", "gig", "msg" };

            var result = GetUniqueMorseCode(morseArray, wordList);

            Assert.IsTrue(result == 2);
        }

        private int GetUniqueMorseCode(string[] morseArray, string[] wordList)
        {
            var set = new HashSet<string>();
            foreach (var word in wordList)
            {
                var list = new List<string>();
                foreach (var c in word)
                {
                    list.Add(morseArray[c - 'a']);
                }

                set.Add(string.Join("", list));
            }

            return set.Count;
        }
    }
}
