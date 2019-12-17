using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{

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

        public static TreeNode deserialize(String data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            String[] d = data.Split(" ");

            Queue<TreeNode> q = new Queue<TreeNode>();
            TreeNode root = new TreeNode(int.Parse(d[0]));
            q.Enqueue(root);
            for (int i = 1; i < d.Length; i++)
            {
                TreeNode t = q.Dequeue();
                if (d[i] != "n")
                {
                    t.left = new TreeNode(int.Parse(d[i]));
                    q.Enqueue(t.left);
                }
                i++;
                if (i >= d.Length) break;
                if (d[i] != "n")
                {
                    t.right = new TreeNode(int.Parse(d[i]));
                    q.Enqueue(t.right);
                }
            }

            return root;
        }
    }
}
