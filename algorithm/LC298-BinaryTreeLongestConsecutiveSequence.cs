using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class LC298_BinaryTreeLongestConsecutiveSequence : IRun
    {
        public void Run()
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(2);
            root.left.right = new TreeNode(3);
            root.left.right.right = new TreeNode(4);
            root.left.right.right.left = new TreeNode(6);
            root.right = new TreeNode(6);
            root.left.left = new TreeNode(7);
            root.left.right.right.right = new TreeNode(9);
            Test.Verify(3, longestConsecutive(root));
        }
        public int longestConsecutive(TreeNode root)
        {
            return longestConsecutive(root, root.val - 1, 0);
        }

        public int longestConsecutive(TreeNode root, int pre, int count)
        {
            if (root == null) return count;
            count = root.val == pre + 1 ? count + 1 : 1;
            int max = Math.Max(longestConsecutive(root.left, root.val, count), longestConsecutive(root.right, root.val, count));
            return Math.Max(max, count);
        }
    }
}
