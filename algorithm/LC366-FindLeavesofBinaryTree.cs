using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class LC366_FindLeavesofBinaryTree : IRun
    {
        public void Run()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.right.right = new TreeNode(6);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.right.left = new TreeNode(7);

            var res = findLeaves(root);
            foreach(var list in res)
            {
                foreach(var n in list)
                {
                    Console.Write(n + "\t");
                }
                Console.WriteLine(" ");
            }
        }

        public IList<IList<int>> findLeaves(TreeNode root)
        {
            var res = new List<IList<int>>();
            if (root == null) return res;
            dsf(root, res);
            return res;
        }

        public int dsf(TreeNode root, IList<IList<int>> res)
        {
            if (root == null) return -1;
            int left = dsf(root.left, res);
            int right = dsf(root.right, res);
            int d = Math.Max(left, right) + 1;
            if (res.Count <= d) res.Add(new List<int>());
            res[d].Add(root.val);
            return d;
        }
    }
}
