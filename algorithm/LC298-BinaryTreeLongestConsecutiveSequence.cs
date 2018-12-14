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
            var root = new TreeNode(1);
            TreeNode head = root;
            root.left = new TreeNode(2);
            root.right = new TreeNode(4);
            root = root.left;
            root.right = new TreeNode(4);
            root.left = new TreeNode(7);
            root = root.right;
            root.right = new TreeNode(5);
            root = root.right;
            root.left = new TreeNode(6);
            Test.Verify(3, longestConsecutive(head));
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
