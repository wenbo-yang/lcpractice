using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC135_Candy
{
    [TestClass]
    public class GiveCandyToChildrenTests
    {
        [TestMethod]
        public void GivenWeighting_GiveCandy_ShouldGiveCorrectNumberOfCandies()
        {
            var childWeighting = new int[] { 1, 0, 2 };
            var result = GiveCandy(childWeighting);

            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void GivenIncreasingSequence_GiveCandy_ShouldGiveCorrectNumberOfCandies()
        {
            var childWeighting = new int[] { 1, 2, 3 };
            var result = GiveCandy(childWeighting);

            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void GivenMultipleIncreasingSequence_GiveCandy_ShouldGiveCorrectNumberOfCandies()
        {
            var childWeighting = new int[] { 1, 2, 3, 1, 2, 3};
            var result = GiveCandy(childWeighting);

            Assert.IsTrue(result == 12);
        }

        [TestMethod]
        public void GivenIncreasingFlatAndThenIncreasingSequence_GiveCandy_ShouldGiveCorrectNumberOfCandies()
        {
            var childWeighting = new int[] { 1, 2, 3, 3, 4, 5 };
            var result = GiveCandy(childWeighting);

            Assert.IsTrue(result == 12);
        }

        [TestMethod]
        public void GivenDecreasingSequence_GiveCandy_ShouldGiveCorrectNumberOfCandies()
        {
            var childWeighting = new int[] { 2, 2, 2, 2, 0 };
            var result = GiveCandy(childWeighting);

            Assert.IsTrue(result == 9);
        }

        private int GiveCandy(int[] childWeighting)
        {
            if (childWeighting.Length == 1)
            {
                return 1;
            }

            var diff = GetDiff(childWeighting);
            var increasingCount = 0;
            var current = 0;

            var decreasingStack = new Stack<int>();

            for (int i = 0; i < diff.Length; i++)
            {
                if (diff[i] > 0)
                {
                    increasingCount++;
                    CalculateDecreasingStack(decreasingStack, ref current);
                }
                else
                {
                    if (increasingCount != 0)
                    {
                        current += increasingCount + 1;
                    }
                    increasingCount = 0;
                    decreasingStack.Push(diff[i]);
                }
            }

            if (increasingCount != 0)
            {
                current += increasingCount + 1;
            }

            CalculateDecreasingStack(decreasingStack, ref current);

            return current + childWeighting.Length;
        }

        private void CalculateDecreasingStack(Stack<int> decreasingStack, ref int current)
        {
            if (decreasingStack.Count > 1)
            {
                var decreasingCount = 0;
                do
                {
                    var top = decreasingStack.Pop();

                    if (top < 0)
                    {
                        current += decreasingStack.Count + 1;
                    }
                }
                while (decreasingStack.Count > 0);

                if (decreasingCount > 0)
                {
                    current += decreasingCount + 1;
                }
            }
        }

        private int[] GetDiff(int[] childWeighting)
        {
            var diff = new int[childWeighting.Length - 1];

            for (int i = 1; i < childWeighting.Length; i++)
            {
                diff[i - 1] = childWeighting[i] - childWeighting[i - 1];
            }

            return diff;
        }
    }
}
