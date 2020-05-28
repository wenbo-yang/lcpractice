
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1411_NumberOfWaysPaintingBoxes
{
    [TestClass]
    public class NumberOfWaysPaintingBoxesTests
    {
        [TestMethod]
        public void GivenN_GetNumberOfWays_ShouldReturnNumberOfWays()
        {
            var n = 1;
            var result = GetNumberOfWays(n);

            Assert.IsTrue(result == 12);
        }

        [TestMethod]
        public void Given2_GetNumberOfWays_ShouldReturnNumberOfWays()
        {
            var n = 2;
            var result = GetNumberOfWays(n);

            Assert.IsTrue(result == 54);
        }

        [TestMethod]
        public void Given3_GetNumberOfWays_ShouldReturnNumberOfWays()
        {
            var n = 3;
            var result = GetNumberOfWays(n);

            Assert.IsTrue(result == 246);
        }

        [TestMethod]
        public void Given7_GetNumberOfWays_ShouldReturnNumberOfWays()
        {
            var n = 7;
            var result = GetNumberOfWays(n);

            Assert.IsTrue(result == 106494);
        }

        [TestMethod]
        public void Given5000_GetNumberOfWays_ShouldReturnNumberOfWays()
        {
            var n = 5000;
            var result = GetNumberOfWays(n);

            Assert.IsTrue(result == 30228214);
        }

        private int GetNumberOfWays(int n)
        {
            if (n == 1)
            {
                return 12;
            }

            var number = new List<int>();
            uint mod = 1000000007;
            (uint singlePattern, uint doublePattern) current = (6, 6);

            for (int i = 2; i <= n; i++)
            {
                uint singlePattern = ((current.doublePattern % mod) * 2) % mod + ((current.singlePattern % mod) * 2) % mod;
                uint doublePattern = ((current.doublePattern % mod) * 3) % mod + ((current.singlePattern % mod) * 2) % mod;

                current = (singlePattern % mod, doublePattern % mod);
            }

            return (int)((current.doublePattern + current.singlePattern) % mod);
        }

        private char[][] GenerateInital()
        {
            var result = new char[12][]
            {
                new char[3] { 'r', 'y', 'r'},
                new char[3] { 'r', 'y', 'g'},
                new char[3] { 'r', 'g', 'r'},
                new char[3] { 'r', 'g', 'y'},
                new char[3] { 'y', 'r', 'y'},
                new char[3] { 'y', 'r', 'g'},
                new char[3] { 'y', 'g', 'r'},
                new char[3] { 'y', 'g', 'y'},
                new char[3] { 'g', 'r', 'y'},
                new char[3] { 'g', 'r', 'g'},
                new char[3] { 'g', 'y', 'r'},
                new char[3] { 'g', 'y', 'g'}
            };

            return result;
        }
    }
}
