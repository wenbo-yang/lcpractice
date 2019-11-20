using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC220_ContainsDuplicate
{
    [TestClass]
    public class ContainsDuplicateTests
    {
        [TestMethod]
        public void GivenValidArrayAndMaxDiffAndMaxDist_CanFindCandidate_ShouldReturnTrue()
        {
            var input = new int[] { 1, 2, 3, 1 };
            var window = 3;
            var diff = 0;
           
            var result = CanFindCandidate(input, window, diff);

            Assert.IsTrue(result);
        }

        private bool CanFindCandidate(int[] input, int window, int diff)
        {
            var sortedSet = new SortedSet<Tuple<int, int>>();
            sortedSet.Add(new Tuple<int, int>(input[0], 0));

            for (int i = 1; i < input.Length; i++)
            {
                var first = sortedSet.First();

                if (Math.Abs(first.Item1 - input[i]) <= diff)
                {
                    return true;
                }
                else
                {
                    sortedSet.Add(new Tuple<int, int>(input[i], i));
                }

                if (sortedSet.Count == window + 1)
                {
                    sortedSet.Remove(new Tuple<int, int>(input[i - window], i - window));
                }
            }


            return false;
        }
    }
}
