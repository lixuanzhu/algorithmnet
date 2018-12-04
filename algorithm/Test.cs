using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class Test
    {
        public static void Verify(int expected, int actual, string desc)
        {
            Console.WriteLine($"{expected == actual} \t Exp: {expected}  \t Act: {actual} \t {desc}");
        }
    }
}
