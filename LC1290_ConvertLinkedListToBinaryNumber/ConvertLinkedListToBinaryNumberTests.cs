using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1290_ConvertLinkedListToBinaryNumber
{
    [TestClass]
    public class ConvertLinkedListToBinaryNumberTests
    {
        [TestMethod]
        public void GivenLinkedList_ConvertToBinaryNumber_ShouldReturnBinaryNumber()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 1, 0, 1 }).Head;
            
            var result = ConvertToBinaryNumber(head);

            Assert.IsTrue(result == 5);
        }

        private int ConvertToBinaryNumber(ListNode head)
        {
            var result = 0;

            while (head != null)
            {
                result = result << 1;
                result = result + head.Value;
                head = head.Next;
            }

            return result;
        }
    }
}
