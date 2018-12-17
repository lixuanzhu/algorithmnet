using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class LC250_CountUnivalueSubtrees : IRun
    {
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
            if (root == null) return 0;
            int left = countUnivalSubtrees(root.left);
            int right = countUnivalSubtrees(root.right);
            if (root.left != null && root.val != root.left.val) return left + right;
            if (root.right != null && root.val != root.right.val) return left + right;
            return left + right + 1;
        }

    }
}
