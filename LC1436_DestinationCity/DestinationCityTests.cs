using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1436_DestinationCity
{
    [TestClass]
    public class DestinationCityTests
    {
        [TestMethod]
        public void GivenTripStrings_DestinationCity_ShouldReturnDestinationCity()
        {
            var paths = new List<List<string>> { new List<string> { "London", "New York" }, new List<string> { "New York", "Lima" }, new List<string> { "Lima", "Sao Paulo" } };

            var result = DestinationCity(paths);

            Assert.IsTrue(result == "Sao Paulo");
        }

        private string DestinationCity(List<List<string>> paths)
        {
            var startCities = new HashSet<string>();
            var destCities = new HashSet<string>();

            for (int i = 0; i < paths.Count; i++)
            {
                startCities.Add(paths[i][0]);
                destCities.Add(paths[i][1]);
            }

            foreach (var city in destCities)
            {
                if (!startCities.Contains(city))
                {
                    return city;
                }
            }

            return "";
        }
    }
}
