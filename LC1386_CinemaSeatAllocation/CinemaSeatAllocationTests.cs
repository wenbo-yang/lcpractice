using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1386_CinemaSeatAllocation
{
    [TestClass]
    public class CinemaSeatAllocationTests
    {
        [TestMethod]
        public void GivenRowsAndReservedSeatsCoordinates_GetMaxiumNumberOfFamilies_ShouldReturnMaxFamilies()
        {
            var n = 3;
            var reservedSeats = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 8 }, new int[] { 2, 6 }, new int[] { 3, 1 }, new int[] { 3, 10 } };

            var result = GetMaxNumberOfFamilies(n, reservedSeats);

            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void GivenAnotherRowsAndReservedSeatsCoordinates_GetMaxiumNumberOfFamilies_ShouldReturnMaxFamilies()
        {
            var n = 2;
            var reservedSeats = new int[][] { new int[] { 2, 1 }, new int[] { 1, 8 }, new int[] { 2, 6 } };

            var result = GetMaxNumberOfFamilies(n, reservedSeats);

            Assert.IsTrue(result == 2);
        }

        private int GetMaxNumberOfFamilies(int n, int[][] reservedSeats)
        {
            var table = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < reservedSeats.Length; i++)
            {
                if (!table.ContainsKey(reservedSeats[i][0]))
                {
                    table.Add(reservedSeats[i][0], new HashSet<int>());
                }

                table[reservedSeats[i][0]].Add(reservedSeats[i][1]);
            }

            var result = 0;

            foreach (var keyValuePair in table)
            {
                var row = new bool[10];

                foreach (var value in keyValuePair.Value)
                {
                    row[value - 1] = true;
                }

                result += GetSeatsForRow(row);
            }

            if (n > table.Count)
            {
                result += (n - table.Count) * 2;
            }

            return result;
        }

        private int GetSeatsForRow(bool[] seats)
        {
            var result = 0;
            if (!seats[1] && !seats[2] && !seats[3] && !seats[4])
            {
                result++;
            }

            if (!seats[5] && !seats[6] && !seats[7] && !seats[8])
            {
                result++;
            }

            if (!seats[3] && !seats[4] && !seats[5] && !seats[6] && result == 0)
            {
                result++;
            }

            return result;
        }
    }
}
