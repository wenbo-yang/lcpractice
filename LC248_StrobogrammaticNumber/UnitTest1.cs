using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC248_StrobogrammaticNumber
{
    [TestClass]
    public class StrobogrammaticNumberTests
    {
        [TestMethod]
        public void GivenRange_FindNumberOfStrobogrammaticNumber_ShouldReturnCorrectNumber()
        {
            var low = "50";
            var hight = "100";

            var result = FindNumberOfStrobogrammaticNumber("50", "100");

            Assert.IsTrue(result == 3);
        }

        private int FindNumberOfStrobogrammaticNumber(string low, string high)
        {
            // param validation

            var result = 0;
            result += FindNumberHelper(low, high, "");
            result += FindNumberHelper(low, high, "0");
            result += FindNumberHelper(low, high, "1");
            result += FindNumberHelper(low, high, "8");

            return result;
        }

        private int FindNumberHelper(string low, string high, string current)
        {
            if (current.Length >= low.Length && int.Parse(current) < int.Parse(low))
            {
                return 0;
            }

            if (current.Length >= high.Length && int.Parse(current) > int.Parse(high))
            {
                return 0;
            }


            var result = 0;

            if (IsValidNumber(low, high, current))
            {
                result++;
            }

            var targets = GeneratePotentialTargets(current);
            foreach (var target in targets)
            {
                result += FindNumberHelper(low, high, target);
            }

            return result;
        }

        private bool IsValidNumber(string low, string high, string current)
        {
            return current.Length > 0 && current[0] != '0' && int.Parse(current) >= int.Parse(low) && int.Parse(current) <= int.Parse(high);
        }

        private List<string> GeneratePotentialTargets(string current)
        {
            var targets = new List<string> {
                "0" + current + "0",
                "1" + current + "1",
                "8" + current + "8",
                "6" + current + "9",
                "9" + current + "6"
            };

            return targets;
        }
    }
}
