using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC242_ValidAnagram
{
    [TestClass]
    public class ValidAnagramTests
    {
        [TestMethod]
        public void GivenAnagram_ValidateAnagram_ShouldReturnCorrectAnswer()
        {
            bool result = ValidateAnagram("anagram", "nagaram");
            Assert.IsTrue(result);
        }

        private bool ValidateAnagram(string v1, string v2)
        {
            if (v1 == null || v2 == null ||  v1.Length != v2.Length)
            {
                return false;
            }

            var table = new Dictionary<char, int>();

            foreach (var ch in v1)
            {
                if (!table.ContainsKey(ch))
                {
                    table.Add(ch, 0);
                }

                table[ch]++;
            }

            foreach (var ch in v2)
            {
                if (!table.ContainsKey(ch))
                {
                    return false;
                }

                table[ch]--;
            }

            return !table.Any(item => item.Value != 0);
        }
    }
}
