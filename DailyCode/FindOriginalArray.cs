using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public static int[] FindOriginalArray(int[] changed)
    {
        if (changed.Length % 2 != 0)
        {
            return Array.Empty<int>();
        }
        Array.Sort(changed);
        List<int> ans = new List<int>();

        Dictionary<int, int> oriDic = new();
        foreach (var t in changed)
        {
                oriDic.TryAdd(t, 0);
                oriDic[t]++;
        }

        foreach (var i in changed)
        {
            if(oriDic[i]==0)continue;
            oriDic[i]--;
            if (!oriDic.ContainsKey(i * 2) || oriDic[i * 2] == 0)
            {
                return Array.Empty<int>();
            }

            oriDic[i * 2]--;
            ans.Add(i);
        }

        return ans.ToArray();
    }


}