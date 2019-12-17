using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class LC234_PalindromeLinkedList
    {
        public void Run()
        {
            ListNode<int> head = new ListNode<int>(new int[] { 9, 8, 9 });
            Test.Verify(true, IsPalindrome(head.PrintListNode()));
        }
        public bool IsPalindrome(ListNode<int> head)
        {
            if (head == null) return true;
            int len = 0;
            ListNode<int> cur = head;
            while (cur != null)
            {
                len++;
                cur = cur.Next;
            }
            int half = len / 2;
            cur = head;

            ListNode<int> pre = null;
            while (half-- > 0)
            {
                ListNode<int> temp = cur.Next;
                cur.Next = pre;
                pre = cur;
                cur = temp;
            }
            if (len % 2 == 1) cur = cur.Next;
            while (pre != null && cur != null)
            {
                if (pre.Val != cur.Val) return false;
                pre = pre.Next;
                cur = cur.Next;
            }
            return true;

        }
    }
}
