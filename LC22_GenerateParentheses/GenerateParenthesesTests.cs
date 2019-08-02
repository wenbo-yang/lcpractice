using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenerateParentheses
{
    [TestClass]
    public class GenerateParenthesesTests
    {
        [TestMethod]
        public void GivenNumber3_Generate_ShouldGenerateValidSet()
        {
            var input = 3;

            var output = GenerateParenthese(3);

            Assert.IsTrue(output.Count == 5);
            Assert.IsNotNull(output.Single(item => item == "()()()"));
            Assert.IsNotNull(output.Single(item => item == "(())()"));
            Assert.IsNotNull(output.Single(item => item == "(()())"));
            Assert.IsNotNull(output.Single(item => item == "((()))"));
            Assert.IsNotNull(output.Single(item => item == "()(())"));
        }

        private List<string> GenerateParenthese(int n)
        {
            var n0 = "()";
            var result = new List<string>();

            Dfs(result, new HashSet<string> { n0 }, n, 1);

            return result;
        }

        private void Dfs(List<string> result, HashSet<string> tempResults, int input, int depth)
        {
            if (input == depth)
            {
                var output = new string[tempResults.Count];
                tempResults.CopyTo(output);
                result.AddRange(output);
                return;
            }

            var nextLevelHash = new HashSet<string>();

            var potentialDup = GetPotentialDupParentheses(depth - 1);

            foreach (var item in tempResults)
            {
                nextLevelHash.Add("(" + item + ")");
                nextLevelHash.Add("()" + item);
                if (potentialDup != item)
                {
                    nextLevelHash.Add(item + "()");
                }
            }

            Dfs(result, nextLevelHash, input, depth + 1);
        }
        private string GetPotentialDupParentheses(int preDepth)
        {
            string target = "";
            for (int i = 0; i <= preDepth; i++)
            {
                target = target + "()";
            }

            return target;
        }


        
    }
}
