﻿using System;
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

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) {val = x;}

        public static string serialize(TreeNode root)
        {
            if (root == null) return "";
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            StringBuilder sb = new StringBuilder();
            while (q.Count != 0)
            {
                TreeNode t = q.Dequeue();
                if (t != null)
                {
                    sb.Append(t.val + " ");
                    q.Enqueue(t.left);
                    q.Enqueue(t.right);
                }
                else
                {
                    sb.Append("n ");
                }
            }
            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public static TreeNode deserialize(String data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            String[] d = data.Split(" ");
            int i = 0;
            Queue<TreeNode> q = new Queue<TreeNode>();
            TreeNode root = new TreeNode(int.Parse(d[i]));
            q.Enqueue(root);
            while (q.Count != 0)
            {
                TreeNode t = q.Dequeue();
                i++;
                if (i >= d.Length) break;
                if (d[i] != "n")
                {
                    int v = int.Parse(d[i]);
                    t.left = new TreeNode(v);
                    q.Enqueue(t.left);
                }
                i++;
                if (i >= d.Length) break;
                if (d[i] != "n")
                {
                    int v = int.Parse(d[i]);
                    t.right = new TreeNode(v);
                    q.Enqueue(t.right);
                }
            }

            return root;
        }
    }
}
