using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    class LC243_Shortest_Word_Distance : IRun
    {
        public void Run()
        {
            string[] words = { "d", "a",  "c", "e", "c","b", "a" };
            Test.Verify(1, SWD(words, "c", "c")); 
        }
        public int SWD (string[] words, string word1, string word2)
        {
            int res = int.MaxValue;
            int cur = -1;
            for (int i  = 0;  i< words.Length; i++)
            {
                if (cur == -1)
                {
                    if (words[i].Equals(word1) || words[i].Equals(word2))
                    {
                        cur = i;
                    }
                }
                else
                {
                    if(words[cur] == word1 && words[i] == word2 || words[cur] == word2 && words[i] == word1)
                    {
                        res = Math.Min(res, i - cur);
                        cur = i;
                    }
                    else if(words[cur] == word1 && words[i] == word1 || words[cur] == word2 && words[i] == word2)
                    {
                        cur = i;
                    }
                }
            }
            return res;
        }
    }
}
