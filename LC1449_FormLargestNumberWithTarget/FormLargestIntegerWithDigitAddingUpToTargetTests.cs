using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1449_FormLargestIntegerWithDigitAddingUpToTarget
{
    [TestClass]
    public class FormLargestIntegerWithDigitAddingUpToTargetTests
    {
        [TestMethod]
        public void GivenCostAndTarget_ConstructLargestNumber_ShouldReturnCorrectAnswer()
        {
            var cost = new int[] { 4, 3, 2, 5, 6, 7, 2, 5, 5 };
            var target = 9;

            var result = ConstructLargestNumber(cost, target);

            Assert.IsTrue(result == "7772");
        }

        private string ConstructLargestNumber(int[] cost, int target)
        {
            var mem = new (int digit, int length)[target + 1];
            for (int i = 0; i < mem.Length; i++)
            {
                mem[i] = (-1, -1);
            }

            DP(target, mem, cost);

            if (mem[target].digit <= 0) return "0";
            var ans = new StringBuilder();
            while (target != 0)
            {
                ans.Append((char)(mem[target].digit + '0'));
                target -= cost[mem[target].digit - 1];
            }
            return ans.ToString();
        }

        private (int digit, int length) DP(int t, (int digit, int length)[] mem, int[] cost)
        {
            if (t < 0) return (0, -1); // Invalid.
            if (t == 0) return (0, 0); // Found a solution.
            if (mem[t].digit != -1) return mem[t];
            mem[t] = (0, -1); // make as solved but invalid.
            for (int d = 1; d <= 9; ++d)
            {
                int l = DP(t - cost[d - 1], mem, cost).length;
                if (l != -1 && l + 1 >= mem[t].length)
                    mem[t] = (d, l + 1);
            }

            return mem[t];
        }

    }
}
