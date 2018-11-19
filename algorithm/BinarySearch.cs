using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class BinarySearch : IRun
    {
        public void Run()
        {
            int[] nums = { 2, 4, 5, 7, 9, 13, 25, 34, 35 };
            for (int i = 0; i < nums.Length; i++)
            {
                int result = Search(nums, nums[i]);
                int target = i;
                Console.WriteLine($"{result == target} result is {result} and answer is {target}");
            }

        }
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 1)
                return -1;
            return UniqueSearch(nums, target, 0, nums.Length - 1);
        }

        private int UniqueSearch ( int[] nums, int target, int left, int right)
        {
            if (left > right)
                return -1;
            int middle = left + (right - left) / 2;
            if (nums[middle] == target)
                return middle;
            if (nums[middle] > target)
                return UniqueSearch(nums, target, left, middle - 1);
            return UniqueSearch(nums, target, middle + 1, right);
        }

        private int DuplicateSearch(int[] nums, int target, int left, int right)
        {
            return -1;
        }
    }
}
