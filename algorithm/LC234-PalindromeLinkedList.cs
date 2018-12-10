using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class LC234_PalindromeLinkedList
    {
        public void Run()
        {
            ListNode head = ListNode.InitListNode(new int[] { 9, 8, 9 });
            Console.WriteLine(isPalindrome(head));
        }
        public bool isPalindrome(ListNode head)
        {
            if (head == null) return true;
            int len = 0;
            ListNode cur = head;
            while (cur != null)
            {
                len++;
                cur = cur.next;
            }
            int half = len / 2;
            cur = head;

            ListNode pre = null;
            while (half-- > 0)
            {
                ListNode temp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = temp;
            }
            if (len % 2 == 1) cur = cur.next;
            while (pre != null && cur != null)
            {
                if (pre.val != cur.val) return false;
            }
            return true;

        }
    }
}
