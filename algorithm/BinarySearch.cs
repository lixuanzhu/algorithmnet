using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class BinarySearch : IRun
    {
        public void Run()
        {
            int[] dupnums = {1, 2, 2, 5};
            Test.Verify(1, DuplicateSearch(dupnums, 2), "dup");
            Test.Verify(-1, DuplicateSearch(dupnums, 3), "dup");
            Test.Verify(3, DuplicateSearch(dupnums, 5), "dup");
            Test.Verify(-1, DuplicateSearch(new int[] { }, 5), "dup empty");
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

        private int RecursiveSearch ( int[] nums, int target, int left, int right)
        {
            if (left > right)
                return -1;
            int middle = left + (right - left) / 2;
            if (nums[middle] == target)
                return middle;
            if (nums[middle] > target)
                return RecursiveSearch(nums, target, left, middle - 1);
            return RecursiveSearch(nums, target, middle + 1, right);
        }

        private int IterativeSearch(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while( left <= right)
            {
                int middle = left + (right - left) / 2;
                if (nums[middle] == target)
                    return middle;
                if(nums[middle] > target)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return -1;
        }

        private int DuplicateSearch(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            int l = 0;
            int r = nums.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if(nums[m] >= target)
                {
                    r = m - 1;
                }
                else 
                {
                    l = m + 1;
                }
            }
            if (nums[l] == target) return l;
            return -1;
        }
    }
}
