using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public static ListNode InitListNode(int[] vals)
        {
            ListNode head = new ListNode(vals[0]);
            ListNode res = head;
            for(int i = 1; i < vals.Length; i++)
            {
                head.next = new ListNode(vals[i]);
                head = head.next;
            }
            return res;
        }

        public static void DispListNode(ListNode head)
        {
            while(head != null)
            {
                Console.Write(head.val + "  ");
                head = head.next;
            }
        }
    }


}
