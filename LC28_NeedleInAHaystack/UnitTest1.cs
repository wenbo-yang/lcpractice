using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC28_NeedleInAHaystack
{
    [TestClass]
    public class NeedleInAHaystackTests
    {
        [TestMethod]
        public void GivenEmptyStringNeedle_FindNeedle_Should_Return0()
        {
            var needle = "";
            var haystack = "somestring";

            int result = FindNeedle(haystack, needle);

            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void GivenSomeNeedle_FindNeedle_Should_Return0()
        {
            var needle = "str";
            var haystack = "someststring";

            int result = FindNeedle(haystack, needle);

            Assert.IsTrue(result == 6);
        }

        private int FindNeedle(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            var result = -1;
            var hayIndex = 0;

            while (hayIndex < haystack.Length)
            {
                if (haystack[hayIndex] != needle[0])
                {
                    hayIndex++;
                }
                else 
                {
                    int numMatching = TryMatching(haystack, hayIndex, needle);

                    if (numMatching == needle.Length)
                    {
                        result = hayIndex;
                        break;
                    }
                    else
                    {
                        hayIndex += numMatching;
                    }
                }
            }

            return result;
        }

        private int TryMatching(string haystack, int hayIndex, string needle)
        {
            var retVal = 0;

            for (int i = 0; i < needle.Length; i++)
            {
                if (haystack[hayIndex] == needle[i])
                {
                    hayIndex++;
                    retVal++;
                }
                else
                {
                    break;
                }
            }

            return retVal;
        }
    }
}
