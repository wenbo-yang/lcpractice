using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC846_NumOfStraights
{
    [TestClass]
    public class NumberOfStraigthsTests
    {
        [TestMethod]
        public void GivenValidArrayOfCardsAndWidth_NumberOfStraights_ShouldReturnTrue()
        {
            var input = new List<int> { 1, 2, 3, 6, 2, 3, 4, 7, 8 };

            var result = NumberOfStraigths(input, 3);

            Assert.IsTrue(result);
        }

        private bool NumberOfStraigths(List<int> input, int width)
        {
            var sortedTable = new SortedDictionary<int, int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (!sortedTable.ContainsKey(input[i]))
                {
                    sortedTable.Add(input[i], 0);
                }
                sortedTable[input[i]]++;
            }

            while (sortedTable.Count != 0)
            {
                var first = sortedTable.First();

                for (int i = first.Key; i < first.Key + width; i++)
                {
                    if (!sortedTable.ContainsKey(i))
                    {
                        return false;
                    }

                    sortedTable[i]--;

                    if (sortedTable[i] == 0)
                    {
                        sortedTable.Remove(i);
                    }
                }
            }

            return true;
        }
    }
}
