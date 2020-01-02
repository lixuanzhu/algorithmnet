using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public class TreeNode
    {
        public int Val { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode(int x)
        {
            Val = x;
        }

        public static string Serialize(TreeNode root)
        {
            if (root == null)
            {
                return "";
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            StringBuilder sb = new StringBuilder();

            while (q.Count != 0)
            {
                TreeNode t = q.Dequeue();
                if (t != null)
                {
                    sb.Append(t.Val + ",");
                    q.Enqueue(t.Left);
                    q.Enqueue(t.Right);
                }
                else
                {
                    sb.Append("n,");
                }
            }

            return sb.ToString();
        }

        public static TreeNode Deserialize(String data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            String[] nodes = data.Split(",");

            Queue<TreeNode> q = new Queue<TreeNode>();
            TreeNode root = new TreeNode(int.Parse(nodes[0]));
            q.Enqueue(root);
            //for (int i = 1; i < nodes.Length; i++)
            //{
            //    TreeNode t = q.Dequeue();
            //    if (nodes[i] != "n")
            //    {
            //        t.Left = new TreeNode(int.Parse(nodes[i]));
            //        q.Enqueue(t.Left);
            //    }
            //    i++;
            //    if (i >= nodes.Length) break;
            //    if (nodes[i] != "n")
            //    {
            //        t.Right = new TreeNode(int.Parse(nodes[i]));
            //        q.Enqueue(t.Right);
            //    }
            //}
            int i = 1;
            while (q.Count != 0)
            {
                TreeNode t = q.Dequeue();
                if(nodes[i] != "n")
                {
                    t.Left = new TreeNode(int.Parse(nodes[i]));
                    q.Enqueue(t.Left);
                }
                i++;
                if (nodes[i] != "n")
                {
                    t.Right = new TreeNode(int.Parse(nodes[i]));
                    q.Enqueue(t.Right);
                }
            }

            return root;
        }
    }
}
