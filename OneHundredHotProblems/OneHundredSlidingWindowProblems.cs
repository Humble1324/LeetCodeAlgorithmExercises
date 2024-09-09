using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OneHundredHotProblems;

public class OneHundredSlidingWindowProblems
{
    public static IList<int> FindAnagrams(string s, string p)
    {
        List<int> ans = new List<int>();
        if (s.Length < p.Length)
        {
            return ans;
        }

        int fast = p.Length - 1, slow = 0;
        int[] textNums = new int[26];
        int[] pNums = new int[26];
        for (var i = 0; i <= fast; i++)
        {
            pNums[p[i] - 'a']++;
        }

        for (var i = 0; i <= fast; i++)
        {
            textNums[s[i] - 'a']++;
        }

        while (fast < s.Length)
        {
            if (IsSame(textNums, pNums))
            {
                ans.Add(slow);
            }

            fast++;
            if (fast == s.Length) break;
            textNums[s[fast] - 'a']++;
            textNums[s[slow++] - 'a']--;
        }

        return ans;
    }

    private static bool IsSame(int[] a, int[] b)
    {
        for (var i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }

        return true;
    }

    // public static void Main(string[] args)
    // {
    //     FindAnagrams("acab", "ab");
    // }
}