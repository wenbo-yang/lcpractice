using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC392_IsSubsequence
{
    [TestClass]
    public class IsSubsequenceTests
    {
        [TestMethod]
        public void GiveSourceStringAndTargetString_IsSubsequence_ShouldReturnCorrectAnswer()
        {
            var source = "abc";
            var target = "ahbgdc";

            var result = IsSubsequence(source, target);

            Assert.IsTrue(result);
        }

        private bool IsSubsequence(string source, string target)
        {
            var i = 0;
            var j = 0;

            while (i < source.Length && j < target.Length)
            {
                if (source[i] == target[j])
                {
                    i++;
                }

                j++;
            }

            return i == source.Length;
        }
    }
}
