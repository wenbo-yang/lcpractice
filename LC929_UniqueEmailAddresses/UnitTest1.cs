using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC929_UniqueEmailAddresses
{
    [TestClass]
    public class UniqueEmailAddressesTests
    {
        [TestMethod]
        public void GivenListOfEmailAddresses_FindUniqueEmailAddresses_ShouldReturnCorrectNumber()
        {
            var input = new string[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" };

            var result = FindUniqueEmailAddresses(input);

            Assert.IsTrue(result == 2);
        }

        private int FindUniqueEmailAddresses(string[] input)
        {

            var hashSet = new HashSet<string>();
            foreach (var address in input)
            {   
                var split = address.Split('@');
                var local = split[0];
                var global = split[1];
                var processedLocal = split[0].Split('+')[0];
                var finalLocal = processedLocal.Replace(".", "");

                hashSet.Add(finalLocal + "@" + global); 
            }

            return hashSet.Count;
        }
    }
}
