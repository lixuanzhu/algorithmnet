using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class SetMerge : IRun
    {
        public void Run()
        {
            List<HashSet<int>> sets = new List<HashSet<int>>();
            sets.Add(new HashSet<int>(new int[] { 1, 2 }));
            sets.Add(new HashSet<int>(new int[] { 3, 4 }));
            sets.Add(new HashSet<int>(new int[] { 1, 5 }));
            sets.Add(new HashSet<int>(new int[] { 7, 4 }));
            var merged = Merge(sets);
            foreach (HashSet<int> set in merged)
            {
                foreach (int i in set)
                {
                    Console.Write(i + "\t");
                }
                Console.WriteLine();
            }
        }

        public List<HashSet<int>> Merge(List<HashSet<int>> sets)
        {
            List<HashSet<int>> res = new List<HashSet<int>>();
            Merge(sets, res);
            return res;
        }

        private void Merge(List<HashSet<int>> sets, List<HashSet<int>> res)
        {
            int size = sets.Count;
            if (size == 0) return;
            
            HashSet<int> last = sets[size - 1];
            int next = size - 2;
            while(next >= 0)
            {
                if(CanMerge(last, sets[next]))
                {
                    Merge(last, sets[next]);
                    sets.RemoveAt(next);
                }
                next--;
            }

            if(sets.Count == size)
            {
                res.Add(last);
                sets.RemoveAt(sets.Count - 1);
            }

            Merge(sets, res);
        }

        private bool CanMerge(HashSet<int> s1, HashSet<int> s2)
        {
            foreach (int i in s2)
            {
                if (s1.Contains(i)) return true;
            }
            return false;
        }

        private void Merge (HashSet<int> s1, HashSet<int> s2)
        {
            foreach(int i in s2)
            {
                if (!s1.Contains(i))
                {
                    s1.Add(i);
                }
            }
        }
    }
}
