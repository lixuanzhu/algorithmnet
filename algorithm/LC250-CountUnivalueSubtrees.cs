using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class LC250_CountUnivalueSubtrees : IRun
    {
        public void Run()
        {
            string tree = "3 2 5 2 2 n 5 4 5 2 2";
            TreeNode root = TreeNode.deserialize(tree);

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
