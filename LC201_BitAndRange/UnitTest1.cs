using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC201_BitAndRange
{
    [TestClass]
    public class BitWiseRangeTests
    {
        [TestMethod]
        public void GivenRange_BitWiseAnd_ShouldGiveCorrectResult()
        {
            uint result = BitWiseRangeAnd(5, 7);

            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void GivenAnotherRange_BitWiseAnd_ShouldGiveCorrectResult()
        {
            uint result = BitWiseRangeAnd(26, 30);

            Assert.IsTrue(result == 24);
        }

        private uint BitWiseRangeAnd(uint lower, uint upper)
        {
            var rangeAnd = lower & upper;

            if (rangeAnd > 0)
            {
                var diff = (upper - lower) + 1;
                var msb = MostSignificantBit(diff) ;
                var mask = AddMaskToMsb(msb);
                rangeAnd &= mask ;
            }

            return rangeAnd;
        }

        private uint AddMaskToMsb(uint msb)
        {
            return uint.MaxValue - (msb - 1);
        }

        private uint MostSignificantBit(uint num)
        {
            num |= num >> 1;
            num |= num >> 2;
            num |= num >> 4;
            num |= num >> 8;
            num |= num >> 16;

            return num - (num >> 1);
        }
    }
}
