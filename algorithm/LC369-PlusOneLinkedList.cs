using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class LC369_PlusOneLinkedList : IRun
    {
        public void Run()
        {
            ListNode<int> head = new ListNode<int>(new int[] { 9,9,9 });
            PlusOne(head).PrintListNode();
        }

        public ListNode<int> PlusOne(ListNode<int> head)
        {
            ListNode<int> dummy = new ListNode<int>(0)
            {
                Next = head
            };
            ListNode<int> cur = dummy;
            ListNode<int> next = dummy;
            while(next != null)
            {
                if(next.Val != 9)
                {
                    cur = next;
                }
                next = next.Next;
            }
            next = cur;
            next.Val += 1;
            next = next.Next;
            while(next != null)
            {
                next.Val = 0;
                next = next.Next;
            }

            return dummy == cur ? dummy : dummy.Next;
        }
    }
}
