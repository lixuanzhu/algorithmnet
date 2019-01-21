using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class Test
    {
        public static void Verify(int expected, int actual, string desc = "")
        {
            Console.WriteLine($"{expected == actual} \t Exp: {expected}  \t Act: {actual} \t {desc}");
        }

        public static void Verify(bool expected, bool actual, string desc = "")
        {
            Console.WriteLine($"{expected == actual} \t Exp: {expected}  \t Act: {actual} \t {desc}");
        }

        public static void PrintArray(int[] nums)
        {
            foreach (int n in nums)
            {
                Console.Write(n + "\t");
            }
            Console.WriteLine();
        }
    }
}
