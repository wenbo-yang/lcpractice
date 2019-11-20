using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC205_IsomorphicStrings
{
    [TestClass]
    public class IsomorphicStringsTests
    {
        [TestMethod]
        public void GivenTwoIsomorphicStrings_IsIsomorphicString_ShouldReturnTrue()
        {
            var s1 = "title";
            var s2 = "paper";

            var result = IsIsomorphicString(s1, s2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoNonIsomorphicStrings_IsIsomorphicString_ShouldReturnTrue()
        {
            var s1 = "foo";
            var s2 = "bar";
            
            var result = IsIsomorphicString(s1, s2);

            Assert.IsFalse(result);
        }

        private bool IsIsomorphicString(string s1, string s2)
        {
            if ((s1 == null && s2 == null) || (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2)))
            {
                return true;
            }

            if (s1.Length != s2.Length)
            {
                return false;
            }

            var mappingTable = new Dictionary<char, char>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (!mappingTable.ContainsKey(s1[i]))
                {
                    mappingTable.Add(s1[i], s2[i]);
                }

                if (mappingTable[s1[i]] != s2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
