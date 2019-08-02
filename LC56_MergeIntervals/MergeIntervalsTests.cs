using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC56_MergeIntervals
{
    [TestClass]
    public class MergeIntervalsTests
    {
        [TestMethod]
        public void GivenListOfIntervals_Merge_ShouldMergeIntervals()
        {
            var input = new int[][] { new int[] { 8, 10 }, new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 9, 18 } };

            List<Tuple<int, int>> output = Merge(input);

            Assert.IsTrue(output.Count == 2);
        }

        private List<Tuple<int, int>> Merge(int[][] input)
        {
            List<Tuple<int, int>> inputList = ConvertToList(input);
            var outputList = new List<Tuple<int, int>>();
            inputList.Sort();
            outputList.Add(inputList[0]);

            for (int i = 1; i < inputList.Count; i++)
            {
                var outputIndex = outputList.Count - 1;

                var raw = inputList[i];
                var merge = outputList[outputIndex];

                if (raw.Item1 < merge.Item2)
                {
                    outputList.RemoveAt(outputIndex);
                    outputList.Add(new Tuple<int, int>(merge.Item1, Math.Max(raw.Item2, merge.Item2)));
                }
                else
                {
                    outputList.Add(raw);
                }
            }

            return outputList;
        }

        private List<Tuple<int, int>> ConvertToList(int[][] input)
        {
            var result = new List<Tuple<int, int>>();
            foreach (var pair in input)
            {
                result.Add(new Tuple<int, int>(pair[0], pair[1]));
            }

            return result;
        }
    }
}
