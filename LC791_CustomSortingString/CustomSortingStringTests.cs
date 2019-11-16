using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC791_CustomSortingString
{
    [TestClass]
    public class CustomSortingStringTests
    {
        [TestMethod]
        public void GivenSourceStringAndTargetString_CustomSort_ShouldReturnValidSortedArray()
        {
            var source = "cba";
            var target = "abcd";

            var result = CustomSort(source, target);

            Assert.IsTrue(result == "cbad");
        }

        private string CustomSort(string source, string target)
        {
            var depthMapping = GenerateDepthMapping(source);
            var frequencyCountForDepth = new Dictionary<int, int>();
            var unaccountedList = new List<char>();

            for (int i = 0; i < target.Length; i++)
            {
                if (depthMapping.ContainsKey(target[i]))
                {
                    if (!frequencyCountForDepth.ContainsKey(depthMapping[target[i]]))
                    {
                        frequencyCountForDepth.Add(depthMapping[target[i]], 0);
                    }

                    frequencyCountForDepth[depthMapping[target[i]]]++;
                }
                else
                {
                    unaccountedList.Add(target[i]);
                }
            }


            var result = new List<char>();

            for (int i = 0; i < depthMapping.Count; i++)
            {
                var f = frequencyCountForDepth[i];
                var pair = depthMapping.First((kv) => kv.Value == i);
                for (var j = 0; j < f; j++)
                {
                    result.Add(pair.Key);
                }
            }

            result.AddRange(unaccountedList);

            return new string(result.ToArray());
        }

        private Dictionary<char, int> GenerateDepthMapping(string source)
        {
            var depthMapping = new Dictionary<char, int>();
            var depth = 0;
            foreach(var c in source)
            {
                if (!depthMapping.ContainsKey(c))
                {
                    depthMapping.Add(c, 0);
                }

                depthMapping[c] = depth;
                depth++;
            }

            return depthMapping;
        }
    }
}
