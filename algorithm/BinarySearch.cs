using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class BinarySearch : IRun
    {
        public void Run()
        {
            int[] dupnums = {1, 2, 2, 5};
            Test.Verify(0, DuplicateLeftSearch(dupnums, 1), "Ldup");
            Test.Verify(1, DuplicateLeftSearch(dupnums, 2), "Ldup");
            Test.Verify(-1, DuplicateLeftSearch(dupnums, 3), "Ldup");
            Test.Verify(3, DuplicateLeftSearch(dupnums, 5), "Ldup");
            Test.Verify(-1, DuplicateLeftSearch(new int[] { }, 5), "Ldup empty");
            Test.Verify(0, DuplicateRightSearch(dupnums, 1), "Rdup");
            Test.Verify(2, DuplicateRightSearch(dupnums, 2), "Rdup");
            Test.Verify(-1, DuplicateRightSearch(dupnums, 3), "Rdup");
            Test.Verify(3, DuplicateRightSearch(dupnums, 5), "Rdup");

            int[] nums = { 2, 3, 5 };
            for (int i = 0; i < nums.Length; i++)
            {
                Test.Verify(i, IterativeSearch(nums, nums[i]), "ite");
                Test.Verify(i, RecursiveSearch(nums, nums[i]), "rec");
            }
            Test.Verify(-1, IterativeSearch(nums, 1), "ite");
            Test.Verify(-1, RecursiveSearch(nums, 4), "rec");
            Test.Verify(-1, IterativeSearch(nums, 6), "ite");
            Test.Verify(-1, RecursiveSearch(nums, 6), "rec");
            Test.Verify(-1, IterativeSearch(new int[] { }, 6), "ite empty");
            Test.Verify(-1, RecursiveSearch(new int[] { }, 6), "rec empty");
        }

        public int RecursiveSearch(int[] nums, int target)
        {
            if (nums == null || nums.Length == 1)
                return -1;
            return RecursiveSearch(nums, target, 0, nums.Length -1);
        }

        private int RecursiveSearch ( int[] nums, int target, int Left, int Right)
        {
            if (Left > Right)
                return -1;
            int middle = Left + (Right - Left) / 2;
            if (nums[middle] == target)
                return middle;
            if (nums[middle] > target)
                return RecursiveSearch(nums, target, Left, middle - 1);
            return RecursiveSearch(nums, target, middle + 1, Right);
        }

        private int IterativeSearch(int[] nums, int target)
        {
            int Left = 0;
            int Right = nums.Length - 1;
            while( Left <= Right)
            {
                int middle = Left + (Right - Left) / 2;
                if (nums[middle] == target)
                    return middle;
                if(nums[middle] > target)
                {
                    Right = middle - 1;
                }
                else
                {
                    Left = middle + 1;
                }
            }
            return -1;
        }

        private int DuplicateLeftSearch(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            int l = 0;
            int r = nums.Length - 1;
            int res = -1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if(nums[m] > target) r = m - 1;
                else 
                {
                    if (nums[m] == target) res = m;
                    l = m + 1;
                }
            }
            
            return res;
        }

        private int DuplicateRightSearch(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            int l = 0;
            int r = nums.Length - 1;
            int res = -1;

            while (l < r)
            {
                int m = l + (r - l) / 2;
                if (nums[m] < target) l = m + 1;
                else
                {
                    if (nums[m] == target) res = m;
                    r = m;
                }
            }
            return res;
        }
    }
}
