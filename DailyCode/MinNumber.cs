using System;
using System.Collections.Generic;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int MinNumber(int[] nums1, int[] nums2)
    {
        var dic = new Dictionary<int, int>();
        var min = int.MaxValue;

        foreach (var num in nums1)
            if (!dic.ContainsKey(num))
                dic.Add(num, 1);

        foreach (var num in nums2)
            if (dic.TryGetValue(num, out var value))
                min = Math.Min(num, min);
            else
                dic.Add(num, 2);

        if (min != int.MaxValue) return min;

        int i = 0, j = 0, temp = 0;

        while (i == 0 || j == 0)
        {
            temp++;
            if (dic.ContainsKey(temp))
            {
                if (dic[temp] == 1 && i == 0) i = temp;
                else if (dic[temp] == 2 && j == 0) j = temp;
            }
        }

        return i < j ? i * 10 + j : j * 10 + i;
    }
}