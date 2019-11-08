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
                var list = new List<char>();
                var index = 0;
                while (index < address.Length)
                {
                    if (address[index] == '+')
                    {
                        index = address.IndexOf('@', index);
                        if (index == -1)
                        {
                            break;
                        }

                        continue;
                    }

                    if (address[index] == '.')
                    {
                        index++;
                        continue;
                    }

                    if (address[index] == '@')
                    {
                        list.AddRange(address.Substring(index, address.Length - index));
                        break;
                    }

                    list.Add(address[index]);
                    index++;
                }

                if (list.Count != 0)
                {
                    hashSet.Add(new string(list.ToArray()));
                }
            }

            return hashSet.Count;
        }
    }
}
