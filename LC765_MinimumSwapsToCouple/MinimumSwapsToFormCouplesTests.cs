using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC765_MinimumSwapsToCouple
{
    [TestClass]
    public class MinimumSwapsToFormCouplesTests
    {
        [TestMethod]
        public void GivenArraySeatingArrangement_FindMinimumSwaps_ShouldReturnMinimumSwaps()
        {
            var input = new int[] { 2, 0, 1, 3 };
            var result = FindMinimumSwaps(input);

            Assert.IsTrue(result == 1);
        }

        private int FindMinimumSwaps(int[] input)
        {
            var position = GeneratePosition(input);

            var numCouples = input.Length / 2;

            var swaps = 0;

            for (int i = 0; i < numCouples; i++)
            {
                if (!IsCoupleAlreadySet(input, i))
                {
                    Swap(input, i, position);
                    swaps++;
                }
            }

            return swaps;
        }

        private void Swap(int[] input, int coupleSlot, int[] position)
        {
            var realPosition = coupleSlot * 2;
            var couple = input[realPosition] % 2 == 0 ? input[realPosition] + 1 : input[realPosition] - 1;

            SwapHelper(input, realPosition + 1, couple, position);
        }

        private void SwapHelper(int[] input, int sourceSlot, int couple, int[] position)
        {
            var targetPosition = position[couple];

            var temp = input[sourceSlot];

            input[sourceSlot] = input[targetPosition];
            input[targetPosition] = temp;

            position[input[sourceSlot]] = sourceSlot;
            position[input[targetPosition]] = targetPosition;
        }

        private bool IsCoupleAlreadySet(int[] input, int coupleSlot)
        {
            var realPosition = coupleSlot * 2;

            if (input[realPosition] % 2 == 0)
            {
                return input[realPosition + 1] == input[realPosition] + 1;
            }

            return input[realPosition + 1] == input[realPosition] - 1;
        }


        private int[] GeneratePosition(int[] input)
        {
            var position = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                position[input[i]] = i;
            }
            return position;
        }
    }
}
