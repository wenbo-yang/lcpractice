using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC40_CombinationSumSingleUse
{
    [TestClass]
    public class CombinationSumSingleUseTests
    {
        // dfs similiar to LC39, change startindex from i to i + 1;
        // and also remember to remove dups 1 1 1 -> 1 1 -> 1 use
        // if (startIndex > i && sortedArray[i] == sortedArray[i - 1]) continue; 
        // to eliminate dupes combination.
        [TestMethod]
        public void GivenArray_CombinationSum_ShouldGenerateCorrectResults()
        {
            var inputArray = new List<int> { 10, 1, 2, 7, 6, 1, 5 };
            var targetSum = 8;
            List<int[]> results = CombinationSum(inputArray, targetSum);

            Assert.IsTrue(results.Count == 4);
        }

        private List<int[]> CombinationSum(List<int> inputArray, int targetSum)
        {
            inputArray.Sort();

            var results = Dfs(inputArray, new List<int>(), 0, targetSum);

            return results;
        }

        private List<int[]> Dfs(List<int> sortedArray, List<int> currentArray, int startIndex, int targetSum)
        {
            var results = new List<int[]>();

            
            for (int i = startIndex; i < sortedArray.Count; i++)
            {
                var item = sortedArray[i];

                if (item == targetSum)
                {
                    var result = new int[currentArray.Count + 1];
                    currentArray.CopyTo(result, 0);
                    result[currentArray.Count] = item;
                    results.Add(result);
                    break;
                }
                
                if(item > targetSum)
                {
                    break;
                }

                if (i > startIndex && sortedArray[i] == sortedArray[i - 1])
                {
                    continue;
                }

                currentArray.Add(item);
                results.AddRange(Dfs(sortedArray, currentArray, i + 1, targetSum - item));
                currentArray.RemoveAt(currentArray.Count - 1);
            }
            
            
            return results;
        }
    }
}
