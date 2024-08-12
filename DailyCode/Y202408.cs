using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.DailyCode;

public class Y202408
{
    public int MaxmiumScore(int[] cards, int cnt)
    {
        Array.Sort(cards);

        int ans = 0;
        int tmp = 0;
        int odd = -1, even = -1;
        int end = cards.Length - cnt;
        for (int i = cards.Length - 1; i >= end; i--)
        {
            tmp += cards[i];
            if ((cards[i] & 1) != 0)
            {
                odd = cards[i];
            }
            else
            {
                even = cards[i];
            }
        }

        if ((tmp & 1) == 0)
        {
            return tmp;
        }

        for (int i = cards.Length - cnt - 1; i >= 0; i--)
        {
            if ((cards[i] & 1) != 0)
            {
                if (even != -1)
                {
                    ans = Math.Max(ans, tmp - even + cards[i]);
                    break;
                }
            }
        }

        for (int i = cards.Length - cnt - 1; i >= 0; i--)
        {
            if ((cards[i] & 1) == 0)
            {
                if (odd != -1)
                {
                    ans = Math.Max(ans, tmp - odd + cards[i]);
                    break;
                }
            }
        }

        return ans;
    }

    public static long NumberOfRightTriangles(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[] col = new int[n];
        long ans = 0;
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                col[j] += grid[i][j];
            }
        }

        for (var i = 0; i < m; i++)
        {
            int row = grid[i].Sum();
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    ans += ((row - 1) * (col[j] - 1));
                }
            }
        }

        return ans;
    }

    public class MagicDictionary
    {
        public HashSet<string> magicHash;

        public MagicDictionary()
        {
            magicHash = new HashSet<string>();
        }

        public void BuildDict(string[] dictionary)
        {
            foreach (var s in dictionary)
            {
                magicHash.Add(s);
            }
        }

        public bool Search(string searchWord)
        {


            var lens = searchWord.Length;
            foreach (var s in magicHash)
            {
                if (s.Length != lens)
                {
                    continue;
                }

                int temp = 0;
                for (int index = 0; index < lens; )
                {
                    
                    while (index < lens && s[index] == searchWord[index])
                    {
                        index++;
                    }


                    if (index < lens && s[index] != searchWord[index])
                    {
                        temp++;
                        index++;

                    }

                    if (index == lens  && temp == 1)
                    {
                        return true;
                    }

                    if (index >= lens || temp != 1)
                    {
                        break;
                    }
                }
            }

            return false;
        }
    }

    /**
     * Your MagicDictionary object will be instantiated and called as such:
     * MagicDictionary obj = new MagicDictionary();
     * obj.BuildDict(dictionary);
     * bool param_2 = obj.Search(searchWord);
     */
//
// public static bool IsLegal(int x, int y, int val)
// {
//     if (m == 0 || n == 0)
//     {
//         return false;
//     }
//
//     return x < n && y < m && x >= 0 && y >= 0 && val == 1;
// }
    // public static void Main()
    // {
    //     MagicDictionary obj = new MagicDictionary();
    //     string[] dictionary = new string[] { "hello", "leetcode" };
    //     obj.BuildDict(dictionary);
    //     bool param_2 = obj.Search("hhllo");
    //     Console.WriteLine(param_2.ToString());
    // }
}