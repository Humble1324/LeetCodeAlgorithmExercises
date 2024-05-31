using System;
using System.Collections.Generic;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int MaximumLength(string s)
    {
        List<List<int>> groups = new();
        int lens = s.Length;
        int cnt = 0;
        for (var i = 0; i < lens; i++)
        {
            cnt++;
            if (i + 1 == s.Length || s[i] != s[i + 1])
            {
                groups.Add(new List<int>() { s[s[i] - 'a'], cnt });
                cnt = 0;
            }
        }

        int ans = 0;
        foreach (var group in groups)
        {
            if (group.Count == 0)
            {
                continue;
            }
            group.Sort((a, b) => b.CompareTo(a));
            group.Add(0);
            group.Add(0);
           ans = Math.Max(ans, Math.Max(group[0] - 2, Math.Max(Math.Min(group[0] - 1, group[1]), group[2])));

        }

        return ans > 0 ? ans : -1;
    }
}