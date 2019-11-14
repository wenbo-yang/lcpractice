using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC760_FindAnagramMappings
{
    [TestClass]
    public class FindAnagramMappingsTests
    {
        [TestMethod]
        public void GivenTwoArrays_FindAnagramMapping_ShouldReturnValidMapping()
        {
            var array1 = new int[] { 12, 28, 46, 32, 50 };
            var array2 = new int[] { 50, 12, 32, 46, 28 };

            var result = FindAnagramMapping(array1, array2);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 1, 4, 3, 2, 0 }));

        }

        private List<int> FindAnagramMapping(int[] array1, int[] array2)
        {
            var result = new List<int>();
            var table = new Dictionary<int, List<int>>();

            for (int i = 0; i < array2.Length; i++)
            {
                if (!table.ContainsKey(array2[i]))
                {
                    table.Add(array2[i], new List<int>());
                }

                table[array2[i]].Add(i);
            }

            for (int i = 0; i < array1.Length; i++)
            {
                result.Add(table[array1[i]].Last());
                table[array1[i]].RemoveAt(table[array1[i]].Count - 1);
            }

            return result;
        }
    }
}
