using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC75_SortColors
{
    [TestClass]
    public class SortColorsTests
    {
        [TestMethod]
        // use hash table of 3
        public void GivenColorArray_SortColorTwoPass_ShouldSortColor()
        {
            var input = new int[] { 2, 0, 2, 1, 1, 0 };
            SortColorTwoPass(input);

            Assert.IsTrue(input.SequenceEqual(new int[] { 0, 0, 1, 1, 2, 2 }));
        }

        [TestMethod]
        public void GivenColorArray_SortColorOnePass_ShouldSortColor()
        {
            var input = new int[] { 2, 0, 2, 1, 1, 0 };
            SortColorOnePass(input);

            Assert.IsTrue(input.SequenceEqual(new int[] { 0, 0, 1, 1, 2, 2 }));
        }

        // swap 2 and 0  but leave one
        private void SortColorOnePass(int[] input)
        {
            int red = 0;
            int blue = input.Length - 1;

            for (int i = 0; i < blue + 1;)
            {
                if (input[i] == 0)
                {
                    var temp = input[i];
                    input[i] = input[red];
                    input[red] = temp;
                    i++;
                    red++;
                }
                else if (input[i] == 2)
                {
                    var temp = input[blue];
                    input[blue] = input[i];
                    input[i] = temp;
                    blue--;
                }
                else
                {
                    i++;
                }
            }

        }

        private void SortColorTwoPass(int[] input)
        {
            var table = new Dictionary<int, int>() { { 0, 0 }, { 1, 0 }, { 2, 0 } };

            for (int i = 0; i < input.Length; i++)
            {
                table[input[i]]++;
            }

            var index = 0;
            for(int i = 0; i <= 2; i++)
            {
                if (table[i] == 0)
                {
                    continue;
                }

                for (int j = index; j < table[i] + index; j++)
                {
                    input[j] = i;
                }

                index = table[i] + index;
            }
        }
    }
}
