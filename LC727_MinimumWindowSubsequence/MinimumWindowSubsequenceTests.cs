using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC727_MinimumWindowSubsequence
{
    [TestClass]
    public class MinimumWindowSubsequenceTests
    {
        [TestMethod]
        public void GivenTargetStringAndSourceString_FindMinimumWindowSubstring_ShouldReturnSubstring()
        {
            var target = "bde";
            var source = "abcdebdde";

            var result = FindMinimumWindowSubstring(source, target);

            Assert.IsTrue(result == "bcde");
        }

        [TestMethod]
        public void GivenAnotherTargetStringAndSourceString_FindMinimumWindowSubstring_ShouldReturnSubstring()
        {
            var target = "bd";
            var source = "abcdebdde";

            var result = FindMinimumWindowSubstring(source, target);

            Assert.IsTrue(result == "bd");
        }

        private string FindMinimumWindowSubstring(string source, string target)
        {
            // param validation

            var result = "";
            var startingIndex = 0;

            do
            {
                startingIndex = FindNextStartingWindow(source, target, startingIndex);

                if (!IsValidWindow(source, target, startingIndex))
                {
                    break;
                }

                var endIndex = MactchingTheRest(source, target, startingIndex + 1);

                if (endIndex == -1)
                {
                    break;
                }

                var frontIndex = MatchingTheRestBackwards(source, target, endIndex);
                var windowedSubstring = source.Substring(frontIndex, endIndex - frontIndex + 1);

                if (string.IsNullOrEmpty(result))
                {
                    result = windowedSubstring;
                }
                else
                {
                    result = windowedSubstring.Length < result.Length ? windowedSubstring : result;
                }

                startingIndex = frontIndex + 1;
            }
            while (startingIndex != -1);

            return result;
        }

        private int MatchingTheRestBackwards(string source, string target, int endIndex)
        {
            var targetIndex = target.Length - 1;
            var frontIndex = -1;
            for (int i = endIndex; i >= 0; i--)
            {
                if (source[i] == target[targetIndex])
                {
                    targetIndex--;

                    if (targetIndex == -1)
                    {
                        frontIndex = i;
                        break;
                    }
                }
            }

            return frontIndex;
        }

        private bool IsValidWindow(string source, string target, int startingIndex)
        {
            return startingIndex != -1 && startingIndex + target.Length <= source.Length;
        }

        private int FindNextStartingWindow(string source, string target, int startIndex)
        {
            for (int i = startIndex; i < source.Length; i++)
            {
                if (source[i] == target[0])
                {
                    return i;
                }
            }

            return -1;
        }

        private int MactchingTheRest(string source, string target, int startingIndex)
        {
            var targetIndex = 1;
            var endIndex = -1;

            for (int i = startingIndex; i < source.Length; i++)
            {
                if (source[i] == target[targetIndex])
                {
                    targetIndex++;                    

                    if (targetIndex == target.Length)
                    {
                        endIndex = i;
                        break;
                    }
                }
            }

            return endIndex;
        }
    }
}
