using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC854_KSimiliarStrings
{
    [TestClass]
    public class KSimiliarStringsTests
    {
        // we can arrange the letter into any order by swaping at most n times
        [TestMethod]
        public void GivenTwoAnagrams_FindSmallestSwap_ShouldReturnCorrectNumber()
        {
            var inputA = "ab";
            var inputB = "ba";

            var result = FindSmallestSwapSuperGreedy(inputA, inputB);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void GivenAnotherValidAnagrams_FindSmallestSwap_ShouldReturnCorrectNumber()
        {
            var inputA = "abac";
            var inputB = "baca";

            var result = FindSmallestSwapSuperGreedy(inputA, inputB);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void GivenAnotherAnagrams_FindSmallestSwap_ShouldReturnCorrectNumber()
        {
            var inputA = "aabbccddee";
            var inputB = "cbeddebaac";

            var result = FindSmallestSwapSuperGreedy(inputA, inputB);

            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void GivenAnotherValidAnagrams_FindSmallestSwapGreedy_ShouldReturnCorrectNumber()
        {
            var inputA = "abac";
            var inputB = "baca";

            var result = FindSmallestSwapGreedy(inputA, inputB);

            Assert.IsTrue(result == 2);
        }

        private int FindSmallestSwapSuperGreedy(string inputA, string inputB)
        {
            // step 1 find all the all dupes
            var matched = GetAllMatchingIndices(inputA, inputB);
            if (matched.Count == inputA.Length)
            {
                return 0;
            }

            var swaps = 0;
            var index = FindFirstUnmatching(inputA, inputB, matched);

            var candidates = RetrieveListOfCandidateForSwapping(inputA, inputB, index, matched);

            var subSwap = int.MaxValue;
            foreach (var candidate in candidates)
            {
                var charArrayA = inputA.ToCharArray();
                Swap(charArrayA, index, candidate);
                var modifiedA = new string(charArrayA);
                subSwap = Math.Min(subSwap, FindSmallestSwapSuperGreedy(modifiedA.Substring(index + 1), inputB.Substring(index + 1)));
            }

            swaps = subSwap + 1;
            return swaps;
        }

        private int FindFirstUnmatching(string inputA, string inputB, HashSet<int> matched)
        {
            for (int i = 0; i < inputA.Length; i++)
            {
                if (matched.Contains(i))
                {
                    continue;
                }

                if (inputA[i] != inputB[i])
                {
                    return i;
                }
            }

            return -1;
        }

        private List<int> RetrieveListOfCandidateForSwapping(string inputA, string inputB, int startIndex,  HashSet<int> matched)
        {
            var targetIndices = new List<int>();
            var target = inputB[startIndex];
            var currentCharFromA = inputA[startIndex];
            for (int i = startIndex + 1; i < inputA.Length; i++)
            {
                if (matched.Contains(i))
                {
                    continue;
                }

                if (inputA[i] == target)
                {
                    targetIndices.Add(i);
                    if (currentCharFromA == inputB[i])
                    {
                        matched.Add(i);
                        break;
                    }
                }
            }

            return targetIndices;
        }

        private HashSet<int> GetAllMatchingIndices(string inputA, string inputB)
        {
            var matched = new HashSet<int>();
            for (int i = 0; i < inputA.Length; i++)
            {
                if (inputA[i] == inputB[i])
                {
                    matched.Add(i);
                }
            }

            return matched;
        }

        private void Swap(char[] charArrayA, int currentIndex, int targetIndex)
        {
            var temp = charArrayA[currentIndex];
            charArrayA[currentIndex] = charArrayA[targetIndex];
            charArrayA[targetIndex] = temp;
        }

        private int FindFirstIndex(char[] charArrayA, int startIndex, char target)
        {
            for (int i = startIndex + 1; i < charArrayA.Length; i++)
            {
                if (charArrayA[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        private int FindSmallestSwapGreedy(string inputA, string B)
        {
            int n = inputA.Length, res = n - 1;
            var A = inputA.ToCharArray();
            for (int i = 0; i < n; i++)
            {
                if (A[i] == B[i])
                {
                    continue;
                }

                var matches = new List<int>(); ;

                for (int j = i + 1; j < n; j++)
                {
                    if (A[j] == B[j] || A[j] != B[i])
                    {
                        continue;
                    }

                    matches.Add(j);

                    if (A[i] != B[j])
                    {
                        continue;
                    }

                    Swap(A, i, j);

                    var next = new string(A);
                    return 1 + FindSmallestSwapGreedy(next.Substring(i + 1), B.Substring(i + 1));
                }

                foreach (int j in matches)
                {
                    Swap(A, i, j);
                    var next = new string(A);
                    res = Math.Min(res, 1 + FindSmallestSwapGreedy(next.Substring(i + 1), B.Substring(i + 1)));
                    Swap(A, i, j);
                }
                return res;
            }
            return 0;
        }

    }
}
