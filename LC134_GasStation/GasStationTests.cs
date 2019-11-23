using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC134_GasStation
{
    [TestClass]
    public class GasStationTests
    {
        [TestMethod]
        public void GivenGasStationCostsAndGasUnits_FindIndex_ShouldReturnIndex()
        {
            var gas = new int[] { 1, 2, 3, 4, 5 };
            var cost = new int[] { 3, 4, 5, 1, 2 };

            var result = FindGasStationIndex(gas, cost);

            Assert.IsTrue(result == 3);
        }

        private int FindGasStationIndex(int[] gas, int[] cost)
        {
            var gasSum = 0;
            var costSum = 0;
            var start = 0; var reserve = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                gasSum += gas[i];
                costSum += cost[i];
                reserve += gas[i] - cost[i];
                if (reserve < 0)
                {
                    start = i + 1;
                    reserve = 0;
                }
            }

            return gasSum >= costSum ? start : - 1;
        }

    }
}
