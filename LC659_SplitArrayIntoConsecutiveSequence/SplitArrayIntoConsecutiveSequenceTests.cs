using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC659_SplitArrayIntoConsecutiveSequence
{
    [TestClass]
    public class SplitArrayIntoConsecutiveSequenceTests
    {
        [TestMethod]
        public void GivenConsecutiveSequences_CanSplit_ShouldReturnTrue()
        {
            var input = new int[] { 1, 2, 3, 3, 4, 4, 5, 5 };

            var result = CanSplit(input);

            Assert.IsTrue(result);
        }

        private bool CanSplit(int[] input)
        {
            var frequency = new Dictionary<int, int>();
            var lacks = new Dictionary<int, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!frequency.ContainsKey(input[i]))
                {
                    frequency.Add(input[i], 0);
                    lacks.Add(input[i], 0);
                }

                frequency[input[i]]++;
            }

            frequency.Add(input.Last() + 1, 0);
            frequency.Add(input.Last() + 2, 0);
            lacks.Add(input.Last() + 1, 0);
            lacks.Add(input.Last() + 2, 0);
            lacks.Add(input.Last() + 3, 0);


            for (int i = 0; i < input.Length; i++)
            {
                if (frequency[input[i]] == 0)
                {
                    continue;
                }

                if (lacks[input[i]] > 0)
                {
                    lacks[input[i]]--;
                    lacks[input[i] + 1]++;
                }
                else if (frequency[input[i] + 1] > 0 && frequency[input[i] + 2] > 0)
                {
                    frequency[input[i] + 2]--;
                    frequency[input[i] + 1]--;
                    lacks[input[i] + 3]++;
                }
                else
                {
                    return false;
                }

                frequency[input[i]]--;
            }

            return true;
        }
    }
}
