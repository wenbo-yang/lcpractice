using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC165_CompareVersions
{
    [TestClass]
    public class CompareVersionsTests
    {
        [TestMethod]
        public void GivenTwoVersion_CompareVersions_ShouldReturnCorrectResponse()
        {
            var version1 = "1.00.01";
            var version2 = "1.0.1";

            var result = CompareVersions(version1, version2);

            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void GivenLeading0TwoVersion_CompareVersions_ShouldReturnCorrectResponse()
        {
            var version1 = "0.00.01";
            var version2 = "1.0.1";

            var result = CompareVersions(version1, version2);

            Assert.IsTrue(result == -1);
        }

        [TestMethod]
        public void GivenSameVersionOfDifferentLength_CompareVersions_ShouldReturnCorrectResponse()
        {
            var version1 = "1.00.00";
            var version2 = "1";

            var result = CompareVersions(version1, version2);

            Assert.IsTrue(result == 0);
        }

        private int CompareVersions(string version1, string version2)
        {
            var v1 = new List<string>(version1.Split('.'));
            var v2 = new List<string>(version2.Split('.'));

            while (v1.Count < v2.Count)
            {
                v1.Add("0");
            }

            while (v2.Count < v1.Count)
            {
                v2.Add("0");
            }

            for (int i = 0; i < v1.Count; i++)
            {
                var result = Compare(v1[i], v2[i]);
                if (result != 0)
                {
                    return result;
                }
            }

            return 0;
        }

        private int Compare(string v1, string v2)
        {
            var value1 = Convert.ToInt16(v1.TrimStart('0') == string.Empty ? "0" : v1);
            var value2 = Convert.ToInt16(v2.TrimStart('0') == string.Empty ? "0" : v2);

            return value1 == value2 ? 0 : (value1 > value2 ? 1 : -1);
        }
    }
}
