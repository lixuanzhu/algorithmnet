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
            root.Left = new TreeNode(2);
            root.Left.Right = new TreeNode(3);
            root.Left.Right.Right = new TreeNode(4);
            root.Left.Right.Right.Left = new TreeNode(6);
            root.Right = new TreeNode(6);
            root.Left.Left = new TreeNode(7);
            root.Left.Right.Right.Right = new TreeNode(9);
            Test.Verify(3, longestConsecutive(root));
        }
        public int longestConsecutive(TreeNode root)
        {
            return longestConsecutive(root, root.Val - 1, 0);
        }

        public int longestConsecutive(TreeNode root, int pre, int count)
        {
            if (root == null) return count;
            count = root.Val == pre + 1 ? count + 1 : 1;
            int max = Math.Max(longestConsecutive(root.Left, root.Val, count), longestConsecutive(root.Right, root.Val, count));
            return Math.Max(max, count);
        }
    }
}
