using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class LC61_RotateList
    {
        public void Run()
        {
            ListNode head = ListNode.InitListNode(new int[] { 1, 2, 3});
            ListNode.DispListNode(rotateRight(head, 3));
        }
        public ListNode rotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0) return head;
            int len = 1;
            ListNode cur = head;
            while (cur.next != null)
            {
                len++;
                cur = cur.next;
            }
            cur.next = head;

            int move = len - k % len - 1;
            while (move-- > 0)
            {
                head = head.next;
            }
            cur = head.next;
            head.next = null;

            return cur;
        }
    }
}
