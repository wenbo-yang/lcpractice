using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC418_FitToScreenLeft
{
    [TestClass]
    public class FitScreenTests
    {
        [TestMethod]
        public void GivenArrayAndRowColSize_FitScreen_ShouldReturnCorrectNumber()
        {
            var input = new string[] { "hello", "world" };
            var rows = 2; var cols = 8;

            var result = FitScreen(input, rows, cols);

            Assert.IsTrue(result == 1);
        }

        private int FitScreen(string[] input, int rows, int cols)
        {
            // param validation
            var numTimes = 0;
            var index = 0;
            for (int i = 0; i < rows; i++)
            {
                TryFitRow(input, cols, ref index, ref numTimes);
            }

            return numTimes;
        }

        private void TryFitRow(string[] input, int cols, ref int index, ref int numTimes)
        {
            var currentIndex = index;
            var currentSize = 0;

            while (CanFit(input, index, cols, currentSize))
            {
                if (currentSize == 0)
                {
                    currentSize = input[index].Length;
                }
                else
                {
                    currentSize += input[index].Length + 1;
                }

                if (index == input.Length - 1)
                {
                    numTimes++;
                    index = 0;
                    continue;
                }

                index++;
            }
        }

        private bool CanFit(string[] input, int index, int cols, int currentSize)
        {
            return currentSize == 0 ? true : currentSize + 1 + input[index].Length <= cols;
        }
    }
}
