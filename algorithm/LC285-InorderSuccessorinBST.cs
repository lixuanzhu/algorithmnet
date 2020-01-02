using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class LC285_InorderSuccessorinBST : IRun
    {
        public void Run()
        {
            string tree = "5 3 7 2 4 6 8";
            TreeNode root = TreeNode.Deserialize(tree);
            TreeNode res = inorderSuccessor(root, 8);
            Console.WriteLine(res.Val);
        }

        public TreeNode inorderSuccessor(TreeNode root, int p)
        {
            if (root == null) return null;
            TreeNode parent = null;
            while(root.Val != p && root != null)
            {
                if(p < root.Val)
                {
                    parent = root;
                    root = root.Left;
                }
                else
                {
                    root = root.Right;
                }
            }
            if (root == null) return null;
            if (root.Right == null) return parent;
            root = root.Right;
            while(root.Left != null)
            {
                root = root.Left;
            }
            return root;
        }
    }
}
