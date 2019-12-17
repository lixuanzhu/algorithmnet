using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class LC61_RotateList
    {
        public void Run()
        {
            ListNode<int> head = new ListNode<int>(new int[] { 1, 2, 3,4,5,6});
            ListNode<int>.PrintListNode(head);
            RotateRight(head.PrintListNode(), 3).PrintListNode();
        }
        public ListNode<int> RotateRight(ListNode<int> head, int k)
        {
            if (head == null || head.Next == null || k == 0) return head;
            int len = 1;
            ListNode<int> cur = head;
            while (cur.Next != null)
            {
                len++;
                cur = cur.Next;
            }
            cur.Next = head;

            int move = len - k % len - 1;
            while (move-- > 0)
            {
                head = head.Next;
            }
            cur = head.Next;
            head.Next = null;

            return cur;
        }
    }
}
