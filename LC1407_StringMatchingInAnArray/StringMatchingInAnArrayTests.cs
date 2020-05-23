using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1407_StringMatchingInAnArray
{
    [TestClass]
    public class StringMatchingInAnArrayTests
    {
        [TestMethod]
        public void GivenArrayAndString()
        {
            var words = new string[] { "mass", "as", "hero", "superhero" };
            var result = StringMatching(words);

            Assert.IsTrue(result.Contains("as") && result.Contains("hero") && result.Count == 2);
        }

        private List<string> StringMatching(string[] words)
        {
            var result = new HashSet<string>();
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    var smaller = words[i].Length < words[j].Length ? words[i] : words[j];
                    var bigger = words[i].Length >= words[j].Length ? words[i] : words[j];

                    if (words[i].Length != words[j].Length && bigger.Contains(smaller))
                    {
                        result.Add(smaller);
                        break;
                    }
                }
            }

            return result.AsEnumerable().ToList();
        }
    }
}
