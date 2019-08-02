using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC171_ExcelColumNumber
{
    [TestClass]
    public class ExcelColumnNumberTests
    {
        [TestMethod]
        public void GivenColumnNumberString_Convert_ShouldConvertToInt()
        {
            var input = "ZY";

            int result = ConvertToInt(input);

            Assert.IsTrue(result == 701);
        }

        private int ConvertToInt(string input)
        {
            var result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                result = result * 26 + (input[i] - 'A' + 1);
            }

            return result;
        }
    }
}
