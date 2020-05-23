using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC377_CombinationSumIV
{
    [TestClass]
    public class CombinationSumTests
    {
        [TestMethod]
        public void GivenArray_FindAllCombinations_ShouldReturnAllCombinations()
        {
            var array = new int[] { 1, 2, 3};
            var target = 4;

            var result = FindAllCombinations(array, target);

            Assert.IsTrue(result == 7);
        }

        [TestMethod]
        public void GivenArray_FindAllCombinationsRecursion_ShouldReturnAllCombinations()
        {
            var array = new int[] { 1, 2, 3 };
            var target = 4;

            var result = FindAllCombinationsRecursion(array, target);

            Assert.IsTrue(result == 7);
        }


        private int FindAllCombinations(int[] array, int target)
        {
            var table = new int[target + 1];
            table[0] = 1;
            Array.Sort(array);

            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] > i)
                    {
                        break;
                    }

                    table[i] += table[i - array[j]];
                }
            }

            return table[target];
        }

        private int FindAllCombinationsRecursion(int[] array, int target)
        {
            var table = new int[target + 1];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = -1;
            }

            table[0] = 1;

            return FindAllCombinationsRecursionHelper(array, target, table);
        }

        private int FindAllCombinationsRecursionHelper(int[] array, int target, int[] table)
        {
            if (target < 0)
            {
                return 0;
            }

            if (table[target] != -1)
            {
                return table[target];
            }

            var result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                result += FindAllCombinationsRecursionHelper(array, target - array[i], table);
            }
            table[target] = result;
            return table[target];
        }
    }
}
