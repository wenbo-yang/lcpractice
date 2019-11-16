using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC953_VerifyingAnAlienDictionary
{
    [TestClass]
    public class VerifyingAlienDictionaryTests
    {
        [TestMethod]
        public void GivenValidWordAndAlienDictionary_IsAlienWordSorted_ShouldReturnTrue()
        {
            var words = new string[] { "hello", "leetcode" };
            var order = "hlabcdefgijkmnopqrstuvwxyz";

            var result = IsAlienWordSorted(words, order);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNotSortedWordAndAlienDictionary_IsAlienWordSorted_ShouldReturnFalse()
        {
            var words = new string[] { "word", "world", "row" };
            var order = "worldabcefghijkmnpqstuvxyz";

            var result = IsAlienWordSorted(words, order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenMatchingWordWithFirstWordLongerThanSecond_IsAlienWordSorted_ShouldReturnFalse()
        {
            var words = new string[] { "apple", "app" };
            var order = "abcdefghijklmnopqrstuvwxyz";

            var result = IsAlienWordSorted(words, order);

            Assert.IsFalse(result);
        }

        private bool IsAlienWordSorted(string[] words, string order)
        {
            for (int i = 1; i < words.Length; i++)
            {
                var prev = words[i - 1];
                var current = words[i];
                var size = Math.Min(prev.Length, current.Length);
                var isSubSet = true;
                for (int j = 0; j < size; j++)
                {
                    if (prev[j] != current[j])
                    {
                        isSubSet = false;

                        var sorted = IsABeforeB(prev[j], current[j], order);

                        if (!sorted)
                        {
                            return false;
                        }

                        break;
                    }
                }

                if (isSubSet && prev.Length > current.Length)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsABeforeB(char a, char b, string order)
        {
            var foundB = false;
            var foundA = false;

            for (int i = 0; i < order.Length; i++)
            {
                if (order[i] == a && !foundB)
                {
                    return true;
                }
                else if (order[i] == b && !foundA)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
