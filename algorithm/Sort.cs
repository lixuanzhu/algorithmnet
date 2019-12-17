using System;

namespace Algorithm
{
    class Sort :IRun
    {
        public void Run()
        {
            int[] nums = new int[] { 9, 1, 12, 45, 3, 13, 6, 2, 6, 4, 23, 45, 7, 8 };
            Action<int[]>[] actions = new Action<int[]>[] { SelectionSort, BubbleSort, InsertionSort, MergeSort, QuickSort }; 
            int[] copy;
            for(int i = 0; i < actions.Length; i++)
            {
                copy = (int[])nums.Clone();
                actions[i](copy);
                Test.PrintArray(copy);
            }

        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        private void SelectionSort(int[] nums)
        {
            int n = nums.Length;
            for(int i  = 0; i < n-1; i++)
            {
                int minIdx = i;
                for(int j = i+1; j < n; j++)
                {
                    if(nums[minIdx] > nums[j])
                    {
                        minIdx = j;
                    }
                }
                Swap(nums, i, minIdx);
            }
        }

        private void BubbleSort(int[] nums)
        {
            int n = nums.Length;
            for(int i = 0; i < n-1; i++)
            {
                bool swap = false;
                for(int j = 0; j < n - i -1; j++)
                {
                    if(nums[j] > nums[j + 1])
                    {
                        Swap(nums, j, j + 1);
                        swap = true;
                    }
                }
                //best case sorted O(n)
                if (!swap) break;
            }
        }

        private void InsertionSort(int[] nums)
        {
            int n = nums.Length;
            for(int i = 1; i < n; i++)
            {
                int hole = i;
                int holeValue = nums[i];
                //best case : sorted. O(n)
                //worst case: reversed. O(n^2)
                while(hole > 0 && holeValue < nums[hole-1])
                {
                    nums[hole] = nums[hole-1];
                    hole--;
                }
                nums[hole] = holeValue;
            }
        }

        private void MergeSort(int[] nums)
        {
            int n = nums.Length;
            if (n < 2) return;
            int m = n / 2;
            int[] left = new int[m];
            int[] right = new int[n - m];
            for(int i = 0; i < m; i++) left[i] = nums[i];
            for(int i = 0; i < n -m; i++) right[i] = nums[i + m];
            MergeSort(left);
            MergeSort(right);
            Merge(left, right, nums);
        }

        private void Merge(int[] left, int[] right, int[] nums)
        {
            int l = 0, r = 0, n = 0;
            while(l < left.Length && r < right.Length)
            {
                if(left[l] <= right[r]) nums[n++] = left[l++];
                else nums[n++] = right[r++];
            }
            while(l < left.Length) nums[n++] = left[l++];
            while (r < right.Length) nums[n++] = right[r++];
        }

        private void QuickSort(int[] nums)
        {
            QuickSort(nums, 0, nums.Length - 1);
        } 

        private void QuickSort(int[] nums, int s, int f)
        {
            if (s < f)
            {
                int pidx = Partition(nums, s, f);
                QuickSort(nums, s, pidx - 1);
                QuickSort(nums, pidx + 1, f);
            }
        }

        private int Partition(int[] nums, int s, int f)
        {
            int pv = nums[f];
            int pi = s;
            for(int i = s; i < f; i++)
            {
                if(pv > nums[i])
                {
                    Swap(nums, pi, i);
                    pi++;
                }
            }
            Swap(nums, pi, f);
            return pi;
        }
    }
}
