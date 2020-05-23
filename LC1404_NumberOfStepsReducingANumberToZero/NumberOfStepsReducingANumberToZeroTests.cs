using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1404_NumberOfStepsReducingANumberToZero
{
    [TestClass]
    public class NumberOfStepsReducingANumberToZeroTests
    {
        [TestMethod]
        public void GivenNumber_GetNumberOfStepsReductingToZero_ShouldReturnCorrectAnswer()
        {
            var s = "1101";

            var result = GetNumberOfStepsReductingToZero(s);

            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void GivenNumber2_GetNumberOfStepsReductingToZero_ShouldReturn1()
        {
            var s = "10";

            var result = GetNumberOfStepsReductingToZero(s);

            Assert.IsTrue(result == 1);
        }

        private int GetNumberOfStepsReductingToZero(string s)
        {
            var numberList = new List<char>();
            var zeroIndexList = new List<int>();
            FormulateListAndGetLastZero(s, numberList, zeroIndexList);
            var steps = 0;
            while (zeroIndexList.Count != 0 && numberList.Count != 2)
            {
                if (numberList[numberList.Count - 1] == '0')
                {
                    numberList.RemoveAt(numberList.Count - 1);
                }
                else 
                {
                    var zeroIndex = zeroIndexList[zeroIndexList.Count - 1];
                    var count = numberList.Count - zeroIndex - 1;
                    steps += count;
                    numberList.RemoveRange(zeroIndex + 1, count);
                    numberList[numberList.Count - 1] = '1';
                }

                zeroIndexList.RemoveAt(zeroIndexList.Count - 1);
                steps++;
            }

            return steps;
        }

        private void FormulateListAndGetLastZero(string s, List<char> numberList, List<int> zeroIndexList)
        {
            numberList.Add('0');
            zeroIndexList.Add(0);
            for (int i = 0; i < s.Length; i++)
            {
                numberList.Add(s[i]);
                if (s[i] == '0')
                {
                    zeroIndexList.Add(i + 1);
                }
            }
        }
    }
}
