using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class LC250_CountUnivalueSubtrees : IRun
    {
        public void Run()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(2);
            root.right = new TreeNode(5);
            root.right.right = new TreeNode(5);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(2);
            root.left.left.left = new TreeNode(4);
            root.left.left.right = new TreeNode(5);
            root.left.right.left = new TreeNode(2);
            root.left.right.right = new TreeNode(2);

            Test.Verify(7, countUnivalSubtrees(root));
        }

        private int count = 0;
        public int countUnivalSubtrees(TreeNode root)
        {
            if (root == null) return 0;
            dsf(root);
            return count;
        }

        public bool dsf (TreeNode root)
        {
            if (root == null) return true;
            bool left = dsf(root.left);
            bool right = dsf(root.right);
            if (!left || !right) return false;
            if (root.left != null && root.val != root.left.val) return false;
            if (root.right != null && root.val != root.right.val) return false;
            count++;
            return true;
        }

    }
}
