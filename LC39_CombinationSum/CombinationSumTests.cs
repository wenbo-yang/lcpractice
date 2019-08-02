using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC39_CombinationSum
{
    [TestClass]
    public class CombinationSumTests
    {
        // dfs
        [TestMethod]
        public void GivenArray_Dfs_Should_ReturnListOfResults()
        {
            var inputArray = new List<int> { 2, 3, 6, 7 };
            var targetSum = 7;

            List<int[]> output = CombinationSumDfs(inputArray, targetSum);

            Assert.IsTrue(output.Count == 2);
            var result1 = output[0];
            var result2 = output[1];
            Assert.IsTrue(result1[0] == 2);
            Assert.IsTrue(result1[1] == 2);
            Assert.IsTrue(result1[2] == 3);
            Assert.IsTrue(result2[0] == 7);
        }

        private List<int[]> CombinationSumDfs(List<int> inputArray, int targetSum)
        {
            inputArray.Sort();

            var results = Dfs(inputArray, new List<int>(), 0, targetSum);

            return results;
        }

        private List<int[]> Dfs(List<int> inputArray, List<int> currentSet, int startIndex, int targetSum)
        {
            var results = new List<int[]>();

            for(int i = startIndex; i < inputArray.Count; i++) 
            {
                var item = inputArray[i];
                if (item < targetSum)
                {
                    var newCurrentSet = new List<int>();
                    newCurrentSet.AddRange(currentSet);
                    newCurrentSet.Add(item);

                    var result = Dfs(inputArray, newCurrentSet, i, targetSum - item);

                    if (result.Count > 0)
                    {
                        results.AddRange(result);
                    }
                }
                else if (item == targetSum)
                {
                    var result = new int[currentSet.Count + 1];
                    currentSet.CopyTo(result, 0);
                    result[result.Length - 1] = item;

                    results.Add(result);
                }
                else
                {
                    break;
                }
            }

            return results;
        }
    }
}
