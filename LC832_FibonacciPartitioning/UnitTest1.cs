using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC832_FibonacciPartitioning
{
    [TestClass]
    public class FibonacciPartitioningSequence
    {
        [TestMethod]
        public void GivenArrayString_SplitIntoFibonacci_ShouldReturnNumberSequence()
        {
            var s = "123456579";

            var result = SplitIntoFibonacci(s);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 123, 456, 579 }));
        }

        private List<int> SplitIntoFibonacci(string s)
        {
            var result = new List<int>();

            var visited = new HashSet<string>();

            var firstTwos = GenerateFirstTwo(s);
            foreach (var firstTwo in firstTwos)
            {
                var current = new List<int> { firstTwo.Item1, firstTwo.Item2 };
                SplitIntoFibonacciHelper(s.Substring((firstTwo.Item1.ToString() + firstTwo.Item2.ToString()).Length), current, visited, result);

                if (result.Count > 0)
                {
                    break;
                }
            }
           
            return result;
        }

        private void SplitIntoFibonacciHelper(string s, List<int> current, HashSet<string> visited, List<int> result)
        {
            if (s.StartsWith("0"))
            {
                return;
            }

            if (s.Length == 0)
            {
                result.AddRange(current);
            }

            var target = (current[current.Count - 1] + current[current.Count - 2]).ToString();

            if (s.StartsWith(target) && !visited.Contains(target))
            {
                current.Add(current[current.Count - 1] + current[current.Count - 2]);
                visited.Add(target);
                SplitIntoFibonacciHelper(s.Substring(target.Length), current, visited, result);
                current.RemoveAt(current.Count - 1);
            }
        }

        private List<Tuple<int, int>> GenerateFirstTwo(string s)
        {

            var result = new List<Tuple<int, int>>();

            for (int i = 1; i < s.Length - 2; i++)
            {
                var first = Convert.ToInt32(s.Substring(0, i));
                var second = Convert.ToInt32(s.Substring(i, s.Length - 1 - i));
                result.Add(new Tuple<int, int>(first, second));            
            }

            return result;
        }
    }
}
