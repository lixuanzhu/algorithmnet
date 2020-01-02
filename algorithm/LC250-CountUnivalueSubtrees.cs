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
            TreeNode root = TreeNode.Deserialize(tree);

            Test.Verify(7, countUnivalSubtrees(root));
        }

        private int count = 0;
        public int countUnivalSubtrees(TreeNode root)
        {
            if (root == null) return 0;
            Dsf(root);
            return count;
        }

        public bool Dsf (TreeNode root)
        {
            if (root == null) return true;
            bool Left = Dsf(root.Left);
            bool Right = Dsf(root.Right);
            if (!Left || !Right) return false;
            if (root.Left != null && root.Val != root.Left.Val) return false;
            if (root.Right != null && root.Val != root.Right.Val) return false;
            count++;
            return true;
        }

    }
}
