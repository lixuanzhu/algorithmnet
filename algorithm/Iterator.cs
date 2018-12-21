using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class Iterator : IRun
    {
        interface IItorator
        {
            bool HasNext();
            int Next();
        }
        class SingleItrator : IItorator
        {
            private int[] collection;
            private int cur;
            private int n;

            public SingleItrator( int[] init)
            {
                collection = init;
                n = init.Length;
                cur = -1;
            }

            public bool HasNext()
            {
                return cur < n - 1;
            }

            public int Next()
            {
                if (!HasNext()) throw new Exception("no next");
                cur++;
                return collection[cur];
            }
        }

        public void Run()
        {
            SingleItrator sit = new SingleItrator(new int[] { 1, 1, 2, 4, 3, 0, 4, 3});
            RepeatIterator rit = new RepeatIterator(sit);
            while (rit.HasNext()) Console.Write(rit.Next() + "\t");
        }

        class RepeatIterator
        {
            private int val;
            private int count;
            private SingleItrator it;

            public RepeatIterator(SingleItrator sit)
            {
                it = sit;
                count = 0;
                val = 0;
            }

            public bool HasNext()
            {
                while (count == 0 && it.HasNext())
                {
                    val = it.Next();
                    if (!it.HasNext()) return false;
                    count = it.Next();
                }
                return count != 0;
            }

            public int Next()
            {
                if(count > 0)
                {
                    count--;
                    return val;
                } 
                else
                {
                    if(this.HasNext())
                    {
                        count--;
                        return val;
                    }
                    throw new Exception("no repeat next");
                }
            }
        }
    }
}
