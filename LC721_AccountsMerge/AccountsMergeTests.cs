using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC721_AccountsMerge
{
    [TestClass]
    public class AccountsMergeTests
    {
        [TestMethod]
        public void GivenAccounts_MergeAccounts_ShouldReturnListOfUniqueAccounts()
        {
            var accounts = new string[][] { new string[] { "John", "johnsmith@mail.com", "john00@mail.com" },
                                         new string[] { "John", "johnnybravo@mail.com" },
                                         new string[] { "John", "johnsmith@mail.com", "john_newyork@mail.com" },
                                         new string[] { "Mary", "mary@mail.com" } };

            var result = MergeAccounts(accounts);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result.Find(x => x.Count == 4 && x[0] == "John" && x.Contains("johnsmith@mail.com") && x.Contains("john00@mail.com") && x.Contains("john_newyork@mail.com")) != null);
        }

        private List<List<string>> MergeAccounts(string[][] accounts)
        {
            var result = new List<List<string>>();

            var childrenTable = ParseIntoParentTable(accounts);

            foreach (var account in childrenTable)
            {
                result.Add(new List<string>());
                result[result.Count - 1].Add(account.Key.Item1);
                var children = new string[account.Value.Count];
                account.Value.CopyTo(children);
                result[result.Count - 1].AddRange(children);
            }

            return result;
        }

        private Dictionary<Tuple<string, string>, HashSet<string>> ParseIntoParentTable(string[][] accounts)
        {
            var childrenTable = new Dictionary<Tuple<string, string>, HashSet<string>>();
            var parentTable = new Dictionary<string, string>();

            foreach (var account in accounts)
            {
                var childrenTableKey = new Tuple<string, string>(account[0], account[1]);
                if (!childrenTable.ContainsKey(childrenTableKey))
                {
                    childrenTable.Add(childrenTableKey, new HashSet<string>());
                }

                if (!parentTable.ContainsKey(account[1]))
                {
                    parentTable.Add(account[1], account[1]);
                }

                var realParent = parentTable[account[1]];

                for (int i = 1; i < account.Length; i++)
                {
                    if (!parentTable.ContainsKey(account[i]))
                    {
                        parentTable.Add(account[i], realParent);
                    }
                    
                    childrenTable[new Tuple<string, string>(account[0], realParent)].Add(account[i]);
                }
            }

            return childrenTable;
        }
    }
}
