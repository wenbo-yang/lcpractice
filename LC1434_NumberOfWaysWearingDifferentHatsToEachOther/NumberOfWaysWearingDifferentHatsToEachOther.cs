using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1434_NumberOfWaysWearingDifferentHatsToEachOther
{
    [TestClass]
    public class NumberOfWaysWearingDifferentHatsToEachOther
    {
        [TestMethod]
        public void GivenHatsArrayForPersons_NumberOfDifferentCombinations_ShouldReturnNumberOfWays()
        {
            var hats = new List<List<int>> { new List<int> {3, 4}, new List<int> { 4, 5}, new List<int> { 5 } };
            var result = GetNumberOfWays(hats);

            Assert.IsTrue(result == 1);
        }

        private int GetNumberOfWays(List<List<int>> hats)
        {
            hats = hats.OrderBy(x => x.Count).ToList();

            var hatsSet = ConvertListIntoSet(hats);
            var maskedSet = InitializeMaskedSet(hatsSet.Length);
            // var mem = new Dictionary<(ulong inSet, ulong masked), uint>();

            return GetNumberOfWaysHelper(hatsSet, maskedSet, 0);
        }

        private HashSet<int>[] InitializeMaskedSet(int length)
        {
            var maskedSet = new HashSet<int>[length];

            for (int i = 0; i < maskedSet.Length; i++)
            {
                maskedSet[i] = new HashSet<int>();
            }

            return maskedSet;
        }

        private int GetNumberOfWaysHelper(HashSet<int>[] hatsSet, HashSet<int>[] maskedSet, int index)
        {
            if (index == hatsSet.Length - 1)
            {
                return hatsSet[index].Count;
            }

            if (hatsSet[index].Count == 0)
            {
                return 0;
            }

            var list = hatsSet[index].ToList();
            var sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                RemoveHatFromSets(hatsSet, maskedSet, list[i], index);
                sum += GetNumberOfWaysHelper(hatsSet, maskedSet, index + 1);
                AddHatBackToSet(hatsSet, maskedSet, list[i], index);
            }

            return sum;
        }

        private void AddHatBackToSet(HashSet<int>[] hatsSet, HashSet<int>[] maskedSet, int value, int index)
        {
            for (int i = index; i < hatsSet.Length; i++)
            {
                if (maskedSet[i].Contains(value))
                {
                    hatsSet[i].Add(value);
                    maskedSet[i].Remove(value);
                }
            }
        }

        private void RemoveHatFromSets(HashSet<int>[] hatsSet, HashSet<int>[] maskedSet, int value, int index)
        {
            for (int i = index; i < hatsSet.Length; i++)
            {
                if (hatsSet[i].Contains(value))
                {
                    hatsSet[i].Remove(value);
                    maskedSet[i].Add(value);
                }
            }
        }

        private HashSet<int>[] ConvertListIntoSet(List<List<int>> hats)
        {
            var hatsSet = new HashSet<int>[hats.Count];

            for (int i = 0; i < hats.Count; i++)
            {
                hatsSet[i] = new HashSet<int>();
                for (int j = 0; j < hats[i].Count; j++)
                {
                    hatsSet[i].Add(hats[i][j]);
                }
            }

            return hatsSet;
        }
    }
}
