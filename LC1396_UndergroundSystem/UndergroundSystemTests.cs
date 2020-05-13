using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1396_UndergroundSystem
{
    [TestClass]
    public class UndergroundSystemTests
    {
        [TestMethod]
        public void GivenUnderGroundSystem_GetAverage_ShouldReturnAverage()
        {
            var undergroundSystem = new UndergroundSystem();
            undergroundSystem.CheckIn(45, "Leyton", 3);
            undergroundSystem.CheckIn(32, "Paradise", 8);
            undergroundSystem.CheckIn(27, "Leyton", 10);
            undergroundSystem.CheckOut(45, "Waterloo", 15);
            undergroundSystem.CheckOut(27, "Waterloo", 20);
            undergroundSystem.CheckOut(32, "Cambridge", 22);

            var result = undergroundSystem.GetAverageTime("Paradise", "Cambridge");

            Assert.IsTrue(result == 14.0d);
        }

        public class UndergroundSystem
        {
            private Dictionary<(string start, string end), (int count, int sum)> _stationTotalTravelTime = new Dictionary<(string station1, string station2), (int count, int sum)>();
            private Dictionary<int, (string station, int t)> _users = new Dictionary<int, (string station, int startTime)>();

            public UndergroundSystem()
            {
            }

            public void CheckIn(int id, string stationName, int t)
            {
                _users.Add(id, (stationName, t));
            }

            public void CheckOut(int id, string stationName, int t)
            {
                var start = _users[id];

                _users.Remove(id);

                if (!_stationTotalTravelTime.ContainsKey((start.station, stationName)))
                {
                    _stationTotalTravelTime.Add((start.station, stationName), (0, 0));
                }

                var current = _stationTotalTravelTime[(start.station, stationName)];

                current = (current.count + 1, current.sum + (t - start.t));

                _stationTotalTravelTime[(start.station, stationName)] = current;
            }

            public double GetAverageTime(string startStation, string endStation)
            {
                var current = _stationTotalTravelTime[(startStation, endStation)];

                return Convert.ToDouble(Convert.ToDouble(current.sum) / current.count);
            }
        }
    }
}
