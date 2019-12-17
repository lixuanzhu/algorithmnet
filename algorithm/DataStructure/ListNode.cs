using System;
using System.Resources;

namespace Algorithm
{
    public class ListNode<T>
    {
        public T Val { get; set; }

        public ListNode<T> Next { get; set; }

        public ListNode(T val)
        {
            Val = val;
        }

        public ListNode(T[] vals)
        {
            if(vals == null || vals.Length == 0)
            {
                return;
            }

            ListNode<T> cur = new ListNode<T>(vals[0]);
            ListNode<T> head = cur;

            for (int i = 1; i < vals.Length; i++)
            {
                cur.Next = new ListNode<T>(vals[i]);
                cur = cur.Next;
            }

            Val = head.Val;
            Next = head.Next;
        }

        public ListNode<T> PrintListNode()
        {
            ListNode<T> cur = this;
            while (cur != null)
            {
                Console.Write(cur.Val + " > ");
                cur = cur.Next;
            }

            Console.WriteLine();
            return this;
        }

        public static void PrintListNode(ListNode<T> x)
        {
            while (x != null)
            {
                Console.Write(x.Val + " > ");
                x = x.Next;
            }

            Console.WriteLine();
        }
    }
}
