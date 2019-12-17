using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class LC25_ReverseNodesInKGroup
    {
        public void Run()
        {
            ListNode<int> head = new ListNode<int>(new int[] { 1,2,3,4,5,6, 7,8 });
            ReverseKGroup(head.PrintListNode(), 3).PrintListNode();
        }

        public ListNode<int> ReverseKGroup(ListNode<int> head, int k)
        {
            if (head == null || head.Next == null) return head;
            int len = 0;
            ListNode<int> m = head;
            while (m != null)
            {
                len++;
                m = m.Next;
            }
            int n = len / k;
            ListNode<int> d = new ListNode<int>(0);
            d.Next = head;
            ListNode<int> cur, pre, first, second;
            cur = head;
            first = d;
            second = head;
            for (int i = 0; i < n; i++)
            {
                pre = null;
                int t = k;
                while (t-- > 0)
                {
                    ListNode<int> temp = cur.Next;
                    cur.Next = pre;
                    pre = cur;
                    cur = temp;
                }
                first.Next = pre;
                second.Next = cur;
                first = second;
                second = cur;

            }
            return d.Next;
        }
    }
}
