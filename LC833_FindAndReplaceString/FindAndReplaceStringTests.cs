using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC833_FindAndReplaceString
{
    [TestClass]
    public class FindAndReplaceStringTests
    {
        [TestMethod]
        public void GivenStringAndTargetToReplace_Replace_ShouldReturnCorrectString()
        {
            var input = "abcd";
            var startIndices = new int[] { 0, 2 };
            var sources = new string[] { "ab", "ec" };
            var targets = new string[] { "eee", "ffff" };

            var result = FindAndReplaceString(input, startIndices, sources, targets);

            Assert.IsTrue(result == "eeecd");
        }

        private string FindAndReplaceString(string input, int[] startIndices, string[] sources, string[] targets)
        {
            var bundle = new List<Tuple<int, string, string>>();
            for (int i = 0; i < startIndices.Length; i++)
            {
                bundle.Add(new Tuple<int, string, string>(startIndices[i], sources[i], targets[i]));
            }

            bundle.Sort();

            return FindAndReplaceStringHelper(input, bundle);
        }

        private string FindAndReplaceStringHelper(string input, List<Tuple<int, string, string>> bundle)
        {
            var tempList = new List<char>();
            var currentTarget = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (currentTarget < bundle.Count && i == bundle[currentTarget].Item1 && Matches(input, i, bundle[currentTarget].Item2))
                {    
                    tempList.AddRange(bundle[currentTarget].Item3.ToCharArray());
                    i = i + bundle[currentTarget++].Item2.Length - 1;
                    continue;
                }

                tempList.Add(input[i]);
            }

            return new string(tempList.ToArray());
        }

       
        private bool Matches(string input, int startIndex, string target)
        {
            var j = 0;
            var end = startIndex + target.Length;
            for (int i = startIndex; i < end; i++)
            {
                if (input[i] != target[j++])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
