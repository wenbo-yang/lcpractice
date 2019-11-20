using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC315_CountNumberSmallerThanSelf
{
    [TestClass]
    // sort with index
    public class CountNumberSmallerThanSelfTests
    {
        [TestMethod]
        public void GivenArray_CountNumberSmallerThanSelf_ShouldReturnCorrectArray()
        {
            var input = new int[] {1, 5, 2, 6, 1 };

            var result = CountNumberSmallerThanSelf(input);
            
            Assert.IsTrue(result.SequenceEqual(new int[] { 0, 2, 1, 1, 0 }));
        }
        [TestMethod]
        public void GivenAnotherArray_CountNumberSmallerThanSelf_ShouldReturnCorrectArray()
        {
            var input = new int[] { 6, 5, 2, 1, 1 };

            var result = CountNumberSmallerThanSelf(input);

            Assert.IsTrue(result.SequenceEqual(new int[] { 4, 3, 2, 0, 0 }));
        }


        private int[] CountNumberSmallerThanSelf(int[] input)
        {
            var result = new int[input.Length];

            var list = new List<Tuple<int, int>>();

            for (int i = 0; i < input.Length; i++)
            {
                list.Add(new Tuple<int, int>(input[i], i));
            }

            list.Sort();

            var diff = new int[input.Length];
            diff[0] = list[0].Item1 == input[0] ? 0 : 1;

            for (int i = 1; i < input.Length; i++)
            {
                diff[i] = diff[i - 1] + (list[i].Item1 == input[i] ? 0 : 1);
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item2 == list.Count - 1)
                {
                    continue;
                }

                result[list[i].Item2] = diff[i];
            }

            return result;
        }
    }
}
