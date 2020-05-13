using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1397_FindAllGoodStrings
{
    [TestClass]
    public class FindAllGoodStringsTests
    {
        [TestMethod]
        public void GivenGoodStringsAndEvilString_FindAllGoodStrings_ShouldReturnCorrectNumber()
        {
            var s1 = "aa";
            var s2 = "da";
            var evil = "b";

            var result = FindAllGoodStrings(s1, s2, evil);

            Assert.IsTrue(result == 51);
        }

        private int FindAllGoodStrings(string s1, string s2, string evil)
        {
            throw new NotImplementedException();
        }
    }
}
