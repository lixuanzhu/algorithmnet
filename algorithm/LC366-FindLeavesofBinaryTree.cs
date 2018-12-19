using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class LC366_FindLeavesofBinaryTree : IRun
    {
        public void Run()
        {
            string tree = "1 2 3 4 5 n 6 n n n n 7 n n n ";
            TreeNode root = TreeNode.deserialize(tree);

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
