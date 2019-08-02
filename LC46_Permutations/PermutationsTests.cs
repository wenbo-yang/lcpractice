using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC46_Permutations
{
    // can be used for LC47 as well
    [TestClass]
    public class PermutationsTests
    {
        [TestMethod]
        public void GivenDistinctInputArray_Permutations_ShouldGenerateListOfPermutations()
        {
            var input = new int[] { 3, 2, 1};

            List<List<int>> permutations = PermutationsDfs(new List<int>(input));

            Assert.IsTrue(permutations.Count == 6);
        }

        [TestMethod]
        public void GivenDupInputArray_Permutations_ShouldGenerateListOfPermutations()
        {
            var input = new int[] { 1, 1, 2 };

            List<List<int>> permutations = PermutationsDfs(new List<int>(input));

            Assert.IsTrue(permutations.Count == 3);
        }

        [TestMethod]
        public void Given3DupInputArray_Permutations_ShouldGenerateListOfPermutations()
        {
            var input = new int[] { 1, 1, 1, 2 };

            List<List<int>> permutations = PermutationsDfs(new List<int>(input));

            Assert.IsTrue(permutations.Count == 4);
        }

        private List<List<int>> PermutationsDfs(List<int> input)
        {
            // sort the input this will account for dup cases
            input.Sort();

            var results = new List<List<int>>();

            Dfs(input, new List<int>(), new HashSet<int>(), results);
            
            return results;
        }

        private void Dfs(List<int> input, List<int> current, HashSet<int> indices, List<List<int>> results)
        {
            if (current.Count == input.Count)
            {
                results.Add(new List<int>(current));
                return;
            }    

            for (int i = 0; i < input.Count; i++)
            {
                if (indices.Contains(i))
                {
                    continue;
                }

                if (i > 0 && input[i] == input[i - 1] && !indices.Contains(i - 1))
                {
                    continue;
                }

                indices.Add(i);
                current.Add(input[i]);
                Dfs(input, current, indices, results);
                
                indices.Remove(i);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
