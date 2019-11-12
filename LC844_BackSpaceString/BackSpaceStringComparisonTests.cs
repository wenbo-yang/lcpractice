using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC844_BackSpaceString
{
    [TestClass]
    public class BackSpaceStringComparisonTests
    {
        [TestMethod]
        public void GivenTwoMatchingStrings_IsEqual_ShouldReturnTrue()
        {
            var s1 = "ab#c";
            var s2 = "ad#c";

            var result = IsEqual(s1, s2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoWouldBeEmptyStrings_IsEqual_ShouldReturnTrue()
        {
            var s1 = "a##c#";
            var s2 = "a##c#";

            var result = IsEqual(s1, s2);

            Assert.IsTrue(result);
        }

        private bool IsEqual(string s1, string s2)
        {
            var i = s1.Length - 1;
            var j = s2.Length - 1;
            var s1BackCount = 0;
            var s2BackCount = 0;

            while (i >= 0 || j >= 0)
            {
                while (i >= 0) // process s1
                {
                    if (s1[i] == '#')
                    {
                        s1BackCount++;
                    }
                    else if (s1BackCount != 0)
                    {
                        s1BackCount--;
                    }
                    else
                    {
                        break;
                    }

                    i--;
                }

                while (j >= 0) // process s2
                {
                    if (s2[j] == '#')
                    {
                        s2BackCount++;
                    }
                    else if (s2BackCount != 0)
                    {
                        s2BackCount--;
                    }
                    else
                    {
                        break;
                    }

                    j--;
                }

                if (i == -1 && j == -1)
                {
                    break;
                }

                if (s1[i] != s1[j])
                {
                    return false;
                }

                i--; j--;
            }

            return i == j;
        }
    }
}
