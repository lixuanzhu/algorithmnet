using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class MaxLengthConsequentNumber
    {
        public void Run()
        {
            int[] arr = new int[] { 101, 5, 2, 99, 4, 3, 100, 1 , 6};
            Console.WriteLine(MaxLength(arr));
            Console.WriteLine(MaxLength2(arr));
        }

        public int MaxLength(int[] arr)
        {
            int maxLength = 0;
            Dictionary<int, bool> map = new Dictionary<int, bool>();
            foreach (int i in  arr)
            {
                map.Add(i, false);
            }
            for(int i = 0; i < arr.Length; i++)
            {
                if (!map[arr[i]])
                {
                    map[arr[i]] = true;
                    int currentStreck = 1;
                    int plus = arr[i] + 1;
                    while (map.ContainsKey(plus))
                    {
                        map[plus] = true;
                        currentStreck++;
                        plus++;
                    }
                    int minus = arr[i] - 1;
                    while (map.ContainsKey(minus))
                    {
                        map[minus] = true;
                        currentStreck++;
                        minus--;
                    }

                    maxLength = Math.Max(maxLength, currentStreck);
                }
            }
            return maxLength;
        }

        public int MaxLength2(int[] arr)
        {
            int maxLength = 0;
            HashSet<int> set = new HashSet<int>(arr);
            foreach (int i in arr)
            {
                if (!set.Contains(i-1))
                {
                    int currentStreck = 1;
                    int j = i + 1;
                    while (set.Contains(j++))
                    {
                        currentStreck++;
                    }

                    maxLength = Math.Max(maxLength, currentStreck);
                }
            }
            return maxLength;
        }

    }
}
