using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1324_PrintWordVertically
{
    [TestClass]
    public class VerticalPrintTests
    {
        [TestMethod]
        public void GivenWordString_VerticalPrint_ShouldReturnCorrectArray()
        {
            var source = "HOW ARE YOU";

            var result = VerticalPrint(source);

            Assert.IsTrue(result[0] == "HAY");
            Assert.IsTrue(result[1] == "ORO");
            Assert.IsTrue(result[2] == "WEU");
        }

        private List<string> VerticalPrint(string s)
        {
            var result = new List<string>();

            var array = s.Split(' ');
            var maxLength = 0;
            foreach(var word in array)
            {
                maxLength = Math.Max(maxLength, word.Length);
            }

            var mat = new char[maxLength][];
            for (int i = 0; i < mat.Length; i++)
            {
                mat[i] = new char[array.Length];
                for (int j = 0; j < array.Length; j++)
                {
                    mat[i][j] = ' ';

                }
            }

            for(int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    mat[j][i] = array[i][j]; 
                }
            }

            foreach (var row in mat)
            {
                result.Add(new string(row).TrimEnd());
            }

            return result;
        }
    }
}
