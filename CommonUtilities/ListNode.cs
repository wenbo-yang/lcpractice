using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities
{
    public class ListNode
    {
        public int Value { get; set; }
        public ListNode Next { get; set; }
    }

    public class LinkedListBuilder // wrapper not tested
    {
        public static List<int> GetList(ListNode head)
        {
            var list = new List<int>();
            var tempHead = head;

            while (tempHead != null)
            {
                list.Add(tempHead.Value);
                tempHead = tempHead.Next;
            }

            return list;
        }

        public ListNode Head { get; private set; }

        public LinkedListBuilder ConstructFromArray(int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                var temp = new ListNode { Value = array[i], Next = Head };
                Head = temp;
            }

            return this;
        }
    }


}
