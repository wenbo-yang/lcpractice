using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1388_PizzaWith3nSlices
{
    [TestClass]
    public class PizzaWith3nSlicesTests
    {
        [TestMethod]
        public void GivenCircularArray_GetMaximum_ShouldReturnSlices()
        {
            var input = new int[] { 1, 2, 3, 4, 5, 6 };

            var result = GetMaximum(input);

            Assert.IsTrue(result == 10);
        }

        private int GetMaximum(int[] input)
        {
            var list = new List<int>(input);
            var max = 0;
            var current = 0;
            GetMaximumHelper(list, current, ref max);

            return max;
        }

        private void GetMaximumHelper(List<int> list, int current, ref int max)
        {
            if (list.Count == 3)
            {
                max = Math.Max(current + list.Max(), max);
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                var me = RemoveMe(i, list);
                var alice = RemoveAlice(i, list);
                var bob = RemoveBob(i, list);

                GetMaximumHelper(list, current + me, ref max);

                AddBackBob(i, list, bob);
                AddBackAlice(i, list, alice);
                AddBackMe(i, list, me);
            }
        }

        private void AddBackMe(int i, List<int> list, int me)
        {
            list.Insert(i, me);
        }

        private void AddBackAlice(int i, List<int> list, int alice)
        {
            if (i == 0)
            {
                list.Add(alice);
            }
            else
            {
                list.Insert(i - 1, alice);
            }
        }

        private void AddBackBob(int i, List<int> list, int bob)
        {
            if (i >= list.Count || i == 0)
            {
                list.Insert(0, bob);
            }
            else
            {
                list.Insert(i - 1, bob);
            }
        }

        private int RemoveBob(int i, List<int> list)
        {
            var bob = 0;
            if (i >= list.Count || i == 0)
            {
                bob = list[0];
                list.RemoveAt(0);
            }
            else
            {
                bob = list[i - 1];
                list.RemoveAt(i - 1);
            }

            return bob;
        }

        private int RemoveAlice(int i, List<int> list)
        {
            var alice = 0;
            if (i == 0)
            {
                alice = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
            }
            else
            {
                alice = list[i - 1];
                list.RemoveAt(i - 1);
            }

            return alice;
        }

        private int RemoveMe(int i, List<int> list)
        {
            var me = list[i];

            list.RemoveAt(i);

            return me;
        }
    }
}
