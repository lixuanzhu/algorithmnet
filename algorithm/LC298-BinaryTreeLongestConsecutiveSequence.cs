using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class LC298_BinaryTreeLongestConsecutiveSequence : IRun
    {
        public int res = 0;

        public void Run()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(4);
            root.left.right = new TreeNode(4);
            root.left.left = new TreeNode(7);
            root.left.right.right = new TreeNode(5);
            root.left.right.right.left = new TreeNode(6);
            Test.Verify(3, longestConsecutive(root));
        }
        public int longestConsecutive(TreeNode root)
        {
            longestConsecutive(root, root.val);
            return res;
        }

        public int longestConsecutive(TreeNode root, int rootval)
        {
            if (root == null) return 0;
            int left = longestConsecutive(root.left, root.val + 1);
            int right = longestConsecutive(root.right, root.val + 1);
            int max = Math.Max(left, right) + 1;
            res = Math.Max(res, max);
            if (rootval != root.val) max = 0;
            return max;
        }
    }
}
