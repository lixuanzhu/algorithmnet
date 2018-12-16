using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class LC250_CountUnivalueSubtrees : IRun
    {
        private int count = 0;

        public void Run()
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(1);
            root.right = new TreeNode(5);
            root.left.right = new TreeNode(5);
            root.left.left = new TreeNode(5);

            root.right.right = new TreeNode(5);
            root.right.right.left = new TreeNode(5);
            root.right.right.right = new TreeNode(5);
            Test.Verify(6, countUnivalSubtrees(root));
        }

        public int countUnivalSubtrees(TreeNode root)
        {
            countUnivalSubtrees(root, root.val);
            return count;
        }

        public bool countUnivalSubtrees(TreeNode root, int val)
        {
            if (root == null) return true;
            if (root.left == null && root.right == null)
            {
                count++;
                return true;
            }
            bool l = countUnivalSubtrees(root.left, root.val);
            bool r = countUnivalSubtrees(root.right, root.val);
            if (root.val == val && l && r)
            {
                count++;
                return true;
            }
            return false;
        }
    }
}
