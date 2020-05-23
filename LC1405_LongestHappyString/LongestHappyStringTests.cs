using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1405_LongestHappyString
{
    [TestClass]
    public class LongestHappyStringTests
    {
        [TestMethod]
        public void GivenCharCount_GetLongestHappyString_ShouldReturnCorrectAnswer()
        {
            var a = 1; var b = 1; var c = 7;

            var result = GetLongestHappyString(a, b, c);

            Assert.IsTrue(result == "ccaccbcc" || result == "ccbccacc");
        }

        [TestMethod]
        public void GivenAnotherCharCount_GetLongestHappyString_ShouldReturnCorrectAnswer()
        {
            var a = 7; var b = 1; var c = 0;

            var result = GetLongestHappyString(a, b, c);

            Assert.IsTrue(result == "aabaa");
        }

        private string GetLongestHappyString(int a, int b, int c)
        {
            var table = new (char c, int count)[3];
            table[0] = ('a', a); table[1] = ('b', b); table[2] = ('c', c);
            
            var list = new List<char>();
            table = table.OrderByDescending(x => x.count).AsEnumerable().ToArray();

            while (Place(list, table))
            {    
                table = table.OrderByDescending(x => x.count).AsEnumerable().ToArray();
            }

            return new string(list.ToArray());
        }

        private bool Place(List<char> list, (char c, int count)[] table)
        {

            for (int i = 0; i < table.Length; i++)
            {
                if (list.Count >= 2 && list[list.Count - 1] == list[list.Count - 2] && table[i].c == list[list.Count - 1])
                {
                    continue;
                }
                else if(table[i].count > 0)
                {
                    table[i].count--;
                    list.Add(table[i].c);

                    return true;
                }
            }

            return false;
            
        }
    }
}
