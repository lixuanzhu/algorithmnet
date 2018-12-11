using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class LC25_ReverseNodesInKGroup
    {
        public void Run()
        {
            ListNode head = ListNode.InitListNode(new int[] { 1,2,3,4,5 });
            ListNode.DispListNode(reverseKGroup(head, 2));
        }

        public ListNode reverseKGroup(ListNode head, int k)
        {
            if (head == null || head.next == null) return head;
            int len = 0;
            ListNode m = head;
            while (m != null)
            {
                len++;
                m = m.next;
            }
            int n = len / k;
            ListNode d = new ListNode(0);
            d.next = head;
            ListNode cur, pre, first, second;
            cur = head;
            first = d;
            second = head;
            for (int i = 0; i < n; i++)
            {
                pre = null;
                int t = k;
                while (t-- > 0)
                {
                    ListNode temp = cur.next;
                    cur.next = pre;
                    pre = cur;
                    cur = temp;
                }
                first.next = pre;
                second.next = cur;
                first = second;
                second = cur;

            }
            return d.next;
        }
    }
}
