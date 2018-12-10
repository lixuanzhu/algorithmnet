using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class LeetCode369_PlusOneLinkedList : IRun
    {
        public void Run()
        {
            ListNode head = ListNode.InitListNode(new int[] { 9,8,9 });
            ListNode.DispListNode(PlusOne(head));
        }

        public ListNode PlusOne(ListNode head)
        {
            ListNode d = new ListNode(0);
            d.next = head;
            ListNode cur = d;
            ListNode next = d;
            while(next != null)
            {
                if(next.val != 9)
                {
                    cur = next;
                }
                next = next.next;
            }
            next = cur;
            next.val = next.val + 1;
            next = next.next;
            while(next != null)
            {
                next.val = 0;
                next = next.next;
            }

            return d == cur ? d : d.next;
        }
    }
}
