using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC766_ToeplitzMatrix
{
    [TestClass]
    public class ToeplitzMatrixTests
    {
        [TestMethod]
        public void GivenValidToeplitzMatrix_IsToeplitzMatrix_ShouldReturnTrue()
        {
            var input = new int[][] { new int[] { 1, 2, 3, 4 },
                                      new int[] { 5, 1, 2, 3 },
                                      new int[] { 9, 5, 1, 2 } };

            var result = IsToeplitzMatrix(input);

            Assert.IsTrue(result);
        }

        private bool IsToeplitzMatrix(int[][] input)
        {
            // param validation

            for (int i = 1; i < input.Length; i++)
            {
                for (int j = 1; j < input[0].Length; j++)
                {
                    var result = input[i][j] == input[i - 1][j - 1];
                    if (!result)
                    {
                        return false;                    
                    }
                }
            }

            return true;
        }
    }
}
