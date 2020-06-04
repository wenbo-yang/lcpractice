using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1307_VerbalArithmeticPuzzle
{
    [TestClass]
    public class VerbalArithmeticPuzzleTests
    {
        [TestMethod]
        public void GivenWordsAndResult_CanDecode_ShouldReturnCorrectAnswer()
        {
            var words = new string[] { "SEND", "MORE" }; var target = "MONEY";
            var result = CanDecode(words, target);

            Assert.IsTrue(result);
        }

        private bool CanDecode(string[] words, string target)
        {
            var rightAligned = RightAlignWords(words, target);
            var possibleCombinations = new Dictionary<char, HashSet<int>> {{' ', new HashSet<int> {0} }};

            for (int i = 0; i < target.Length; i++)
            {
                GetTargetPossibleCombinations(rightAligned, target, target[i], possibleCombinations);
            }
            
        }

        private void GetTargetPossibleCombinations(char[][] rightAligned, string target, char targetChar, Dictionary<char, HashSet<int>> possibleCombinations)
        {
            if (!possibleCombinations.ContainsKey(targetChar))
            {
                possibleCombinations.Add(targetChar, new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9});
            }
            

        }

        private char[][] RightAlignWords(string[] words, string target)
        {
            var rightAligned = new char[words.Length][];
            for (int i = 0; i < rightAligned.Length; i++)
            {
                rightAligned[i] = new char[target.Length];
                var index = words[i].Length - 1;
                for (int j = target.Length - 1; j >= 0; j++)
                {
                    if (index < 0)
                    {
                        rightAligned[i][j] = ' ';
                    }
                    else
                    {
                        rightAligned[i][j] = words[i][index--];
                    }
                }
            }

            return rightAligned;
        }
    }
}
