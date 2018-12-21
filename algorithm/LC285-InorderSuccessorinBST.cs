using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class LC285_InorderSuccessorinBST : IRun
    {
        public void Run()
        {
            string tree = "5 3 7 2 4 6 8";
            TreeNode root = TreeNode.deserialize(tree);
            TreeNode res = inorderSuccessor(root, 8);
            Console.WriteLine(res.val);
        }

        public TreeNode inorderSuccessor(TreeNode root, int p)
        {
            if (root == null) return null;
            TreeNode parent = null;
            while(root.val != p && root != null)
            {
                if(p < root.val)
                {
                    parent = root;
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }
            }
            if (root == null) return null;
            if (root.right == null) return parent;
            root = root.right;
            while(root.left != null)
            {
                root = root.left;
            }
            return root;
        }
    }
}
