using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1276_NumberOfBurgers
{
    [TestClass]
    public class NumberOfBurgersTests
    {
        [TestMethod]
        public void GivenAllTheIngredients_GetNumberOfBurgers_ShouldReturnNumberOfBurgersWithNoWastes()
        {
            var tomato = 16; var cheese = 7;

            var result = GetNumberOfBurgers(tomato, cheese);

            Assert.IsTrue(result[0] == 1 && result[1] == 6);
        }

        private int[] GetNumberOfBurgers(int tomato, int cheese)
        {
            var totalNumber = cheese;
            var result = new int[2];

            if (tomato % 2 == 0 && tomato / 2 >= totalNumber)
            {
                result[0] = tomato / 2 - totalNumber;
                result[1] = totalNumber - result[0];
            }

            return result;
        }
    }
}
